# RECOVERY PROGRESS — Disney Super Speedway (DSSRacer)

Proyecto de trabajo: `recovery/DSSRacer_U6` (Unity 6000.6.3f1, Built-in RP, Gamma, Mono, PC primero).
Estrategia y decisiones: [RECOVERY_REPORT.md](RECOVERY_REPORT.md) §11–§12. Etiquetas: RECUPERADO · RECUPERADO-AOT · ADAPTADO-U6 · RECONSTRUIDO · ELIMINADO.

## Checklist

### Fase 0–3
- [x] Estructura del proyecto analizada · versión Unity (4.3.4f1) · Mono Full-AOT ARMv7
- [x] Escenas, prefabs, assets y datos serializados catalogados
- [x] Estrategia C modificada aprobada (Unity 6.6, sin servicios iOS, PC → Android)

### Etapa 0 — Preparación
- [x] 0.1 `aotlift`: listados ARM anotados de las 666 clases del juego (`recovery/aot_listings/`)
- [x] 0.1 Prueba de calidad: `ProgressTriggerLogic` y `DrawArea3D..ctor` traducidos (RECUPERADO-AOT)
- [x] 0.2a Mallas comprimidas Unity 4 → 365 mallas descomprimidas desde los `.assets` originales (29 personajes con skinning)
- [x] 0.2b Static batching deshecho: 1574 renderers con malla local propia (oráculo 273/280 vs colliders originales)
- [x] 0.2c Matriz de colisión de capas original (0xFFFFFFFF ×32)
- [x] 0.3 Inventario JSON de 91 partículas legacy y 1579 renderers con lightmap; componentes Unity 4 retirados del YAML
- [x] 0.4 Esqueleto compilable: 2235 métodos con `RecoveryPending.Hit`, 42 scripts de servicios iOS eliminados
- [x] 0.4b Servicios retirados de los assets sin scripts perdidos (prefabs, EnsureGlobals, botones desactivados, MoreDisney fuera del build)
- [x] 0.5 Primera importación completa en Unity 6.6: **0 errores**
- [x] 0.6 Herramientas de editor ejecutadas: ajustes (Gamma, Input Manager, Mono, lightmaps dLDR, física original), 214 materiales → shaders built-in de Unity 6 (0 faltantes), **91/91** partículas convertidas, lightmaps restaurados en **12/12** escenas (1579 renderers)
- [x] 0.7 Validadores (`recovery/reports/stage0/stage0_validation.log`):
  - 0 scripts perdidos · 0 materiales con shader erróneo · 0 personajes con skinning dañado
  - 28 renderers / 13 colliders con malla nula: **todos nulos ya en el build original** (verificado con UnityPy) salvo los 7 subconjuntos vacíos del batching (tampoco dibujaban)
  - Suelo bajo **1717/1730** waypoints y posiciones de salida; los 13 restantes son **saltos** (la IA original los grabó con `inAir`)
  - Capturas de las 16 escenas: `recovery/reports/stage0/screens/`
- [x] **Etapa 0 completa**

### Etapa 1 — Boot → Menú ✅ (traducida y validada en Unity 6.6 local, 2026-09-26)
- [x] 1.1 Banco de pruebas: `PlayModeRunner` (Play Mode desatendido con log de `RecoveryPending`, errores, cambios de escena, capturas y clics simulados vía `RecoveryTestInput`) · comprobación de compilación sin abrir Unity: `forensics/scripts/compile_check.py`, con Roslyn contra los ensamblados de Unity 6.6 del PC. En la nube el mismo script usa Roslyn y las referencias de Unity 2021.3.33 de NuGet, preparadas por `cloud_refs.sh` (Unity no se puede descargar desde la nube). El antiguo `mcs_check`, contra el `UnityEngine.dll` de Unity 4.3, se retiró el 2026-09-27.
- [x] 1.2 Núcleo: `Script`, `SingletonScript<T>`, `EnsureGlobals`, `DataUtility` + `CloudSaveData`/`LocalOptionsData`/`LifetimeMetrics` con guardado local (`LocalSaveStore`, mismas claves y codificación que JCloud), `Localize`/`MiniJSON`/`DictionaryToString`/`LocalizedString`
- [x] 1.3 Arranque: `CloudStrap` → `FrontEndTest` (`SceneManager`), `LocalizeCloudStrap`, `RotatorAI`, puente `OnLevelWasLoaded` (U4Compat)
- [x] 1.4 UI visible: `UghCamera`, `UghSprite`/`UghSpritePrototype` (mallas nine-slice), `UghText`, `UghAlign`, `UghStretch`
- [x] 1.5 UI que responde: `UghInput` (ratón = dedo 0), `UghControl`, `UghButton(Disablable)`, `UghToggle`, `UghSlider`, `UghSlideToggle`, `UghHeldButton`, `UghPublisher`
- [x] 1.6 Menú: `FrontEndLogic` (menús, transiciones, bono diario con reloj local), `FrontEndCamera(Target)`, `FadeHelper`, `ScreenFade`, `ScreenFader`, `Mathfx`, `ShiftUIPublisher`, `PlayMenuPublisher`, `ShiftContentsOn*Down`, `CameraShake`, `LiftControlAI`
- [x] 1.7 Ajustes y créditos: `SettingsMenuPublisher`, `VolumeSlider`, `CreditsPublisher`, `ConfirmationPublisher`, `InputBlocker`, `DailyBonusPublisher`, `GenericPopupPublisher`, `PopoverPublisher` (botones de servicios eliminados ocultos)
- [x] 1.8 Cierre: `PreFrontEndHoop`, `ScreenTimeoutController`, `QualityControl`, `LowEndInhibitor` (calidad fija PC), `AnimatedTexture`, `ExternalPersistentArchive`, `AudioManager`/`AudioCrumb`/`AudioSourcex`; fontanería mínima de etapas posteriores que el arranque lee (`AchievementManager.Instance/Awake/Start/AllAchievements`, accesores de `TrackUnlockHelper`)
- [x] 1.9 **Validación en Unity 6.6 (PC local)** con `PlayModeRunner` y clics simulados por nombre de objeto:
  - Arranque: `CloudStrap` → `FrontEndTest` en ~1,3 s; guardado local operativo (idioma, claves, métricas; "Times Loaded" incrementa).
  - Menú principal visible: logo, PLAY, engranaje (captura `recovery/reports/stage1/`).
  - **Ajustes**: la cámara va al monitor, aparece la palanca original (trofeo, personalización, bandera, personaje, ajustes) y el panel SETTINGS con volumen de música y efectos, "Reset Data" y "Credits". **Créditos**: pantalla original completa (Gravity/Graveck, v1.3.0).
  - **PLAY**: retira el menú, guarda y mueve la cámara (el monitor pasa al mapa). El menú "Circuit Select" no llega a mostrarse porque el flujo original espera a `PreviewCart.StartDriveout` (salida del kart del garaje, **Etapa 2**).
  - Errores: solo la `NullReferenceException` conocida de `ShiftUIPublisher.Start` y el ruido interno del editor (`SearchDatabase`).
  - Corrección aplicada: `Main Body` de `SettingsMenu` venía inactivo y lo activaba el Age Gate al acertar (`AgeGatePopup.TestAnswer` → `enabler.SetActive(true)`); con el gate ELIMINADO se aplica ese resultado en el prefab (sin él, Ajustes se abría vacío).
  - Banco de pruebas: la pantalla virtual en batch mide 640×480; los clics por coordenadas fallaban en elementos anclados a esquinas → nuevos clics `obj:<nombre>` y volcado de estado `-runDump` (campos por reflexión y renderers de un objeto).

