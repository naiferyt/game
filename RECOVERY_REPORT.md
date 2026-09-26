# GAME RECOVERY REPORT — Disney Super Speedway (DSSRacer) v1.3

Fecha: 2026-09-26 · Alcance: Fase 0 (herramientas), Fase 1 (diagnóstico forense), Fase 3 (propuesta de estrategia).
**Revisión 2 (2026-09-26):** la Fase 3 se rehízo según las decisiones del usuario (ruta C modificada, Unity 6.6 obligatorio,
eliminación total de servicios iOS, PC primero y Android después). Ver §11 y §12.
No se ha escrito código de gameplay. Todo lo afirmado aquí fue **re-verificado contra los binarios originales**
con scripts propios (`forensics/scripts/`), no copiado de los informes del intento anterior.

---

## 0. Resumen ejecutivo

| Pregunta | Respuesta | Confianza |
|---|---|---|
| Versión de Unity | **4.3.4f1** (todos los archivos serializados; `unity default resources` = 4.3.0b5, normal) | ALTA |
| Backend | **Mono Full-AOT** (iOS, ARMv7 32-bit). **No es IL2CPP.** | ALTA |
| ¿Hay código C# en los DLL? | Solo metadata: nombres, campos, firmas, enums, **constantes** y **literales de texto**. Los 4.289 cuerpos de método son `ret` (IL eliminado). | ALTA |
| ¿Se perdió la lógica? | **No.** Está compilada a ARM dentro de `DSSRacing`. He reconstruido las tablas Mono AOT y cada método C# se mapea a su código nativo **sin una sola discrepancia** (4.289/4.289). Las llamadas y literales se resuelven a nombres reales. | ALTA |
| ¿Están los assets? | Sí: 17 escenas, 579 prefabs, karts, 15 personajes, 12 definiciones de carrera, audio, animaciones, UI. | ALTA |
| ¿Por qué "el menú aparece pero la carrera falla"? | El proyecto previo (`phase4_reconstruction/WorkingProject`) compila, pero **todos los métodos están vacíos** (p. ej. `RaceManager.InitRace(){}`), porque se generaron desde el DLL sin IL. Nada ejecuta lógica. | ALTA |
| Estrategia acordada | **C modificada**: proyecto **Unity 6.6** desde el export de AssetRipper (escenas, prefabs y datos originales) + esqueleto C# con nombres y campos exactos + **cuerpos recuperados traduciendo el ARM AOT método a método**. **Servicios iOS eliminados.** PC primero, Android después. Ver §11. | — |

La conclusión del intento anterior ("los cuerpos no son recuperables sin un proyecto de reversing tipo Ghidra/IDA")
era demasiado pesimista: con las tablas AOT que ya he decodificado, la lectura del ARM es **dirigida y anotada**
(nombres de métodos llamados, literales, constantes), no reversing a ciegas.

---

## 1. Fase 0 — Herramientas disponibles (verificado con `command -v`)

| Herramienta | Estado | Nota |
|---|---|---|
| git | ✅ 2.55 | Repo existía sin commits y con 53.687 archivos en staging (ver §9). |
| dotnet | ✅ | |
| ilspycmd / ILSpy | ⚠️ no en PATH, **descargado localmente**: `tools/ilspycmd_10.1.1.8388`, `tools/ILSpy_10.1.1.8388_x64` | Sirve, pero el IL está vacío: solo da esqueletos (ya generados en `phase3_code/ILSpyProjects`). |
| Il2CppDumper / Il2CppInspector | ❌ | **No necesarios**: no es IL2CPP. |
| AssetRipper | ⚠️ no en PATH, **descargado**: `tools/AssetRipper_1.3.14_win_x64` | Export ya hecho en `phase2_extraction/`. |
| Python | ✅ 3.14 en `%LOCALAPPDATA%\Python\bin\python.exe` (el `python` del PATH es el alias de Microsoft Store, no funciona) | numpy, pillow. **Sin UnityPy, sin capstone.** |
| Unity Hub / Editor | ✅ **Unity 6000.6.3f1** en `C:\Program Files\Unity\Hub\Editor\6000.6.3f1` (instalado el 2026-09-26 a las 04:07, durante la Fase 1; en la primera comprobación aún no estaba). Módulos: Windows Standalone (Mono) y WebGL. **Sin módulo Android** (se añadirá en el port). | El Unity 6000.5.3f1 que usó el intento previo ya no está. |
| Disassembler ARM (capstone / Ghidra / IDA) | ❌ | Necesario para la ruta recomendada (ver §11). |
| Internet | ✅ (pypi, github, unity.com responden) | No he instalado nada: requiere tu aprobación. |

---

## 2. Identificación del build

| Campo | Valor | Fuente |
|---|---|---|
| Juego | Disney Super Speedway ("Speedway"), `com.disney.DSSRacer`, v1.3 | `Info.plist` |
| IPA fuente | `Downloads\ddsracer\DSSRACER\com.disney.DSSRacer-iOS6.0-(Clutch-2.0.4).ipa`, SHA256 `5630012A…621A` (idéntico a `Downloads\com.(Clutch-2.0.4).ipa`) | Internet Archive, dump descifrado con Clutch |
| Plataforma | iOS 6.0+, SDK 7.1, Xcode 5.1.1, iPhone+iPad, landscape | `Info.plist` |
| Binario | Mach-O ARMv7 (32-bit), 17,2 MB, `cryptid=0` (descifrado), tabla de símbolos casi vacía (1.632) | parser propio `macho.py` |
| Unity | 4.3.4f1, formato serializado 9, **todos los archivos íntegros** (tamaño de cabecera = tamaño real) | `hdr.py` |
| Scripting | Mono 2.x **Full-AOT, estático**, formato AOT **v66**, 9 módulos AOT | `aotglobals.py`, `aotinspect.py` |
| Módulos AOT | mscorlib, System, System.Core, System.Xml, UnityEngine, Assembly-CSharp-firstpass, Assembly-CSharp, Assembly-UnityScript | |

### 2.1 Estructura del `.app`
```
DSSRacing.app/
├── DSSRacing                 ← ejecutable ARMv7: motor Unity + TODO el código C# compilado AOT
├── Data/
│   ├── mainData              ← managers globales + escena 0 (CloudStrap)
│   ├── level0 … level15      ← escenas 1…16
│   ├── sharedassets0…16.assets, resources.assets (Resources/), unity default resources
│   ├── Resources/unity_builtin_extra
│   └── Managed/*.dll         ← solo metadata (IL vaciado)
├── DMOAnalytics/             ← plugin nativo de analítica (libtapalytics.a + .h/.mm)
└── iconos, launch images, offline.html
```
**No existe `Data/Raw` (StreamingAssets)** ni AssetBundles físicos, ni en el `.app` ni en el `.ipa` (99 entradas verificadas con `unzip -l`). Ver §7.3: no es un bloqueo.

