# AGENTS.md — Manual para cualquier IA que continúe este proyecto

> Léelo entero antes de tocar nada. Sirve para Cline, Roo, Continue, Cursor, Copilot, Codex, Gemini CLI o Claude Code.
> Lo escribió Claude (Opus 5.5) el 2026-09-26 con todo lo que usa para trabajar en este repo.

## 1. Qué es el proyecto

Estamos recuperando **Disney Super Speedway** (paquete `com.disney.DSSRacer`, v1.3). Es un juego de iOS hecho con Unity 4.3.4f1 y compilado Mono Full-AOT ARMv7. El objetivo es que funcione en **Unity 6000.6.3f1**: primero en PC (Windows) y después en Android.

- **Proyecto de trabajo:** `recovery/DSSRacer_U6` (Built-in RP, Gamma, Input "Both").
- **Originales:** en `phase1_analysis/` y `phase2_extraction/`. **Nunca se modifican.**
- **Plan y estado:** `RECOVERY_PROGRESS.md`. Es la fuente de verdad: dice qué etapa y qué bloque toca.
- **Informe técnico:** `RECOVERY_REPORT.md`. **Pendientes por etapa:** `PENDIENTES_POR_ETAPA.md`.
- **Qué cambió cada sesión:** `SINCRONIZAR_A_LOCAL.md`.
- **Catálogo de los 4477 métodos:** `recovery/catalog/METHOD_CATALOG.md` y `.csv`, con etapa, token y dirección ARM de cada uno.

### Decisiones del usuario (no se discuten)

- **Ruta "C modificada":**
  - Los assets vienen de AssetRipper.
  - El C# parte del esqueleto original.
  - El cuerpo de cada método se traduce a mano desde el código ARM AOT original.
- **Unity 6000.6.3f1 es obligatorio.** No se cambia de versión ni de pipeline, salvo URP después de la Etapa 4.
- **Todos los servicios de iOS se ELIMINAN, no se simulan:** StoreKit, Game Center, iCloud, anuncios, analítica, More Disney, age gate y enlaces legales o web. El guardado es local.
- **Pranksgiving** va activado por defecto, con un interruptor local.
- **Identidad de git:** `STEEP <vidalesnaifer9@gmail.com>`.

## 2. Método de trabajo: traducir ARM a C#

Cada método del juego tiene su listado ARM anotado en `recovery/aot_listings/<Ensamblado>/<Tipo>.txt`, por ejemplo `recovery/aot_listings/Assembly-CSharp/Coin.txt`. La cabecera de cada listado da los campos con su offset, del tipo `+0x10 audioSource`.

### Estado de un método

- **Pendiente:** su cuerpo solo contiene `RecoveryPending.Hit("Clase.Metodo");`. En ejecución avisa con `[RecoveryPending] ...` en el log.
- **Traducido:** lleva encima un comentario con una de estas etiquetas:
  - `// RECUPERADO-AOT Clase::Metodo token 0x06000xxx @0x000xxxxx`: traducción fiel del ARM.
  - `// ADAPTADO-U6: ...`: cambio necesario porque la API de Unity 4 ya no existe. Por ejemplo, `Component.audio` pasa a `GetComponent<AudioSource>()` y `ParticleEmitter` pasa a `ParticleSystem`.
  - `// RECONSTRUIDO: ...`: no hay ARM y se ha reescrito (herramientas, datos perdidos).
  - `// ELIMINADO: ...`: servicio de iOS quitado por decisión del usuario.

### Reglas

1. **Fidelidad:** traduce lo que hace el ARM, sin "mejorarlo". Si el original tiene un bug, se mantiene y se documenta.
2. **Nada inventado:** si no puedes leer un método con seguridad, déjalo como `RecoveryPending.Hit` y anótalo en `RECOVERY_PROGRESS.md`. Una traducción falsa es peor que un pendiente.
3. **Estilo:** copia el estilo de los archivos ya traducidos, como `CarCollider.cs`, `SoundSequencer.cs` o `HUDLogic.cs`. Eso incluye tabuladores, `base.gameObject` y los comentarios de etiqueta.
4. **`Debug`:** usa `UnityEngine.Debug`, porque `System.Diagnostics` también define `Debug` (error CS0104).
5. **API de iOS:** no uses `UnityEngine.iOS` en código de juego, porque rompe el build de Windows. Usa `U4Compat` y `U4iPhoneGeneration` (en `Assets/Plugins/_RecoveryRuntime/U4Compat.cs`).