Resultado esperado de la validación: logo → garaje con el menú Play (Play / Settings / Info); Settings abre ajustes (volumen, créditos, borrar datos); Play gira la palanca y pide el menú "Circuit Select" (su contenido es de la Etapa 2). Sin kart, sin música ni efectos (Etapa 2/4). Solo avisos `[RecoveryPending]` de sistemas de etapas posteriores, más la excepción conocida de `ShiftUIPublisher.Start` (ver KNOWN ISSUES).

Métodos de etapas posteriores que el arranque llama y siguen pendientes (devuelven valores por defecto sin romper nada): `PlayerInstance.Bootstrap/GetCartSlot`, `PreviewCart.GenerateCartPreview/StartDriveout/IsLoading`, `CharacterPreview.Refresh`, `StreamManager.Cleanup/PrependRootFileLocation`, `AchievementManager.InitFrontEndAchievements`, `MusicPlayer.Instance/PlayMusic/UpdateVolume`, `SoundLibrary.ButtonClickPlay/PlayRandomWhoosh`, `TrackUnlockHelper.IsCircuitUnlocked/RelockEverything/UnlockAllEverything`, `CartCustomizerPublisher.Refresh`, `BaseEffect.InitComboLookup`; y los `Awake/Start/Update` de los globales `CartPartList`, `SoundLibrary`, `MusicPlayer`, `StreamManager`, `PlayerInstance`, `ParticleLibrary`, `CartPrimaryTextureProfile`, `TrackUnlockHelper`.

Herramientas nuevas: `forensics/scripts/armsym.py` (evaluador simbólico de código ARM de coma flotante), `U4Compat` (`FindObjectOfType(s)`, `WebRequest`, puente `OnLevelWasLoaded`), `LocalSaveStore`.