---

## 3. Hallazgo central: la lógica original es recuperable desde el ARM

### 3.1 Evidencia
1. **IL vacío (confirmado de forma independiente)** — `climeta.py` (lector ECMA-335 propio):

   | Assembly | MethodDef | Cuerpo = solo `ret` | Sin cuerpo (abstract/extern) | IL real |
   |---|---:|---:|---:|---:|
   | Assembly-CSharp | 2.914 | 2.886 | 28 | **0** |
   | Assembly-CSharp-firstpass | 1.553 | 1.393 | 160 | **0** |
   | Assembly-UnityScript | 10 | 10 | 0 | **0** |

2. **Tablas Mono AOT localizadas** — cada módulo exporta una tabla de *globals* (nombre → dirección): `methods`, `method_addresses`, `method_offsets`, `method_info`, `got_info`, `plt`, `class_name_table`, `ex_info`, `unwind_info`, `mono_image_table`…

3. **Mapeo método ⇄ código nativo exacto** (`mapcheck.py`): el índice *i* de `method_addresses` corresponde al token `0x06000000+i+1`:
   - Assembly-CSharp: 2.886 métodos con código, 28 sin código → **coinciden exactamente** con los 2.886 cuerpos `ret` y los 28 abstractos. 0 discrepancias.
   - firstpass: 1.393 / 160 → 0 discrepancias. UnityScript: 10 / 0 → 0 discrepancias.
   - Volumen: **682 KB** de ARM (Assembly-CSharp) + **343 KB** (firstpass) + 11 KB (UnityScript). Tabla completa: [`forensics/output/native_method_map.csv`](forensics/output/native_method_map.csv).

4. **Llamadas resolubles a nombres** (`aotdec.py`): 19.578 instrucciones `BL` del código de juego van a la PLT; cada entrada PLT codifica su destino. Decodificadas: 870 métodos distintos, p. ej. `MonoBehaviour::.ctor`, `Physics::Raycast`, `Vector3::op_Subtraction`, `Application::LoadLevelAsync`, `PlayerPrefs::SetInt`, `CarAIPathRecorder::DistanceCompressPath`. Listado: [`forensics/output/plt_resolved.tsv`](forensics/output/plt_resolved.tsv).

5. **Literales resolubles** (`gotdec.py`): las 965 entradas `ldstr` de la GOT apuntan a sus cadenas exactas (el heap `#US` sobrevivió): 959 literales en Assembly-CSharp y 288 en firstpass ([`forensics/output/*_userstrings.txt`](forensics/output/)). Ej.: `"PreFrontEnd"`, `"FrontEndTest"`, `"Loading"`, `"RaceResults"`, `"+RaceManager"`, `"musicVolumeLevel"`, `"raceDifficulty"`, `"Finished Lap"`, `"Crossed Finish Line Backwards"`, `"Body asset is not finished loading! Aborting car build."`.

6. **Constantes en metadata**: `RaceManager.COINS_TO_SPAWN=20`, `CATCHUP_DISTANCE=400`, `SLOWDOWN_DISTANCE=200`, `BASE_FIRST_PLACE_REWARD=300`, `BASE_NON_PLACE_REWARD=10`, `PLACEMENT_DIVISOR=2`; `CarCollider.CAR_GRAVITY=10`, `COLLISION_RESTITUTION=0.3`, `STALL_TIME=3`, capas `ground=256`, `car=512`, `collide=1024`.

### 3.2 Qué significa y qué límites tiene
- El código ARM **es** el comportamiento original. Traducirlo a C# es recuperar, no inventar. Lo etiquetaré como **RECUPERADO-AOT** (distinto de "RECUPERADO" directo) porque la traducción es manual y puede tener errores: se valida compilando, ejecutando y contrastando con los datos serializados.
- Pendiente de implementar en la herramienta de anotación: llamadas virtuales (slot de vtable → método), resolución de clases/campos estáticos en la GOT (decodificación parcial ya hecha), offsets de campos de instancia (calculables desde la metadata y verificables con los getters), constantes float de los literal pools.
- Los "extra methods" (2.855 en Assembly-CSharp) son instanciaciones genéricas/wrappers del runtime, no lógica de juego nueva.

---

## 4. Estado del trabajo previo en la carpeta (julio 2026)

| Carpeta | Contenido | Valor / problema |
|---|---|---|
| `phase1_analysis/ipa_unpacked` | `.ipa` descomprimido | **Referencia original.** No se toca. |
| `phase2_extraction/AssetRipperUnityProject/ExportedProject` | Export AssetRipper 1.3.14 (6.003 archivos) | **Base recomendada** (GUIDs/fileIDs originales). Shaders en modo *Dummy*. |
| `phase2_extraction/AssetRipperPrimaryContent` | GLB/PNG/audio sueltos | Redundante, útil para inspección. |
| `phase3_code/ILSpyProjects` | Esqueletos C# (355 `.cs`) | Útil: nombres, campos, firmas, enums, constantes. Sin lógica. |
| `phase4_reconstruction/WorkingProject` | Copia del export con **todos los métodos vaciados** a stubs compilables | Explica el síntoma actual. Contiene una clase **inventada** `MultilayerTextureBundleDef` (§7.2). No recomiendo construir encima. |
| `phase4_reconstruction/android_toolchain` | SDK Android (36.756 archivos, ~1 GB) | Excluido de git. |
| Informes FASE 4/5 | Mencionan `C:\Users\STEEP\Documents\game\phase4_reconstruction\Unity6Project` | **Esa ruta ya no existe**; el proyecto Unity 6 no está en esta carpeta. |

---

## 5. Escenas (Build Settings, extraídas de `mainData`)

| # | Archivo | Escena | Contenido clave (componentes serializados) | Rol |
|---|---|---|---|---|
| 0 | mainData | `CloudStrap` | `CloudStrap`, logo localizado, rueda de carga, icono iCloud | Boot: inicialización iCloud/nube |
| 1 | level0 | `PreFrontEnd` | `PreFrontEndHoop`, `ScreenFader` | Transición previa al menú |
| 2 | level1 | `Front End/FrontEndTest` | `EnsureGlobals` (14 prefabs globales), `FrontEndLogic` (lista de menús), `PreviewCart`, `CharacterPreview`, `FrontEndCamera`, garaje | **Menú principal / garaje** |
| 3 | level2 | `Front End/Loading` | `LoadingPublisher`, botón Go, "100%", paneles de logros | Carga de carrera |
| 4 | level3 | `MoreDisney` | `MoreDisneyLogic` | Promo cruzada Disney (servicio muerto) |
| 5 | level4 | `Front End/RaceResults` | `RaceResultsPublisher` (Retry, Redo, Continue, monedas), `MissionDialogPublisher` | Resultados |
| 6–8 | level5–7 | `Tracks/Fish Hooks Track 1–3` | ver §6.2 | Circuito Fish Hooks |
| 9–11 | level8–10 | `Tracks/Kick Butt Track 1–3` | | Circuito Kick Buttowski |
| 12–14 | level11–13 | `Tracks/Phineas Track 1–3` | | Circuito Phineas & Ferb |
| 15 | level14 | `Tracks/Tutorial Track` | | Tutorial |
| 16 | level15 | `Test Scenes/Pranksgiving Test` | | Pista estacional (activada por URL remota) |