### Leer ARM Mono AOT: convenciones

- **Llamadas virtuales:** el slot de vtable está en el offset `0x24 + 4*slot`. Los virtuales nuevos van en orden **inverso** al de los metadatos.
- **Slots de `BaseEffect`:** FixedUpdate +0x34, Stack +0x3c, Shutdown +0x40, Update +0x44, Init +0x48.
- **`GetType()` inline:** `obj.vtable->+0x10`.
- **Iteradores (`<Metodo>c__IteratorN::MoveNext`):** son el cuerpo real de las corrutinas. Si guardan un enumerador struct de 16 bytes, los offsets de la cabecera que vienen detrás están mal; recalcúlalos por el uso de `$current` y `$PC`.
- **`switch`:** los listados solo muestran `SWITCH switch table[n]`. Decodifica los destinos con `switch_tables.py`.

### Herramientas de lectura

Todas están en `forensics/scripts/`. Python está en `%LOCALAPPDATA%\Python\bin\python.exe` y tiene capstone y UnityPy.

```bash
# Listado condensado, sin prólogos ni pools de literales. Guárdalo en un archivo temporal:
"$LOCALAPPDATA/Python/bin/python.exe" forensics/scripts/condense.py Assembly-CSharp Coin > /tmp/Coin.txt
# Solo algunos métodos (regex):
"$LOCALAPPDATA/Python/bin/python.exe" forensics/scripts/condense.py Assembly-CSharp Coin "Start|OnTrigger"
# Pseudocódigo simbólico de un tramo del listado condensado (líneas a..b).
# OJO: dentro de foreach pierde llamadas virtuales; compruébalo con lab.sh.
"$LOCALAPPDATA/Python/bin/python.exe" forensics/scripts/fsym.py /tmp/Coin.txt 1 120 this
# ARM crudo entre dos etiquetas o números de línea:
bash forensics/scripts/lab.sh /tmp/Coin.txt L12 L30
# Destinos de un switch:
"$LOCALAPPDATA/Python/bin/python.exe" forensics/scripts/switch_tables.py Assembly-CSharp <got_slot> <inicio_metodo_hex>
```

## 3. Ciclo por bloque (obligatorio)

1. Mira en `RECOVERY_PROGRESS.md` qué bloque toca y qué clases incluye.
2. Traduce los métodos de una clase. Trabaja **una clase cada vez**.
3. **Comprueba que compila** (tarda unos segundos y no abre Unity):
   ```bash
   "$LOCALAPPDATA/Python/bin/python.exe" forensics/scripts/compile_check.py
   ```
   Si da errores, corrígelos antes de seguir. **Nunca hagas commit con errores de compilación.**
4. Prueba en Unity cuando el bloque se pueda ejercitar (sección 4).
5. Documenta el avance del bloque en `RECOVERY_PROGRESS.md` y la lista de archivos en `SINCRONIZAR_A_LOCAL.md`.
6. Regenera el catálogo:
   ```bash
   "$LOCALAPPDATA/Python/bin/python.exe" forensics/scripts/method_catalog.py && "$LOCALAPPDATA/Python/bin/python.exe" forensics/scripts/catalog_md.py
   ```
7. Haz commit (sección 5).

## 4. Pruebas en Unity (sin abrir el editor a mano)

- **Editor:** `C:\Program Files\Unity\Hub\Editor\6000.6.3f1\Editor\Unity.exe`. Los scripts ya exportan `DOTNET_gcServer=0 DOTNET_GCHeapHardLimit=0x30000000`; sin eso, Unity falla con "GC heap initialization failed".
- **Cierra Unity** antes de lanzar pruebas en batchmode: no puede haber dos instancias con el mismo proyecto.
- **Consola:** los scripts `.sh` necesitan **Git Bash**. En la terminal de VS Code, elige "Git Bash", o llama a `bash script.sh` desde PowerShell.
- **Guardado real:** las carreras de prueba modifican `C:/Users/STEEP/AppData/LocalLow/Walt Disney/Speedway/DSSRacer_save.txt`. **Haz copia antes y restáurala después**, salvo que estés probando el guardado. `run_player.sh` ya lo hace solo.

