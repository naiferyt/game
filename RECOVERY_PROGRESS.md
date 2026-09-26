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
- [x] 1.1 Banco de pruebas: `PlayModeRunner` (Play Mode desatendido con log de `RecoveryPending`, errores, cambios de escena, capturas y clics simulados vía `RecoveryTestInput`) · `forensics/scripts/mcs_check/compile_check.sh` (compila el C# contra el `UnityEngine.dll` original de Unity 4.3 + un shim de las API de Unity 6: detecta errores sin abrir Unity)
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

### Etapa 2 — Menú → Carrera  ·  Etapa 3 — Carrera mínima  ·  Etapa 4 — Sistemas completos
- [ ] (pendiente)

## Catálogo de trabajo pendiente
- [recovery/catalog/METHOD_CATALOG.md](recovery/catalog/METHOD_CATALOG.md): los 4477 métodos del juego con su etapa (y [CSV](recovery/catalog/METHOD_CATALOG.csv) con token y dirección ARM). Estado tras la Etapa 1: Etapa 1 = 713 recuperados, 0 pendientes; pendientes Etapa 2 = 476 (+18 ya recuperados), Etapa 3 = 436 (+56), Etapa 4 = 1382 (+93); 269 sin uso detectado, 155 sin uso (incluye `Dialog`, `LEDScroller` y `UghScrollView`, que ningún asset ni código instancia), 19 de depuración, 8 para Android, 664 eliminados.
- El catálogo cuenta como recuperados los iteradores/lambdas cuyo token cita el C#, y los constructores triviales (≤52 bytes: solo llaman al constructor base) de las clases traducidas; los métodos listados bajo una cabecera `// ELIMINADO` cuentan como eliminados.
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
| `MiniJSON`: números con cultura invariante | ADAPTADO-U6 | evita fallos con separador decimal "," en Windows |
| 16 shaders built-in → equivalentes Unity 6 (`Legacy Shaders/...`) | ADAPTADO-U6 | mismos shaders de Unity, renombrados |

## ELIMINATED (decisión del usuario, 2026-09-26)
StoreKit, Game Center, iCloud/JCloud/GravCloud/P31, Burstly, GDMO/Tapalytics, MoreGames/More Disney, Email, Age Gate, enlaces legales/web de Disney.
Detalle: `forensics/output/removed_service_scripts.json`, `forensics/output/service_cleanup_report.json` y comentarios `ELIMINADO` en el código.
En la Etapa 1 además: notificaciones locales de iOS del bono diario, aviso de compras de iTunes en la primera ejecución (`Purchase Notification Popup`), tienda de monedas (`FrontEndLogic.NeedMoreCoins`, botones "More Coins"/"BuyCoins" ocultos), botón de Game Center, botones "More Disney", los 4 enlaces de Créditos, analítica GDMO y anuncios Burstly, y la descarga de `PartCosts.epa.xml` (se conserva la caché local cifrada).

## KNOWN ISSUES
- `dirt_road2` (Kick Butt Track 2 / Bus Jumper) era un MeshCollider cóncavo *trigger*: PhysX 2.8 lo admitía y los raycasts de suelo lo detectaban; Unity 5+ no soporta triggers cóncavos. Pasa a collider normal (ADAPTADO-U6). Sin ello, la parrilla de salida no tenía suelo.
- Unity añadió 23 componentes por `[RequireComponent]` del código original (SoundSequencer en 20 prefabs de ruedas, 1 Rigidbody en un botón, 2 MeshRenderer en TextMesh).
- Fish Hooks se ve muy luminosa en las capturas del editor (posible efecto de cáusticos sin animar): revisar en ejecución.
- `Plane_003` (Phineas Track 2): la malla separada mide 200×200, su collider 2×2 (sin explicar; original).
- Parámetros de partículas convertidas son aproximación (fuerzas, damping, `tangentVelocity`): revisar visualmente.
- 151 mallas de UI sin nombre tienen AABB desactualizado desde el original (no afecta).
- Unity inyecta paquetes por defecto (compras/analytics) al abrir un proyecto "antiguo": el manifest se limitó a módulos integrados.
- En esta máquina Unity necesita `DOTNET_gcServer=0` y `DOTNET_GCHeapHardLimit` para que sus compiladores .NET arranquen (memoria comprometible libre ~5 GB).

- **Etapa 1 · `ShiftUIPublisher.Start`**: llama a `UpdateCharacterIcon(PlayerInstance.GetCartSlot(character).partInSlot.UIName.baseText)`; hasta recuperar `PlayerInstance.Bootstrap` y `CartPartList` (Etapa 2, piezas del kart) la ranura es nula y se registra **una** `NullReferenceException` al entrar al garaje (el icono de personaje de la palanca no se actualiza; el resto funciona).
- **Etapa 1 · `Fader SpriteAtlas.mat` aparece modificado tras jugar en el editor**: `ScreenFader` (original) cambia la opacidad del material compartido; en el editor Unity lo guarda en el `.mat`. Es inofensivo (en un build no persiste); descartar ese cambio con `git checkout` antes de hacer commit.
- **Etapa 1 → 2 · PLAY no abre "Circuit Select"** hasta recuperar `PreviewCart.StartDriveout`/`IsLoading` (Etapa 2).
- **Etapa 1 · `Trying to save, but there is a null value?`** (×2) al pulsar PLAY: aviso del propio `DataUtility.Save` original con un valor aún nulo (probablemente la ranura del kart, Etapa 2); revisar en la Etapa 2.
- **Etapa 1 · `FrontEndLogic.NeedMoreCoins`** eliminado con la tienda: el aviso informativo "Need More Tokens" que mostraba ese mismo popup (sin compra) tampoco aparece; revisar en la Etapa 4 (compra de piezas) si hace falta un aviso local.
- **Etapa 1 · comportamientos originales conservados tal cual**: `FadeHelper.IsFading(Transform)` solo termina si la jerarquía tiene algún `Renderer` (los menús siempre lo tienen); `Dialog.Awake` arrancaba su corrutina `Start` además de la que lanza Unity; `Mathfx.Parameter` interpola la primera mitad con `(0.5 - value) * 2`; `AudioCrumb.Play` aplica el volumen de efectos dos veces; `FrontEndCamera.SetCameraTargetByIndex` acepta `index == Length`.
- **Etapa 1 · puente `OnLevelWasLoaded`**: Unity 6 ya no envía ese mensaje; `U4Compat` envía `OnLevelWasLoadedU6` a todos los GameObjects tras cada carga no aditiva (los tres receptores originales se renombraron para no recibirlo dos veces). Validar el orden respecto a `Start` en la prueba en Unity.
- **Etapa 1 · `UghSprite`** reutiliza la malla existente sin `Clear()` antes de reasignar vértices, como el original; si Unity 6 protesta por tamaños de índices, añadir `Clear()` (ADAPTADO-U6).

## STILL UNKNOWN
- Valores de coste de piezas (`PartCosts.epa.xml` era remoto).
- Contenido exacto del interruptor remoto de Pranksgiving (se sustituye por interruptor local activado).