### Etapa 2 — Menú → selección → carga de la carrera ✅ (traducida y validada en Unity 6.6 local, 2026-09-26)
Objetivo: desde el garaje, **PLAY → circuito → pista → `Loading` → escena de pista cargada** con el kart del jugador
construido; y **personaje** elegible en el menú CharacterSelect, con el kart y el personaje visibles en el garaje.
Volumen inicial: 476 métodos pendientes, ~123 KB de ARM. Resultado: **494 recuperados, 0 pendientes** en la Etapa 2
([catálogo](recovery/catalog/METHOD_CATALOG.md#etapa-2--menú--selección--carga-de-la-carrera)).

- [x] 2.1 **Datos del kart**: `CartSlot`, `CartPart`, `AlternateForm`, `PaintJob`, `CartAttributes`, `CartPartList` (`LoadPartCosts` lee **solo la caché local** cifrada; descarga ELIMINADA), `CharacterConfigData`, `PlayerInstance` (`Bootstrap`, `GetCartSlot`, `MatchAlternateForms`, `ReleaseCart`). Desaparece la `NullReferenceException` de `ShiftUIPublisher.Start`; el icono de personaje de la palanca se actualiza.
- [x] 2.2 **Streaming (ruta RESOURCE)**: `StreamManager` (+ `Asset`, `AssetCluster`, `LoadAsset`, `RequestAsset`, `Cleanup`…); la rama AssetBundle (`WWW`) se conserva y solo se usa con `DataUtility.forceWebPlayer`.
- [x] 2.3 **Texturas compuestas del kart**: `MultilayerTexture`, `StreamedMultilayerTexture`, `CompositeTextureUtil` (+ `AsyncTextureProcessor`), `CompositeProfile`, `CartPrimaryTextureProfile`, `SourceFactory`. No hicieron falta los 8 `MultilayerTextureBundleDef` (la ruta RESOURCE no los usa).
- [x] 2.4 **Kart y personaje**: `PreviewCart` (piezas, pinturas, transparencias, carga, salida del garaje `DriveOutCoroutine`), `CharacterPreview`, `ParticleLibrary`, y `PlayerInstance.ConstructCart` (kart de carrera "LocalPlayer": raíz = ruedas con `CarCollider`/`PowerupHolder`/`PlayerControlLinker`, carrocería, piezas en sus `<Ranura>Slot`, atributos sumados, pinturas compuestas en un material `Mobile/Diffuse`, piloto sentado con `AnimationDriver`).
- [x] 2.5 **Selección**: `SelectCircuitPublisher` (banners, trofeos, candados, Tutorial, Pranksgiving con interruptor local D2 `RecoverySwitches.PranksgivingEnabled`), `UnlockedCircuitPublisher`, `TrackSelectPublisher`, `DifficultyMenuPublisher`, `TrackUnlockHelper` completo, `CharacterSelectPublisher` + `CharacterButtonPublisher` (logos de serie, estados Using/Owned/Buy/Locked, monedas).
- [x] 2.6 **Carga de la carrera**: `RaceSettings` (IA aleatoria sin repetir ni al jugador, exclusión Agente P ↔ Phineas/Ferb, assets `Cart Assets/AI Carts/<Nombre>_AI`), `LoadingPublisher` (misiones, escena con `SceneManager.LoadSceneAsync` — ADAPTADO-U6, espera de piezas, construcción del kart, botón Go), `LoadSpin`.
- [x] 2.7 **Métodos de Etapas 3/4 adelantados** porque el flujo los ejecuta: `AnimationDriver` (completo), `AchievementManager` (completo: elección de 3 misiones por carrera, ventanas de logro; Game Center/analítica ELIMINADOS), `CharacterVOController` + `GetVOController`, `CartCustomizerPublisher.IsTemporaryInSlot`, accesores de `RaceManager.raceInitFinishedEvent`. Queda pendiente, a propósito, `RaceManager.InitRace` (Etapa 3: arranque de la carrera tras pulsar Go).
- [x] 2.8 **Validación en Unity 6.6 (PC local)** — capturas en `recovery/reports/stage2/`:
  - PLAY → el kart sale del garaje → "Circuit Select" (Newbie/Pro/Master, candados, trofeos, Pranksgiving con el pavo) → "Newbie" → "Track Select" (Kick Butt!, Doof's Tower, Freshwater High con miniaturas y medallas en silueta) → pista 1 → salida del kart (`DriveOutCoroutine`) → escena `Loading` → `Kick Butt Track 1` cargada (~1,4 s).
  - "LocalPlayer" construido en la pista: ruedas, carrocería, interior, luz y piloto; 5 rivales IA elegidos; pantalla de carga con "Go!".
  - Go → fundido → `RaceSettings.Launch` (elimina el `DebugTrackStrapper`) → `RaceManager.InitRace` (**pendiente, Etapa 3**): la pantalla queda en negro, que es el final esperado de esta etapa.
  - Garaje → Personaje → flechas: Dipper (logo Gravity Falls), Ferb (logo Phineas and Ferb), coste 3500; "Buy" sin monedas → ruta "necesita monedas" (tienda eliminada).
  - Sin excepciones del juego (solo el ruido interno del editor `SearchDatabase`).
  - No ejercitado: cambiar a un personaje gratuito/comprado y comprobar que persiste entre ejecuciones (hacen falta monedas; se revisará con la tienda local de piezas, Etapa 4). El menú de dificultad no forma parte del flujo PLAY (cada circuito fija su dificultad).
- [x] 2.9 Cierre: catálogo regenerado, `RECOVERY_PROGRESS.md` y `SINCRONIZAR_A_LOCAL.md` al día.

### Etapa 3 — Carrera mínima ✅ (completada 2026-09-26)
Objetivo: tras "Go!", **parrilla → cámara de presentación → cuenta atrás → conducir con teclado → checkpoints y vueltas →
meta → resultados → reintentar / volver al menú**, con HUD y pausa. La IA rival (rutas grabadas, estados) es de la Etapa 4:
aquí los rivales aparecen en la parrilla y se tolera que no conduzcan (o lo hagan en modo "gimped" si ya funciona).
Volumen: **467 métodos pendientes, ~161 KB de ARM** ([catálogo](recovery/catalog/METHOD_CATALOG.md#etapa-3--carrera-mínima-conducir-vueltas-meta-resultados)).
Pendientes no-traducción: [PENDIENTES_POR_ETAPA §Etapa 3](recovery/catalog/PENDIENTES_POR_ETAPA.md) (3.1–3.9).
Mismo ciclo por bloque: traducir → `compile_check.py` → Unity con `PlayModeRunner` → documentar → commit.

| Bloque | Clases | Métodos · ARM |
|---|---|---|
| Gestión de carrera | `RaceManager`, `CarProgress`, `RaceResults`, `DebugTrackStrapper`, `ObjectTrackDistanceLogic` | 102 · 29,8 KB |
| Pista | `WaypointLogic`, `SpeedPoint`, `ResetTrigger`, `TerrainEffectTrigger`, `CausticsManager`, `Vector3x.Berp` | 36 · 18,3 KB |
| Cámaras | `PreRaceCamera`, `FollowCamera`, `CameraWobble` | 17 · 9,5 KB |
| Vehículo | `CarCollider`, `TriFoot`, `SpringConnection`, `AnimationTire`, `ShadowBlob`, `CarMetrics`, `CatchupNotify` | 109 · 44,2 KB |
| Control PC | `PlayerKeyboardControl`, `PlayerControlLinker`, `DriftButton`, `ReverseButton` | 22 · 3,9 KB |
| HUD | `HUDLogic`, `BlipTrackPublisher`, `DriftScalePublisher` | 123 · 33,3 KB |
| Pausa / resultados | `PausePublisher`, `RaceResultsPublisher`, `PlaySummaryPublisher` | 58 · 22,0 KB |

- [x] 3.1 **Arranque de la carrera**: `RaceManager` (`InitRace` → `Init`: coches en la parrilla desde `RaceSettings.AICarts` y el kart del jugador, orden de salida, eventos `raceInitFinishedEvent`/`raceEndEvent`, `PreraceCountdown`, `PreLaunchCoroutine`), `CarProgress`, `RaceResults`, `ObjectTrackDistanceLogic`, y `DebugTrackStrapper` (abre una pista directamente con el kart por defecto: acelera todas las pruebas siguientes).
  Criterio: tras "Go!" los 6 karts aparecen en la parrilla sin excepciones; abrir `Kick Butt Track 1` directamente también arranca la carrera.
- [x] 3.2 **Pista**: `WaypointLogic` (precálculos, distancia a lo largo de la pista, muros), `SpeedPoint`, `ResetTrigger`, `TerrainEffectTrigger`, `CausticsManager` (agua animada de Fish Hooks, pendiente 3.1), `Vector3x.Berp`. `ProgressTriggerLogic` ya estaba recuperado (Etapa 0).
- [x] 3.3 **Cámaras**: `PreRaceCamera` (recorrido de presentación), `FollowCamera` (persecución, cámara de choque), `CameraWobble`.
  Criterio: presentación de la pista → cámara detrás del kart del jugador.
- [x] 3.4 **Vehículo**: `CarCollider` (movimiento propio con `CAR_GRAVITY=10`, aceleración, giro, derrape y power-slide, colisión con suelo por raycast a `Ground`, muros/límites, calado, sentido contrario, recolocación en pista), `TriFoot` (orientación sobre el terreno con tres raycasts), `SpringConnection` (suspensión de la carrocería), `AnimationTire`, `ShadowBlob`, `CarMetrics`, `CatchupNotify`. Validación de física PhysX 2.8 → moderno (pendientes 3.2, 3.3, 3.8).
- [x] 3.5 **Control de PC**: `PlayerKeyboardControl` (acciones originales Accelerate, Break, TurnLeft, TurnRight, Drift, UsePowerup, BuyPowerup, Pause; teclas por defecto del ARM, pendiente 3.5), `PlayerControlLinker`, `DriftButton`, `ReverseButton`. Banco de pruebas: teclas simuladas en `RecoveryTestInput` (solo tooling) para conducir en `PlayModeRunner`.
- [x] 3.6 **HUD**: `HUDLogic` (cuenta atrás, posición, vuelta, flechas, avisos de sentido contrario, botón de pausa, notificaciones), `BlipTrackPublisher` (mapa de posiciones), `DriftScalePublisher` (medidor de derrape).
- [x] 3.7 **Pausa, resultados y resumen**: `PausePublisher` (continuar / reiniciar / salir), `RaceResultsPublisher` (clasificación, monedas, reintentar, terminar), `PlaySummaryPublisher` (resumen previo cuando la pista tiene opciones de carrera). Vuelta al garaje por `ScreenFader`.
  Hecho (commits `3caf4f8`, `a273cf9`, nube): `DriftScalePublisher` y `BlipTrackPublisher` completan el HUD. También están `PausePublisher`, `PlaySummaryPublisher`, `FrontEndTutorialHandler.ActiveTutorial` y `RaceResultsPublisher` completo: filas 1st–6th con tiempo `(mm:ss)` e icono del personaje (resaltado azul del jugador), recuento animado de monedas (tokens ×10, bonus de puesto, multiplicador de dificultad), tutoriales de monedas y de rebobinado, Done / Retry / Rewind y el récord "Highest Place <pista>".
  ELIMINADO: la analítica GDMO de pausa y de fin de carrera, y el diálogo "Need More Tokens" de `RaceResultsPublisher.NeedMoreCoins` (tienda StoreKit, igual que `FrontEndLogic.NeedMoreCoins`).
  Fiel al ARM: `FillRanks` comprueba `Length > 3` también para las filas 5.ª y 6.ª.
  Sin validar en Unity: pendiente de 3.9 (TEST 11–13).
- [x] 3.8 **Métodos de la Etapa 4 que la carrera ya ejecuta** (38: `EffectManager`, `PowerupHolder`, `GimpedCarAI`, `CarAI.ClearStates`, `SoundLibrary.PlaySoundOnPlayer`, `MissionManager.Signal`, `AchievementListener.HasAchieved`…): se dejan pendientes salvo que bloqueen la carrera; los que bloqueen se adelantan y se anotan aquí.
  Hecho (commit `e56e8c0`): rebobinado de la última vuelta, `RaceManager.RecordSnapshot` y `RaceRewind` junto con `CarSnapShot` y `SnapShotInfo`. Eran los últimos métodos de la Etapa 3 en `RaceManager`.
  Sus llamadas a `EffectManager`, `PowerupHolder`, `GimpedCarAI` y `BaseEffect` siguen pendientes de la Etapa 4 (hoy devuelven 0 o null y no se entra en esos bucles). El botón Rewind abre `RewindDialogPublisher`, que también es de la Etapa 4.
  Siguen pendientes de la Etapa 3, **aplazados a la Etapa 4** por decisión de la sesión local (junto al sistema de misiones): `HUDLogic.SignalMissionStart`/`SignalMissionComplete` y sus iteradores (15 métodos).
  Ningún otro pendiente de la Etapa 4 bloquea la carrera según el análisis estático; lo confirmará el log `[RecoveryPending]` de 3.9.
  **Adelantados en 3.9** porque la validación demostró que bloqueaban la carrera:
  - Sistema de efectos: `EffectManager` (completo), `BaseEffect` (accesores, `isBeneficial`, `GetEffectInstance`, combos, `DebugDump`) y siete efectos. Son `BoosterEffect` (tiras de turbo), `SlowdownEffect`, `WipeoutEffect`, `ShockedEffect` (tipo 17, pistas de Phineas), `SkidEffect` y `FlipEffect` (choques), y `GuidedJumpEffect` + `GuidedJumpTrigger` (saltos de rampa: sin ellos el kart cae al hueco del salto de Kick Butt Track 1 y no completa la vuelta).
  - Las tablas `switch` de `isBeneficial`/`GetEffectInstance` se decodificaron del parche SWITCH del binario con la herramienta nueva `forensics/scripts/switch_tables.py`.
  - `MusicPlayer.Instance`/`Exists` (la meta usaba `Instance` → `NullReferenceException` y la carrera no terminaba).
  - `MissionManager.GetHasStartedFirstMission`.
  - Siguen en la Etapa 4 los power-ups (mina, misil, escudo, embestida, teletransporte, combos), `PowerupHolder`, la IA (`CarAI`, `GimpedCarAI`), el audio (`SoundLibrary`, `SoundSequencer`, resto de `MusicPlayer`) y las monedas de pista (`CoinPoint.SpawnCoins`).
- [x] 3.9 **Validación en Unity 6.6** — capturas en `recovery/reports/stage3/`, logs `recovery/logs/playrun_s3*.log`.
  Banco de pruebas nuevo (solo tooling, `PlayModeRunner`/`RecoveryTestInput`):
  - `key:<Tecla>@t1-t2`: teclas simuladas.
  - `auto@t1-t2` (admite varios tramos): piloto automático que mantiene W y gira hacia el siguiente waypoint.
  - `load:<escena>@t`: carga directa de una escena.
  - `hidetype:<Tipo>@t`: oculta un overlay en las capturas.
  - En cada captura se registran la posición, vuelta y puesto del jugador y los botones de UI activos.
  - TEST 5 · parrilla ✅: jugador y 5 rivales en las posiciones de salida, apoyados en el suelo (`TriFoot`).
  - TEST 6 · presentación y cuenta atrás ✅: vuelo de `PreRaceCamera`, semáforo 3-2-1-GO del HUD ("6th", "Lap 0 / 3").
  - TEST 7 · conducción con teclado ✅:
    - acelerar (el kart acelera solo salvo al frenar, como en el original), frenar hasta ir marcha atrás, girar;
    - derrape con medidor y power-slide ("Drifting — Let Go!") y el turbo al soltar.
  - TEST 8 · física ✅:
    - suelo, rampas, muros (deslizamiento por `DoRoadBoundaries`), turbos y saltos guiados en Kick Butt Track 1;
    - vuelta completa en Bus Jumper (Kick Butt Track 2, `dirt_road2`) sin quedarse clavado ni atravesar el terreno.
  - TEST 9 · checkpoints ✅: `ProgressTriggerLogic` cuenta las vueltas; aviso "Wrong Way!" al dar la vuelta; recolocación por calado/`ResetTrigger` tras caer.
  - TEST 10 · vueltas ✅: "Lap n / 3" y "1st" en el HUD, monedas, mapa lateral de posiciones.
  - TEST 11 · meta → resultados ✅: tres vueltas en ~2:10 → `PostRaceCountdown` → escena `RaceResults`:
    - 1.º–6.º con tiempos e iconos, el jugador en azul;
    - bonus de puesto 300 × dificultad (Easy ×1).
  - TEST 12 · pausa ✅: botón de pausa → Resume / Restart / Quit.
    - Continuar congela y reanuda.
    - Reiniciar vuelve a cargar la pista con su "Go".
    - Salir lleva a `PreFrontEnd` → garaje (selector de circuitos con el trofeo de 1.º).
  - TEST 13 · resultados ✅: Retry → nueva carrera completa; Continue → garaje.
    - El guardado local (`DSSRacer_save.txt`) registra `Highest Place Kick Butt!` = 0 (0 = 1.º, codificación del original).
    - Las monedas quedan acumuladas: 700 en memoria durante la 2.ª carrera, 1000 guardadas tras ella.
  - Revisión visual ✅: Kick Butt 1 y 2, Phineas Track 1 y Fish Hooks Track 1 (vía `load:`, porque los circuitos Pro/Master están bloqueados por la progresión original) cargan, se conducen y cuentan vueltas.
  - Observaciones:
    - **Doble carga de `DebugTrackStrapper`** (fiel al original, solo en la vía de depuración). Abrir una pista sin pasar por el menú necesita `DataUtility`, como en el original. Con `load:` la pista se carga dos veces (pista → Loading → pista). El `HUDLogic` de la primera carga queda suscrito a `raceInitFinishedEvent`, y su `OnRaceInit` lanza `MissingReferenceException` y corta el evento. Por eso la pantalla de carga no se cierra y el HUD muestra el texto de ejemplo. Por el menú normal no ocurre.
    - **Medidor de derrape** (fiel). Con el temporizador a 0 el relleno tiene escala X = 0 y `UghSprite` divide los márgenes entre `lossyScale` (NaN): Unity 6 avisa "Invalid worldAABB" y "Mesh.vertices is too small" (el original tampoco llama a `Mesh.Clear`). No tiene efecto visible.
    - **Fish Hooks** se ve muy claro (cáusticos aditivos, pendiente 3.1): comparar con el original.
    - **Karts rivales**: no conducen (IA de la Etapa 4); el jugador gana siempre.
    - **Monedas**: "Coins: 0" en resultados porque las monedas de pista son de la Etapa 4.
    - **Pausa por foco**: al perder el foco la ventana, `HUDLogic.OnApplicationPause` abre la pausa (original).
- [x] 3.10 Cierre: catálogo regenerado, `RECOVERY_PROGRESS.md`, `PENDIENTES_POR_ETAPA.md` y `SINCRONIZAR_A_LOCAL.md` al día, commit "Etapa 3 completa".

### Etapa 4 — Sistemas completos ✅ (completada 2026-09-27)
Objetivo: **el juego completo y jugable en PC dentro de Unity 6.6**. Incluye:
- rivales que corren;
- power-ups, obstáculos y monedas en pista;
- música, efectos y voces;
- misiones y logros;
- personalización y tienda local de piezas;
- tutorial, modo Elimination y rebobinado;
- pendientes visuales de la Etapa 3 y 60 fps estables.

Al cerrarla, el juego está "listo en PC" y se genera un ejecutable de Windows. Después vienen Android y URP (§11.7 de `RECOVERY_REPORT.md`).
Volumen: **1262 métodos pendientes, ~241 KB de ARM**, más los 15 de misiones del HUD aplazados de la Etapa 3 ([catálogo](recovery/catalog/METHOD_CATALOG.md)).
Mismo ciclo por bloque: traducir → `compile_check.py` → Unity con `PlayModeRunner` → documentar → commit.

| Bloque | Clases principales | Métodos · ARM |
|---|---|---|
| 4.1 PC a 60 fps | arranque de la plataforma PC | — |
| 4.2 Audio | `SoundLibrary`, `SoundSequencer`, `SoundPackageManager`, `MusicPlayer`, `SoundLibraryAddendum` | 102 · 15,2 KB |
| 4.3 IA de rivales | `GimpedCarAI`, `CarAI`, `CarAIPathManager`, `CarAIPersonality`, estados `Drive*`/`UsePowerup*`, `PathMoverAI`, `SphereMoverAI` | 136 · 41,9 KB |
| 4.4 Power-ups y obstáculos | `PowerupHolder`, `PickupSpawner`, pickups, efectos restantes (mina, misil, escudo, embestida, teletransporte, combos, tarta), `RocketAI`, `MineAI`, `UFOLogic`, `Crab`, barriles, `PieLauncher`… | 386 · 77,2 KB |
| 4.5 Monedas en pista | `CoinPoint`, `Coin` | 11 · 8,6 KB |
| 4.6 Misiones y logros | `MissionManager`, misiones, `AchievementListener` y sus 30 variantes, `AchievementUI`/ventanas, `HUDLogic.SignalMission*` (de la Etapa 3) | 471 · 56,8 KB |
| 4.7 Personalización y tienda | `CartCustomizerPublisher`, `PaintSlotPublisher` | 89 · 30,2 KB |
| 4.8 Tutorial, rebobinado y utilidades | `FrontEndTutorialPublisher`/`Handler`, `TutorialLauncherPublisher`, `RewindDialogPublisher`, `PIDVectorController`, `ParticleSystemDestroy` | 82 · 17,1 KB |
| 4.9 Pendientes visuales | agua de Fish Hooks (3.1), light probes (3.4), lightmaps (3.6), `[RequireComponent]` (3.7), `Plane_003` (3.8), partículas convertidas (4.1) | — |
| 4.10 Validación completa en PC | una carrera por pista (10 + tutorial), Elimination, misiones, tienda, guardado | — |
| 4.11 Cierre y ejecutable de Windows | build de PC, documentación, commit "Etapa 4 completa" | — |

- [x] 4.0 **Correcciones de etapas anteriores** (detectadas al revisar las capturas, 2026-09-26). Van antes que el resto:
  - **Karts y personajes oscuros en carrera** (pendiente 3.4, no resuelto). `RaceManager.Init` destruye todas las luces de la pista, como el original, y los objetos móviles se iluminaban con las light probes horneadas de Unity 4, que Unity 6 no carga. Los datos originales están en cada `Scenes/Tracks/<pista>/LightProbes.asset`: 510 posiciones con sus coeficientes SH y la tetraedrización. Solución: aplicarlos en ejecución a karts, pilotos y objetos dinámicos (RECUPERADO los datos, ADAPTADO-U6 el muestreo).
  - **Interfaz a cualquier resolución y aspecto** (PC 16:9, 16:10, 21:9, 4:3; móvil 19,5:9). La cámara Ugh usa 9,6 unidades de alto; `UghAlign.AlignToScreen` calcula el ancho con `Screen.width / 100` (fiel al ARM, pensado para las resoluciones de iOS). Hay que medirlo en un ejecutable de Windows a varias resoluciones y adaptar el anclaje (ADAPTADO-U6). Además el `PlayModeRunner` capturaba a 1280×720 con la pantalla del editor a 640×480, así que sus capturas no son fiables para la interfaz: se corrige para capturar al tamaño real.
  - **Recuadros con "Mi…" y chulos amarillos** en el borde derecho del HUD. Son los tres avisos de logro/misión de `HUDLogic` ("Achievement Notification 1–3"): deben quedar fuera de pantalla y entrar deslizándose al conseguir un logro. Asoman por el mismo problema de anclaje.
  **Avance (2026-09-26, en curso):**
  - ✅ Iluminación: `LegacyLightProbes` (Runtime) aplica las probes originales. Las exporta `forensics/scripts/lightprobes_export.py` a `Resources/LegacyLightProbes/<escena>.bytes`, para 11 escenas más Tutorial Track, que comparte las de Kick Butt 1. Interpola con los tetraedros originales. Probado en Unity: karts y pilotos con color y luz en Kick Butt 1.
  - ✅ Interfaz: el anclaje real (`UghAlign.Align` → `ScreenAnchorToPosition`) sigue al aspecto de la cámara. Los recuadros "Mi…" eran un artefacto de las capturas del runner, ya corregido (captura al aspecto real). Nuevo en `UghCamera.Update`: recolocar la interfaz si cambia el tamaño de la ventana (ADAPTADO-U6).
  - ✅ Probado en el ejecutable de Windows a 16:9, 16:10, 4:3, 21:9 y 19,5:9: menús centrados y HUD en las esquinas.
  - ✅ Tutorial Track con las probes de Kick Butt 1 (karts iluminados).
  - **Ejecutable de Windows** adelantado de 4.11 para las pruebas:
    - `DSSRecovery.BuildTools.BuildWindows` y `forensics/scripts/build_windows.sh` generan `recovery/build/Windows/DSSRacer.exe` (290 MB, ~1 min; carpeta fuera de git).
    - `forensics/scripts/run_player.sh` lo lanza con el arnés `RecoveryPlayerTest`: solo se activa con `-recoveryTest`, admite pulsaciones, teclas, piloto automático, capturas, fps, fuentes de audio sonando y cambio de resolución.
    - Para compilar para Windows hubo que sustituir `UnityEngine.iOS.DeviceGeneration` (solo existe en editor e iOS) por el enum local `U4iPhoneGeneration`, con los mismos valores.
- [x] 4.1 **PC a 60 fps**: el original (iOS) corría a 30 fps de pantalla con física a 60 Hz (`Fixed Timestep` 0,0167, `DoPhysicsAt30fps` = falso). En PC se fija `Application.targetFrameRate = 60` con vSync desactivado (ADAPTADO-U6, plataforma PC). El `PlayModeRunner` registra los fps medios entre capturas para vigilar el rendimiento.
  **Avance:** ✅ `PcFrameRate` (Runtime): 60 fps sin vSync. Medido 58–60 fps en el editor y en el ejecutable, en menús y en carrera.
- [x] 4.2 **Audio**: `SoundLibrary`, `SoundSequencer`, `MusicPlayer`, `SoundLibraryAddendum`, `SoundPackageManager` y las clases de datos de paquetes (commits `c08d9b3`, `2ff6b78`). Probado en el editor y en el ejecutable: música de menú y de pista, motor, turbo, choques, power-ups, público y "stings" (el arnés del ejecutable lista las fuentes que suenan).
- [x] 4.3 **IA de rivales**: `CarAI` y sus estados, `CarAIPersonality`, `CarAIPathManager`, `GimpedCarAI` (rutas grabadas), `PIDVectorController`, `PathMoverAI`, `SphereMoverAI`, `ForwardForceAI`, `CarAIPathRecorder` (commits `fb4110a`, `b9b9a43`, `05e7763`). Los rivales corren las 10 pistas, usan power-ups y ganan en Medium/Hard al piloto automático de pruebas.
- [x] 4.4 **Power-ups y obstáculos**: `PowerupHolder`, pickups y `PickupSpawner`, todos los efectos (mina, misil, escudo, embestida, teletransporte, combos, tarta, ancla, disparo aleatorio, cohete, imán), `RocketAI`, `MineAI`, `MineSpreaderAI`, y los obstáculos de pista: barriles, cangrejo, OVNI, tartas, láser, cojín, chorros, trampolines, pirotecnia, baloncesto, dron, pavo (commits `3a76420` … `972dd30`).
- [x] 4.5 **Monedas en pista**: `CoinPoint` (anillos y relleno aleatorio) y `Coin`; "Coins" y total en resultados.
- [x] 4.6 **Misiones y logros**: `MissionManager`, `BaseMission` y las 9 misiones, `MissionCollection`, banners de misión del HUD (`HUDLogic.SignalMission*`, aplazados de la Etapa 3), `AchievementListener` y sus 30 variantes, `AchievementUI`, ventanas y paneles de logros (commits `972dd30`, `9077992`). Sin Game Center (ELIMINADO). Probado: ventanas de logro al arrancar ("Catch Some Air" +100), pestaña de misiones, progreso de misiones (Tracks/Coins/Stunts/Misc.), misiones en la pausa.
- [x] 4.7 **Personalización y tienda local**: `CartCustomizerPublisher` (54 métodos) y `PaintSlotPublisher` (commit `1d9f308`). Probado: ranuras, flechas, compra con monedas (1450 → 1200), equipar, menú de pinturas. La analítica GDMO de compra/equipado queda ELIMINADA.
- [x] 4.8 **Tutorial, rebobinado, Elimination y utilidades**: `FrontEndTutorialHandler`/`Publisher`, `TutorialLauncherPublisher`, `RewindDialogPublisher`, `RewindLapSlotPublisher`, `ParticleSystemDestroy` (commit `9077992`). Probado: consejos del tutorial en garaje, menú previo y resultados; Tutorial Track encadena sus pasos (espacio → B → escudo/combos → Shift); Elimination a 5 vueltas elimina al último de cada vuelta.
- [x] 4.9 **Pendientes visuales** (comparados con las miniaturas originales de `Texture2D/Level Previews SpriteAtlas.png`, que son capturas del juego):
  - **Partículas magenta** (4.1): el extractor de la Etapa 0 (`extract_legacy.py`) leía la línea `- {fileID: …}` del material como una clave, así que las **91** partículas convertidas no tenían material. `forensics/scripts/fix_particle_materials.py` repara los datos y los renderers de 25 prefabs y 5 escenas; nuevo volcado `badmat` del arnés: 0 renderers sin material en carrera.
  - **Agua de Fish Hooks** (3.1): el color y el brillo de Freshwater High, Hokey Poke y Fishtankia coinciden con sus miniaturas originales (cáusticos cian aditivos). Sin cambios.
  - **`[RequireComponent]`** (3.7): los únicos Rigidbody no cinemáticos son el barril y los balones de baloncesto (físicos a propósito); los 2 MeshRenderer que Unity añadió a TextMesh del personalizador pintaban un "Action" gigante: se añaden deshabilitados en el prefab (el original no tenía renderer, era invisible).
  - **`Plane_003`** (3.8) y lightmaps (3.6): Danville River y el resto de pistas se ven como sus miniaturas; nada anómalo.
- [x] 4.10 **Validación en Unity 6.6** (logs `recovery/logs/playrun_v4*.log`):
  - Carreras completas por el menú normal en las **10 pistas + tutorial**, con un guardado de prueba que desbloquea Pro/Master (el real se restaura tras cada prueba). Llegan a resultados Kick Butt 1, Doof's Tower (326 s), Fishtankia, Pranksgiving y Elimination; el resto se corta a los 260 s en la 3.ª vuelta, sin errores. **0 `RecoveryPending`** y 0 excepciones de juego en todas.
  - Menús: garaje, personalizador, logros, personaje, ajustes, selección de circuito, menú previo (dificultad y tipo de carrera), pausa, resultados.
  - Rendimiento: 58–60 fps en editor y ejecutable.
  - **Correcciones de la validación** (a petición del usuario, 2026-09-27):
    - **Textos fuera de sus recuadros**: la fuente bitmap `CCUpUpAndAway` (451 TextMesh) guarda los glifos medidos desde la línea superior (Unity 4); Unity 5+ los lee desde la línea base y dibujaba todo una ascendente más abajo. `m_Ascent: 0` deja la línea base donde la ponía Unity 4 (ADAPTADO-U6, medido con `_Recovery/Editor/FontProbe.cs`: "!" entre −0,30 y −4,90 frente a −0,275/−4,975 del original).
    - **Kart que se atasca en la rampa de Kick Butt 1 y en los bordillos de Doof's Tower**: `CarCollider.DoMovement` barre una esfera de radio `bounds.size.x` (2,4, original). En Unity 4 los barridos de PhysX 2.8 no devolvían los colliders ya solapados al empezar ni los triggers; Unity 6 devuelve ambos (solapes con `point` = 0, y triggers por `queriesHitTriggers`). El código original tomaba la normal como `posición − point`, así que frenaba el kart cada frame. ADAPTADO-U6: se ignoran solapes iniciales y triggers. Medido con la nueva traza `trace@t1-t2`: la rampa ya no se sube a 17 sino a ~25 y el salto llega en la mitad de tiempo; el láser del robot (trigger) ya no para el kart de 45 a 5. Queda un único golpe al pisar la rampa (el bloque Collide bajo la pendiente choca con la esfera de 2,4): es geometría y código originales.
    - **Cambios pedidos por el usuario sobre el original** (2026-09-27, etiqueta `MODIFICADO` en el código; no son fieles al ARM):
      - `CarCollider.DoMovement`: con el kart en el suelo se ignoran los contactos con objetos a menos de 0,5 por encima de su base (como un escalón). Quita el golpe de la rampa de Kick Butt 1: ahora se sube a 54–56 sin frenar.
      - `GimpedCarAI.DoRoadBoundaries`: sin muros mientras el bot está en el aire. El waypoint más cercano se busca en 3D y, sobre el foso del salto de Kick Butt 1, un bot en la línea grabada izquierda (x≈135) recibía el `Waypoint 22` de la carretera 15 unidades más abajo y quedaba clavado en el aire hasta 13 s. Tras el cambio, 45 pasadas de bots por el salto en 3 carreras, todas completas.
    - **Fallos vistos por el usuario en el ejecutable** (capturas, 2026-09-27):
      - **Personajes rotos** (Randy convertido en un amasijo rojo y negro gigante, triángulos turquesa en Perry, "lanza" blanca en Kick): el 4.º peso de hueso de 5 mallas (`head_003` = Randy, `Perry`, `kick`, `Phineas`, `gunther`; 296 vértices) valía ≈ −27. En las mallas comprimidas de Unity 4 ese peso no se guarda y vale (31 − suma)/31; el decodificador de UnityPy de la Etapa 0 escribía 1 − suma de los valores de 5 bits. El editor usa el nivel de calidad "Fastest" (1 hueso por vértice) y no se veía; el ejecutable usa "Fantastic" (4 huesos). RECUPERADO: `forensics/scripts/fix_skin_weights.py` repara las mallas y `repair_meshes.py` queda corregido. Verificado con la calidad 5 en el editor (`quality:5@t` del arnés).
      - **Iluminación de Fish Hooks muy brillante** y, en general, lightmaps distintos al original: Unity 6 reimportaba los PNG de lightmap de Unity 4 (dLDR) como RGBM tratando el PNG como luz final en espacio lineal: `DecodeLightmap` devolvía `png^(1/2,2)` en vez del original `2 × png` (zonas muy iluminadas hasta un 45 % más oscuras en todas las pistas), y el shader portado del agua, que leía el texel crudo × 2, salía ~2,7 veces más claro. ADAPTADO-U6: los 48 lightmaps pasan a EXR HDR con `(2 × png)^2,2` (`DSSRecovery.LightmapHdrConverter` + `forensics/scripts/lightmaps_to_exr.sh`, conservando los GUID) y el shader del agua usa `DecodeLightmap`. Medido: 0,727 frente al original 0,725 (Fish Hooks) y 1,116 frente a 1,108 (Kick Butt); la arena de Freshwater High y la tierra de Kick Butt recuperan el tono de las miniaturas originales.
- [x] 4.11 **Cierre**: ejecutable de Windows (`bash forensics/scripts/build_windows.sh`, 291 MB) probado con `run_player.sh` a 1920×1080 (carrera, audio, 60 fps, interfaz); catálogo regenerado (Etapa 4: **1480 recuperados, 0 pendientes**); `RECOVERY_PROGRESS.md`, `PENDIENTES_POR_ETAPA.md`, `SINCRONIZAR_A_LOCAL.md`; commit "Etapa 4 completa".
- [x] **Etapa 4 completa**: el juego es jugable de principio a fin en PC (editor y ejecutable de Windows). Siguiente: Android (y URP opcional), §11.7 de `RECOVERY_REPORT.md`.

## Catálogo de trabajo pendiente
- [recovery/catalog/METHOD_CATALOG.md](recovery/catalog/METHOD_CATALOG.md): los 4477 métodos del juego con su etapa (y [CSV](recovery/catalog/METHOD_CATALOG.csv) con token y dirección ARM). Estado tras la Etapa 2: Etapa 1 = 713 recuperados, 0 pendientes; Etapa 2 = 494 recuperados, 0 pendientes; pendientes Etapa 3 = 467 (+25 ya recuperados), Etapa 4 = 1357 (+118); 269 sin uso detectado, 155 sin uso (incluye `Dialog`, `LEDScroller` y `UghScrollView`, que ningún asset ni código instancia), 19 de depuración, 8 para Android, 664 eliminados. Estado tras 3.8: Etapa 3 = 477 recuperados, 15 pendientes (misiones del HUD, aplazadas); Etapa 4 = 1342 pendientes (+137 ya recuperados); 265 sin uso detectado.
- El catálogo cuenta como recuperados los iteradores/lambdas cuyo token cita el C#, y los constructores triviales (≤52 bytes: solo llaman al constructor base) de las clases traducidas (salvo los de clases generadas de iteradores/lambdas: antes contaban como recuperados iteradores de `RaceManager` sin traducir; corregido al empezar la Etapa 3); los métodos listados bajo una cabecera `// ELIMINADO` cuentan como eliminados.
- [recovery/catalog/PENDIENTES_POR_ETAPA.md](recovery/catalog/PENDIENTES_POR_ETAPA.md): pendientes que no son traducción (agua animada, guardado local, aspecto de pantalla, física, partículas, light probes…).
- Regenerar tras cada avance: `python forensics/scripts/method_catalog.py && python forensics/scripts/catalog_md.py`.

## RECOVERED FROM ORIGINAL
| Elemento | Etiqueta | Evidencia |
|---|---|---|
| 17 escenas, 579 prefabs, materiales, texturas, audio, animaciones | RECUPERADO | export AssetRipper de los `.assets` originales |
| 365 mallas comprimidas | RECUPERADO | decodificadas con UnityPy desde los `.assets` originales; verificadas contra su AABB |
| 3 shaders fixed-function custom | RECUPERADO | texto ShaderLab original del build |
| Matriz de colisión de capas | RECUPERADO | `PhysicsManager` en `mainData` |
| `ProgressTriggerLogic.CanTriggerForCar/OnTriggerEnter`, `DrawArea3D..ctor` | RECUPERADO-AOT | listados en `recovery/aot_listings/` |
| Etapa 1: 713 métodos (arranque, framework Ugh, localización, guardado, menús, ajustes, popups) | RECUPERADO-AOT | cabecera `// RECUPERADO-AOT <Clase>::<Método> token … @…` en cada método |
| Etapa 2: 494 métodos (datos y construcción del kart, streaming, texturas compuestas, menús de selección, carga de la carrera) | RECUPERADO-AOT | ídem |
| Clave AES de `ExternalPersistentArchive` (32 bytes) | RECUPERADO | datos estáticos `<PrivateImplementationDetails>.$$field-0` de `Assembly-CSharp-firstpass.dll` |
| Tabla de triángulos de `UghSlideToggle` | RECUPERADO | datos estáticos del DLL |

## RECONSTRUCTED / ADAPTED
| Elemento | Etiqueta | Motivo |
|---|---|---|
| Separación del static batching (1574 mallas) | ADAPTADO-U6 | Unity 6 ignora `m_SubsetIndices` de Unity 4 |
| `LegacyLightmapRestorer` | ADAPTADO-U6 | Unity 5+ no carga la lista de lightmaps de Unity 4 |
| Conversor de partículas legacy → Shuriken | ADAPTADO-U6 | `ParticleEmitter/Animator/Renderer` no existen desde 2018.3 |
| `Unlit Under The Sea` GLSL → CG | ADAPTADO-U6 | misma matemática que el programa GLES original |
| `iPhoneGeneration` → `iOS.DeviceGeneration`; `ParticleEmitter[]` → `ParticleSystem[]` | ADAPTADO-U6 | API eliminada |
| `RecoveryPending`, herramientas de editor | RECONSTRUIDO (tooling) | infraestructura, no lógica de juego |
| `dirt_road2` collider trigger → no trigger | ADAPTADO-U6 | Unity 5+ no admite MeshCollider cóncavo como trigger |
| Guardado local `LocalSaveStore` (`<persistentDataPath>/DSSRacer_save.txt`) | RECONSTRUIDO (backend) / RECUPERADO (datos) | sustituye a JCloud/GravCloudPrefs con las mismas claves y codificación por campo |
| `U4Compat`: `FindObjectOfType(s)` → `FindAnyObjectByType/FindObjectsByType`, `WWW` → `UnityWebRequest`, `OnLevelWasLoaded` → mensaje `OnLevelWasLoadedU6` enviado desde `SceneManager.sceneLoaded` | ADAPTADO-U6 | API eliminadas u obsoletas |
| `Application.LoadLevel` → `SceneManager.LoadScene`; `.camera/.renderer/.collider/.audio` → `GetComponent<T>()`; `DestroyObject` → `Destroy`; ramas `Application.isWebPlayer` retiradas (siempre falso) | ADAPTADO-U6 | API eliminadas |
| `LowEndInhibitor`: la inhibición por modelo de iPhone no se aplica en PC | ADAPTADO-U6 | calidad fija para PC (§11.2) |
| Interruptor de Pranksgiving: `RecoverySwitches.PranksgivingEnabled` (PlayerPrefs `DSSR_Pranksgiving`, activado por defecto) | RECONSTRUIDO | el original lo leía de `pranksgiving.txt` remoto (decisión D2) |
| `Application.LoadLevelAsync` → `SceneManager.LoadSceneAsync`; `Transform.FindChild` → `Find` | ADAPTADO-U6 | API eliminadas |
| `MiniJSON`: números con cultura invariante | ADAPTADO-U6 | evita fallos con separador decimal "," en Windows |
| 16 shaders built-in → equivalentes Unity 6 (`Legacy Shaders/...`) | ADAPTADO-U6 | mismos shaders de Unity, renombrados |
| Lightmaps de Unity 4 (48 PNG dLDR) → EXR HDR `(2 × texel)^2,2` | ADAPTADO-U6 | Unity 6 los recodifica en RGBM como si fueran luz lineal; así `DecodeLightmap` devuelve el 2 × texel original |
| 4.º peso de hueso de 5 mallas de personaje | RECUPERADO | (31 − suma)/31 como en la compresión de Unity 4; UnityPy escribía ≈ −27 |
| Fuente bitmap `CCUpUpAndAway`: `m_Ascent` 48,75 → 0 | ADAPTADO-U6 | Unity 5+ mide los glifos desde la línea base y Unity 4 desde la línea superior; sin el cambio todos los textos bajaban una ascendente |
| `CarCollider.DoMovement`: el barrido ignora solapes iniciales y triggers | ADAPTADO-U6 | PhysX 2.8 no los devolvía; en Unity 6 frenaban el kart en rampas, bordillos y el láser |
| Materiales de las 91 partículas convertidas | RECUPERADO | la guid de cada `ParticleRenderer` original, perdida por un fallo del extractor de la Etapa 0 |
| MeshRenderer deshabilitados en 2 TextMesh de `CartCustomizerMenu` | ADAPTADO-U6 | Unity 6 exige el renderer; el original no lo tenía y el texto era invisible |

## ELIMINATED (decisión del usuario, 2026-09-26)
StoreKit, Game Center, iCloud/JCloud/GravCloud/P31, Burstly, GDMO/Tapalytics, MoreGames/More Disney, Email, Age Gate, enlaces legales/web de Disney.
Detalle: `forensics/output/removed_service_scripts.json`, `forensics/output/service_cleanup_report.json` y comentarios `ELIMINADO` en el código.
En la Etapa 1 además: notificaciones locales de iOS del bono diario, aviso de compras de iTunes en la primera ejecución (`Purchase Notification Popup`), tienda de monedas (`FrontEndLogic.NeedMoreCoins`, botones "More Coins"/"BuyCoins" ocultos), botón de Game Center, botones "More Disney", los 4 enlaces de Créditos, analítica GDMO y anuncios Burstly, y la descarga de `PartCosts.epa.xml` (se conserva la caché local cifrada).

## KNOWN ISSUES
- `dirt_road2` (Kick Butt Track 2 / Bus Jumper) era un MeshCollider cóncavo *trigger*: PhysX 2.8 lo admitía y los raycasts de suelo lo detectaban; Unity 5+ no soporta triggers cóncavos. Pasa a collider normal (ADAPTADO-U6). Sin ello, la parrilla de salida no tenía suelo.
- Unity añadió 23 componentes por `[RequireComponent]` del código original (SoundSequencer en 20 prefabs de ruedas, 1 Rigidbody en un botón, 2 MeshRenderer en TextMesh). Revisado en 4.9: los 2 MeshRenderer del personalizador se dejan deshabilitados en el prefab (el original no los tenía); el resto no altera nada.
- Fish Hooks se ve muy luminosa: comparado en 4.9 con las miniaturas originales del juego, el brillo y el color coinciden (cáusticos aditivos).
- `Plane_003` (Phineas Track 2): la malla separada mide 200×200, su collider 2×2 (sin explicar; original).
- Parámetros de partículas convertidas son aproximación (fuerzas, damping, `tangentVelocity`). Sus materiales se habían perdido en la Etapa 0 (salían magenta): restaurados en 4.9 con `fix_particle_materials.py`.
- **Etapa 4 · radio de colisión del kart**: `CarCollider.DoMovement` barre una esfera de radio `bounds.size.x` (el diámetro, 2,4): el kart choca con muros y bordillos a 1,2 unidades de tocarlos. Es el código original (confirmado en el ARM); se conserva. El golpe al pisar la rampa de Kick Butt 1 se quitó a petición del usuario (contactos a ras de suelo ignorados, `MODIFICADO`).
- **Etapa 4 · pausa al perder el foco** en el ejecutable (`HUDLogic.OnApplicationPause`, original).
- **Etapa 4 · "There are no audio listeners in the scene"** durante la escena `Loading` (no tiene cámara con AudioListener, como en el original).
- 151 mallas de UI sin nombre tienen AABB desactualizado desde el original (no afecta).
- Unity inyecta paquetes por defecto (compras/analytics) al abrir un proyecto "antiguo": el manifest se limitó a módulos integrados.
- En esta máquina Unity necesita `DOTNET_gcServer=0` y `DOTNET_GCHeapHardLimit` para que sus compiladores .NET arranquen (memoria comprometible libre ~5 GB).

- ~~Etapa 1 · `ShiftUIPublisher.Start` NullReferenceException~~ y ~~PLAY no abre "Circuit Select"~~: **resueltos en la Etapa 2**.
- **Materiales/clips compartidos modificados tras jugar en el editor**: `Fader SpriteAtlas.mat` (`ScreenFader`), `Mobile Cart Part.mat` (pulso de transparencia de `PreviewCart.UpdateColorShift`) y a veces `AnimationClip/crash_idle.anim` (`wrapMode` cambiado en tiempo de ejecución). El código original modifica assets compartidos y el editor los guarda. Inofensivo en un build: descartarlos con `git checkout` antes de cada commit.
- **Etapa 1 · `Trying to save, but there is a null value?`**: con la Etapa 2 aparece solo **una** vez, al crear el guardado nuevo durante `PlayerInstance.Bootstrap` (comportamiento del `DataUtility.Save` original).
- **Etapa 1 · `FrontEndLogic.NeedMoreCoins`** eliminado con la tienda: el aviso informativo "Need More Tokens" que mostraba ese mismo popup (sin compra) tampoco aparece; revisar en la Etapa 4 (compra de piezas) si hace falta un aviso local.
- **Etapa 1 · comportamientos originales conservados tal cual**: `FadeHelper.IsFading(Transform)` solo termina si la jerarquía tiene algún `Renderer` (los menús siempre lo tienen); `Dialog.Awake` arrancaba su corrutina `Start` además de la que lanza Unity; `Mathfx.Parameter` interpola la primera mitad con `(0.5 - value) * 2`; `AudioCrumb.Play` aplica el volumen de efectos dos veces; `FrontEndCamera.SetCameraTargetByIndex` acepta `index == Length`.
- **Etapa 1 · puente `OnLevelWasLoaded`**: Unity 6 ya no envía ese mensaje; `U4Compat` envía `OnLevelWasLoadedU6` a todos los GameObjects tras cada carga no aditiva (los tres receptores originales se renombraron para no recibirlo dos veces). Validar el orden respecto a `Start` en la prueba en Unity.
- **Etapa 2 · avisos "Mesh object at version 8 / AnimationClip at version 4, below the supported minimum"**: los 678 `.asset` de malla y 231 clips exportados conservan la versión serializada de Unity 4; Unity los actualiza en memoria al cargarlos (funcionan). Opcional: `AssetDatabase.ForceReserializeAssets` para silenciarlo (cambia miles de archivos; se decidirá antes del build).
- **Etapa 2 · `PlayerInstance.ReleaseCart`**: se omite la rama original `partInSlot.guiText != null` (`Component.guiText`, API eliminada; en el juego nunca es cierta).
- **Etapa 2 · `CharacterConfigData`**: traducido, pero ningún prefab/escena lo contiene. `GetCharacterCost` no lo necesita (lee `CartPartList`); `GetCharacterMessage` sí (error "Scene requires a CharacterConfigData!" + excepción), pero solo se llama para un personaje sin pieza en `CartPartList`, que no existe en los datos. Igual que en el original.
- **Etapa 2 · medallas y misiones**: `AchievementListener.HasAchieved` y los `IsAvailable` de las misiones son de la Etapa 4; mientras tanto las medallas salen en silueta y la pantalla de carga no muestra misiones (se ve el logo grande, que el original muestra cuando no hay misiones activas).
- **Etapa 2 · comportamientos originales conservados**: `LoadingPublisher.Start` crea la corrutina `SetupMissionText` sin arrancarla (la arranca `LoadingProcess`); `WaitForLevelLoad` muestra el progreso de las piezas, no el de la escena; `AnimationDriver.CrossFadeToNewAnimation` deja `inCoroutine` activo si el clip actual es en bucle; `CharacterVOController.PickClip` omite el último paso del barajado.
- **Etapa 1 · `UghSprite`** reutiliza la malla existente sin `Clear()` antes de reasignar vértices, como el original; si Unity 6 protesta por tamaños de índices, añadir `Clear()` (ADAPTADO-U6).

## STILL UNKNOWN
- Valores de coste de piezas (`PartCosts.epa.xml` era remoto).
- Contenido exacto del interruptor remoto de Pranksgiving (se sustituye por interruptor local activado).
