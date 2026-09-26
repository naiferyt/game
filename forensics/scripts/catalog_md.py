# Renders recovery/catalog/METHOD_CATALOG.md from METHOD_CATALOG.csv (run method_catalog.py first).
import csv, os, collections
HERE = os.path.dirname(os.path.abspath(__file__))
OUT = os.path.join(HERE, '..', '..', 'recovery', 'catalog')
R = list(csv.DictReader(open(os.path.join(OUT, 'METHOD_CATALOG.csv'), encoding='utf-8-sig')))
TITLE = {'1': 'Etapa 1 — Arranque → Menú principal', '2': 'Etapa 2 — Menú → selección → carga de la carrera',
         '3': 'Etapa 3 — Carrera mínima (conducir, vueltas, meta, resultados)', '4': 'Etapa 4 — Sistemas completos',
         'ANDROID': 'Port Android (después de la Fase 4)', 'OPCIONAL': 'Opcional — herramientas de depuración del equipo original',
         'SIN USO DETECTADO': 'Sin uso detectado (no se traducen salvo que aparezcan en el log)',
         'SIN USO': 'Sin uso (scripts UnityScript sin referencias)', 'ELIMINADO': 'Eliminados (servicios iOS/externos)',
         '-': 'Sin código nativo (abstract / extern)'}
ORDER = ['1', '2', '3', '4', 'ANDROID', 'OPCIONAL', 'SIN USO DETECTADO', 'SIN USO', 'ELIMINADO', '-']
L = ['# Catálogo de métodos del juego por etapa', '',
     'Generado por `forensics/scripts/method_catalog.py` + `catalog_md.py` a partir de los listados ARM originales',
     '(`recovery/aot_listings/`). Tabla completa (un método por fila, con token y dirección ARM): [METHOD_CATALOG.csv](METHOD_CATALOG.csv).', '',
     '## Cómo se asignó la etapa', '',
     '1. **Sistema de la clase** según el plan (RECOVERY_REPORT.md §11.6): arranque, UI, menú, selección, construcción del kart, carrera, vehículo, pista, cámaras, HUD, IA, power-ups, audio, misiones…',
     '2. **Grafo de llamadas original** extraído del ARM: llamadas directas y PLT, candidatos de llamadas virtuales/interfaz, delegados, corrutinas y lambdas, constructores estáticos, métodos invocados por nombre (`SendMessage`/`Invoke`/`StartCoroutine`) y `AddComponent<T>`.',
     '3. **Raíces por etapa**: los componentes que de verdad contienen las escenas/prefabs de cada etapa (YAML) — sus `Awake/Start/Update/On*`, constructores — y los botones `Ugh` (`functionName`) de esos menús.',
     '', '- Clases de sistemas concretos → etapa de su sistema.',
     '- Clases de utilidades compartidas → la **primera etapa desde la que se ejecutan**.',
     '- Columna **“se ejecuta ya en Etapa N”**: el método pertenece a una etapa posterior pero el flujo original lo llama antes. Mientras no se traduzca, `RecoveryPending` lo registrará y devolverá el valor por defecto; hay que comprobar que eso no rompa el flujo (si lo rompe, se adelanta su traducción).',
     '', '## Resumen', '', '| Etapa | Pendientes | ARM pendiente | Recuperados | Llamados antes de su etapa |', '|---|---:|---:|---:|---:|']
for st in ORDER:
    rows = [r for r in R if r['stage'] == st]
    if not rows: continue
    pend = [r for r in rows if r['status'] == 'PENDIENTE']
    L.append('| %s | %d | %.0f KB | %d | %d |' % (TITLE[st], len(pend), sum(int(r['arm_bytes']) for r in pend) / 1024,
                                                sum(1 for r in rows if r['status'] == 'RECUPERADO-AOT'), sum(1 for r in rows if r['note'])))
for st in ORDER:
    rows = [r for r in R if r['stage'] == st]
    if not rows: continue
    L += ['', '---', '', '## ' + TITLE[st], '']
    if st in ('1', '2', '3'):
        early = [r for r in R if r['note'] == 'se ejecuta ya en Etapa %s' % st and r['status'] == 'PENDIENTE']
        if early:
            L.append('**Métodos de etapas posteriores que el flujo original ya ejecuta aquí** (%d) — deben tolerar quedar pendientes o adelantarse:' % len(early))
            L.append('')
            by = collections.defaultdict(list)
            for r in early: by[(r['stage'], r['type'])].append(r['method'])
            for (s, t), ms in sorted(by.items()): L.append('- Etapa %s · `%s`: %s' % (s, t, ', '.join('`%s`' % m for m in sorted(set(ms)))))
            L.append('')
    systems = collections.defaultdict(lambda: collections.defaultdict(list))
    for r in rows: systems[r['system']][r['type']].append(r)
    for sysname in sorted(systems, key=lambda s: -sum(int(r['arm_bytes']) for t in systems[s].values() for r in t)):
        types = systems[sysname]
        n = sum(len(v) for v in types.values()); kb = sum(int(r['arm_bytes']) for v in types.values() for r in v) / 1024
        L += ['### %s — %d métodos, %.1f KB ARM' % (sysname, n, kb), '', '| Clase | Métodos (bytes ARM) |', '|---|---|']
        for t in sorted(types):
            parts = []
            for r in sorted(types[t], key=lambda r: r['method']):
                s = '`%s` (%s)' % (r['method'], r['arm_bytes'])
                if r['status'] == 'RECUPERADO-AOT': s = '✅ ' + s
                if r['note']: s += ' ⚠' + r['note'].replace('se ejecuta ya en ', '')
                parts.append(s)
            L.append('| `%s` | %s |' % (t, ', '.join(parts)))
        L.append('')
open(os.path.join(OUT, 'METHOD_CATALOG.md'), 'w', encoding='utf8').write('\n'.join(L))
print('ok', len(R))