---

## 6. Datos serializados que definen la arquitectura original

### 6.1 Definiciones de carrera (`RaceSettings` como prefabs en `Assets/GameObject/`)
| Nombre UI | Escena | Modo | Vueltas | IA | Dificultad base |
|---|---|---|---:|---:|---|
| Doof's Tower | Phineas Track 1 | Campaign | 3 | 5 | EASY |
| Danville River | Phineas Track 2 | Campaign | 3 | 5 | MEDIUM |
| Danville Arena | Phineas Track 3 | Campaign | 3 | 5 | HARD |
| Freshwater High | Fish Hooks Track 1 | Campaign | 3 | 5 | EASY |
| Hokey Poke | Fish Hooks Track 2 | Campaign | 3 | 5 | MEDIUM |
| Fishtankia | Fish Hooks Track 3 | Campaign | 3 | 5 | HARD |
| Kick Butt! | Kick Butt Track 1 | Campaign | 3 | 5 | EASY |
| Bus Jumper | Kick Butt Track 2 | Campaign | 3 | 5 | MEDIUM |
| Dirt Devils | Kick Butt Track 3 | Campaign | 3 | 5 | HARD |
| Pranksgiving | Pranksgiving Test | Campaign | 3 | 5 | HARD |
| Tutorial | Tutorial Track | Mission | 1 | 0 | EASY |
| DEBUG | Pranksgiving Test | Campaign | 25 | 5 | NINTENDO_HARD |

Enums reales: `RaceModes {Campaign, Mission, Elimination}`, `RaceDifficultyLevel {EASY, MEDIUM, HARD, NINTENDO_HARD}`.
Literales: *"Unlock Medium difficulty by placing 3rd or better on all tracks with Easy difficulty."* (regla de progresión original).

### 6.2 Estructura de pista (idéntica en las 11 pistas — [`track_structure.txt`](forensics/output/track_structure.txt))
```
Track Logic
├── Progress Triggers      3–5 × ProgressTriggerLogic {nextTrigger, isLapLine, trackDistance}  → 1 línea de meta por pista
├── ResetTrigger ×1–11     ResetTrigger {underGap, spawnPoint}                                  → respawn
├── Waypoints  86–329      WaypointLogic {forwardPoint, backwardPoint, distanceToNext,
│                                         totalTrackDistance, waypointWallDist, branchHints}    → distancia en pista / límites / sentido
├── Speed Points 71–182    SpeedPoint {forwardPoint, backwardPoint, branches}                   → grafo de velocidad/IA
└── LOS Blockers           BoxColliders
Track Dressings: Pole Positions (6 parrillas), Pickups (PickupSpawner), Coin points, Speed Strips (TerrainEffectTrigger)
+CarAIPathManager          24–36 trayectorias de IA GRABADAS por pista (15 en Pranksgiving) (punto, rotación, inAir)
+RaceManager, HUDLogic, FollowCamera (+curvas), PreRaceCamera, DebugTrackStrapper (kart por defecto)
```
Sistema de vueltas original = cadena de `ProgressTriggerLogic` (checkpoints secuenciales) + `isLapLine`; posición = distancia acumulada sobre la lista de waypoints (`totalTrackDistance`, `GetCarLastTrackDistance`). No hay que inventarlo.

### 6.3 Karts y personajes (`Resources/cart assets`, 98 prefabs)
- Carrocerías: Kart 0–5, Bike 0–5, Truck 0–5, cada una con slots `CharacterSlot, ScoopSlot, SpoilerSlot, ThrustersSlot, WheelsSlot`.
- Ruedas (`AnimationTire, SpringConnection, SphereCollider, Rigidbody`), spoilers, thrusters, scoops.
- Personajes (15): Agent P, Bea, Brad, Crash, Dipper, Ferb, Gunther, Kick, Mabel, Mike, Milo, Oscar, Phineas, Randy, Soos.
- Karts IA (14): `<Nombre>_AI` = `Rigidbody + SphereCollider + CarCollider + CarAI + PowerupHolder + EffectManager + SoundSequencer + AnimationDriver` + `CarAIPersonality`.

### 6.4 Menú (datos de `FrontEndLogic` en `FrontEndTest`)
`menues`: CartCustomizer, CharacterSelect, **Play** (`initialMenuIndex = 2`), Settings, Track Select, Difficulty Select, Achievement Categories, Achievements, Circuit Select, … cada uno con `menuPrefab` + `cameraTarget`. Popups: more coins, tutorial launcher, daily bonus, purchase notification.

### 6.5 Controles
`PlayerAccelControl` (inclinación, `Input.acceleration`), `TouchTurnTrack` (volante táctil), `UghInput` (toques UI) y **`PlayerKeyboardControl` original** con `KeyEvents {UsePowerup, BuyPowerup, Pause, Drift, Accelerate, Break, TurnLeft, TurnRight}`. InputManager: ejes `Horizontal, Vertical, Drift, Use, Buy, Pause`. → Para PC existe control por teclado **original**, no hay que inventarlo.

### 6.6 Guardado
`DataUtility` (`CloudSaveData`, `LocalOptionsData`, `LifetimeMetrics`, `IsUnlocked/Unlock`, `SetCartPart/SetCartPaint`, monedas, snapshots por vuelta), PlayerPrefs (`musicVolumeLevel`, `sfxVolumeLevel`, `raceDifficulty`, …), iCloud (`GravCloudPrefs`, `JCloud*`).

---

## 7. Referencias rotas, daños y ausencias

