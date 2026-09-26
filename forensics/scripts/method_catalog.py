# Builds recovery/catalog/METHOD_CATALOG.{csv,md}: every original game method with its reconstruction stage.
# Evidence used:
#  1) system of the class (functional map of the plan, RECOVERY_REPORT.md 11.6)
#  2) the ORIGINAL call graph extracted from the annotated ARM listings (direct/PLT calls, virtual/interface
#     candidates, delegates (METHODCONST), coroutine/lambda classes, static constructors, string-dispatched methods)
#  3) which components the scenes/prefabs of each stage really contain (YAML) + UghPublisher button bindings
# stage(method) = stage of its system; for shared utility classes = earliest stage whose roots reach it.
# 'needed_from' = earliest stage whose roots reach it (if earlier than its stage, it will log RecoveryPending earlier).
import os, re, glob, csv, collections, json
HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, '..', '..'))
LIST = os.path.join(ROOT, 'recovery', 'aot_listings')
PROJ = os.path.join(ROOT, 'recovery', 'DSSRacer_U6', 'Assets')
OUT = os.path.join(ROOT, 'recovery', 'catalog')

S = {1: 'Etapa 1', 2: 'Etapa 2', 3: 'Etapa 3', 4: 'Etapa 4'}
UTIL = None
# (regex on top-level type name, system, stage)   first match wins
RULES = [
    (r'^(StoreKit|GameCenter|iCloud|JCloud|GravCloud|P31|Burstly|GDMO|MoreGames|MoreDisney|Email$|ResultLogger|AgeGatePopup|DebugMoreCoinsPublisher)', 'ELIMINADO (servicio iOS/externo)', 'ELIMINADO'),
    (r'^(Car_Script|Plane_Script|WheelData)$', 'Sin uso (UnityScript, 0 referencias)', 'SIN USO'),
    (r'^(Debug\w*Publisher|RuntimeEditorUtils|StreamTest|ApplyEffectDebugUtility)$', 'Depuración (herramientas del equipo original)', 'OPCIONAL'),
    (r'^(TouchTurnTrack|PlayerAccelControl)$', 'Input táctil/inclinación (Android)', 'ANDROID'),
    (r'^(UghScrollView|LEDScroller|Dialog)$', 'Framework UI: componentes sin instancias ni llamadas en el juego', 'SIN USO'),
    # ---- Etapa 1
    (r'^(CloudStrap|LocalizeCloudStrap|EnsureGlobals|SingletonScript|PreFrontEndHoop|ScreenFader|ScreenFade|FadeHelper|RotatorAI|ScreenTimeoutController|QualityControl|LowEndInhibitor|PlatformProfile)', 'Arranque y globales', 1),
    (r'^(Ugh|LEDScroller|TransformReference|TransformsDictionary|TextString|ShiftContentsOn|Dialog$|PopoverPublisher|GenericPopupPublisher|ConfirmationPublisher|InputBlocker$)', 'Framework UI propio (Ugh)', 1),
    (r'^(Localize|LocalizedString|UnlocalizedString|LanguageAsset|LocalizedAssetSwapper)', 'Localización', 1),
    (r'^(DataUtility|CloudSaveData|LocalOptionsData|ExternalPersistentArchive|LocalFileManager|CloudFileManager|DocumentLock)', 'Guardado local y datos globales', 1),
    (r'^(FrontEndLogic|FrontEndCamera|FrontEndCameraTarget|ShiftUIPublisher|Shifter|ShiftKeyframe|PlayMenuPublisher|SettingsMenuPublisher|VolumeSlider|CreditsPublisher|MenuStruct|CameraShake|LiftControlAI|DailyBonusPublisher$)', 'Menú principal / garaje', 1),
    # ---- Etapa 2
    (r'^(SelectCircuitPublisher|TrackSelectPublisher|CharacterSelectPublisher|CharacterButtonPublisher|DifficultyMenuPublisher|CircuitBanner|CircuitTracks|TrackIcon|TrackMedals|TrophyAssets|UnlockedCircuitPublisher|CharacterIcon|Icon$|Logo$|TrackUnlockHelper)', 'Selección de circuito/pista/personaje', 2),
    (r'^(PreviewCart|PreviewPart|PreviewPaint|CharacterPreview|PlayerInstance|CartPartList|CartSlot|CartPart|CartAttributes|PaintJob|MultilayerTexture|StreamedMultilayerTexture|Composite|SourceFactory|Layer$|AsyncTextureProcessor|CartPrimaryTextureProfile|FormData|AlternateForm|CharacterConfigData|ConfigData)', 'Construcción del kart y vista previa', 2),
    (r'^(RaceSettings|AICartSettings|StreamManager|Asset$|AssetCluster|LoadingPublisher|LoadSpin)', 'Carga de carrera (RaceSettings/StreamManager/Loading)', 2),
    # ---- Etapa 3
    (r'^(RaceManager|CarProgress|RaceResults|DebugTrackStrapper|ObjectTrackDistanceLogic)$', 'Gestión de carrera', 3),
    (r'^(CarCollider|TriFoot|SpringConnection|CarMetrics|AnimationTire|ShadowBlob|AnimationDriver|PlayerKeyboardControl|KeyEventBinding|PlayerControlLinker|DriftButton|ReverseButton|CatchupNotify)$', 'Vehículo: física, input PC, animación', 3),
    (r'^(WaypointLogic|SpeedPoint|SpeedBranchStruct|ProgressTriggerLogic|ResetTrigger|TerrainEffectTrigger|CausticsManager)$', 'Pista: waypoints, vueltas, respawn, superficies', 3),
    (r'^(FollowCamera|PreRaceCamera|CameraWobble)$', 'Cámaras de carrera', 3),
    (r'^(HUDLogic|PausePublisher|DriftScalePublisher|RaceResultsPublisher|PlaySummaryPublisher|BlipTrackPublisher|ArrowTarget)$', 'HUD, pausa y resultados', 3),
    # ---- Etapa 4
    (r'^(CarAI|BaseCarAIState|Drive\w*AIState|UsePowerupAIState|GimpedCarAI|CarAIPath|CarAIPathManager|CarAIPathRecorder|CarAIPersonality|PersonalityTrait|PathPoint|PathMoverAI|ForwardForceAI|SphereMover)', 'IA de rivales', 4),
    (r'(Pickup|Effect$|Effect\b)|^(PickupSpawner|PowerupHolder|PowerupMagnet|PowerupDisplay|EffectManager|RocketAI|MineAI|MineSpreaderAI|ShotDroneAI|UFOLogic|LaserLogic|Pie|TurkeyGooShooter|WhoopieCushion|BasketBall|Barrel|ExplodingBarrel|Explosion|PyroTechnics|BubbleJet|Crab|BreakableObject|TripLine|GuidedJumpTrigger|SpringTrigger|TeleportTrigger|RocketRideRemover|MineNotifyPublisher|ParticleLibrary|ParticlePrefab|ParticleReducer|InRaceAquirePickupListener|RandomShotEffect)', 'Power-ups, efectos y obstáculos', 4),
    (r'^(Coin|CoinPoint)$', 'Monedas en pista', 4),
    (r'(Mission|AchievementListener|Achievement)', 'Misiones y logros internos', 4),
    (r'^(Sound|ClipReference|ClipHashDictionary|HashClipDictionary|MusicPlayer|CharacterVOController|AudioManager)', 'Audio (música, SFX, voces)', 4),
    (r'^(FrontEndTutorial|TutorialLauncherPublisher|TutorialSettings)', 'Tutorial', 4),
    (r'^(CartCustomizerPublisher|PaintSlotPublisher)$', 'Personalización del kart', 4),
    (r'^(LifetimeMetrics|SnapShotInfo|CarSnapShot|Rewind\w*Publisher)$', 'Progresión, bono diario, rewind', 4),
]

