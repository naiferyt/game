# Pendientes que no son "traducir un método", por etapa

Complementa a [METHOD_CATALOG.md](METHOD_CATALOG.md) (métodos del juego por etapa). Aquí están los asuntos de
configuración, compatibilidad y verificación visual detectados hasta ahora, con su evidencia y en qué etapa se resuelven.
Etiquetas: RECUPERADO · RECUPERADO-AOT · ADAPTADO-U6 · RECONSTRUIDO · ELIMINADO.

---

## Etapa 1 — Arranque → Menú principal

| # | Pendiente | Evidencia | Cómo se resuelve |
|---|---|---|---|
| 1.1 | **Arranque sin iCloud**. `CloudStrap.Start` llamaba a `GravCloudPrefs.Load` (iCloud) y, al responder la nube, `ContinueToFrontEnd` hacía `LoadLevel("FrontEndTest")`. | ARM de `CloudStrap` | `Start` → carga local → `ContinueToFrontEnd` (mismo destino, sin esperar a la nube). ELIMINADO la parte iCloud; ADAPTADO-U6 `LoadLevel` → `SceneManager.LoadScene`. |
| 1.2 | **Backend de guardado local**. El modelo de datos original (`CloudSaveData`, `LocalOptionsData`) se guardaba en iCloud (`GravCloudPrefs`/`JCloud`) + PlayerPrefs. | `DataUtility` (60 métodos), `ExternalPersistentArchive` | Se conserva el formato de datos y los métodos `Load/Save` traducidos del ARM; el almacenamiento pasa a archivo local en `Application.persistentDataPath` (RECONSTRUIDO solo el backend). |
| 1.3 | **Globales**: `EnsureGlobals.Awake` llamaba a `MoreGamesBinding.Init` (eliminado) y luego instancia los prefabs globales. | ARM de `EnsureGlobals` | Se traduce sin la llamada a MoreGames (ELIMINADO). |
| 1.4 | **Analítica en el menú**: `FrontEndLogic.Start` envía `player_info`/`soft_currency` con `GDMOManager.SendWithContext`. | ARM de `FrontEndLogic.Start` | Se omite (ELIMINADO); el resto de `Start` se traduce íntegro. |
| 1.5 | **Calidad por modelo de iPhone** (`iPhone.generation` en `QualityControl`, `LowEndInhibitor`, `CausticsManager`, `ParticleReducer`). | llamadas `UnityEngine.iPhone::get_generation` en el ARM | En PC se toma siempre la rama del dispositivo más potente (ADAPTADO-U6). |
| 1.6 | **Pantalla/aspecto**: la UI `Ugh` se diseñó para iPhone/iPad en horizontal (3:2, 16:9 del iPhone 5, 4:3 del iPad). `UghAlign`/`UghStretch` anclan los elementos. | escenas/prefabs, `Screen.orientation` en el ARM | Verificar en 16:9 y 16:10; `Screen.orientation` no aplica en PC (se ignora). Resolución de ventana inicial 1280×720. |
| 1.7 | **Ratón en vez de toque**: `UghInput` usa `Input.touches` y también `Input.mousePosition` (el original ya soportaba ratón en editor/web). | llamadas `Input::get_touches`, `Input::get_mousePosition` | Traducir `UghInput` tal cual; comprobar que el clic funciona en PC. |
| 1.8 | **Idioma**: `Localize` elige idioma con `Application.systemLanguage`; hay `Localize-Default` y `Localize-SW`. La URL de idioma remoto está muerta. | literales `QueryLocalizedLanguageURL`, recursos `languages/` | Solo ficheros locales (ELIMINADO la descarga). |
| 1.9 | **Ajustes**: los botones de compra, Game Center, web Disney, IAP y Age Gate están desactivados en los assets. | `service_cleanup_report.json` | Al traducir `SettingsMenuPublisher`, no reactivarlos (sus handlers quedan como ELIMINADO). |
| 1.10 | **30 métodos de etapas posteriores que el arranque ya ejecuta** (`PlayerInstance.Bootstrap`, `PreviewCart.GenerateCartPreview`, `MusicPlayer.PlayMusic`, `AchievementManager.InitFrontEndAchievements`, `LifetimeMetrics.Load/Save`, `SoundLibrary.ButtonClickPlay`…). | [METHOD_CATALOG.md](METHOD_CATALOG.md#etapa-1--arranque--menú-principal) | En la Etapa 1 se dejan pendientes (devuelven el valor por defecto) **salvo que rompan el flujo**; el garaje se verá sin kart, sin música y sin sonidos de botón hasta sus etapas. Si alguno bloquea el menú, se adelanta. |

---

## Etapa 2 — Menú → selección → carga de la carrera

| # | Pendiente | Evidencia | Cómo se resuelve |
|---|---|---|---|
| 2.1 | **Carga de escenas** `Application.LoadLevel/LoadLevelAsync/loadedLevelName`. | PLT del ARM | `SceneManager.*` (ADAPTADO-U6), mismo orden de escenas del build. |
| 2.2 | **StreamManager**: confirmar que en iOS usaba la rama `RESOURCE` (contenido en `Resources/cart assets`). | enum `StreamType`, literales `IOSBundles/`, `file://` | Leer `PrependRootFileLocation`/`GatherRequiredAssets` en el ARM; la rama AssetBundle se deja compilada con `UnityWebRequestAssetBundle` pero sin uso. |
| 2.3 | **Pranksgiving**: la pista se activaba leyendo `http://datg-apps.com/ss/pranksgiving.txt` (servidor muerto). | literal en `Assembly-CSharp` | Interruptor local **activado por defecto** (decisión D2). |
| 2.4 | **Costes de piezas**: `LoadPartCosts` leía `PartCosts.epa.xml` remoto; el `PartCosts.json` local es una plantilla (“Blah”, 100). | literales, `Resources/PartCosts.json` | Buscar los costes serializados en cada `CartPart`; si no existen, documentar el valor usado (RECONSTRUIDO). |
| 2.5 | **Pinturas del kart**: 8 assets `MultilayerTextureBundleDef` que AssetRipper no pudo leer (tipo de editor). | log de AssetRipper | Leerlos con UnityPy desde `resources.assets` si la vista previa los necesita. |
| 2.6 | **Construcción del kart** (`ConstructCart`, `ComposeCart`, texturas compuestas en tiempo de ejecución). | iteradores `<ConstructCart>`, `<ComposeCart>` | Verificar visualmente el kart del garaje contra las piezas originales. |

---

## Etapa 3 — Carrera mínima

| # | Pendiente | Evidencia | Cómo se resuelve |
|---|---|---|---|
| 3.1 | **Agua sin animar (Fish Hooks)**. El shader `Mobile/Unlit Under The Sea` suma dos muestras de una textura de cáusticos desplazadas por el global `_CausticVector`. `CausticsManager` (en las 3 pistas de Fish Hooks): el constructor fija `causticsVector` con las constantes 3.0, −0.3, −0.9, 1.5; `Start` sustituye el shader por el normal en iPhones antiguos y arranca una corrutina que cada **1/30 s** hace `Shader.SetGlobalVector("_CausticVector", causticsVector × Time.realtimeSinceStartup)`. Sin el script el vector vale 0 → los cáusticos quedan **quietos** (en las capturas del editor la zona se ve muy clara porque los cáusticos son aditivos). | ARM de `CausticsManager` (3 métodos + corrutina), 48 materiales de Fish Hooks usan el shader | Traducir `CausticsManager` (RECUPERADO-AOT); en PC tomar siempre la rama con agua animada. Después comparar el brillo con el original en ejecución. |
| 3.2 | **Física PhysX 2.8 → PhysX moderno**. `CarCollider` integra su propio movimiento (`CAR_GRAVITY=10`), usa raycasts contra la capa Ground (256) y `OnCollision*` contra Collide (1024). | constantes y llamadas del ARM | Validar tras traducir `CarCollider`/`TriFoot`/`SpringConnection`: suelo, rampas, muros, saltos. |
| 3.3 | **`dirt_road2` (Bus Jumper)** pasó de trigger a collider normal (Unity 5+ no admite triggers cóncavos). | validación Etapa 0 | Comprobar que el kart no rebota en esa superficie; si lo hiciera, moverlo a una capa solo para raycasts. |
| 3.4 | **Light probes de Unity 4** no portadas: personajes y karts en movimiento se iluminaban con ellas. | `LightProbes.asset` por escena (formato Unity 4), `m_UseLightProbes` en renderers | Evaluar el aspecto; si hace falta, re-hornear probes con las luces originales (RECONSTRUIDO) o usar ambiente. |
| 3.5 | **Controles de PC**: `PlayerKeyboardControl` original (`KeyEvents`: Accelerate, Break, TurnLeft, TurnRight, Drift, UsePowerup, BuyPowerup, Pause). | enum y ARM de `Awake`/`Update` | Traducir; las teclas por defecto salen del ARM (`dynamicKeys`). |
| 3.6 | **Lightmaps**: verificar brillo (codificación dLDR = ×2, como el original). | Etapa 0 | Comparación visual en ejecución. |
| 3.7 | **Componentes añadidos por `[RequireComponent]`** (SoundSequencer en ruedas, etc.). | log de importación | Comprobar que no alteran nada. |
| 3.8 | `Plane_003` (Phineas Track 2): malla 200×200 frente a collider 2×2. | oráculo de separación | Revisar visualmente. |
| 3.9 | **Punto de entrada de pruebas**: `DebugTrackStrapper` (original) permite abrir una pista directamente con el kart por defecto. | escenas de pista | Traducirlo pronto para probar la carrera sin pasar por el menú. |


**Estado al cerrar la Etapa 3 (2026-09-26, validación 3.9):**
- **Resueltos:**
  - 3.2 física validada: suelo, rampas, muros, turbos y saltos guiados.
  - 3.3 `dirt_road2`: vuelta completa en Bus Jumper sin rebotes.
  - 3.5 controles de PC con las teclas del ARM.
  - 3.9 `DebugTrackStrapper` traducido. Necesita la sesión arrancada (`DataUtility`), como en el original: en pruebas se usa `load:<pista>` del `PlayModeRunner` tras `CloudStrap`.
- **Parciales:**
  - 3.1 `CausticsManager` traducido; el agua anima, pero Fish Hooks se ve muy claro: comparar el brillo con el original.
  - 3.4 **no resuelto**: en carrera los karts y personajes se ven oscuros (sin luces de pista ni light probes); pasa al bloque 4.0.
  - 3.6: las pistas se ven bien; queda comparar el brillo de los lightmaps con el original.
- **Sin revisar:** 3.7 y 3.8. Pasan a la revisión visual de la Etapa 4.
- **Nuevos, fieles al original** (ver `RECOVERY_PROGRESS.md` §3.9): doble carga de la vía de depuración y avisos NaN del medidor de derrape.
---

## Etapa 4 — Sistemas completos

| # | Pendiente | Evidencia | Cómo se resuelve |
|---|---|---|---|
| 4.1 | **Partículas convertidas**: la conversión legacy → Shuriken es aproximada en fuerzas, damping (a 30 fps), escala del elipsoide; `tangentVelocity` de `Sparks` no se mapeó. | `stage0_particles.log` | Ajuste visual caso a caso (ADAPTADO-U6). |
| 4.2 | **Audio**: clips mp3/wav, volumen global (`musicVolumeLevel`, `sfxVolumeLevel`), sonido 3D (rolloff Unity 4 → 6). | PlayerPrefs en el ARM | Traducir `SoundLibrary`/`MusicPlayer`/`SoundSequencer`; revisar volúmenes. |
| 4.3 | **Logros internos**: se mantienen; se quita el envío a Game Center. | `AchievementManager` | ELIMINADO solo el reporte. |
| 4.4 | **Bono diario**: se mantiene (reloj local); se quitan las notificaciones locales de iOS (`NotificationServices`). | PLT del ARM | ELIMINADO las notificaciones. |
| 4.5 | **IA**: rutas grabadas (15–36 por pista), personalidades y estados. | `CarAIPathManager` serializado | Validar que los rivales siguen las rutas grabadas. |
| 4.6 | **Tutorial, misiones, Elimination, rewind** | enums y escenas | Traducir y probar cada modo. |

**Estado al cerrar la Etapa 4 (2026-09-27):**
- **Resueltos:**
  - 4.1 partículas: además de la conversión, sus materiales se habían perdido (magenta); restaurados en las 91 con `forensics/scripts/fix_particle_materials.py`.
  - 4.2 audio probado en editor y ejecutable (música, motor, efectos, público).
  - 4.3 logros internos sin Game Center; 4.4 bono diario sin notificaciones.
  - 4.5 IA: los rivales siguen sus rutas grabadas en las 10 pistas.
  - 4.6 tutorial (pasos del garaje y de Tutorial Track), misiones, Elimination y rebobinado probados.
  - Pendientes de la Etapa 3 que quedaban: 3.1 agua de Fish Hooks y 3.6 lightmaps coinciden con las miniaturas originales; 3.7 `[RequireComponent]` revisado; 3.8 `Plane_003` sin anomalías visibles.
- **Nuevos, corregidos en la validación:** textos una ascendente más abajo (fuente bitmap de Unity 4) y kart frenado por solapes iniciales y triggers en el barrido de `CarCollider` (ver `RECOVERY_PROGRESS.md` §4.10).
- **Conservados del original:** radio de barrido del kart = diámetro (golpe breve al pisar la rampa de Kick Butt 1; choca con muros a 1,2 unidades), pausa al perder el foco.

---

## Después de la Fase 4
- **Android**: `TouchTurnTrack` y `PlayerAccelControl` (input táctil e inclinación), IL2CPP ARM64, safe area, módulo Android de Unity.
- **URP (opcional)**: reescritura de shaders fixed-function y apilado de cámaras de la UI `Ugh`.