### 7.1 Clasificación general
| Elemento | Clasificación |
|---|---|
| Escenas, prefabs, materiales, mallas, texturas, animaciones (231 legacy `Animation`), audio (85 mp3 + 37 wav), fuentes, TextMesh (488) | **EXISTE Y SE PUEDE RECUPERAR** |
| Datos serializados de gameplay (waypoints, triggers, rutas IA, RaceSettings, menús, cámara) | **EXISTE Y SE PUEDE RECUPERAR** |
| Estructura de clases, campos, enums, constantes, literales | **EXISTE Y SE PUEDE RECUPERAR** |
| Lógica de juego (4.289 métodos) | **EXISTE (en ARM) — recuperable por traducción** |
| 4 shaders custom (`Double Texture Additive Unlit`, `Transparent And Color Unlit`, `Transparent Color Shift Unlit`, `Underwater Unlit`) | Dañados **solo en el export** (modo *Dummy*). En los `.assets` originales están en texto: 3 son ShaderLab *fixed-function* completos (`iPhone/Transparent Color Shift Unlit`, `iPhone/Transparent And Color Unlit`, `Additive Unlit Double Texture`) → **recuperables tal cual**; `Mobile/Unlit Under The Sea (Supports Lightmap)` es GLSL/GLES compilado → recuperable portando ese GLSL a CG (shader pequeño: unlit + textura cáustica) |
| 16 shaders built-in (`Mobile/*`, `Particles/*`, `Unlit/*`, `Transparent/*`…) | Sustituibles por los built-in de Unity del mismo nombre (sin cambio visual) |
| 8 assets `MultilayerTextureBundleDef` (pinturas kart0–6) | **EXISTE PERO ESTÁ DAÑADO**: el tipo no está en los DLL (era de editor); los datos crudos siguen en `resources.assets`. El intento previo inventó la clase. Probablemente no se usan en runtime (el runtime usa `StreamedMultilayerTexture`); a verificar. |
| Servicios iOS: StoreKit, Game Center, iCloud, Burstly (ads), DMO/Tapalytics, MoreGames, GravCloud | **SE ELIMINAN** (decisión del usuario, §11.2). El guardado pasa a ser local. |
| Contenido remoto: `datg-apps.com/ss/pranksgiving.txt`, `PartCosts.epa.xml`, URLs de idioma | **NO EXISTE** (servidores muertos) → valor por defecto local |
| `Assembly-CSharp-Editor.dll` | **NO EXISTE** (editor-only; no afecta runtime) |
| `Data/Raw/IOSBundles/*.unity3d` | **NO EXISTE**, pero ver 7.3 |
| `Assembly-UnityScript` (`Car_Script`, `Plane_Script`) | Existe; **0 referencias** en escenas/prefabs → restos sin uso |

### 7.2 Compatibilidad de componentes
- **91 sistemas de partículas legacy** (`EllipsoidParticleEmitter + ParticleAnimator + ParticleRenderer`) + 64 Shuriken. Las legacy **desaparecen en Unity ≥ 2018.3** (el intento previo a Unity 6 las perdió o sustituyó).
- En Unity 6.6 siguen existiendo la animación legacy, `TextMesh` y el Input Manager clásico. `WWW`, `Application.LoadLevel` y `OnLevelWasLoaded` son obsoletos y se adaptan (§11.3).

### 7.3 AssetBundles
`StreamManager.StreamType {UNKNOWN, ASSET_BUNDLE, RESOURCE}` y `RaceSettings.AICartSettings {bundlePath, resourcePath}`: el juego soportaba ambas rutas. Todo el contenido de karts/personajes está en `Resources/cart assets`, y el juego funcionaba en iOS sin `Data/Raw` → en iOS se usaba la ruta `RESOURCE` (literales `IOSBundles/`, `/WebBundles/` corresponden a otras plataformas). **Confianza MEDIA**; se confirmará leyendo el ARM de `StreamManager.PrependRootFileLocation` / `RaceSettings.GatherRequiredAssets`.

---

## 8. Sistemas del juego: evidencia, estado y confianza

Tamaños = bytes de ARM original por clase (`native_bytes_per_class.txt`). Confianza = de poder restaurar el comportamiento **original**.

| Sistema | Clases originales (evidencia) | ARM | Datos serializados | Confianza |
|---|---|---:|---|---|
| Boot / globales | `CloudStrap`, `EnsureGlobals`, `SingletonScript`, `+DataUtility`, `+StreamManager`, `+Localize`, `+AchievementManager`, `+PlayerInstance`, `+TrackUnlockHelper`, `+Screen Timeout Controller` | pequeño | lista de 14 globales | **ALTO** |
| UI framework propio | `Ugh*` (firstpass): `UghSprite` 25 KB, `UghInput`, `UghCamera`, `UghButton`, `UghText`, `UghAlign`, `UghStretch`, `UghScrollView`, `UghPublisher`… (+ utilidades `Util` 18 KB, `GUIx` 16 KB) | 68 KB (`Ugh*`) | toda la UI serializada | **ALTO** (volumen grande) |
| Menú principal | `FrontEndLogic`, `FrontEndCamera`, `*Publisher` (CharacterSelect 8 KB, TrackSelect 5 KB, SelectCircuit, CartCustomizer 24 KB, Settings, Play…) | ~90 KB | lista de menús + prefabs | **ALTO** |
| Scene management | `Application.LoadLevel/LoadLevelAsync`, `ScreenFader`, `FadeHelper` 10 KB, `LoadingPublisher` | pequeño | nombres de escena en literales | **ALTO** |
| Race Manager | `RaceManager` 22 KB: `InitRace`, `PreLaunchCoroutine`, `PreraceCountdown`, `CalculateCarPositionPump`, `DoFinishLineEffect`, `PostRaceCountdown`, `RaceOutCoroutine`, `EndRace`, `PauseRace`, `EliminateCar`, `RaceRewind` | 22 KB + iteradores | `RaceSettings` ×12 | **ALTO** |
| Kart / física | `CarCollider` 24 KB (física arcade propia), `TriFoot` 11 KB (contacto suelo), `SpringConnection`, `CartAttributes`, `CarMetrics` | ~45 KB | atributos por pieza | **MEDIO-ALTO** (matemática float densa; riesgo de error de traducción) |
| Construcción del kart | `PlayerInstance`, `CartPartList`, `CartSlot`, `PreviewCart`, `<ConstructCart>`, `<ComposeCart>` | ~25 KB | slots + prefabs de piezas | **ALTO** |
| Input | `PlayerKeyboardControl`, `PlayerAccelControl`, `TouchTurnTrack`, `PlayerControlLinker`, `InputBlocker` | pequeño | ejes InputManager | **ALTO** |
| Track / vueltas | `ProgressTriggerLogic`, `WaypointLogic` 12 KB, `SpeedPoint`, `ResetTrigger`, `DoWrongWayCheck` | ~20 KB | grafos completos | **ALTO** |
| Posiciones | `RaceManager.CalculateCarPositions`, `CarProgress`, `GetCarLastTrackDistance` | incl. | `totalTrackDistance` | **ALTO** |
| IA | `CarAI`, `GimpedCarAI` 10 KB, estados `DriveWaypoints/AvoidTerrain/HitBeneficial/Pickup`, `CarAIPersonality`, `CarAIPathManager` | ~30 KB | 15–36 rutas grabadas/pista | **ALTO** (datos) / MEDIO (volumen) |
| Cámaras | `FollowCamera`, `PreRaceCamera`, `CameraShake`, `FrontEndCamera` | ~12 KB | parámetros + curvas | **ALTO** |
| HUD | `HUDLogic` 12 KB, `PausePublisher` | ~15 KB | jerarquía completa | **ALTO** |
| Resultados | `RaceResults`, `RaceResultsPublisher`, `PlaySummaryPublisher` | ~12 KB | escena RaceResults | **ALTO** |
| Power-ups / efectos | `BasePickup`, `PowerupHolder`, `EffectManager`, `Rocket*`, `Mine*`, `Shield*`, `BoosterEffect`, `WipeoutEffect`… | ~40 KB | prefabs + partículas | **MEDIO-ALTO** (depende de partículas legacy) |
| Audio | `SoundLibrary`, `MusicPlayer`, `SoundSequencer`, `SoundPackageManager`, `CharacterVOController` | ~15 KB | clips + librerías | **ALTO** |
| Guardado / progresión | `DataUtility` 13 KB, `TrackUnlockHelper`, `MissionManager`, `AchievementManager`, `LifetimeMetrics` | ~30 KB | PlayerPrefs keys | **MEDIO-ALTO** (la capa iCloud se sustituye por local) |
| Tienda / IAP / ads / GameCenter / analytics | Prime31 StoreKit/GameCenter/iCloud, Burstly, DMO | — | — | **ELIMINADO** (decisión del usuario, §11.2) |
| Pranksgiving | `http://datg-apps.com/ss/pranksgiving.txt` | — | escena + RaceSettings | **MEDIO** (el interruptor remoto no existe) |

