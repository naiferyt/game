# GAME RECOVERY REPORT — Disney Super Speedway (DSSRacer) v1.3

Fecha: 2026-09-26 · Alcance: Fase 0 (herramientas), Fase 1 (diagnóstico forense), Fase 3 (propuesta de estrategia).
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
| Estrategia recomendada | **C) Híbrido**: proyecto desde el export de AssetRipper (escenas/prefabs/datos originales) + esqueleto C# con nombres/campos exactos + **cuerpos recuperados traduciendo el ARM AOT método a método**. Reconstrucción razonada solo donde el ARM no sirva (servicios iOS muertos). | — |

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
| Unity Hub | ✅ instalado | **Ningún editor instalado** (`unity editors`: 0 instalados). El Unity 6000.5.3f1 que usó el intento previo ya no está. |
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
| Servicios iOS: StoreKit, Game Center, iCloud, Burstly (ads), DMO/Tapalytics, MoreGames, GravCloud | **HAY QUE RECONSTRUIR** como stubs locales (servicios muertos / no portables) |
| Contenido remoto: `datg-apps.com/ss/pranksgiving.txt`, `PartCosts.epa.xml`, URLs de idioma | **NO EXISTE** (servidores muertos) → valor por defecto local |
| `Assembly-CSharp-Editor.dll` | **NO EXISTE** (editor-only; no afecta runtime) |
| `Data/Raw/IOSBundles/*.unity3d` | **NO EXISTE**, pero ver 7.3 |
| `Assembly-UnityScript` (`Car_Script`, `Plane_Script`) | Existe; **0 referencias** en escenas/prefabs → restos sin uso |

### 7.2 Compatibilidad de componentes
- **91 sistemas de partículas legacy** (`EllipsoidParticleEmitter + ParticleAnimator + ParticleRenderer`) + 64 Shuriken. Las legacy **desaparecen en Unity ≥ 2018.3** (el intento previo a Unity 6 las perdió o sustituyó).
- Animación legacy, TextMesh, Input Manager clásico, `WWW`, `Application.LoadLevel`, `OnLevelWasLoaded`: soportados sin cambios hasta Unity 2017.4.

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
| Tienda / IAP / ads / GameCenter / analytics | Prime31 StoreKit/GameCenter/iCloud, Burstly, DMO | — | — | **BAJO** (irrecuperable como servicio → stub) |
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
MoreDisney ─ promo (stub)
```
El orden exacto de las corrutinas es **MEDIO** (deducido de nombres/literales); se fijará al leer el ARM de `RaceManager`.

---

## 11. FASE 3 — Estrategia propuesta

### A) Reabrir/reparar el proyecto original — **descartada**
No hay proyecto original: faltan fuentes C#, scripts de editor y ajustes originales. El único "proyecto" existente es el `WorkingProject` del intento previo, que es un cascarón con métodos vacíos y una clase inventada.

### B) Proyecto nuevo con AssetRipper y lógica reescrita desde cero — **descartada como ruta principal**
Funcionaría, pero reescribir `CarCollider`, IA, RaceManager, etc. "a ojo" violaría RECOVER > INVENT **teniendo el código original compilado a mano**. La física arcade (24 KB de ARM) no se puede adivinar con fidelidad.

### C) Híbrido — **RECOMENDADA**
1. **Proyecto base**: copia nueva del export de AssetRipper (`phase2_extraction/.../ExportedProject`) en `recovery/UnityProject/` → escenas, prefabs, GUIDs y datos serializados originales intactos. El original y los exports no se tocan.
2. **Scripts**: partir del esqueleto ILSpy (nombres, campos, atributos, constantes exactos ⇒ la serialización de escenas/prefabs encaja sin tocar YAML).
3. **Cuerpos de método — RECUPERADO-AOT**: herramienta `forensics/aotlift` que, por cada método, emite un listado ARM anotado (llamadas PLT con nombre, literales, clases/campos estáticos, offsets de campo → nombre de campo, constantes float). Traduzco a C# **sistema por sistema**, con cabecera `// RECUPERADO-AOT token 0x06xxxxxx @0x....` en cada método.
4. **RECONSTRUIDO** solo para: servicios iOS muertos (stubs locales: StoreKit/GameCenter/iCloud→PlayerPrefs, ads/analytics→no-op), URLs remotas (valores por defecto), shaders built-in (sustitución por el original de Unity), y lo que el ARM no permita recuperar (se documentará caso a caso).
5. **Orden de trabajo** (ciclo implementar→compilar→ejecutar→diagnosticar→documentar→commit por sistema):
   - **Etapa 1 — Boot→Menú**: `SingletonScript`, `EnsureGlobals`, `CloudStrap` (iCloud stub), `PreFrontEndHoop`, `ScreenFader`/`FadeHelper`, núcleo `Ugh*` necesario para pintar y pulsar, `Localize`, `DataUtility.Load` (local), `FrontEndLogic` + menú Play.
   - **Etapa 2 — Menú→carga de carrera**: Track/Circuit/Character select mínimos, `RaceSettings`, `StreamManager` (RESOURCE), `LoadingPublisher`.
   - **Etapa 3 — Carrera mínima**: `RaceManager`, `PlayerInstance`+construcción de kart, `CarCollider`+`TriFoot`+`SpringConnection`, `PlayerKeyboardControl`, `WaypointLogic`/`SpeedPoint`/`ProgressTriggerLogic`/`ResetTrigger`, `FollowCamera`/`PreRaceCamera`, `HUDLogic`, `RaceResults*` → vuelta al menú.
   - **Etapa 4**: IA completa, power-ups/efectos, monedas, misiones/logros, audio completo, guardado/progresión, customizador, Pranksgiving.