### 4.1 Play Mode automático en el editor

```bash
bash forensics/scripts/run_play.sh "<escena>" <segundos> <nombre> "<acciones>" "<t de capturas>" [lineas_log] ["<dump>"]
```

**Salida:**
- Log de la prueba: `recovery/logs/playrun_<nombre>.log`, con errores, `[RecoveryPending]`, cambios de escena, fps, posición, vuelta y puesto del jugador, y botones activos.
- Log completo de Unity: `recovery/logs/unity_play_<nombre>.log`.
- Capturas PNG en `recovery/logs/`.

**Acciones** (separadas por `;`):

| Acción | Qué hace |
|---|---|
| `x,y@t` | Clic en coordenadas normalizadas (0..1, con el origen abajo a la izquierda) en el segundo t |
| `obj:Nombre@t` | Clic sobre el objeto con ese nombre |
| `key:W@t1-t2` | Mantiene pulsada una tecla entre t1 y t2 |
| `auto@t1-t2` | Piloto automático hacia el siguiente waypoint (admite varios rangos) |
| `load:<Escena>@t` | Carga directa de una escena después de arrancar |
| `hidetype:<Tipo>@t` | Oculta los objetos con ese componente |

**Recetas probadas:**
- **Carrera completa en Kick Butt 1**, desde la escena de arranque `Assets/Scenes/CloudStrap.unity`:
  `0.50,0.18@8;obj:Circuit 1 banner@12;obj:Panel 1 Snapshot@16;obj:Go Button@32;auto@40-176`. Termina hacia los 173 s y los resultados salen hacia los 178 s.
- **Pausa:** `PauseButton`, `ResumeButton`, `Restart`, `QuitButton`.
- **Resultados:** `Retry Button`, `continue button`, `Redo Button`.
- **Garaje:** `Character Button`, `Arrow - Right`, `Buy Use Button`.
- **Carga directa de pista:** `load:` más `hidetype:LoadingPublisher`. La doble carga deja la pantalla de carga puesta; es comportamiento original.

**Limpieza antes del commit:** el editor ensucia algunos assets al jugar. Restáuralos:

```bash
cd recovery/DSSRacer_U6 && git checkout -- "Assets/Material/Fader SpriteAtlas.mat" "Assets/Material/Mobile Cart Part.mat" Assets/AnimationClip/crash_idle.anim Assets/AnimationClip/kick_idle.anim; cd ../..
```

Comprueba con `git status` que no quedan esos cuatro archivos modificados.

### 4.2 Ejecutable de Windows

```bash
bash forensics/scripts/build_windows.sh
bash forensics/scripts/run_player.sh <nombre> 1920 1080 60 "obj:Play Button@6;..." "5,20,40"
```

- **Salida del build:** `recovery/build/Windows/DSSRacer.exe`. Tarda ~1 min y la carpeta está fuera de git.
- **Resultados de `run_player.sh`:** en `recovery/build/Windows/recovery_tests/` (log y capturas).
- **Arnés de pruebas:** `RecoveryPlayerTest` solo se activa con `-recoveryTest`. Acepta las mismas acciones que el editor, más `res:WxH@t` para cambiar de resolución en caliente, y registra las fuentes de audio que suenan.
- **Clics:** en el ejecutable el menú reabre la última pantalla, así que pulsa por nombre de objeto (`obj:`), no por coordenadas.

**Mira siempre las capturas** con tus propios ojos o con un modelo con visión. Revisa que los karts no salgan oscuros, que la interfaz esté bien colocada y que no haya objetos rosas (shader roto).

## 5. Git

- **Commit:**
  ```bash
  git add -A
  git -c user.name=STEEP -c user.email=vidalesnaifer9@gmail.com commit -m "Stage 4.x (part): <qué>"
  ```
  Añade al final del mensaje la línea de coautoría del modelo que uses.
- **Ramas:** trabajo local en `main`. Remotos: `origin` → github.com/naiferyt/game, con las ramas `mi-proyecto` y `claude/optimistic-archimedes-kmux3s`.
- **Subir:**
  ```bash
  git push origin main:mi-proyecto
  git push origin main:claude/optimistic-archimedes-kmux3s
  ```
