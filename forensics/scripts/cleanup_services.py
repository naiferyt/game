# Stage 0.4b — remove iOS/external services from the ASSETS (user decision, report 11.2), leaving no Missing Script.
#  * deletes the service prefabs and the MoreDisney scene (still intact in phase2 export + git history)
#  * EnsureGlobals: drops GameCenterManager / StoreKitManager from globalsList
#  * any reference to a deleted prefab -> {fileID: 0}
#  * UI entry points to removed services are DEACTIVATED (m_IsActive: 0), not deleted, so layouts and
#    publisher references stay intact: buttons bound to PressedMoreDisney/PressedBuyCoins/PressedGameCenter/
#    PressedMoreCoins, plus Age Gate / IAP toggle objects of SettingsMenu.
import os, re, glob, json
HERE = os.path.dirname(os.path.abspath(__file__))
PROJ = os.path.join(HERE, '..', '..', 'recovery', 'DSSRacer_U6')
A = os.path.join(PROJ, 'Assets')
DELETE = ['GameObject/Age Gate Popup.prefab', 'GameObject/BuyCoinsPrefab.prefab', 'GameObject/GameCenterManager.prefab',
          'GameObject/StoreKitManager.prefab', 'Scenes/MoreDisney.unity']
SERVICE_FUNCS = {'PressedMoreDisney', 'PressedBuyCoins', 'PressedGameCenter', 'PressedMoreCoins'}
SETTINGS_EXTRA = {'Age Gate Popup', 'iap toggle button'}   # objects inside SettingsMenu.prefab
AGEGATE_SCRIPT_GUID = None
DOC_RE = re.compile(r'^--- !u!(\d+) &(-?\d+)( stripped)?\s*$', re.M)
report = []


def docs(text):
    ms = list(DOC_RE.finditer(text)); out = {}
    for i, m in enumerate(ms):
        out[m.group(2)] = (int(m.group(1)), m.start(), ms[i + 1].start() if i + 1 < len(ms) else len(text))
    return out


def set_active(text, go_fid, rel, why):
    D = docs(text)
    if go_fid not in D: return text
    c, a, b = D[go_fid]
    seg = text[a:b]
    name = re.search(r'm_Name: ?(.*)', seg).group(1).strip()
    if 'm_IsActive: 0' in seg: return text
    seg = re.sub(r'm_IsActive: 1', 'm_IsActive: 0', seg, count=1)
    report.append(dict(file=rel, object=name, action='deactivated', why=why))
    return text[:a] + seg + text[b:]


def main():
    deleted_guids = {}
    for rel in DELETE:
        p = os.path.join(A, rel)
        if os.path.exists(p + '.meta'):
            deleted_guids[re.search(r'guid: (\w+)', open(p + '.meta', encoding='utf8').read()).group(1)] = rel
    for rel in DELETE:
        p = os.path.join(A, rel)
        for q in (p, p + '.meta'):
            if os.path.exists(q): os.remove(q)
        report.append(dict(file='Assets/' + rel, action='deleted'))
    files = glob.glob(os.path.join(A, '**', '*.unity'), recursive=True) + glob.glob(os.path.join(A, '**', '*.prefab'), recursive=True)
    for f in files:
        rel = os.path.relpath(f, PROJ).replace('\\', '/')
        text = open(f, encoding='utf8').read(); orig = text
        # 1) EnsureGlobals list entries + any reference to deleted prefabs
        for g, what in deleted_guids.items():
            if g not in text: continue
            n_list = len(re.findall(r'^  - \{fileID: -?\d+, guid: %s, type: 2\}\n' % g, text, flags=re.M))
            text = re.sub(r'^  - \{fileID: -?\d+, guid: %s, type: 2\}\n' % g, '', text, flags=re.M)
            n_ref = len(re.findall(r'\{fileID: -?\d+, guid: %s, type: \d\}' % g, text))
            text = re.sub(r'\{fileID: -?\d+, guid: %s, type: \d\}' % g, '{fileID: 0}', text)
            report.append(dict(file=rel, action='unlinked %s' % what, list_entries_removed=n_list, references_nulled=n_ref))
        # 2) buttons bound to removed service functions -> deactivate their GameObject
        for m in re.finditer(r'  - name: ([^\n]*)\n    reference: \{fileID: (-?\d+)\}\n    functionName: (\w+)', text):
            if m.group(3) not in SERVICE_FUNCS or m.group(2) == '0': continue
            D = docs(text); comp = m.group(2)
            if comp not in D: continue
            c, a, b = D[comp]
            go = re.search(r'm_GameObject: \{fileID: (-?\d+)\}', text[a:b]).group(1)
            text = set_active(text, go, rel, 'boton de servicio eliminado: %s (%s)' % (m.group(1), m.group(3)))
        # 3) SettingsMenu: Age Gate / IAP toggle objects; drop the AgeGatePopup component (script removed)
        if rel.endswith('GameObject/SettingsMenu.prefab'):
            D = docs(text)
            for fid, (c, a, b) in list(D.items()):
                if c == 1:
                    nm = re.search(r'm_Name: ?(.*)', text[a:b]).group(1).strip()
                    if nm in SETTINGS_EXTRA: text = set_active(text, fid, rel, 'servicio eliminado: ' + nm)
            D = docs(text); removed = []
            for fid, (c, a, b) in D.items():
                if c == 114 and 'guid: cd5f' in text[a:b]: pass
            # AgeGatePopup MonoBehaviour: find by script guid of the (deleted) AgeGatePopup.cs from the export
            exp_meta = os.path.join(HERE, '..', '..', 'phase2_extraction', 'AssetRipperUnityProject', 'ExportedProject', 'Assets', 'Scripts', 'Assembly-CSharp', 'AgeGatePopup.cs.meta')
            ag = re.search(r'guid: (\w+)', open(exp_meta, encoding='utf8').read()).group(1)
            D = docs(text)
            for fid, (c, a, b) in sorted(D.items(), key=lambda x: -x[1][1]):
                if c == 114 and ag in text[a:b]:
                    text = text[:a] + text[b:]; removed.append(fid)
            for fid in removed:
                text = re.sub(r'^  - 114: \{fileID: %s\}\n' % fid, '', text, flags=re.M)
                report.append(dict(file=rel, action='removed AgeGatePopup component', fileID=fid))
        if text != orig:
            open(f, 'w', encoding='utf8', newline='\n').write(text)
    # 4) build settings: drop MoreDisney
    eb = os.path.join(PROJ, 'ProjectSettings', 'EditorBuildSettings.asset')
    t = open(eb, encoding='utf8').read()
    t2 = re.sub(r'  - enabled: 1\n    path: Assets/Scenes/MoreDisney.unity\n(    guid: \w+\n)?', '', t)
    if t2 != t:
        open(eb, 'w', encoding='utf8', newline='\n').write(t2); report.append(dict(file='ProjectSettings/EditorBuildSettings.asset', action='removed MoreDisney scene'))
    json.dump(report, open(os.path.join(HERE, '..', 'output', 'service_cleanup_report.json'), 'w'), indent=1)
    for r in report: print(r)


if __name__ == '__main__':
    main()