---

## 9. Git

- El repo existía **sin commits** con 53.687 archivos en staging. Creé `.gitignore` excluyendo `tools/` (binarios de terceros re-descargables) y `phase4_reconstruction/android_toolchain/` (SDK Android), los saqué del índice (siguen en disco) y creé el commit base `3b4c2ea5` = estado original + intento previo, antes de tocar nada.
- Identidad usada solo en ese commit: `STEEP <vidalesnaifer9@gmail.com>` (no hay `user.name` configurado). Cámbiala si prefieres otra.

---

## 10. Mapa de dependencias (según evidencia; no plantilla)

```
CloudStrap (mainData) ─ CloudStrap: init iCloud/nube, logo            [literales + escena]
   └─► PreFrontEnd ─ PreFrontEndHoop, ScreenFader
         └─► FrontEndTest ─ EnsureGlobals → 14 singletons (+DataUtility, +StreamManager, +Localize, ...)
               FrontEndLogic → menús [Play*, CharacterSelect, CartCustomizer, Track/Circuit/Difficulty Select, Settings, Achievements]
               PreviewCart / CharacterPreview / FrontEndCamera
               DataUtility.CurSettings = RaceSettings elegido
               └─► Loading ─ LoadingPublisher; RaceSettings.StartBundleLoads/GatherRequiredAssets → StreamManager (RESOURCE)
                     └─► Track scene (LoadLevelAsync, "Go")
                           RaceSettings.Launch → RaceManager.InitRace(numLaps)
                           ├─ PlayerInstance/CartPartList → construye kart jugador (CarCollider + input)
                           ├─ DetermineAICars → karts <Char>_AI en Pole Positions (CarAI + CarAIPathManager)
                           ├─ PreRaceCamera → PreLaunchCoroutine → PreraceCountdown (HUD "PreRace Count")
                           ├─ Carrera: CarCollider.FixedUpdate/CarUpdatePump, ProgressTriggerLogic → AdvanceCarLap,
                           │           CalculateCarPositionPump, SpawnCoins, pickups/efectos, ResetTrigger, FollowCamera, HUDLogic
                           ├─ Meta: DoFinishLineEffect → PostRaceCountdown → RaceOutCoroutine → EndRace (raceEndEvent)
                           └─► RaceResults ─ RaceResultsPublisher: Retry | Redo (RaceRewind por snapshots de vuelta) | Continue → FrontEndTest
MoreDisney ─ promo Disney (se elimina del build, §11.2)
```
El orden exacto de las corrutinas es **MEDIO** (deducido de nombres/literales); se fijará al leer el ARM de `RaceManager`.

---

## 11. FASE 3 — Estrategia (v2: "C modificada", decisiones del usuario del 2026-09-26)

> La v1 de esta sección recomendaba Unity 2017.4 y stubs para iOS. **Queda sustituida** por las decisiones del usuario:
> 1. Ruta **C (híbrida)**: assets/escenas/datos originales + lógica recuperada del ARM AOT.
> 2. **Unity 6000.6.3f1 (Unity 6.6)**, la versión instalada, **obligatoriamente**, asumiendo el trabajo extra de compatibilidad.
> 3. **Se eliminan por completo los servicios de iOS** (no se simulan con stubs).
> 4. Plataforma: **PC (Windows) primero**; **Android después**, como port separado.

### 11.1 Etiquetas de procedencia (se usan en código y en `RECOVERY_PROGRESS.md`)
| Etiqueta | Significado |
|---|---|
| **RECUPERADO** | Tomado directamente del original: escena, prefab, dato serializado, metadata (nombres, campos, constantes, literales). |
| **RECUPERADO-AOT** | Cuerpo de método traducido del ARM original. Cabecera obligatoria: `// RECUPERADO-AOT <Clase>.<Método> token 0x06xxxxxx @0x<dirección>`. |
| **ADAPTADO-U6** | Cambio mecánico exigido por Unity 6 que conserva la semántica original (p. ej. `Application.LoadLevel` → `SceneManager.LoadScene`). |
| **RECONSTRUIDO** | Sin evidencia directa. Solo se usa donde no hay otra opción, y se justifica por escrito. |
| **ELIMINADO** | Servicio iOS o servicio externo quitado por decisión del usuario. Se documenta qué era y qué punto del juego afectaba. |

### 11.2 Lo que se elimina: servicios iOS y externos
Son 42 clases y ~102 KB de ARM que **no se traducen** (≈10 % del código del juego).