UNITY_MESSAGES = {'Awake', 'Start', 'Update', 'LateUpdate', 'FixedUpdate', 'OnEnable', 'OnDisable', 'OnDestroy', 'OnGUI',
                  'OnTriggerEnter', 'OnTriggerExit', 'OnTriggerStay', 'OnCollisionEnter', 'OnCollisionExit', 'OnCollisionStay',
                  'OnLevelWasLoaded', 'OnApplicationPause', 'OnApplicationQuit', 'OnApplicationFocus', 'OnBecameVisible',
                  'OnBecameInvisible', 'OnPreRender', 'OnPostRender', 'OnRenderObject', 'OnWillRenderObject', '.ctor', '.cctor'}

STAGE_ASSETS = {
    1: ['Scenes/CloudStrap.unity', 'Scenes/PreFrontEnd.unity', 'Scenes/Front End/FrontEndTest.unity',
        'GameObject/PlayMenu.prefab', 'GameObject/SettingsMenu.prefab', '@ENSUREGLOBALS'],
    2: ['Scenes/Front End/Loading.unity', 'GameObject/Select Circuit Menu.prefab', 'GameObject/Select Track Menu.prefab',
        'GameObject/CharacterSelectMenu.prefab', '@RACESETTINGS'],
    3: ['Scenes/Tracks/Fish Hooks Track 1.unity', 'Scenes/Tracks/Fish Hooks Track 2.unity', 'Scenes/Tracks/Fish Hooks Track 3.unity',
        'Scenes/Tracks/Kick Butt Track 1.unity', 'Scenes/Tracks/Kick Butt Track 2.unity', 'Scenes/Tracks/Kick Butt Track 3.unity',
        'Scenes/Tracks/Phineas Track 1.unity', 'Scenes/Tracks/Phineas Track 2.unity', 'Scenes/Tracks/Phineas Track 3.unity',
        'Scenes/Test Scenes/Pranksgiving Test.unity', 'Scenes/Front End/RaceResults.unity',
        'Resources/cart assets/bodies/*.prefab', 'Resources/cart assets/wheels/*.prefab', 'Resources/cart assets/characters/*.prefab',
        'Resources/cart assets/spoilers/*.prefab', 'Resources/cart assets/thrusters/*.prefab', 'Resources/cart assets/scoops/*.prefab'],
    4: ['**/*.unity', '**/*.prefab'],
}


