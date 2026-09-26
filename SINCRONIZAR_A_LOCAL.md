# Sincronizar el trabajo de la nube con tu proyecto local

Este documento lista **todo lo que se crea o modifica en la nube** y explica cómo pasarlo a tu copia local
(`C:\Users\STEEP\Documents\game work`) para probarlo en Unity. Se actualiza al final de cada etapa o bloque de trabajo:
la sección nueva se añade arriba del [registro](#registro-de-cambios-por-etapa) y la tabla de estado se pone al día.

## Estado actual

| | |
|---|---|
| Rama de trabajo en la nube | `claude/optimistic-archimedes-kmux3s` |
| Tu rama local | `main` en `C:\Users\STEEP\Documents\game work` desde la Etapa 2 (la Etapa 1 partió de `mi-proyecto`, commit `a6604d9`) |
| Último bloque sincronizable | **Etapa 3 — bloques 3.6 (resto), 3.7 y 3.8 hechos en la nube** (commits `3caf4f8` … `e56e8c0` + documentación). Los bloques 3.1–3.6 los hiciste en local y subiste hasta `44c3b88` |
| Etapa 2 | hecha directamente en tu copia local, rama `main`: commits `3468d93` … commit "Etapa 2 completa" |
| Etapa 1 | commits `a96ac2b` … `9c02b40` (nube) + validación local `3440f48` |
| Archivos que trae esta sincronización | 12 desde `44c3b88` (9 del proyecto Unity, 3 herramientas) + la documentación y el catálogo; ver el [inventario](#inventario-de-archivos-de-la-etapa-3-nube) |
| Pendiente en tu PC | **traer 3 commits de código + 1 de documentación** con los pasos de la [sección de la Etapa 3](#etapa-3--bloques-36-resto-37-y-38-nube) y hacer las pruebas 3.9 en Unity |

## 1. Antes de empezar

1. **Cierra Unity** (si está abierto con el proyecto, puede reescribir `.meta` o ajustes mientras copias).
2. Abre **Git Bash** (o PowerShell) en la carpeta del repositorio:
   ```bash
   cd "/c/Users/STEEP/Documents/game work"
   git status
   ```
3. Si `git status` muestra cambios tuyos que quieras conservar, guárdalos antes:
   ```bash
   git add -A && git commit -m "Cambios locales antes de sincronizar"
   ```
   Si no los quieres (por ejemplo, archivos que Unity tocó solo al abrir el proyecto), apártalos con `git stash`.
   Las carpetas que genera Unity (`Library/`, `Temp/`, `Logs/`, `UserSettings/`, `obj/`) están en `.gitignore`: no se tocan.

## 2. Traer los cambios (opción recomendada: git)

```bash
git fetch origin
git checkout mi-proyecto
git merge --ff-only origin/claude/optimistic-archimedes-kmux3s
git push origin mi-proyecto        # opcional: deja tu rama igual que la de la nube
```

- `--ff-only` solo avanza tu rama si no hay conflicto posible. Es lo esperado mientras no hagas commits propios en `mi-proyecto`.
- Si falla con *"Not possible to fast-forward"* es que tienes commits locales nuevos: usa `git merge origin/claude/optimistic-archimedes-kmux3s`
  y, si aparece algún conflicto, no lo resuelvas a mano: pásame el mensaje y lo resuelvo yo.

**Sin git (alternativa):** en GitHub abre la rama `claude/optimistic-archimedes-kmux3s` → *Code* → *Download ZIP*, y copia
encima de tu carpeta **solo los archivos del [inventario](#inventario-de-archivos-de-la-etapa-1)** respetando las rutas.
Copia siempre cada `.cs` junto con su `.cs.meta` cuando el inventario los lista a los dos (los `.meta` guardan el GUID que usan escenas y prefabs).

## 3. Comprobar que la copia está completa

```bash
git log -1 --oneline                                              # debe ser el último commit de la nube
git diff --stat origin/claude/optimistic-archimedes-kmux3s        # no debe mostrar nada
git diff --name-only a6604d9 HEAD | wc -l                         # 81 tras la Etapa 1 (79 + este documento + sync_manifest.py)
```

Comprobación rápida a mano: `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/FrontEndLogic.cs` debe empezar con el comentario
`// Garage / front-end controller…` y contener líneas `// RECUPERADO-AOT`.

## 4. Probar en Unity

1. Abre el proyecto con **`recovery/AbrirUnity.bat`** (fija los ajustes de .NET que necesita tu PC). La primera vez reimporta los scripts.
2. En la **Console** no debe haber errores de compilación (`error CS…`). Si hay alguno, cópiamelo tal cual.
3. Prueba desatendida del arranque (desde Git Bash, con Unity **cerrado**):
   ```bash
   bash forensics/scripts/run_play.sh "Assets/Scenes/CloudStrap.unity" 15 boot
   ```
   Genera `recovery/logs/playrun_boot.log`, `recovery/logs/unity_play_boot.log` y capturas en `recovery/logs/screens/`.
   También puedes probar a mano: abre `Assets/Scenes/CloudStrap.unity` y pulsa Play.
4. Resultado esperado de la Etapa 1: logo → garaje con el menú Play (Play / Settings / Info); Settings abre volumen, créditos y
   "borrar datos"; Play mueve la palanca y pide el menú "Circuit Select" (su contenido es de la Etapa 2). Sin kart, música ni efectos.
   Avisos `[RecoveryPending]` de sistemas de etapas posteriores y **una** `NullReferenceException` en `ShiftUIPublisher.Start`
   son esperados (explicados en `RECOVERY_PROGRESS.md`, *KNOWN ISSUES*).

## 5. Devolverme los resultados

Para que yo pueda leer los resultados desde la nube, súbelos a tu rama:

```bash
git add -f recovery/logs/playrun_boot.log recovery/logs/unity_play_boot.log recovery/logs/screens
git commit -m "Resultados de la prueba de arranque (Etapa 1)"
git push origin mi-proyecto
```

y dime "ya subí los logs". Si prefieres, pega en el chat el contenido de `playrun_boot.log` y los errores de la Console.

## Registro de cambios por etapa

### Etapa 3 — bloques 3.6 (resto), 3.7 y 3.8 (nube)

Continúa donde lo dejó tu sesión local (`44c3b88`, "Stage 3.6: HUD logic and publishers prep"). Solo cambian **scripts**:
no se tocan escenas, prefabs ni materiales.

Qué cambió (detalle en `RECOVERY_PROGRESS.md`, sección *Etapa 3*):
- **3.6 HUD (resto)**: `DriftScalePublisher` (medidor de derrape y aviso de power-slide) y `BlipTrackPublisher` (mapa lateral de posiciones).
- **3.7 Pausa, resultados y resumen**:
  - `PausePublisher`: continuar, reiniciar y salir; lista de misiones o logo de tutorial.
  - `PlaySummaryPublisher`: modo y dificultad antes de correr.
  - `FrontEndTutorialHandler.ActiveTutorial`.
  - `RaceResultsPublisher`: clasificación con tiempos e iconos, recuento animado de monedas, Done / Retry / Rewind, récord "Highest Place".
- **3.8**: rebobinado de la última vuelta (`RaceManager.RecordSnapshot`/`RaceRewind`, `CarSnapShot`, `SnapShotInfo`).
  `HUDLogic.SignalMissionStart/Complete` quedan para la Etapa 4, como decidiste.
- **Herramientas**: `compile_check.sh` ignora ahora los errores de APIs que solo existen en Unity 6 (`u6_only_errors.txt`), para
  que la comprobación con el `UnityEngine.dll` 4.3 siga sirviendo con tu código de 3.1–3.6.

Traer los cambios a tu PC (Unity cerrado; en tu copia trabajas en `main`):
```bash
cd "/c/Users/STEEP/Documents/game work"
git status                                   # sin cambios pendientes (si los hay: commit o git stash)
git fetch origin
git checkout main
git merge --ff-only origin/claude/optimistic-archimedes-kmux3s
git log -1 --oneline                         # debe ser el último commit de la nube
git diff --stat origin/claude/optimistic-archimedes-kmux3s   # no debe mostrar nada
```

Pruebas en Unity (bloque 3.9, lista completa en `RECOVERY_PROGRESS.md`):
1. Abre el proyecto con `recovery/AbrirUnity.bat`: la Console no debe mostrar `error CS…`.
2. Carrera directa (Unity cerrado, desde Git Bash), acelerando con W entre los segundos 12 y 40:
   ```bash
   bash forensics/scripts/run_play.sh "Assets/Scenes/Tracks/Kick Butt Track 1.unity" 45 s3race "key:W@12-40" "10,20,30,44"
   ```
3. A mano, en el editor: abre `Kick Butt Track 1` y pulsa Play. Completa la carrera y comprueba:
   - **Pausa** (Escape): continuar, reiniciar y salir.
   - **Resultados**: las filas aparecen una a una, suben las monedas y funcionan **Retry** y **Done** (vuelve al garaje).
4. Esperado en el log: avisos `[RecoveryPending]` de sistemas de la Etapa 4 (IA, power-ups, misiones, `RewindDialogPublisher` si pulsas Rewind).
   No son errores. Cualquier `Exception` sí lo es: pásamela.

Devolver resultados: `git add -f recovery/logs/playrun_s3race.log recovery/logs/unity_play_s3race.log recovery/logs/screens`,
commit y `git push origin main:claude/optimistic-archimedes-kmux3s` (o pega el log en el chat).

#### Inventario de archivos de la Etapa 3 (nube)

Generado con `python forensics/scripts/sync_manifest.py 44c3b88 e56e8c0`. A estos se suma el commit de documentación
(`RECOVERY_PROGRESS.md`, este documento y `recovery/catalog/METHOD_CATALOG.csv/.md` regenerados).

Rango: `44c3b88..e56e8c0` (12 archivos).

##### Proyecto Unity (necesario para probar en Unity) — 9

| Estado | Archivo |
|---|---|
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/BlipTrackPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CarSnapShot.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/DriftScalePublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/FrontEndTutorialHandler.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/PausePublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/PlaySummaryPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/RaceManager.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/RaceResultsPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/SnapShotInfo.cs` |

##### Herramientas de análisis (no las usa Unity) — 3

| Estado | Archivo |
|---|---|
| nuevo | `forensics/scripts/mcs_check/u6_only_errors.txt` |
| modificado | `forensics/scripts/mcs_check/U6Shim.cs` |
| modificado | `forensics/scripts/mcs_check/compile_check.sh` |

##### Por commit

- **3caf4f8 Stage 3.6: drift meter and position track (DriftScalePublisher, BlipTrackPublisher)** — `U6Shim.cs`, `compile_check.sh`, `u6_only_errors.txt`, `BlipTrackPublisher.cs`, `DriftScalePublisher.cs`
- **a273cf9 Stage 3.7: pause, results and play summary (PausePublisher, RaceResultsPublisher, PlaySummaryPublisher)** — `FrontEndTutorialHandler.cs`, `PausePublisher.cs`, `PlaySummaryPublisher.cs`, `RaceResultsPublisher.cs`
- **e56e8c0 Stage 3.8: last-lap snapshot and race rewind (RaceManager.RecordSnapshot/RaceRewind, CarSnapShot, SnapShotInfo)** — `CarSnapShot.cs`, `RaceManager.cs`, `SnapShotInfo.cs`

### Etapa 2 — Menú → selección → carga de la carrera

**Hecha en tu PC** (sesión local de Claude Code sobre `C:\Users\STEEP\Documents\game work`, rama `main`), así que **no hay nada
que sincronizar**: los archivos ya están en tu carpeta. Si quieres llevarla a la rama de la nube o a GitHub, basta con `git push origin main`.

Qué cambió (detalle completo en `RECOVERY_PROGRESS.md`, sección *Etapa 2*):
- **Código traducido del ARM original** (`RECUPERADO-AOT`): datos del kart (`CartSlot`, `CartPart`, `CartPartList`, `PlayerInstance`…),
  streaming por `Resources` (`StreamManager`), texturas compuestas del kart, vista previa del kart y del personaje en el garaje
  (`PreviewCart`, `CharacterPreview`), menús de circuito/pista/dificultad/personaje, pantalla de carga (`RaceSettings`,
  `LoadingPublisher`, `LoadSpin`), construcción del kart de carrera (`PlayerInstance.ConstructCart`), y adelantados de etapas
  posteriores que este flujo usa (`AnimationDriver`, `AchievementManager`, `CharacterVOController`, `ParticleLibrary`).
- **Archivo nuevo del proyecto Unity**: `_Recovery/Runtime/RecoverySwitches.cs` (+ `.meta`): interruptor local de Pranksgiving
  (`PlayerPrefs` `DSSR_Pranksgiving`, activado por defecto; decisión D2).
- **No se tocaron** escenas, prefabs ni materiales: solo scripts. (Tras jugar en el editor, Unity puede marcar como modificados
  `Fader SpriteAtlas.mat`, `Mobile Cart Part.mat` y `crash_idle.anim`: descártalos con `git checkout -- <archivo>`; ver *KNOWN ISSUES*.)
- **Pruebas**: capturas en `recovery/reports/stage2/`.

Prueba del flujo completo (Unity cerrado, desde Git Bash):
```bash
bash forensics/scripts/run_play.sh "Assets/Scenes/CloudStrap.unity" 45 s2go "0.50,0.18@8;obj:Circuit 1 banner@12;obj:Panel 1 Snapshot@16;obj:Go Button@32" "14,17,20,30,36,44" 400 "obj:LocalPlayer"
```
Resultado esperado: PLAY → el kart sale del garaje → circuitos → pistas → `Loading` → `Kick Butt Track 1` con el kart "LocalPlayer";
tras "Go!" la pantalla queda en negro porque `RaceManager.InitRace` es de la Etapa 3.

#### Inventario de archivos de la Etapa 2

Generado con `python forensics/scripts/sync_manifest.py 9686467e ca1d059f`. A estos se suma el commit "Etapa 2 completa"
(`RECOVERY_PROGRESS.md`, este documento, `recovery/catalog/METHOD_CATALOG.csv/.md` y las 6 capturas de `recovery/reports/stage2/`).

Rango: `9686467e..ca1d059f` (37 archivos).

##### Proyecto Unity (necesario para probar en Unity) — 36

| Estado | Archivo |
|---|---|
| nuevo | `recovery/DSSRacer_U6/Assets/_Recovery/Runtime/RecoverySwitches.cs` |
| nuevo | `recovery/DSSRacer_U6/Assets/_Recovery/Runtime/RecoverySwitches.cs.meta` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/AchievementManager.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/AlternateForm.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/AnimationDriver.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CartAttributes.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CartCustomizerPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CartPart.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CartPartList.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CartPrimaryTextureProfile.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CartSlot.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CharacterButtonPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CharacterConfigData.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CharacterPreview.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CharacterSelectPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CharacterVOController.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CharacterVOControllerGameObjectExtender.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CompositeProfile.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CompositeTextureUtil.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/DifficultyMenuPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/LoadSpin.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/LoadingPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/MultilayerTexture.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/PaintJob.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/ParticleLibrary.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/PlayerInstance.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/PreviewCart.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/RaceManager.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/RaceSettings.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/SelectCircuitPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/SourceFactory.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/StreamManager.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/StreamedMultilayerTexture.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/TrackSelectPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/TrackUnlockHelper.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/UnlockedCircuitPublisher.cs` |

##### Documentación y catálogo — 1

| Estado | Archivo |
|---|---|
| modificado | `RECOVERY_PROGRESS.md` |

##### Por commit

- **3468d938 Stage 2 plan; 2.1 kart data model translated (slots, parts, part list, player instance)** — `RECOVERY_PROGRESS.md`, `AlternateForm.cs`, `CartAttributes.cs`, `CartPart.cs`, `CartPartList.cs`, `CartSlot.cs`, `CharacterConfigData.cs`, `PaintJob.cs`, `PlayerInstance.cs`
- **d25d350a Stage 2.2-2.3: StreamManager (Resources route) and kart texture compositing** — `CartPrimaryTextureProfile.cs`, `CompositeProfile.cs`, `CompositeTextureUtil.cs`, `MultilayerTexture.cs`, `SourceFactory.cs`, `StreamManager.cs`, `StreamedMultilayerTexture.cs`
- **75c1f39c Stage 2.4: garage kart and character preview (PreviewCart, CharacterPreview)** — `CharacterPreview.cs`, `ParticleLibrary.cs`, `PreviewCart.cs`
- **33850f63 Stage 2.5 (part 1): circuit, track and difficulty menus; progression helper** — `DifficultyMenuPublisher.cs`, `SelectCircuitPublisher.cs`, `TrackSelectPublisher.cs`, `TrackUnlockHelper.cs`, `RecoverySwitches.cs`, `RecoverySwitches.cs.meta`
- **453be55f Stage 2.6: race settings, Loading screen and spinner** — `LoadSpin.cs`, `LoadingPublisher.cs`, `RaceSettings.cs`
- **76332c85 Stage 2.4/2.7: race kart construction, AnimationDriver, AchievementManager** — `AchievementManager.cs`, `AnimationDriver.cs`, `PlayerInstance.cs`
- **69b4d481 Stage 2.5/2.7: character select, unlocked-circuit window, voice lines** — `CartCustomizerPublisher.cs`, `CharacterButtonPublisher.cs`, `CharacterSelectPublisher.cs`, `CharacterVOController.cs`, `CharacterVOControllerGameObjectExtender.cs`, `RaceManager.cs`, `UnlockedCircuitPublisher.cs`
- **ca1d059f Stage 2: CharacterSelectPublisher viewingIndex initializer (-1)** — `CharacterSelectPublisher.cs`

### Etapa 1 — Boot → Menú

Qué cambió (detalle completo en `RECOVERY_PROGRESS.md`, sección *Etapa 1*):
- **Código del juego traducido del ARM original** (etiqueta `RECUPERADO-AOT` en cada método): arranque (`CloudStrap`, `EnsureGlobals`,
  singletons), guardado local (`DataUtility` y sus datos), localización, framework de UI Ugh (cámara, sprites, textos, botones, entrada
  con ratón), menús del garaje (`FrontEndLogic`, cámara, fundidos, palanca `ShiftUIPublisher`, menú Play), ajustes, créditos, popups,
  y piezas de cierre (`PreFrontEndHoop`, reposo de pantalla, calidad fija, audio básico, `ExternalPersistentArchive`).
- **Archivos nuevos del proyecto Unity**: `Plugins/_RecoveryRuntime/U4Compat.cs` (compatibilidad Unity 4 → 6) y
  `_Recovery/Runtime/LocalSaveStore.cs` (guardado en `%USERPROFILE%\AppData\LocalLow\…\DSSRacer_save.txt`), cada uno con su `.meta`.
- **Servicios eliminados** en esta etapa: notificaciones iOS, aviso de iTunes, tienda de monedas, Game Center, More Disney, enlaces de
  Disney, analítica, anuncios y la descarga remota de costes de piezas.
- **Herramientas** (no las usa Unity): `forensics/scripts/mcs_check/` (compila el C# sin Unity), `armsym.py`, `method_catalog.py`,
  `sync_manifest.py`.
- **No se tocaron** escenas, prefabs, materiales ni ajustes del proyecto: solo scripts `.cs` (y 2 `.meta` nuevos).

#### Inventario de archivos de la Etapa 1

Generado con `python3 forensics/scripts/sync_manifest.py a6604d9 9c02b40`. A estos se suman el commit de este documento
(`SINCRONIZAR_A_LOCAL.md` y `forensics/scripts/sync_manifest.py`, ambos nuevos).

Rango: `a6604d9..9c02b40` (79 archivos).

#### Proyecto Unity (necesario para probar en Unity) — 72

| Estado | Archivo |
|---|---|
| nuevo | `recovery/DSSRacer_U6/Assets/Plugins/_RecoveryRuntime/U4Compat.cs` |
| nuevo | `recovery/DSSRacer_U6/Assets/Plugins/_RecoveryRuntime/U4Compat.cs.meta` |
| nuevo | `recovery/DSSRacer_U6/Assets/_Recovery/Runtime/LocalSaveStore.cs` |
| nuevo | `recovery/DSSRacer_U6/Assets/_Recovery/Runtime/LocalSaveStore.cs.meta` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/AudioCrumb.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/AudioManager.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/AudioSourcex.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/DictionaryToString.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/EdgePixels.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/ExternalPersistentArchive.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/LanguageAsset.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/Localize.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/LocalizedString.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/Mathfx.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/MiniJSON.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/Rangef.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/ScreenFade.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/Script.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/SingletonScript.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghAlign.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghButton.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghButtonDisablable.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghCamera.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghControl.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghInput.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghSlideToggle.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghSlider.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghSprite.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghSpritePrototype.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghStretch.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghText.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghToggle.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UghTriangle.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Plugins/Assembly-CSharp-firstpass/UnlocalizedString.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/AchievementManager.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/AnimatedTexture.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CameraShake.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CloudSaveData.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CloudStrap.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/ConfirmationPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/CreditsPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/DailyBonusPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/DataUtility.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/EnsureGlobals.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/FadeHelper.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/FrontEndCamera.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/FrontEndCameraTarget.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/FrontEndLogic.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/GenericPopupPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/InputBlocker.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/LifetimeMetrics.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/LiftControlAI.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/LocalOptionsData.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/LocalizeCloudStrap.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/LocalizedAssetSwapper.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/LowEndInhibitor.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/PlayMenuPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/PopoverPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/PreFrontEndHoop.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/QualityControl.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/RaceManager.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/RotatorAI.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/ScreenFader.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/ScreenTimeoutController.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/SettingsMenuPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/ShiftContentsOnButtonDown.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/ShiftContentsOnToggleDown.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/ShiftUIPublisher.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/TrackUnlockHelper.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/UghHeldButton.cs` |
| modificado | `recovery/DSSRacer_U6/Assets/Scripts/Assembly-CSharp/VolumeSlider.cs` |

#### Herramientas de análisis (no las usa Unity) — 4

| Estado | Archivo |
|---|---|
| nuevo | `forensics/scripts/armsym.py` |
| nuevo | `forensics/scripts/mcs_check/U6Shim.cs` |
| nuevo | `forensics/scripts/mcs_check/compile_check.sh` |
| modificado | `forensics/scripts/method_catalog.py` |

#### Documentación y catálogo — 3

| Estado | Archivo |
|---|---|
| modificado | `RECOVERY_PROGRESS.md` |
| modificado | `recovery/catalog/METHOD_CATALOG.csv` |
| modificado | `recovery/catalog/METHOD_CATALOG.md` |

#### Por commit

- **a96ac2b Stage 1: cloud compile check and Unity 4 -> 6 compatibility layer** — `U6Shim.cs`, `compile_check.sh`, `U4Compat.cs`, `U4Compat.cs.meta`
- **a63e8d3 Stage 1: core translated (Script, singletons, EnsureGlobals, save data, Localize)** — `DictionaryToString.cs`, `LanguageAsset.cs`, `Localize.cs`, `LocalizedString.cs`, `MiniJSON.cs`, `Script.cs`, `SingletonScript.cs`, `UnlocalizedString.cs`, `CloudSaveData.cs`, `DataUtility.cs`, `EnsureGlobals.cs`, `LifetimeMetrics.cs`, `LocalOptionsData.cs`, `LocalizedAssetSwapper.cs`, `LocalSaveStore.cs`, `LocalSaveStore.cs.meta`
- **a3eaa66 Stage 1: boot scene translated (CloudStrap -> FrontEndTest)** — `CloudStrap.cs`, `LocalizeCloudStrap.cs`, `RaceManager.cs`, `RotatorAI.cs`
- **a4688d7 Stage 1: Ugh UI rendering translated (camera, sprite meshes, text, align, stretch)** — `EdgePixels.cs`, `UghAlign.cs`, `UghCamera.cs`, `UghSprite.cs`, `UghSpritePrototype.cs`, `UghStretch.cs`, `UghText.cs`, `UghTriangle.cs`
- **0f4f076 Stage 1: Ugh UI input translated (UghInput, buttons, toggles, sliders, UghPublisher)** — `armsym.py`, `Rangef.cs`, `UghButton.cs`, `UghButtonDisablable.cs`, `UghControl.cs`, `UghInput.cs`, `UghPublisher.cs`, `UghSlideToggle.cs`, `UghSlider.cs`, `UghToggle.cs`, `UghHeldButton.cs`
- **62e1fe2 Stage 1: menu layer translated (fades, garage camera, FrontEndLogic, shifter and Play menu)** — `Mathfx.cs`, `ScreenFade.cs`, `U4Compat.cs`, `CameraShake.cs`, `FadeHelper.cs`, `FrontEndCamera.cs`, `FrontEndCameraTarget.cs`, `FrontEndLogic.cs`, `LiftControlAI.cs`, `PlayMenuPublisher.cs`, `ScreenFader.cs`, `ShiftContentsOnButtonDown.cs`, `ShiftContentsOnToggleDown.cs`, `ShiftUIPublisher.cs`
- **b4dd1cc Stage 1: settings, credits and popups translated** — `ConfirmationPublisher.cs`, `CreditsPublisher.cs`, `DailyBonusPublisher.cs`, `GenericPopupPublisher.cs`, `InputBlocker.cs`, `PopoverPublisher.cs`, `SettingsMenuPublisher.cs`, `VolumeSlider.cs`
- **7df6e27 Stage 1: closing pieces (PreFrontEndHoop, sleep timeout, fixed quality, boot plumbing)** — `AchievementManager.cs`, `AnimatedTexture.cs`, `LowEndInhibitor.cs`, `PreFrontEndHoop.cs`, `QualityControl.cs`, `ScreenTimeoutController.cs`, `TrackUnlockHelper.cs`
- **3d2aeb5 Stage 1: ExternalPersistentArchive, audio helpers; catalog counts generated code** — `method_catalog.py`, `AudioCrumb.cs`, `AudioManager.cs`, `AudioSourcex.cs`, `ExternalPersistentArchive.cs`, `SingletonScript.cs`, `METHOD_CATALOG.csv`, `METHOD_CATALOG.md`
- **9c02b40 Stage 1: progress report, catalog and tooling notes** — `RECOVERY_PROGRESS.md`, `armsym.py`, `method_catalog.py`, `METHOD_CATALOG.csv`, `METHOD_CATALOG.md`