| Grupo | Clases originales | Dónde está enganchado en los assets | Qué queda en su lugar |
|---|---|---|---|
| Compras (StoreKit) | `StoreKitBinding/EventListener/GUIManager/Manager/Product/Transaction`; en `DataUtility`: `PurchaseCoinsFromStoreKit`, `SetupItemsForPurchase`, `Purchase*`, `StartStorePurchase`, `Finalize*`, `ProductList*` | `StoreKitManager.prefab` (en `EnsureGlobals`), `BuyCoinsPrefab` (`DebugMoreCoinsPublisher`, = `FrontEndLogic.moreCoinsPopupPrefab`) | Nada. Se oculta la tienda de monedas con dinero real. **La economía interna se conserva**: monedas ganadas en carrera y compras de piezas con monedas (`BuyItem`). |
| Game Center | `GameCenter*` (10 clases) + callbacks `gc*` de `DataUtility` | `GameCenterManager.prefab` (en `EnsureGlobals`) | Los **logros internos del juego se mantienen** (`AchievementManager`, menús Achievements). Se quitan el envío a Game Center y los leaderboards. |
| iCloud / nube | `iCloud*`, `P31CloudFile`, `P31Prefs`, `JCloud*`, `GravCloud*`; `DataUtility.iCloudDataChanged` / `JCloudDataDidChangeExternally` | escena `CloudStrap` (icono iCloud giratorio) | Guardado **local**: se conserva el modelo de datos original (`CloudSaveData`, `LocalOptionsData`, `LifetimeMetrics`) y se persiste en `Application.persistentDataPath` / PlayerPrefs (backend RECONSTRUIDO, datos RECUPERADO). `CloudStrap` sigue como escena de arranque con logo, sin esperar a la nube. |
| Anuncios | `BurstlyBinding` | — | Nada. |
| Analítica | `GDMOBinding`, `GDMOManager`, carpeta nativa `DMOAnalytics/` | — | Nada. |
| Promo Disney | `MoreGamesBinding`, `MoreDisneyLogic`, escena `MoreDisney` | escena 4 del build | Se quita la escena del build y su botón. |
| Control parental / enlaces legales | `AgeGatePopup` (5 KB), `Application.OpenURL` a disney.com, términos, privacidad y soporte | `Age Gate Popup.prefab`, dentro de `SettingsMenu.prefab` | Se quitan el gate y los enlaces (solo protegían compras y enlaces externos). |
| Notificaciones iOS | `NotificationServices.ScheduleLocalNotification/CancelAll…`, `LocalNotification` | — | Nada (en Android se valorará aparte). |
| APIs exclusivas de iOS/web | `iPhone.generation` (calidad por modelo de iPhone), `Application.ExternalCall` (web player), `Email` | — | Calidad fija para PC (ADAPTADO-U6). `ExternalCall`/`Email`: ELIMINADO. |
| Contenido remoto muerto | `http://datg-apps.com/ss/pranksgiving.txt`, `PartCosts.epa.xml` (`LoadPartCosts`, `LoadWebConfig`), URL de idioma localizado | — | Valores locales. Pranksgiving pasa a un interruptor local (decisión D2, §11.8). Costes de piezas: se buscarán primero en los datos serializados de cada pieza; si no están, se documentará el valor usado. Idioma: los ficheros locales `Localize-Default` y `Localize-SW`. |

**Se conserva** (no son servicios): la inclinación y el táctil (`PlayerAccelControl`, `TouchTurnTrack`), necesarios para Android; `Screen Timeout Controller` (API multiplataforma); el bono diario (`DailyBonusPublisher`, reloj local); el popup de confirmación de compra con monedas (`ConfirmationPublisher`).

**Cómo se elimina** (sin dejar "Missing Script"): una herramienta de editor quita los componentes y prefabs de servicio de escenas, prefabs y de la lista `EnsureGlobals.globalsList`, y oculta los botones asociados. Genera un informe de cada objeto tocado. En el código recuperado, cada llamada a un servicio se sustituye por nada o por el equivalente local, con un comentario `// ELIMINADO (servicio iOS): <qué hacía>`.

### 11.3 El trabajo extra que exige Unity 6.6
Todo verificado contra los DLL de tu instalación (`6000.6.3f1\Editor\Data\Managed\UnityEngine`):