- **Nunca** hagas `push --force`, `reset --hard` ni borres ramas sin preguntar al usuario.
- **Antes de empezar,** si hubo trabajo en la nube: `git fetch origin` y `git merge --ff-only origin/claude/optimistic-archimedes-kmux3s`.

## 6. Problemas ya conocidos (no los "arregles" otra vez)

- **Mapas deformados o sin suelo:** los causan el static batching de Unity 4, las mallas comprimidas y una matriz de capas corrupta. Ya está resuelto en la Etapa 0; no reimportes las escenas.
- **Iluminación de karts:** la dan las light probes originales, vía `Assets/_Recovery/Runtime/LegacyLightProbes.cs` y `forensics/scripts/lightprobes_export.py`. `RaceManager.Init` destruye las luces de la pista a propósito, igual que el original.
- **60 fps en PC:** los fija `Assets/_Recovery/Runtime/PcFrameRate.cs`.
- **Errores "Invalid worldAABB" y "Mesh.vertices is too small"** del medidor de derrape: son del original (escala 0 en `UghSprite`).
- **Interfaz Ugh:** la cámara mide 9,6 unidades de alto y el ancho sigue al aspecto. `UghCamera.Update` recoloca la interfaz al cambiar el tamaño de la ventana.
- **Textos de la interfaz:** la fuente bitmap `Assets/Font/CCUpUpAndAway.asset` lleva `m_Ascent: 0` a propósito (Unity 4 medía los glifos desde la línea superior). No la restaures a 48.75: todos los textos bajarían fuera de sus recuadros. Se comprueba con `DSSRecovery.FontProbe.Run`.
- **Barrido de colisión del kart** (`CarCollider.DoMovement`): ignora solapes iniciales y triggers, como PhysX 2.8. El radio `bounds.size.x` (2,4) es el del original; no lo cambies.
- **Cambios pedidos por el usuario** (etiqueta `// MODIFICADO (petición del usuario…)`, no fieles al ARM, no los reviertas): el kart ignora contactos a ras de suelo (rampa de Kick Butt 1) y los bots no aplican muros en el aire ni cuando su propio punto de ruta está fuera del muro (`GimpedCarAI.DoRoadBoundaries`). Para revisar bots usa `aitrace@t1-t2` en `run_play.sh`.
- **Waypoints de longitud cero** (Bus Jumper, Dirt Devils, Hokey Poke): `WaypointLogic.SegmentRatio` evita el 0/0 que cerraba el juego. Compruébalo con `DSSRecovery.WaypointCheck.Run`.
- **Rivales:** `Assets/_Recovery/Runtime/RivalTuning.cs` (`MODIFICADO`, PlayerPrefs `DSSR_CompetitiveRivals` = 0 para el comportamiento original).
- **Guardado del usuario:** el usuario juega entre pruebas. Antes de una tanda que toque `DSSRacer_save.txt`, copia el guardado actual y repón exactamente esa copia (nunca una antigua).
- **Pesos de hueso:** 5 mallas de personaje tenían el 4.º peso ≈ −27 (fallo de UnityPy); reparadas con `forensics/scripts/fix_skin_weights.py`. Prueba los personajes con la calidad del ejecutable (`quality:5@t` en `run_play.sh`): el editor usa 1 hueso por vértice y oculta estos fallos.
- **Lightmaps:** son EXR HDR generados desde los PNG de Unity 4 (`LightmapHdrConverter`) para que `DecodeLightmap` dé el 2 × texel original. No los vuelvas a importar como PNG.
- **Partículas:** sus materiales se restauraron con `forensics/scripts/fix_particle_materials.py`; el volcado `badmat` del arnés lista renderers sin material.
- **Probar circuitos Pro/Master:** usa una copia del guardado con `Highest Place <pista>::0;;` para las 9 pistas en `LifeTimeMetrics`. El menú previo exige pulsar primero la flecha del tipo de carrera (`0.0625,0.49`, `0.547,0.495`), luego `obj:Play Button` y en pista `obj:Go Button`. Al arrancar, cierra las ventanas de logro con `obj:Input Blocker Invisible` (3 veces, cada 3 s).

## 7. Qué hacer si no estás seguro

Detente y pregunta al usuario. No borres archivos, no cambies decisiones de la sección 1 y no marques un bloque como terminado sin haberlo probado en Unity.