def system_of(top):
    for rx, sysname, st in RULES:
        if re.search(rx, top): return sysname, st
    return 'Utilidades compartidas', UTIL


def parse_listings():
    methods = []   # dicts
    for f in sorted(glob.glob(os.path.join(LIST, '*', '*.txt'))):
        asm = os.path.basename(os.path.dirname(f))
        cur = None
        for line in open(f, encoding='utf8'):
            if line.startswith('== '):
                head = line[3:].rstrip('\n')
                if '  token ' not in head: continue
                name, rest = head.split('  token ', 1)
                tok = rest.split()[0]
                m = re.search(r'@0x([0-9a-f]+) \((\d+) bytes\)', rest)
                cur = dict(assembly=asm, key=name, token=tok, addr=('0x' + m.group(1)) if m else '', bytes=int(m.group(2)) if m else 0,
                           nocode='no native code' in rest, calls=set(), types=set(), strings=set())
                methods.append(cur); continue
            if cur is None: continue
            m = re.search(r'; CALL (?!\[)(\S+)', line)
            if m and not m.group(1).startswith('0x'): cur['calls'].add(m.group(1))
            for m in re.finditer(r'(?:METHODCONST|METHOD_RGCTX|ICALL_ADDR) (\S+)', line): cur['calls'].add(m.group(1))
            m = re.search(r'VIRTUAL CALL slot \+0x[0-9a-f]+: (.*)$', line)
            if m:   # receiver type unknown: keep only unambiguous sites; generated classes are reached through their creation
                cands = [c.split(' ...')[0].strip() for c in m.group(1).split(' | ') if '<' not in c.split('::')[0]]
                if '...(' not in m.group(1) and len(cands) <= 4:
                    for c in cands: cur['calls'].add(c)
            m = re.search(r'INTERFACE CALL (\S+)', line)
            if m: cur['calls'].add(m.group(1))
            m = re.search(r'GOT\[\d+\] (?:VTABLE|CLASS|CLASS_INIT|SFLDA|DELEGATE_TRAMPOLINE|TYPE_FROM_HANDLE|IID) (?:typeof\()?([^\s)]+)', line)
            if m: cur['types'].add(m.group(1).split('::')[0])
            m = re.search(r"LDSTR '([A-Za-z_]\w*)'", line)
            if m: cur['strings'].add(m.group(1))
    return methods