### Versión de Unity
| Opción | Pros | Contras |
|---|---|---|
| 4.3.4f1 (original) | API exacta | Editor de 2013; activación de licencia Unity 4 y soporte en Windows 11 inciertos. Riesgo alto. |
| **2017.4.40f1 LTS (recomendada)** | Última LTS que conserva **partículas legacy**, animación legacy, `WWW`, `LoadLevel`, `OnLevelWasLoaded`, runtime .NET 3.5 compatible con el código Unity 4; instalable desde Unity Hub con licencia Personal actual | Editor antiguo (≈2 GB); C# 6 como máximo (suficiente: el original era C# 3) |
| 2022 LTS / Unity 6 | Moderno | Pierde las 91 partículas legacy (habría que re-crearlas → cambio estético), más cambios de API |

Recomiendo 2017.4 para la reconstrucción fiel; un port posterior a una versión moderna sería un paso aparte y opcional.

### Qué necesito instalar (pendiente de tu aprobación)
| Herramienta | Tamaño aprox. | Por qué | Obligatoria |
|---|---|---|---|
| `capstone` (pip) | ~5 MB | Desensamblador ARM para el pipeline de anotación AOT | Sí (ruta C) |
| Unity 2017.4.40f1 (Hub) + Windows Build Support | ~2–3 GB | Abrir, compilar y **ejecutar** el proyecto para probar cada etapa | Sí |
| `UnityPy` (pip) | ~10 MB | Leer objetos crudos de los `.assets` originales (p. ej. los 8 `MultilayerTextureBundleDef` que AssetRipper no pudo leer) sin depender del export | Recomendable |
| Ghidra + JDK | ~700 MB | Descompilación a pseudo-C como apoyo en funciones muy densas (física) | Opcional, no ahora |

### Riesgos
1. **Volumen**: ~1 MB de ARM en total; las etapas 1–3 tocan del orden de 40–60 clases (~250–350 KB). Es trabajo largo, pero acotado y medible por clase.
2. **Errores de traducción** en matemática de física/IA → mitigación: validación en ejecución, comparación con datos serializados (curvas, distancias), revisión por método.
3. **Llamadas virtuales/interfaces y genéricos**: requieren completar la resolución de vtables y del GOT; lo haré dentro de la herramienta antes de la Etapa 3.
4. **Partículas legacy** si se decide una versión de Unity ≥ 2018.3.

---

## 12. Decisiones que necesito de ti antes de la Fase 4
1. ¿Apruebas la **estrategia C** (proyecto desde el export de AssetRipper + lógica recuperada del ARM)?
2. ¿Apruebas instalar **capstone** y **Unity 2017.4.40f1 LTS** (y opcionalmente UnityPy)?
3. Plataforma de prueba: propongo **Windows (editor + standalone)** con el control por teclado original. ¿Android sigue siendo objetivo final?
4. ¿Mantengo la identidad git `STEEP <vidalesnaifer9@gmail.com>` para los commits?

---

## Anexo — Reproducibilidad
Scripts en `forensics/scripts/` (Python 3, sin dependencias externas):
`hdr.py` (versiones/integridad), `climeta.py` (lector de metadata .NET), `macho.py` (Mach-O), `aotglobals.py`/`aotinspect.py` (tablas AOT), `mapcheck.py` (mapeo método→ARM), `blscan.py` (destinos de BL), `aotdec.py` (PLT→nombres), `gotdec.py` (GOT/literales), `usheap.py` (literales), `scene.py`/`fields.py`/`tracks.py` (escenas YAML), `classsize.py` (volumen por clase).
Salidas en `forensics/output/`. Nota: `macho.pkl`/`aotmods.pkl`/`methodmap.pkl` se regeneran ejecutando `macho.py → aotglobals.py → mapcheck.py` en ese orden.