| # | Tema | Unity 4.3 (original) | Unity 6.6 | Solución | Etiqueta |
|---|---|---|---|---|---|
| 1 | Pipeline de render | Built-in | Built-in **deprecado desde 6.5**, pero soportado todo el ciclo de 6.7 LTS ([docs](https://docs.unity3d.com/6000.6/Documentation/Manual/render-pipelines.html), [estrategia 2026](https://unity.com/topics/render-pipelines-strategy-for-2026)) | **Built-in para la reconstrucción** (máxima fidelidad, sin reescribir shaders ni cámaras). Migrar a URP es una fase aparte y opcional, después (§11.7). | ADAPTADO-U6 |
| 2 | Espacio de color | Gamma | Gamma disponible | Mantener Gamma (en Linear cambiarían todos los colores). | RECUPERADO |
| 3 | Shaders built-in (16) | `Mobile/*`, `Particles/*`, `Transparent/*`, `Unlit/*`, `Self-Illumin/*` | Muchos se renombraron a `Legacy Shaders/...` | AssetRipper exportó copias *dummy*. Remapeo de materiales a los shaders built-in reales de Unity 6 por nombre. | ADAPTADO-U6 |
| 4 | Shaders custom (4) | 3 fixed-function + 1 GLSL | Fixed-function sigue funcionando en Built-in | Los 3 fixed-function se copian **literalmente** del texto original. `Unlit Under The Sea` se porta de GLSL a CG con la misma matemática. | RECUPERADO / ADAPTADO-U6 |
| 5 | **Partículas legacy (91 sistemas)** | `EllipsoidParticleEmitter + ParticleAnimator + ParticleRenderer` | **No existen** | Conversor en dos pasos: (a) un script Python extrae sus parámetros del YAML del export **antes** de que Unity los descarte al importar (emisión, energía→vida, tamaño, velocidades, color animado, crecimiento, amortiguación, material y modo del renderer); (b) una herramienta de editor crea un `ParticleSystem` equivalente. El código que las usaba (`particleEmitter.emit`, etc.) pasa a la API de ParticleSystem. | ADAPTADO-U6 |
| 6 | **Lightmaps** (pistas: cientos de renderers con lightmap) | Lista de lightmaps en la escena + índice/offset en cada renderer (Beast, codificación dLDR móvil) | Unity 5+ ignora ese formato al cargar | Componente `LegacyLightmapRestorer` por escena, con las texturas y el índice/offset de cada renderer extraídos del YAML, que se aplica en `Awake`. Codificación de lightmaps en Low Quality (dLDR) para decodificar igual que el original. | ADAPTADO-U6 |
| 7 | Light probes | Formato Unity 4 | No compatible | Evaluar el impacto en la iluminación de personajes; si hace falta, re-hornearlas con las luces originales de la escena. | RECONSTRUIDO (si aplica) |
| 8 | Input | Input Manager clásico: ejes, `GetKey`, `touches`, `acceleration` | Existe (`InputLegacyModule`) | *Active Input Handling* = **Both**: el código original funciona tal cual y el Input System nuevo queda disponible para mando/Android. Control PC = `PlayerKeyboardControl` **original**. | RECUPERADO |
| 9 | Carga de escenas | `Application.LoadLevel/LoadLevelAsync/loadedLevelName`, `OnLevelWasLoaded` | Obsoletos | `SceneManager.*` y `sceneLoaded`. Mismo orden de escenas (el código puede usar índices). | ADAPTADO-U6 |
| 10 | Streaming de assets | `WWW`/AssetBundle y `Resources.Load` | `WWW` obsoleto | Solo se usa la ruta `RESOURCE` (§7.3). La rama ASSET_BUNDLE se conserva vía `UnityWebRequestAssetBundle`, marcada como sin uso. | ADAPTADO-U6 |
| 11 | Componentes obsoletos en YAML | `GUILayer` en cámaras | Solo stub obsoleto | Se retira del YAML (no se usaban `GUIText`/`GUITexture`). `Halo` sigue existiendo. | ADAPTADO-U6 |
| 12 | Animación legacy (235 `Animation`, 231 clips) | `Animation` | Existe | Verificar que los clips importan como `m_Legacy: 1`. | RECUPERADO |
| 13 | TextMesh (488) + fuentes | `TextMesh` | Existe | Sin cambios; verificar el render de fuentes. | RECUPERADO |
| 14 | Física | PhysX 2.8 | PhysX moderno | Se mantienen capas originales (`Ground` 8, `Cars` 9, `Collide` 10, `LOS Blocking` 11, `GUI` 20, `TV Screen Fuzz` 21), `RaycastsHitTriggers=1`, timestep 0,0167 y gravedad. `CarCollider` integra su propio movimiento, así que el riesgo se concentra en raycasts, triggers y colisiones → validación dirigida en la Etapa 3. | RECUPERADO / riesgo |
| 15 | Scripting | Mono 2.x, C# 3 | C# 9, .NET Standard 2.1 | Las corutinas generadas por el compilador (`<X>c__IteratorN`) se reescriben como métodos `yield`; los `AnonStorey` como lambdas. | ADAPTADO-U6 |
| 16 | Calidad | `QualityControl` por `iPhone.generation` | No existe | Nivel fijo en PC (el más alto que usaba el original). | ADAPTADO-U6 |
| 17 | Pantalla | Landscape iPhone/iPad | PC 16:9 y otras | La UI `Ugh*` ancla con `UghAlign`/`UghStretch`; verificar en 16:9 y 16:10. | RECUPERADO / riesgo |
| 18 | Backend | Mono Full-AOT (ARMv7) | Mono x64 (PC); IL2CPP ARM64 (Android) | Desarrollo en Mono. IL2CPP solo en el port Android. | — |

### 11.4 Estructura del proyecto y del código
```
game work/
├── phase1_analysis/ … phase4_reconstruction/   ← ORIGINAL + intento previo (solo lectura)
├── forensics/
│   ├── scripts/            ← análisis y herramienta aotlift (anotador ARM)
│   └── output/
├── recovery/
│   ├── DSSRacer_U6/        ← PROYECTO UNITY 6.6 (copia nueva del export de AssetRipper)
│   │   └── Assets/
│   │       ├── (assets exportados: misma estructura, mismos GUID)
│   │       ├── Scripts/Assembly-CSharp/<Sistema>/*.cs     ← clases originales ordenadas por sistema
│   │       ├── Plugins/Assembly-CSharp-firstpass/…         ← Ugh*, Localize, utilidades (sin servicios iOS)
│   │       └── _Recovery/
│   │           ├── Runtime/    ← capa de compatibilidad (LegacyLightmapRestorer, SaveBackend local, RecoveryPending)
│   │           └── Editor/     ← conversor de partículas, remapeo de shaders, limpieza de servicios, validadores
│   └── aot_listings/       ← listados ARM anotados por clase (generados, fuente de la traducción)
├── RECOVERY_REPORT.md
└── RECOVERY_PROGRESS.md    ← se crea en la Etapa 0
```
Reglas:
- **Se conservan los nombres de clase y los GUID** de cada `.cs` (se mueve el `.meta` con el archivo) para que escenas y prefabs sigan enlazados.
- La organización modular se consigue con carpetas por sistema (`Core/`, `FrontEnd/`, `Race/`, `Vehicle/`, `Track/`, `AI/`, `Camera/`, `UI/`, `Audio/`, `Save/`, `Pickups/`). **No se renombran clases.** Solo el código nuevo (compatibilidad) vive en `_Recovery/`.
- Se mantienen las dos assemblies originales (firstpass en `Plugins/`, el resto en `Assembly-CSharp`) para no alterar el orden de compilación ni las dependencias.
- **Métodos pendientes**: todo método aún no traducido llama a `RecoveryPending.Hit("Clase.Método")`, que registra un aviso la primera vez que se ejecuta. Así, al correr el juego, el log dice **qué método hace falta traducir a continuación**. Es la base del ciclo incremental, y evita que un stub silencioso esconda un fallo (el problema del intento anterior).

### 11.5 Pipeline RECUPERADO-AOT (herramienta `aotlift`)
1. Desensamblar el rango ARM de cada método con **capstone**.
2. Anotar cada instrucción con:
   - llamadas PLT → `Clase::Método` (ya funciona);
   - GOT → literales (ya funciona), clases, vtables y campos estáticos (decodificación a completar);
   - offsets de campo → nombre del campo, calculados desde la metadata con las reglas de layout de Mono y verificados con los getters/setters triviales;
   - llamadas virtuales (slot de vtable → método) y constantes float de los literal pools;
   - regiones try/finally (`ex_info`).
3. Emitir `recovery/aot_listings/<Clase>.txt` con un bloque por método.
4. Traducir a C# respetando la firma original. Se versionan juntos el listado y el C# resultante, para poder revisarlos.
5. Validar con "oráculos" de datos originales siempre que existan. Ejemplos:
   - el cálculo de `distanceToNext`/`totalTrackDistance` en `WaypointLogic` debe reproducir los valores serializados en cada pista;
   - la compresión de rutas de `CarAIPathRecorder` debe reproducir las rutas guardadas;
   - las curvas de `FollowCamera` ya están en la escena.

### 11.6 Plan por etapas (Fase 4) y criterios de éxito
Volumen de ARM **estimado** por etapa (clases principales; se traduce bajo demanda, método a método, según lo que pida `RecoveryPending`):

| Etapa | Objetivo | Clases originales principales | ARM aprox. | Tests |
|---|---|---|---:|---|
| **0 — Preparación** | Proyecto Unity 6.6 abre y compila sin errores, sin scripts perdidos ni materiales rosas; servicios iOS retirados; partículas y lightmaps convertidos | Herramientas (`aotlift`, conversores, validadores); ninguna lógica de juego | — | abre, compila, 0 missing, 0 shader de error |
| **1 — Boot → Menú** | CloudStrap → PreFrontEnd → FrontEndTest con menú Play navegable | `SingletonScript`, `EnsureGlobals`, `CloudStrap`, `PreFrontEndHoop`, `ScreenFader`, `FadeHelper`, núcleo `Ugh*` (Sprite, Text, Button, Align, Stretch, Camera, Input, Publisher), `Localize`, `Messenger`, `DataUtility` (carga/guardado local), `FrontEndLogic`, `FrontEndCamera`, `ShiftUIPublisher`, `PlayMenuPublisher` | ~175 | TEST 1, 2 |
| **2 — Menú → carrera** | Elegir circuito, pista y personaje; carga `Loading` → escena de pista | `SelectCircuitPublisher`, `TrackSelectPublisher`, `CharacterSelectPublisher`, `CharacterPreview`, `PreviewCart`, `CartPartList`, `CartSlot`, `PlayerInstance`, `RaceSettings`, `StreamManager` (RESOURCE), `LoadingPublisher`, `TrackUnlockHelper` | ~69 | TEST 3, 4 |
| **3 — Carrera mínima** | Spawn en parrilla → countdown → conducir → checkpoints → vueltas → meta → resultados → reintentar/volver al menú | `RaceManager`, `CarCollider`, `TriFoot`, `SpringConnection`, `CartAttributes`, `PlayerKeyboardControl`, `PlayerControlLinker`, `WaypointLogic`, `SpeedPoint`, `ProgressTriggerLogic`, `ResetTrigger`, `FollowCamera`, `PreRaceCamera`, `HUDLogic`, `PausePublisher`, `RaceResults`, `RaceResultsPublisher` | ~121 | TEST 5–13 |
| **4 — Sistemas completos** | IA (rutas grabadas, estados, personalidades, catch-up), power-ups/efectos, monedas, misiones, logros internos, tutorial, audio completo (música, SFX, voces), guardado/progresión (desbloqueo de dificultades), customizador y pinturas, bono diario, Pranksgiving, modo Elimination, rewind | resto | ~540 (incluye utilidades que quizá no hagan falta) | TEST 14–16 |

Cada sistema sigue el ciclo: traducir → compilar → ejecutar → leer el log de `RecoveryPending` y la consola → corregir → documentar en `RECOVERY_PROGRESS.md` → **commit**.

### 11.7 Después de la Fase 4 (no entra ahora)
- **Port a Android**:
  - instalar el módulo Android Build Support (OpenJDK, SDK, NDK) desde Unity Hub; el SDK del intento previo no se reutiliza;
  - IL2CPP ARM64;
  - reactivar el input original de inclinación y táctil (`PlayerAccelControl`, `TouchTurnTrack`);
  - safe area, resolución y rendimiento.
- **Migración a URP (opcional)**: solo cuando el juego funcione en Built-in, porque URP obliga a reescribir shaders (los fixed-function no existen en URP) y a rehacer el apilado de cámaras de la UI `Ugh*`. Conviene hacerla antes de que Unity retire el Built-in (su fecha aún no está decidida).

### 11.8 Riesgos
1. **Volumen**: ~900 KB de ARM a traducir, sin contar servicios. Se mitiga traduciendo bajo demanda y midiendo el avance por clase.
2. **Errores de traducción** en física e IA: se mitigan con oráculos de datos y revisión por método.
3. **Diferencias de Unity 6** (física, partículas convertidas, lightmaps): se validan visualmente y con pruebas por etapa.
4. **Built-in deprecado**: soportado todo el ciclo 6.7 LTS; la migración a URP queda planificada como fase opcional.
5. **Costes de piezas y contenido remoto**: si los valores originales no están en los datos locales, se documenta el valor usado (RECONSTRUIDO).

---

## 12. Cómo arrancamos la Fase 4

### 12.1 Etapa 0, en orden (cada paso con su commit)
1. **Herramienta ARM**: instalar `capstone` (pip, ~5 MB) y construir `forensics/scripts/aotlift`. Primer entregable: listado anotado de una clase pequeña (p. ej. `ProgressTriggerLogic`) y su C# traducido, como prueba de calidad **antes** de escalar.
2. **Inventario para la conversión** (Python, sobre el export, antes de abrir Unity): extraer a JSON los parámetros de las 91 partículas legacy y los datos de lightmaps (texturas + índice/offset por renderer) de las 11 pistas y del resto de escenas.
3. **Crear `recovery/DSSRacer_U6`**: copia nueva del export de AssetRipper (no del `WorkingProject` previo).
   - Retirar del YAML los componentes que Unity 6 no admite (`GUILayer`, legacy particles, ya inventariadas).
   - Colocar los scripts: esqueleto original con cuerpos `RecoveryPending`.
   - Quitar las clases de servicios iOS.
4. **Ajustes del proyecto**:
   - Built-in, Gamma, Input *Both*, Mono x64, lightmaps en Low Quality;
   - capas y tags originales, timestep 0,0167, InputManager original;
   - orden de escenas del build original, sin `MoreDisney`.
5. **Primera apertura en Unity 6.6** (batchmode): importar y compilar hasta 0 errores. Hay que confirmar que Unity Hub tiene la sesión/licencia activa; si no, la tendrás que activar tú.
6. **Herramientas de editor** en `_Recovery/Editor`:
   - remapeo de shaders built-in y restauración de los 4 custom;
   - conversor de partículas;
   - `LegacyLightmapRestorer`;
   - limpieza de servicios (`EnsureGlobals`, `SettingsMenu`, `BuyCoinsPrefab`, `Age Gate`).
7. **Validador**: 0 missing scripts, 0 materiales con shader de error, informe de objetos tocados. Crear `RECOVERY_PROGRESS.md`. **Commit "Etapa 0 completa".**
8. Pasar a la **Etapa 1**: ejecutar `CloudStrap` en el editor, leer qué métodos pide `RecoveryPending` y empezar a traducirlos.

### 12.2 Decisiones pendientes para arrancar
| # | Decisión | Mi recomendación |
|---|---|---|
| D1 | Instalar `capstone` (pip, ~5 MB). Es imprescindible para la ruta C. | Sí |
| D2 | Pranksgiving (antes activada por URL remota) | Interruptor local **activado por defecto**, para que el contenido sea jugable (desviación documentada) |
| D3 | Enlaces legales y web de Disney en Ajustes | Eliminarlos junto con el Age Gate |
| D4 | `UnityPy` (pip, ~10 MB) para leer datos crudos que AssetRipper no pudo (8 `MultilayerTextureBundleDef`) | Sí, cuando lleguemos al customizador (Etapa 4) |
| D5 | Identidad git `STEEP <vidalesnaifer9@gmail.com>` | Mantener, salvo que prefieras otra |

---

## Anexo — Reproducibilidad
Scripts en `forensics/scripts/` (Python 3, sin dependencias externas):
`hdr.py` (versiones/integridad), `climeta.py` (lector de metadata .NET), `macho.py` (Mach-O), `aotglobals.py`/`aotinspect.py` (tablas AOT), `mapcheck.py` (mapeo método→ARM), `blscan.py` (destinos de BL), `aotdec.py` (PLT→nombres), `gotdec.py` (GOT/literales), `usheap.py` (literales), `scene.py`/`fields.py`/`tracks.py` (escenas YAML), `classsize.py` (volumen por clase).
Salidas en `forensics/output/`. Nota: `macho.pkl`/`aotmods.pkl`/`methodmap.pkl` se regeneran ejecutando `macho.py → aotglobals.py → mapcheck.py` en ese orden.