def script_guid_map():
    g2c = {}
    for m in glob.glob(os.path.join(PROJ, '**', '*.cs.meta'), recursive=True):
        g = re.search(r'guid: (\w+)', open(m, encoding='utf8').read())
        if g: g2c[g.group(1)] = os.path.basename(m)[:-8]
    return g2c


def asset_roots(patterns, g2c):
    files = set()
    for p in patterns:
        if p == '@ENSUREGLOBALS':
            t = open(os.path.join(PROJ, 'Scenes', 'Front End', 'FrontEndTest.unity'), encoding='utf8').read()
            block = t[t.index('globalsList:'):][:4000]
            guids = re.findall(r'- \{fileID: \d+, guid: (\w+)', block.split('\n--- ')[0])
            for m in glob.glob(os.path.join(PROJ, 'GameObject', '*.prefab.meta')):
                if re.search(r'guid: (\w+)', open(m, encoding='utf8').read()).group(1) in guids: files.add(m[:-5])
        elif p == '@RACESETTINGS':
            for f in glob.glob(os.path.join(PROJ, 'GameObject', '*.prefab')):
                if '14938888863ffa5c373b8f39c15c49ed' in open(f, encoding='utf8').read(): files.add(f)
        else:
            files.update(glob.glob(os.path.join(PROJ, p), recursive=True))
    comps = set(); funcs = set()
    for f in files:
        t = open(f, encoding='utf8', errors='ignore').read()
        docs = re.split(r'^--- !u!', t, flags=re.M)
        for d in docs:
            if not d.startswith('114 '): continue
            g = re.search(r'm_Script: \{fileID: \d+, guid: (\w+)', d)
            if not g or g.group(1) not in g2c: continue
            cls = g2c[g.group(1)]; comps.add(cls)
            for fn in re.findall(r'functionName: (\w+)', d): funcs.add((cls, fn))
    return comps, funcs, files


def main():
    methods = parse_listings()
    by_key = collections.defaultdict(list); by_type = collections.defaultdict(list); by_name = collections.defaultdict(list)
    for m in methods:
        t, n = m['key'].rsplit('::', 1)
        m['type'] = t; m['name'] = n; m['top'] = t.split('/')[0]
        by_key[m['key']].append(m); by_type[t].append(m); by_name[n].append(m)
    # adjacency
    adj = collections.defaultdict(set)
    for i, m in enumerate(methods):
        for c in m['calls']:
            base = re.sub(r'<[^<>]*>$', '', c)          # generic method args
            if '::' in c:                                # generic TYPE args: Messenger`1<System.String>::Broadcast -> Messenger`1::Broadcast
                ty, nm = c.rsplit('::', 1)
                while re.search(r'<[^<>]*>', ty): ty = re.sub(r'<[^<>]*>', '', ty)
                base2 = ty + '::' + re.sub(r'<[^<>]*>$', '', nm)
                if base2 != c and base2 != base:
                    for tgt in by_key.get(base2, []): adj[id(m)].add(id(tgt))
            for tgt in by_key.get(c, []) + (by_key.get(base, []) if base != c else []): adj[id(m)].add(id(tgt))
            am = re.search(r'::AddComponent<(\w+)>$', c)   # components added at runtime: their Unity messages run
            if am:
                for tgt in by_type.get(am.group(1), []):
                    if tgt['name'] in UNITY_MESSAGES or tgt['name'].startswith('On'): adj[id(m)].add(id(tgt))
            ctype = c.rsplit('::', 1)[0]
            if c.endswith('::.ctor') and '<' in ctype:   # coroutine / lambda class: its whole body belongs to the caller
                for tgt in by_type.get(ctype, []): adj[id(m)].add(id(tgt))
        for ty in m['types']:
            for tgt in by_type.get(ty, []):
                if tgt['name'] == '.cctor' or '<' in ty: adj[id(m)].add(id(tgt))
        for s in m['strings']:   # SendMessage / Invoke / StartCoroutine("name") / Messenger by name
            cands = [x for x in by_name.get(s, []) if x['top'] == m['top']] or by_name.get(s, [])
            for tgt in cands[:12]: adj[id(m)].add(id(tgt))
        # generated classes nested in a method's type are reached through their creator; iterator bodies -> owner
    ids = {id(m): m for m in methods}
    g2c = script_guid_map()
    reach = {}
    stage_roots_info = {}
    for st in (1, 2, 3, 4):
        comps, funcs, files = asset_roots(STAGE_ASSETS[st], g2c)
        roots = []
        for c in comps:
            sysname, sst = system_of(c)
            if isinstance(sst, int) and sst > st: continue          # component of a later system present in this scene
            if sst in ('ELIMINADO', 'SIN USO'): continue
            for m in by_type.get(c, []):
                if m['name'] in UNITY_MESSAGES or m['name'].startswith('On'): roots.append(m)
        for cls, fn in funcs:
            if system_of(cls)[1] in ('ELIMINADO',): continue
            roots += [m for m in by_type.get(cls, []) if m['name'] == fn and (not isinstance(system_of(cls)[1], int) or system_of(cls)[1] <= st)]
        stage_roots_info[st] = dict(files=len(files), components=len(comps), roots=len(roots))
        seen = set(); stack = [id(r) for r in roots]
        while stack:
            x = stack.pop()
            if x in seen: continue
            seen.add(x)
            tm = ids[x]
            sysname, sst = system_of(tm['top'])
            if isinstance(sst, int) and sst > st:   # don't expand through later systems, but record they're called
                continue
            stack.extend(adj[x])
        for x in seen:
            reach.setdefault(x, st)
    # recovered already?
    # A method counts as recovered when a C# comment cites its token: the "// RECUPERADO-AOT X token T" header, or the
    # "(iterator ... MoveNext token T)" / "(predicate ... token T)" notes that name the compiler-generated methods whose
    # bodies were folded into a translated method. A generated iterator/closure class counts as recovered as a whole
    # once any of its methods is cited (its ctor, get_Current, Dispose and Reset have no logic of their own).
    # Methods listed under an "// ELIMINADO" header as "//   - <signature>" were removed from the C# class on purpose.
    recovered = set()
    removed = set()   # (assembly, top type, method name)
    for f in glob.glob(os.path.join(PROJ, '**', '*.cs'), recursive=True):
        asm = 'Assembly-CSharp-firstpass' if os.sep + 'Plugins' + os.sep in f else 'Assembly-CSharp'
        text = open(f, encoding='utf8').read()
        if 'RECUPERADO-AOT' in text:
            for line in text.split('\n'):
                if '//' in line and 'token' in line.split('//', 1)[1]:
                    for m in re.finditer(r'\b(0x06[0-9a-f]{6})\b', line.split('//', 1)[1]): recovered.add((asm, m.group(1)))
        cls = os.path.basename(f)[:-3]
        for m in re.finditer(r'^\s*//   - (?:[\w<>\[\],. ]+ )?(\w+)\s*\(', text, re.M): removed.add((asm, cls, m.group(1)))
    # Constructors of at most 52 bytes only chain to the base constructor (static ones are empty): nothing to
    # translate, so they count as recovered once their class has been translated.
    translated_types = set((m['assembly'], m['top']) for m in methods if (m['assembly'], m['token']) in recovered)
    for m in methods:
        # (not for compiler-generated iterator/closure classes: their trivial .ctor would mark the whole class recovered)
        if m['name'] in ('.ctor', '.cctor') and m['bytes'] <= 52 and (m['assembly'], m['top']) in translated_types                 and not re.search(r'/<.*>c__(Iterator|AnonStorey)', m['type']):
            recovered.add((m['assembly'], m['token']))
    gen_types = collections.defaultdict(list)
    for m in methods:
        if re.search(r'/<.*>c__(Iterator|AnonStorey)', m['type']): gen_types[(m['assembly'], m['type'])].append(m)
    for key, ms in gen_types.items():
        if any((x['assembly'], x['token']) in recovered for x in ms):
            for x in ms: recovered.add((x['assembly'], x['token']))
        owner = re.match(r'.*/<(\w+)>c__(?:Iterator|AnonStorey)', key[1])
        if owner and (key[0], key[1].split('/')[0], owner.group(1)) in removed:
            for x in ms: removed.add((x['assembly'], x['top'], x['name']))
    for m in methods:   # lambdas <Owner>m__N of a removed method
        lam = re.match(r'<(\w+)>m__', m['name'])
        if lam and (m['assembly'], m['top'], lam.group(1)) in removed: removed.add((m['assembly'], m['top'], m['name']))
    rows = []
    for m in methods:
        sysname, sst = system_of(m['top'])
        need = reach.get(id(m))
        if m['nocode']: status, stage = 'SIN CÓDIGO (abstract/extern)', '-'
        elif sst == 'ELIMINADO' or (m['assembly'], m['top'], m['name']) in removed: status, stage = 'ELIMINADO', 'ELIMINADO'
        elif (m['assembly'], m['token']) in recovered: status, stage = 'RECUPERADO-AOT', str(sst if isinstance(sst, int) else (need or 4))
        else:
            status = 'PENDIENTE'
            if isinstance(sst, int): stage = str(sst)
            elif sst is UTIL: stage = str(need) if need else 'SIN USO DETECTADO'
            else: stage = sst
        early = ''
        if need and stage.isdigit() and need < int(stage): early = 'se ejecuta ya en Etapa %d' % need
        rows.append(dict(stage=stage, status=status, system=sysname, assembly=m['assembly'], type=m['type'], method=m['name'],
                         token=m['token'], arm_addr=m['addr'], arm_bytes=m['bytes'], note=early))
    order = {'1': 1, '2': 2, '3': 3, '4': 4, 'ANDROID': 5, 'OPCIONAL': 6, 'SIN USO DETECTADO': 7, 'SIN USO': 8, 'ELIMINADO': 9, '-': 10}
    rows.sort(key=lambda r: (order.get(r['stage'], 11), r['system'], r['type'], r['method']))
    os.makedirs(OUT, exist_ok=True)
    with open(os.path.join(OUT, 'METHOD_CATALOG.csv'), 'w', newline='', encoding='utf-8-sig') as fh:
        w = csv.DictWriter(fh, fieldnames=list(rows[0].keys())); w.writeheader(); w.writerows(rows)
    json.dump(stage_roots_info, open(os.path.join(OUT, 'stage_roots.json'), 'w'), indent=1)
    return rows, stage_roots_info


if __name__ == '__main__':
    rows, info = main()
    c = collections.Counter((r['stage'], r['status']) for r in rows)
    kb = collections.Counter()
    for r in rows: kb[r['stage']] += r['arm_bytes']
    for k in sorted(c, key=str): print(k, c[k])
    print({k: round(v / 1024) for k, v in kb.items()})
    print(info)
