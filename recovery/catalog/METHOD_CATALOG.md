# Catálogo de métodos del juego por etapa

Generado por `forensics/scripts/method_catalog.py` + `catalog_md.py` a partir de los listados ARM originales
(`recovery/aot_listings/`). Tabla completa (un método por fila, con token y dirección ARM): [METHOD_CATALOG.csv](METHOD_CATALOG.csv).

## Cómo se asignó la etapa

1. **Sistema de la clase** según el plan (RECOVERY_REPORT.md §11.6): arranque, UI, menú, selección, construcción del kart, carrera, vehículo, pista, cámaras, HUD, IA, power-ups, audio, misiones…
2. **Grafo de llamadas original** extraído del ARM: llamadas directas y PLT, candidatos de llamadas virtuales/interfaz, delegados, corrutinas y lambdas, constructores estáticos, métodos invocados por nombre (`SendMessage`/`Invoke`/`StartCoroutine`) y `AddComponent<T>`.
3. **Raíces por etapa**: los componentes que de verdad contienen las escenas/prefabs de cada etapa (YAML) — sus `Awake/Start/Update/On*`, constructores — y los botones `Ugh` (`functionName`) de esos menús.

- Clases de sistemas concretos → etapa de su sistema.
- Clases de utilidades compartidas → la **primera etapa desde la que se ejecutan**.
- Columna **“se ejecuta ya en Etapa N”**: el método pertenece a una etapa posterior pero el flujo original lo llama antes. Mientras no se traduzca, `RecoveryPending` lo registrará y devolverá el valor por defecto; hay que comprobar que eso no rompa el flujo (si lo rompe, se adelanta su traducción).

## Resumen

| Etapa | Pendientes | ARM pendiente | Recuperados | Llamados antes de su etapa |
|---|---:|---:|---:|---:|
| Etapa 1 — Arranque → Menú principal | 0 | 0 KB | 713 | 0 |
| Etapa 2 — Menú → selección → carga de la carrera | 0 | 0 KB | 494 | 11 |
| Etapa 3 — Carrera mínima (conducir, vueltas, meta, resultados) | 419 | 153 KB | 73 | 7 |
| Etapa 4 — Sistemas completos | 1327 | 260 KB | 148 | 69 |
| Port Android (después de la Fase 4) | 8 | 1 KB | 0 | 0 |
| Opcional — herramientas de depuración del equipo original | 19 | 3 KB | 0 | 0 |
| Sin uso detectado (no se traducen salvo que aparezcan en el log) | 269 | 78 KB | 0 | 0 |
| Sin uso (scripts UnityScript sin referencias) | 155 | 49 KB | 0 | 0 |
| Eliminados (servicios iOS/externos) | 0 | 0 KB | 0 | 0 |
| Sin código nativo (abstract / extern) | 0 | 0 KB | 0 | 0 |

---

## Etapa 1 — Arranque → Menú principal

**Métodos de etapas posteriores que el flujo original ya ejecuta aquí** (9) — deben tolerar quedar pendientes o adelantarse:

- Etapa 4 · `AchievementListener`: `Fail`
- Etapa 4 · `BaseEffect`: `InitComboLookup`
- Etapa 4 · `CartCustomizerPublisher`: `Refresh`
- Etapa 4 · `MusicPlayer`: `PlayMusic`, `UpdateVolume`, `get_Instance`
- Etapa 4 · `SoundLibrary`: `ButtonClickPlay`, `PlayRandomWhoosh`

### Framework UI propio (Ugh) — 285 métodos, 77.8 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `ConfirmationPublisher` | ✅ `.ctor` (52), ✅ `Close` (72), ✅ `DestroyThis` (72), ✅ `PressedNo` (88), ✅ `PressedYes` (88), ✅ `Start` (48), ✅ `Update` (44) |
| `ConfirmationPublisher/<Close>c__Iterator55` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (264), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ConfirmationPublisher/<DestroyThis>c__Iterator56` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (340), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `GenericPopupPublisher` | ✅ `.ctor` (52), ✅ `DestroyThis` (72), ✅ `PressedBacking` (104), ✅ `SetText` (100), ✅ `Start` (48), ✅ `Update` (44) |
| `GenericPopupPublisher/<DestroyThis>c__Iterator5D` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (340), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `InputBlocker` | ✅ `.ctor` (52), ✅ `FadeOut` (80), ✅ `FadeOutHelper` (72), ✅ `Start` (72) |
| `InputBlocker/<FadeOutHelper>c__Iterator2B` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (832), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `InputBlocker/<Start>c__Iterator2A` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (832), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PopoverPublisher` | ✅ `.ctor` (268), ✅ `FixedUpdate` (824), ✅ `PressedBacking` (80), ✅ `SetText` (100), ✅ `Start` (224) |
| `ShiftContentsOnButtonDown` | ✅ `.ctor` (220), ✅ `OnDisable` (272), ✅ `OnDownHandler` (1236), ✅ `OnEnable` (272) |
| `ShiftContentsOnToggleDown` | ✅ `.ctor` (220), ✅ `OnDisable` (272), ✅ `OnDownHandler` (1216), ✅ `OnEnable` (272) |
| `UghAlign` | ✅ `.ctor` (84), ✅ `Align` (1732), ✅ `AlignToScreen` (540), ✅ `AlignToSprite` (560), ✅ `OnDisable` (152), ✅ `OnDrawGizmos` (80), ✅ `OnEnable` (312), ✅ `OnMPDirtyAlign` (84), ✅ `Start` (52), ✅ `Update` (68), ✅ `get_IsDirty` (52), ✅ `set_IsDirty` (60) |
| `UghButton` | ✅ `.ctor` (52), ✅ `OnMouseEnter` (100), ✅ `OnMouseExit` (120), ✅ `OnUghInputDown` (72), ✅ `OnUghInputUp` (120), ✅ `OnUghInputUpAsButton` (204) |
| `UghButton/<OnUghInputDown>c__Iterator1B` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (200), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `UghButtonDisablable` | ✅ `.ctor` (52), ✅ `OnUghInputDown` (72), ✅ `OnUghInputUpAsButton` (92), ✅ `SetLock` (100), ✅ `Start` (56), ✅ `ToggleLock` (104) |
| `UghButtonDisablable/<OnUghInputDown>c__Iterator1C` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (160), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `UghCamera` | ✅ `.cctor` (76), ✅ `.ctor` (228), ✅ `OnLevelWasLoaded` (88), ✅ `Reset` (52), ✅ `ResetCamera` (400), ✅ `ResetCameraPosition` (224), ✅ `ScreenAnchorToPosition` (2324), ✅ `Start` (60), ✅ `Update` (72), ✅ `get_Aspect` (168), ✅ `get_CameraPixelSize` (192), ✅ `get_Instance` (552), ✅ `get_ScreenExtents` (132), ✅ `get_ScreenSize` (240) |
| `UghControl` | ✅ `.cctor` (36), ✅ `.ctor` (60), ✅ `AutoSizeCollider` (528), ✅ `OnDrawGizmos` (108), ✅ `OnUghInputDown` (64), ✅ `OnUghInputDrag` (44), ✅ `OnUghInputUp` (44), ✅ `OnUghInputUpAsButton` (44), ✅ `OnUghInputUpLate` (44), ✅ `Reset` (188), ✅ `get_HotFingerID` (52), ✅ `get_isLegalControl` (152), ✅ `set_HotFingerID` (60) |
| `UghControl/<OnUghInputDown>c__Iterator1A` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (68), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `UghHeldButton` | ✅ `.ctor` (52), ✅ `OnButtonDown` (44), ✅ `OnButtonHeld` (44), ✅ `OnButtonUp` (44), ✅ `SetButtonVisualState` (128), ✅ `Update` (592), ✅ `get_isDown` (52), ✅ `set_isDown` (64) |
| `UghInput` | ✅ `.ctor` (104), ✅ `<TouchBeginEvent>m__6` (228), ✅ `<TouchEndedEvent>m__7` (228), ✅ `Awake` (80), ✅ `InputToWorldPoint` (144), ✅ `LateUpdate` (696), ✅ `Touch` (44), ✅ `TouchBeginEvent` (724), ✅ `TouchCanceledEvent` (252), ✅ `TouchEndedEvent` (1280), ✅ `TouchPersistEvent` (416), ✅ `get_InputPosition` (176), ✅ `get_InputPositionInWorldSpace` (144), ✅ `get_Instance` (516), ✅ `get_IsInputDown` (88), ✅ `get_UseTouchInput` (44) |
| `UghPublisher` | ✅ `.ctor` (52), ✅ `Awake` (332), ✅ `GetButton` (72), ✅ `GetSprite` (236), ✅ `OnButtonPressed` (184), ✅ `get_ledScrollers` (52), ✅ `get_transforms` (52), ✅ `get_ughButtons` (52), ✅ `get_ughSlideToggles` (52), ✅ `get_ughSliders` (52), ✅ `get_ughTexts` (52) |
| `UghPublisher/<GetSprite>c__AnonStorey2A` | ✅ `.ctor` (44), ✅ `<>m__8` (84) |
| `UghPublisher/LEDScrollerReference` | ✅ `.ctor` (44) |
| `UghPublisher/LEDScrollersDictionary` | ✅ `.ctor` (188), ✅ `get_Item` (72) |
| `UghPublisher/TransformReference` | ✅ `.ctor` (44) |
| `UghPublisher/TransformsDictionary` | ✅ `.ctor` (188), ✅ `get_Item` (72) |
| `UghPublisher/UghButtonReference` | ✅ `.ctor` (44) |
| `UghPublisher/UghButtonsDictionary` | ✅ `.ctor` (188), ✅ `get_Item` (72) |
| `UghPublisher/UghSlideToggleDictionary` | ✅ `.ctor` (188), ✅ `get_Item` (72) |
| `UghPublisher/UghSlideToggleReference` | ✅ `.ctor` (44) |
| `UghPublisher/UghSliderDictionary` | ✅ `.ctor` (188), ✅ `get_Item` (72) |
| `UghPublisher/UghSliderReference` | ✅ `.ctor` (44) |
| `UghPublisher/UghTextReference` | ✅ `.ctor` (44) |
| `UghPublisher/UghTextsDictionary` | ✅ `.ctor` (188), ✅ `get_Item` (72) |
| `UghSlideToggle` | ✅ `.ctor` (76), ✅ `AutoSizeCollider` (44), ✅ `Awake` (84), ✅ `LocalPositionForInput` (488), ✅ `OnUghInputDown` (72), ✅ `OnUghInputUp` (56), ✅ `OnUghInputUpAsButton` (56), ✅ `SendOnChanged` (76), ✅ `Update` (64), ✅ `UpdateMeshWithSpritePrototype` (2936), ✅ `UpdateRealDeltaTime` (132), ✅ `get_State` (52), ✅ `set_State` (160) |
| `UghSlideToggle/<OnUghInputDown>c__Iterator23` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (2464), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `UghSlider` | ✅ `.ctor` (76), ✅ `Awake` (104), ✅ `LocalPositionForInput` (488), ✅ `OnUghInputDown` (72), ✅ `OnUghInputUp` (64), ✅ `OnUghInputUpAsButton` (64), ✅ `UpdatePosition` (484), ✅ `get_Current` (100), ✅ `get_CurrentNormalized` (64), ✅ `set_Current` (116), ✅ `set_CurrentNormalized` (128) |
| `UghSlider/<OnUghInputDown>c__Iterator24` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (672), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `UghSprite` | ✅ `.ctor` (60), ✅ `AnchorToTextAnchor` (176), ✅ `GetLocalCenter` (372), ✅ `GetLocalOrigin` (184), ✅ `GetOffsetForAnchor` (1564), ✅ `GetParentPublisher` (160), ✅ `GetUVArray` (1540), ✅ `MeshColumnCount` (156), ✅ `MeshRowCount` (156), ✅ `MeshVertexCount` (72), ✅ `OnDisable` (184), ✅ `OnDrawGizmos` (116), ✅ `OnEnable` (80), ✅ `TextAnchorToAnchor` (176), ✅ `UpdateMesh` (116), ✅ `UpdateMeshWithSpritePrototype` (19888), ✅ `get_Offset` (108), ✅ `get_Prototype` (52), ✅ `set_Prototype` (112) |
| `UghSpritePrototype` | ✅ `.ctor` (316), ✅ `CreateSprite` (380), ✅ `OnEnable` (52), ✅ `UpdatePrototype` (1220) |
| `UghStretch` | ✅ `.ctor` (60), ✅ `Align` (2096), ✅ `DoSignalDirtyAlign` (108), ✅ `OnDrawGizmos` (52), ✅ `Start` (52), ✅ `Update` (68), ✅ `add_HandleMPDirtyAlign` (160), ✅ `get_IsDirty` (52), ✅ `remove_HandleMPDirtyAlign` (160), ✅ `set_IsDirty` (60) |
| `UghText` | ✅ `.ctor` (244), ✅ `AutoInheritText` (44), ✅ `ForceUpdate` (144), ✅ `GetParentPublisher` (160), ✅ `OnDrawGizmos` (64), ✅ `SetTextMeshAndWordWrap` (1996), ✅ `Start` (52), ✅ `UpdateDropShadow` (904), ✅ `get_Text` (68), ✅ `set_Text` (68) |
| `UghToggle` | ✅ `.ctor` (52), ✅ `GetUghSpritePrototypeForCurrentState` (108), ✅ `OnMouseExit` (100), ✅ `OnUghInputDown` (72), ✅ `OnUghInputUp` (116), ✅ `OnUghInputUpAsButton` (148), ✅ `SendOnChanged` (76), ✅ `UpdateMeshForCurrentState` (72), ✅ `get_HighlightState` (52), ✅ `get_State` (52), ✅ `set_HighlightState` (64), ✅ `set_State` (72) |
| `UghToggle/<OnUghInputDown>c__Iterator25` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (160), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `UghTriangle` | ✅ `.ctor` (512), ✅ `.ctor` (140), ✅ `AddToMeshList` (648), ✅ `MakeQuad` (1032) |

### Menú principal / garaje — 149 métodos, 33.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CameraShake` | ✅ `.ctor` (124), ✅ `Start` (64), ✅ `TurnOffShake` (108), ✅ `TurnOnShake` (188), ✅ `TurnOnStationaryShake` (316), ✅ `Update` (2000), ✅ `get_IsShaking` (52), ✅ `get_IsStationary` (52), ✅ `set_IsStationary` (60) |
| `CreditsPublisher` | ✅ `.ctor` (52), ✅ `PressedBackButton` (64), ✅ `PressedCustomerSupport` (68), ✅ `PressedLinkButton` (68), ✅ `PressedPrivacyButton` (68), ✅ `PressedTermsOfUseButton` (68), ✅ `Start` (44), ✅ `Update` (44) |
| `DailyBonusPublisher` | ✅ `.ctor` (52), ✅ `DestroyThis` (72), ✅ `OnPressed` (80), ✅ `Start` (48), ✅ `Update` (44) |
| `DailyBonusPublisher/<DestroyThis>c__Iterator57` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (340), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `FrontEndCamera` | ✅ `.ctor` (236), ✅ `FixedUpdate` (504), ✅ `ForceCameraTarget` (68), ✅ `SetCameraTarget` (128), ✅ `SetCameraTargetByIndex` (148), ✅ `Start` (108), ✅ `StartTransition` (684), ✅ `get_isTransitioning` (80) |
| `FrontEndCameraTarget` | ✅ `.ctor` (52), ✅ `OnDrawGizmos` (316) |
| `FrontEndLogic` | ✅ `.cctor` (60), ✅ `.ctor` (60), ✅ `CheckForDailyBonus` (1200), ✅ `CheckMenuTransitionOK` (88), ✅ `GetInstance` (168), ✅ `GiveDailyBonus` (948), ✅ `HideMenu` (112), ✅ `HideMenuHelper` (72), ✅ `NeedMoreCoins` (992), ✅ `OnApplicationPause` (96), ✅ `PlayRandomWhoosh` (116), ✅ `PopupDailyBonusNote` (460), ✅ `RequestMenuChange` (268), ✅ `Start` (1280), ✅ `StartMenuTransition` (72), ✅ `Update` (360), ✅ `get_CurrentMenu` (52) |
| `FrontEndLogic/<CheckMenuTransitionOK>c__Iterator59` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (484), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `FrontEndLogic/<HideMenuHelper>c__Iterator58` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (308), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `FrontEndLogic/<RequestMenuChange>c__AnonStoreyA0` | ✅ `.ctor` (44), ✅ `<>m__24` (68) |
| `FrontEndLogic/MenuStruct` | ✅ `.ctor` (44) |
| `LiftControlAI` | ✅ `.ctor` (124), ✅ `FixedUpdate` (372), ✅ `SetTransition` (208), ✅ `Start` (104) |
| `PlayMenuPublisher` | ✅ `.ctor` (52), ✅ `PressedInfo` (148), ✅ `PressedMoreDisney` (80), ✅ `PressedPlayButton` (164), ✅ `PressedSettings` (128), ✅ `Start` (364), ✅ `StartTutLoad` (64), ✅ `StartTutorial` (264), ✅ `Update` (128) |
| `PlayMenuPublisher/<StartTutLoad>c__Iterator65` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (188), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `SettingsMenuPublisher` | ✅ `.ctor` (52), ✅ `CheckResetConfirm` (72), ✅ `OnAppPurchaseToggleChanged` (260), ✅ `OnDebugCoinPressed` (72), ✅ `OnDebugUnlockPressed` (52), ✅ `OnMusicVolumeChanged` (124), ✅ `OnSFXVolumeChanged` (92), ✅ `PressedBuyCoins` (76), ✅ `PressedCredits` (64), ✅ `PressedGameCenter` (92), ✅ `PressedMoreDisney` (80), ✅ `PressedResetData` (80), ✅ `Start` (1656), ✅ `UnlockAll` (316), ✅ `Update` (196) |
| `SettingsMenuPublisher/<CheckResetConfirm>c__Iterator71` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (796), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ShiftUIPublisher` | ✅ `.ctor` (108), ✅ `Awake` (3040), ✅ `Hide` (464), ✅ `PlayRandomShiftSound` (108), ✅ `PressedCartCustomizer` (96), ✅ `PressedCharacter` (96), ✅ `PressedMoreCoins` (88), ✅ `PressedMoreDisney` (100), ✅ `PressedOptions` (96), ✅ `PressedPlayButton` (96), ✅ `PressedTrophy` (96), ✅ `SetStickPosition` (292), ✅ `ShiftSurfaceCoroutine` (180), ✅ `Show` (464), ✅ `Start` (476), ✅ `SwitchSlot` (1092), ✅ `Update` (436), ✅ `UpdateCharacterIcon` (488), ✅ `add_ChangedShifterSlot` (160), ✅ `remove_ChangedShifterSlot` (160) |
| `ShiftUIPublisher/<ShiftSurfaceCoroutine>c__Iterator72` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (656), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ShiftUIPublisher/Icon` | ✅ `.ctor` (44) |
| `ShiftUIPublisher/ShiftKeyframe` | ✅ `.ctor` (80) |
| `ShiftUIPublisher/ShifterPosition` | ✅ `.ctor` (112), ✅ `Lerp` (340) |
| `ShiftUIPublisher/ShifterSlot` | ✅ `.ctor` (72) |
| `VolumeSlider` | ✅ `.ctor` (256), ✅ `MouseLogic` (84), ✅ `OnMouseDown` (160), ✅ `OnMouseUp` (56), ✅ `TouchLogic` (684), ✅ `Update` (776), ✅ `get_percent` (180), ✅ `set_percent` (360) |

### Arranque y globales — 133 métodos, 27.4 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CloudStrap` | ✅ `.ctor` (52), ✅ `ContinueToFrontEnd` (276), ✅ `Start` (268) |
| `EnsureGlobals` | ✅ `.ctor` (52), ✅ `Awake` (296) |
| `FadeHelper` | ✅ `.cctor` (36), ✅ `.ctor` (148), ✅ `<CleanNullEntries>m__8` (76), ✅ `<CleanNullEntries>m__9` (76), ✅ `CleanNullEntries` (392), ✅ `Fade` (244), ✅ `Fade` (164), ✅ `Fade` (460), ✅ `Fade` (1604), ✅ `FadeRecursively` (1388), ✅ `Fader` (124), ✅ `GetAllChildren` (708), ✅ `IsFading` (1552), ✅ `IsFading` (236), ✅ `SetOpacity` (464), ✅ `SetOpacity` (632), ✅ `SetOpacityRecursively` (1380), ✅ `get_Instance` (256) |
| `FadeHelper/<Fade>c__AnonStorey92` | ✅ `.ctor` (44), ✅ `<>m__6` (88), ✅ `<>m__7` (88) |
| `FadeHelper/<Fader>c__Iterator29` | ✅ `.ctor` (44), ✅ `<>m__A` (92), ✅ `<>m__B` (88), ✅ `<>m__C` (92), ✅ `<>m__D` (92), ✅ `Dispose` (56), ✅ `MoveNext` (4580), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `FadeHelper/<IsFading>c__AnonStorey91` | ✅ `.ctor` (44), ✅ `<>m__5` (88) |
| `LocalizeCloudStrap` | ✅ `.ctor` (52), ✅ `Awake` (404), ✅ `Start` (44), ✅ `Update` (44) |
| `LowEndInhibitor` | ✅ `.ctor` (160), ✅ `Start` (204) |
| `PreFrontEndHoop` | ✅ `.ctor` (52), ✅ `Start` (64) |
| `PreFrontEndHoop/<Start>c__Iterator86` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (404), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `QualityControl` | ✅ `Apply` (116), ✅ `get_DoDummiedPlayerCollision` (48), ✅ `get_DoFullAI` (48), ✅ `get_DoFullTriFoot` (48), ✅ `get_DoPerFrameCollision` (48), ✅ `get_DoPhysicsAt30fps` (48), ✅ `get_IsGameHardcore` (40) |
| `RotatorAI` | ✅ `.ctor` (96), ✅ `RotateCoroutine` (72), ✅ `Start` (204) |
| `RotatorAI/<RotateCoroutine>c__Iterator4` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (388), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ScreenFade` | ✅ `.cctor` (36), ✅ `.ctor` (52), ✅ `Fade` (88), ✅ `Fade` (96), ✅ `FadeHelper` (124), ✅ `LoadLevelWithFade` (72), ✅ `LoadSceneHelper` (80), ✅ `Start` (124), ✅ `get_FadedAmount` (64), ✅ `get_Instance` (248), ✅ `get_IsFaded` (100), ✅ `get_IsFading` (52), ✅ `set_FadedAmount` (384), ✅ `set_IsFaded` (172) |
| `ScreenFade/<FadeHelper>c__Iterator28` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (836), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ScreenFade/<LoadSceneHelper>c__Iterator29` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (168), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ScreenFader` | ✅ `.cctor` (36), ✅ `.ctor` (84), ✅ `CreateScreenFader` (296), ✅ `FadeIn` (96), ✅ `FadeInHelper` (72), ✅ `FadeOut` (96), ✅ `FadeOutHelper` (72), ✅ `LoadLevel` (108), ✅ `LoadLevel` (84), ✅ `OnLevelWasLoaded` (88), ✅ `Start` (684), ✅ `Update` (132), ✅ `get_Instance` (248) |
| `ScreenFader/<FadeInHelper>c__Iterator8C` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (592), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ScreenFader/<FadeOutHelper>c__Iterator8D` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (524), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ScreenTimeoutController` | ✅ `.cctor` (36), ✅ `.ctor` (52), ✅ `AllowSleep` (84), ✅ `OnDestroy` (48), ✅ `SupressSleep` (152), ✅ `Update` (320) |
| `SingletonScript` | ✅ `.ctor` (44) |
| `SingletonScript`1` | ✅ `.ctor` (52), ✅ `Existed` (68), ✅ `Exists_VERY_EXPENSIVE` (88), ✅ `ForceReload` (84), ✅ `OnLevelWasLoaded` (92), ✅ `SingletonCreated` (44), ✅ `get_i` (356) |

### Guardado local y datos globales — 59 métodos, 15.2 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CloudSaveData` | ✅ `.ctor` (112), ✅ `get_CurrentCloudSaveDataVersion` (40) |
| `DataUtility` | ✅ `.cctor` (36), ✅ `AddPlayerMoney` (96), ✅ `AddPlayerMoney` (128), ✅ `AddSnapshot` (152), ✅ `Awake` (88), ✅ `BuyItem` (236), ✅ `CleanupAllSnapShots` (656), ✅ `CleanupSnapShots` (552), ✅ `DoActualPurchase` (140), ✅ `GetSnapshot` (168), ✅ `IsCurrentPaint` (280), ✅ `IsUnlocked` (144), ✅ `Load` (2752), ✅ `OnApplicationPause` (124), ✅ `OnApplicationQuit` (72), ✅ `OnDisable` (844), ✅ `OnEnable` (820), ✅ `PrependBundlePath` (220), ✅ `Relock` (152), ✅ `Save` (1348), ✅ `SetCartPaint` (340), ✅ `SetCartPart` (340), ✅ `Start` (160), ✅ `Unlock` (216), ✅ `get_CurSettings` (52), ✅ `get_Exists` (64), ✅ `get_Instance` (256), ✅ `get_PopupDone` (52), ✅ `get_playerCoins` (56), ✅ `set_CurSettings` (92), ✅ `set_PopupDone` (60) |
| `ExternalPersistentArchive` | ✅ `.cctor` (120), ✅ `.ctor` (92), ✅ `Decode` (632), ✅ `DecryptLocal` (360), ✅ `Encode` (560), ✅ `ExternalPersistanceCoroutine` (72), ✅ `LoadFromWebCoroutine` (88), ✅ `Serialize` (216), ✅ `Start` (88), ✅ `get_TextData` (52), ✅ `set_TextData` (64) |
| `ExternalPersistentArchive/<ExternalPersistanceCoroutine>c__Iterator6` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (704), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `ExternalPersistentArchive/<LoadFromWebCoroutine>c__Iterator5` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (500), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LocalOptionsData` | ✅ `.ctor` (120), ✅ `Load` (288), ✅ `Save` (204) |

### Utilidades compartidas — 39 métodos, 12.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `AnimatedTexture` | ✅ `.ctor` (148), ✅ `Start` (376), ✅ `Update` (44) |
| `AnimatedTexture/<UpdateTexture>c__Iterator1A` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (688), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `AudioCrumb` | ✅ `Play` (240) |
| `AudioSourcex` | ✅ `PlayClipAtPosition` (532) |
| `DictionaryToString` | ✅ `Parse` (760), ✅ `ToString` (728) |
| `EdgePixels` | ✅ `DeepCopy` (128) |
| `MiniJSON` | ✅ `.cctor` (100), ✅ `eatWhitespace` (164), ✅ `getLastIndexOfNumber` (152), ✅ `jsonDecode` (216), ✅ `jsonEncode` (132), ✅ `lookAhead` (76), ✅ `nextToken` (1048), ✅ `parseArray` (296), ✅ `parseNumber` (184), ✅ `parseObject` (356), ✅ `parseString` (1092), ✅ `parseValue` (380), ✅ `serializeArray` (252), ✅ `serializeDictionary` (560), ✅ `serializeNumber` (88), ✅ `serializeObject` (396), ✅ `serializeString` (620), ✅ `serializeValue` (1532) |
| `Rangef` | ✅ `.ctor` (96), ✅ `.ctor` (88), ✅ `Clamp` (132), ✅ `Lerp` (132) |
| `Script` | ✅ `.ctor` (52), ✅ `Instantiate` (168), ✅ `Instantiate` (80) |

### Localización — 48 métodos, 7.4 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `LanguageAsset` | ✅ `.ctor` (96) |
| `Localize` | ✅ `.cctor` (36), ✅ `.ctor` (72), ✅ `<Awake>m__4` (80), ✅ `Awake` (316), ✅ `Get` (580), ✅ `GetBaseURL` (140), ✅ `GetDynamicKeys` (1036), ✅ `GetURL` (308), ✅ `LoadDefaultLanguage` (140), ✅ `LoadKeys` (376), ✅ `LoadLanguage` (436), ✅ `LoadLanguageAsset` (288), ✅ `UseLocalizedLanguage` (76), ✅ `UseLocalizedLanguageHelper` (88), ✅ `WebLoadingHelper` (72) |
| `Localize/<UseLocalizedLanguageHelper>c__Iterator9` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (768), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `Localize/<WebLoadingHelper>c__Iterator8` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (268), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LocalizedAssetSwapper` | ✅ `.ctor` (52), ✅ `Start` (72) |
| `LocalizedAssetSwapper/<Start>c__Iterator3F` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (704), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LocalizedString` | ✅ `.ctor` (72), ✅ `.ctor` (84), ✅ `ToString` (64), ✅ `get_Text` (56) |
| `UnlocalizedString` | ✅ `.ctor` (72), ✅ `.ctor` (84), ✅ `ToString` (52), ✅ `UnlocalizedStringMarker` (48), ✅ `get_Text` (52), ✅ `op_Addition` (60), ✅ `op_Implicit` (80), ✅ `op_Implicit` (52) |


---

## Etapa 2 — Menú → selección → carga de la carrera

**Métodos de etapas posteriores que el flujo original ya ejecuta aquí** (1) — deben tolerar quedar pendientes o adelantarse:

- Etapa 3 · `RaceManager`: `InitRace`

### Construcción del kart y vista previa — 231 métodos, 67.4 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `AlternateForm` | ✅ `.ctor` (52), ✅ `FindFirstWithForm` (180), ✅ `GetBodyForm` (140), ✅ `IndexOf` (156) |
| `AlternateForm/FormData` | ✅ `.ctor` (44) |
| `CartAttributes` | ✅ `.ctor` (404), ✅ `CompareAcceleration` (104), ✅ `CompareHandlingRating` (104), ✅ `ComparePowerSlide` (104), ✅ `CompareSpeed` (104), ✅ `GetAccelerationRating` (212), ✅ `GetHandlingRating` (296), ✅ `GetPowerSlideRating` (276), ✅ `GetSpeedRating` (212), ✅ `get_MaxAttributes` (388), ✅ `get_MinAttributes` (388), ✅ `op_Addition` (512), ✅ `op_Subtraction` (512) |
| `CartPart` | ✅ `.ctor` (52), ✅ `GetAlternatePartOfForm` (212), ✅ `get_AreAllAlternateFormsLocked` (180), ✅ `get_IsLocked` (112), ✅ `get_bodyFormType` (200) |
| `CartPartList` | ✅ `.ctor` (52), ✅ `CartPartListExists` (136), ✅ `GetAllPaintJobs` (44), ✅ `GetAllParts` (44), ✅ `GetDefaultParts` (44), ✅ `GetInstance` (168), ✅ `GetMostExpensiveAffordablePart` (212), ✅ `GetMostExpensiveUnlockableAffordablePart` (1060), ✅ `GetNextPurchasablePartForSlot` (164), ✅ `GetPaintJob` (160), ✅ `GetPart` (300), ✅ `GetSlotPaintJobList` (80), ✅ `GetSlotPartList` (80), ✅ `LoadPartCosts` (1612), ✅ `ModifyPartCostsCoroutine` (72), ✅ `OnDisable` (276), ✅ `OnEnable` (276), ✅ `OnExternalArchiveRead` (64), ✅ `Start` (1700) |
| `CartPartList/<LoadPartCosts>c__AnonStorey90` | ✅ `.ctor` (44), ✅ `<>m__2` (72), ✅ `<>m__3` (72) |
| `CartPartList/<ModifyPartCostsCoroutine>c__Iterator1F` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (260), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `CartPrimaryTextureProfile` | ✅ `.ctor` (52), ✅ `Awake` (156), ✅ `get_profile` (124) |
| `CartSlot` | ✅ `.cctor` (3364), ✅ `.ctor` (60), ✅ `GetCustomizerCameraPosition` (168), ✅ `GetCustomizerCameraTarget` (168), ✅ `GetIsSlotRequired` (108), ✅ `GetSlotName` (112), ✅ `GetSlotTargetGameObjectName` (112), ✅ `get_name` (116), ✅ `get_required` (112), ✅ `get_targetGameObjectName` (116) |
| `CharacterConfigData` | ✅ `.ctor` (52), ✅ `GetCharacterCost` (84), ✅ `GetCharacterIsSyncable` (48), ✅ `GetCharacterMessage` (340), ✅ `GetCharacterUnlockString` (132), ✅ `LoadDefaultConfig` (168), ✅ `LoadWebConfig` (72), ✅ `OnDisable` (276), ✅ `OnEnable` (276), ✅ `OnExternalArchiveRead` (64), ✅ `ProcXML` (1348), ✅ `Start` (100), ✅ `get_Instance` (176) |
| `CharacterConfigData/<LoadWebConfig>c__Iterator1D` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (260), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `CharacterConfigData/ConfigData` | ✅ `.ctor` (44) |
| `CharacterPreview` | ✅ `.ctor` (104), ✅ `Blackout` (428), ✅ `Hide` (276), ✅ `OnDestroy` (100), ✅ `PlayRandomIdleAnimation` (780), ✅ `Refresh` (88) ⚠Etapa 1, ✅ `SetCharacter` (576), ✅ `Unhide` (284), ✅ `Update` (2176) |
| `CharacterPreview/PreviewPart` | ✅ `.ctor` (44) |
| `CompositeProfile` | ✅ `.ctor` (52), ✅ `FindSlotByName` (172), ✅ `SetSlotSource` (176) |
| `CompositeProfile/CompositeSlot` | ✅ `.ctor` (44) |
| `CompositeProfile/CompositeSource` | ✅ `.ctor` (44) |
| `CompositeTextureUtil` | ✅ `AlphaBlendColor32` (544), ✅ `BlitPixels` (1148), ✅ `BlitToCachedTexture` (656), ✅ `ColorMultiply` (328), ✅ `GenerateCompositeTexture` (520), ✅ `MergeLayers` (536) |
| `CompositeTextureUtil/AsyncTextureProcessor` | ✅ `.ctor` (44), ✅ `GenerateCompositeTextureAsync` (88) |
| `CompositeTextureUtil/AsyncTextureProcessor/<GenerateCompositeTextureAsync>c__Iterator1E` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (748), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `MultilayerTexture` | ✅ `.ctor` (44), ✅ `ComposeTexture` (320), ✅ `FindLayerByName` (152), ✅ `SetLayerColor` (88), ✅ `SetLayerTexture` (84) |
| `MultilayerTexture/Layer` | ✅ `.ctor` (104) |
| `PaintJob` | ✅ `.ctor` (52), ✅ `GetTexture` (108) |
| `PlayerInstance` | ✅ `.cctor` (36), ✅ `.ctor` (268), ✅ `Awake` (56), ✅ `Bootstrap` (1764) ⚠Etapa 1, ✅ `ConstructCart` (56), ✅ `GetCartSlot` (100) ⚠Etapa 1, ✅ `GetConstructedCart` (112), ✅ `MatchAlternateForms` (484), ✅ `ReleaseCart` (324), ✅ `Start` (88), ✅ `get_Instance` (256) |
| `PlayerInstance/<ConstructCart>c__Iterator20` | ✅ `.ctor` (44), ✅ `Dispose` (268), ✅ `MoveNext` (5672), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PreviewCart` | ✅ `.ctor` (244), ✅ `<CharacterVisibility>m__25` (68), ✅ `AddPaint` (460), ✅ `AddPart` (512), ✅ `ApplyPaints` (72), ✅ `CharacterVisibility` (420), ✅ `CheckLoadingCoroutine` (72), ✅ `ClearnTransparencies` (188), ✅ `ComposeCart` (72), ✅ `DriveOutCoroutine` (72), ✅ `GenerateCartPreview` (404) ⚠Etapa 1, ✅ `GetPartTransform` (616), ✅ `OnDestroy` (700), ✅ `RemovePaint` (304), ✅ `RemovePart` (292), ✅ `SetPartVisibility` (176), ✅ `SetSlotTransparent` (272), ✅ `ShowLoadingObject` (248), ✅ `StartDriveout` (376) ⚠Etapa 1, ✅ `Update` (432), ✅ `UpdateCachedPaint` (72), ✅ `UpdateColorShift` (72), ✅ `UpdateRenderers` (72), ✅ `get_CachedPaint` (52), ✅ `get_IsLoading` (128) ⚠Etapa 1, ✅ `get_IsUpdating` (160), ✅ `set_CachedPaint` (60) |
| `PreviewCart/<AddPaint>c__AnonStoreyA3` | ✅ `.ctor` (44), ✅ `<>m__28` (84) |
| `PreviewCart/<AddPart>c__AnonStoreyA1` | ✅ `.ctor` (44), ✅ `<>m__26` (84) |
| `PreviewCart/<ApplyPaints>c__Iterator66` | ✅ `.ctor` (44), ✅ `<>m__2A` (80), ✅ `Dispose` (424), ✅ `MoveNext` (2512), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PreviewCart/<CheckLoadingCoroutine>c__Iterator6A` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (1572), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PreviewCart/<ComposeCart>c__Iterator69` | ✅ `.ctor` (44), ✅ `Dispose` (472), ✅ `MoveNext` (2820), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PreviewCart/<DriveOutCoroutine>c__Iterator6C` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (2828), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PreviewCart/<RemovePaint>c__AnonStoreyA4` | ✅ `.ctor` (44), ✅ `<>m__29` (104) |
| `PreviewCart/<RemovePart>c__AnonStoreyA2` | ✅ `.ctor` (44), ✅ `<>m__27` (84) |
| `PreviewCart/<UpdateCachedPaint>c__Iterator6B` | ✅ `.ctor` (44), ✅ `<>m__2B` (80), ✅ `Dispose` (268), ✅ `MoveNext` (2136), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PreviewCart/<UpdateColorShift>c__Iterator68` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (816), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PreviewCart/<UpdateRenderers>c__Iterator67` | ✅ `.ctor` (44), ✅ `Dispose` (268), ✅ `MoveNext` (1100), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PreviewCart/PreviewPaint` | ✅ `.ctor` (44) |
| `PreviewCart/PreviewPart` | ✅ `.ctor` (44) |
| `SourceFactory` | ✅ `.ctor` (56), ✅ `GetSource` (140), ✅ `GetUsedList` (52), ✅ `Init` (556), ✅ `RecycleSources` (188), ✅ `SetPriority` (608) |
| `StreamedMultilayerTexture` | ✅ `.ctor` (44), ✅ `IsLoaded` (88), ✅ `PrepareMultilayerTexture` (1164), ✅ `ReleaseAssets` (172), ✅ `RequestAssets` (108) |
| `StreamedMultilayerTexture/Layer` | ✅ `.ctor` (44) |

### Selección de circuito/pista/personaje — 141 métodos, 35.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CharacterButtonPublisher` | ✅ `.ctor` (52), ✅ `OnPressedButton` (132) |
| `CharacterSelectPublisher` | ✅ `.ctor` (60), ✅ `<Start>m__23` (80), ✅ `Awake` (108), ✅ `IsTemporary` (288), ✅ `LoadInLocalizedAssets` (88), ✅ `OnDestroy` (192), ✅ `PressedAction` (804), ✅ `PressedLeftArrow` (112), ✅ `PressedRightArrow` (112), ✅ `RefreshCharacter` (136), ✅ `RefreshDisplay` (1680), ✅ `RefreshStatBars` (52), ✅ `SetCharacter` (1068), ✅ `SetStatBar` (896), ✅ `Start` (348), ✅ `Update` (392), ✅ `UpdateLogo` (1528) |
| `CharacterSelectPublisher/<LoadInLocalizedAssets>c__Iterator54` | ✅ `.ctor` (44), ✅ `Dispose` (268), ✅ `MoveNext` (940), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `CharacterSelectPublisher/Logo` | ✅ `.ctor` (44) |
| `DifficultyMenuPublisher` | ✅ `.ctor` (52), ✅ `CalculateCompletion` (252), ✅ `PushedEasy` (100), ✅ `PushedHard` (180), ✅ `PushedMedium` (180), ✅ `ShowPopover` (144), ✅ `Start` (836) |
| `SelectCircuitPublisher` | ✅ `.ctor` (268), ✅ `AnimateIn` (72), ✅ `DetermineTrophies` (828), ✅ `LoadCircuitTextures` (72), ✅ `OnDisable` (48), ✅ `OnEnable` (520), ✅ `PressedCircuitButton1` (248), ✅ `PressedCircuitButton2` (300), ✅ `PressedCircuitButton3` (300), ✅ `PressedPranksgiving` (228), ✅ `PressedTutorial` (244), ✅ `ShowPopupDialog` (184), ✅ `Start` (72), ✅ `StartTutLoad` (64) |
| `SelectCircuitPublisher/<AnimateIn>c__Iterator6F` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (768), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `SelectCircuitPublisher/<LoadCircuitTextures>c__Iterator6D` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (1740), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `SelectCircuitPublisher/<Start>c__Iterator6E` | ✅ `.ctor` (44), ✅ `<>m__2C` (80), ✅ `<>m__2D` (80), ✅ `<>m__2E` (80), ✅ `<>m__2F` (80), ✅ `<>m__30` (80), ✅ `Dispose` (56), ✅ `MoveNext` (2708), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `SelectCircuitPublisher/<StartTutLoad>c__Iterator70` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (188), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `SelectCircuitPublisher/CircuitBanner` | ✅ `.ctor` (44) |
| `SelectCircuitPublisher/TrophyAssets` | ✅ `.ctor` (44) |
| `TrackSelectPublisher` | ✅ `.ctor` (268), ✅ `DetermineTrophies` (1620), ✅ `FixedUpdate` (536), ✅ `GetTrackIconsList` (148), ✅ `PressedBackButton` (84), ✅ `PressedTrackButton1` (200), ✅ `PressedTrackButton2` (200), ✅ `PressedTrackButton3` (200), ✅ `RaceOrSummary` (136), ✅ `Refresh` (324), ✅ `Start` (384), ✅ `UpdateTrackSnapshots` (1356) |
| `TrackSelectPublisher/TrackIcon` | ✅ `.ctor` (44) |
| `TrackUnlockHelper` | ✅ `.ctor` (52), ✅ `CheckForPreraceSetupUnlock` (336), ✅ `GetCircuitMedalCount` (448), ✅ `GetCircuitTracks` (372), ✅ `GetHasEnoughMedals` (92), ✅ `GetHighestTrackPlace` (396), ✅ `GetTrackMedalCount` (420), ✅ `IsCircuitUnlocked` (332) ⚠Etapa 1, ✅ `RelockEverything` (336) ⚠Etapa 1, ✅ `Start` (72), ✅ `TestForUltraHard` (188), ✅ `UnlockAllEverything` (336), ✅ `get_CanPranksgiving` (52), ✅ `get_DebugUnlock` (52), ✅ `set_DebugUnlock` (76) ⚠Etapa 1 |
| `TrackUnlockHelper/<GetCircuitMedalCount>c__AnonStorey98` | ✅ `.ctor` (44), ✅ `<>m__19` (76) |
| `TrackUnlockHelper/<GetCircuitTracks>c__AnonStorey9A` | ✅ `.ctor` (44), ✅ `<>m__1B` (76) |
| `TrackUnlockHelper/<GetTrackMedalCount>c__AnonStorey99` | ✅ `.ctor` (44), ✅ `<>m__1A` (84) |
| `TrackUnlockHelper/<Start>c__Iterator49` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (664), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `TrackUnlockHelper/CircuitTracks` | ✅ `.ctor` (44) |
| `TrackUnlockHelper/TrackMedals` | ✅ `.ctor` (44) |
| `UnlockedCircuitPublisher` | ✅ `.ctor` (76), ✅ `LoadCircuitTextures` (72), ✅ `SetContent` (224), ✅ `ShowCircuitBanner` (476), ✅ `Start` (72), ✅ `Update` (68), ✅ `get_Circuit` (52), ✅ `set_Circuit` (60) |
| `UnlockedCircuitPublisher/<LoadCircuitTextures>c__Iterator75` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (1772), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `UnlockedCircuitPublisher/<Start>c__Iterator74` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (196), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `UnlockedCircuitPublisher/CircuitBanner` | ✅ `.ctor` (44) |

### Carga de carrera (RaceSettings/StreamManager/Loading) — 122 métodos, 22.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `LoadSpin` | ✅ `.ctor` (52), ✅ `FadeHelper` (108), ✅ `FadeOut` (80), ✅ `FadeOut` (88), ✅ `Start` (72) |
| `LoadSpin/<FadeHelper>c__Iterator2D` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (712), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LoadSpin/<Start>c__Iterator2C` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (392), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LoadingPublisher` | ✅ `.ctor` (52), ✅ `FadeAndDestroyCoroutine` (72), ✅ `LoadingProcess` (72), ✅ `PressedGoButton` (228), ✅ `SetAssetCluster` (60), ✅ `SetupMissionText` (72), ✅ `Start` (648), ✅ `Update` (44), ✅ `WaitForAssetBundles` (72), ✅ `WaitForCartConstruction` (72), ✅ `WaitForLevelLoad` (72) |
| `LoadingPublisher/<FadeAndDestroyCoroutine>c__Iterator63` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (256), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LoadingPublisher/<LoadingProcess>c__Iterator62` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (904), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LoadingPublisher/<SetupMissionText>c__Iterator61` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (1376), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LoadingPublisher/<WaitForAssetBundles>c__Iterator5E` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (560), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LoadingPublisher/<WaitForCartConstruction>c__Iterator5F` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (252), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `LoadingPublisher/<WaitForLevelLoad>c__Iterator60` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (468), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceSettings` | ✅ `.cctor` (116), ✅ `.ctor` (780), ✅ `<DetermineAICars>m__17` (128), ✅ `<DetermineAICars>m__18` (100), ✅ `Awake` (56), ✅ `CleanupCoroutine` (64), ✅ `DetermineAICars` (1196), ✅ `GatherRequiredAssets` (728), ✅ `GetCircuit` (668), ✅ `Launch` (284), ✅ `StartBundleLoads` (216), ✅ `get_AICarts` (52), ✅ `get_RaceType` (52), ✅ `set_RaceType` (60) |
| `RaceSettings/<CleanupCoroutine>c__Iterator48` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (164), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceSettings/<DetermineAICars>c__AnonStorey97` | ✅ `.ctor` (44), ✅ `<>m__16` (96) |
| `RaceSettings/AICartSettings` | ✅ `.ctor` (44) |
| `StreamManager` | ✅ `.cctor` (36), ✅ `.ctor` (88), ✅ `Awake` (56), ✅ `Cleanup` (780) ⚠Etapa 1, ✅ `DebugDump` (1756), ✅ `FlushAll` (412), ✅ `LoadAsset` (80), ✅ `PreloadAsset` (216), ✅ `PrependRootFileLocation` (192) ⚠Etapa 1, ✅ `ReleaseAsset` (156), ✅ `RequestAsset` (288), ✅ `Start` (88), ✅ `get_Instance` (256), ✅ `get_isAvailable` (64) |
| `StreamManager/<LoadAsset>c__Iterator32` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (584), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `StreamManager/Asset` | ✅ `.ctor` (44), ✅ `Unload` (216), ✅ `get_isDone` (104), ✅ `get_isInUse` (64), ✅ `get_mainAsset` (128), ✅ `get_progress` (200) |
| `StreamManager/AssetCluster` | ✅ `.ctor` (100), ✅ `AddAsset` (124), ✅ `GetAsset` (356), ✅ `GetMainObjectOfAsset` (132), ✅ `Load` (296), ✅ `Preload` (252), ✅ `Release` (316), ✅ `get_isDone` (356), ✅ `get_progress` (444) |


---

## Etapa 3 — Carrera mínima (conducir, vueltas, meta, resultados)

**Métodos de etapas posteriores que el flujo original ya ejecuta aquí** (38) — deben tolerar quedar pendientes o adelantarse:

- Etapa 4 · `AchievementListener`: `HasAchieved`
- Etapa 4 · `BaseEffect`: `.cctor`, `GetEffectInstance`, `isBeneficial`
- Etapa 4 · `BoosterEffect`: `.ctor`
- Etapa 4 · `CarAI`: `ClearStates`
- Etapa 4 · `CarAIPathManager`: `.cctor`
- Etapa 4 · `CarAIPathRecorder`: `FinishRecording`, `StartRecording`
- Etapa 4 · `CarSnapShot`: `.ctor`, `AddEffectToPowerUpholder`, `AddToEffectList`
- Etapa 4 · `EffectManager`: `AddEffect`, `GetEffect`, `GetEffectCount`, `HasEffect`, `RemoveAllEffects`, `RemoveEffect`
- Etapa 4 · `GimpedCarAI`: `.ctor`, `FixedUpdate`, `GetGimpedSnapShot`, `SetToClosestPathHead`, `Start`, `Update`
- Etapa 4 · `MissionDialogPublisher`: `SetRollState`
- Etapa 4 · `MissionManager`: `Signal`
- Etapa 4 · `MusicPlayer`: `HijackMusicPlayerForSoundStings`
- Etapa 4 · `PowerupHolder`: `AddEffect`, `ExecutePowerups`, `get_CanTakePowerup`, `get_Item`
- Etapa 4 · `SlowdownEffect`: `.ctor`
- Etapa 4 · `SnapShotInfo`: `AddCarSnap`
- Etapa 4 · `SoundLibrary`: `PlaySoundOnPlayer`
- Etapa 4 · `SoundLibraryAddendum`: `Dispose`
- Etapa 4 · `SoundSequencer`: `RequestPlay`

### HUD, pausa y resultados — 181 métodos, 55.3 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `BlipTrackPublisher` | `.ctor` (52), `InitBlips` (864), `InitValues` (176), `UpdateBlips` (1320) |
| `DriftScalePublisher` | `.ctor` (100), `BlinkLabelCoroutine` (72), `BlinkWarningCoroutine` (72), `Start` (500), `Update` (828) |
| `DriftScalePublisher/<BlinkLabelCoroutine>c__Iterator77` | `.ctor` (44), `Dispose` (56), `MoveNext` (376), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `DriftScalePublisher/<BlinkWarningCoroutine>c__Iterator78` | `.ctor` (44), `Dispose` (56), `MoveNext` (548), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic` | `.cctor` (36), `.ctor` (140), `AchievementSlideNotificationCoroutine` (104), `AnimateBrakeButtonIn` (64), `AnimateDriftButtonIn` (64), `AnimatePowerupDohickeyIn` (64), `DisplayNotification` (96), `DisplayNotificationCoroutine` (124), `DoWrongWayNotice` (72), `GimpedHudCoroutine` (72), `OnApplicationPause` (328), `OnRaceInit` (800), `PreraceCountCoroutine` (72), `PressedBuyButton` (1804), `PressedDrift` (44), `PressedPauseButton` (428), `PressedPower` (192), `SetPlayerObject` (76), `ShowAchievementNotification` (184), `ShowDriftScale` (60), `ShowMineNotify` (760), `ShowPreraceCount` (80), `SignalCatchUp` (44), `SignalMissionComplete` (88), `SignalMissionStart` (88), `Start` (892), `Update` (1076), `UpdateHUD` (3608), `get_CatchUpNeeded` (52), `get_Instance` (260), `get_WrongWay` (52), `get_playerCar` (76), `isAchievementNoteEngaged` (136), `set_CatchUpNeeded` (60), `set_WrongWay` (60) |
| `HUDLogic/<AchievementSlideNotificationCoroutine>c__Iterator7A` | `.ctor` (44), `Dispose` (56), `MoveNext` (1760), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<AnimateBrakeButtonIn>c__Iterator7F` | `.ctor` (44), `Dispose` (56), `MoveNext` (664), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<AnimateDriftButtonIn>c__Iterator80` | `.ctor` (44), `Dispose` (56), `MoveNext` (672), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<AnimatePowerupDohickeyIn>c__Iterator81` | `.ctor` (44), `Dispose` (56), `MoveNext` (696), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<DisplayNotificationCoroutine>c__Iterator7C` | `.ctor` (44), `Dispose` (56), `MoveNext` (1084), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<DoWrongWayNotice>c__Iterator82` | `.ctor` (44), `Dispose` (56), `MoveNext` (532), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<GimpedHudCoroutine>c__Iterator7B` | `.ctor` (44), `Dispose` (56), `MoveNext` (204), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<PreraceCountCoroutine>c__Iterator79` | `.ctor` (44), `Dispose` (56), `MoveNext` (2320), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<SignalMissionComplete>c__Iterator7E` | `.ctor` (44), `Dispose` (56), `MoveNext` (1444), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<SignalMissionStart>c__Iterator7D` | `.ctor` (44), `<>m__34` (92), `Dispose` (56), `MoveNext` (3840), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HUDLogic/<UpdateHUD>c__AnonStoreyA5` | `.ctor` (44), `<>m__31` (96), `<>m__32` (96), `<>m__33` (96) |
| `HUDLogic/ArrowTarget` | `.ctor` (44) |
| `HUDLogic/PowerupDisplay` | `.ctor` (44) |
| `PausePublisher` | `.ctor` (52), `OnDestroy` (76), `PressedQuitButton` (392), `PressedRestartButton` (84), `PressedResumeButton` (64), `SetupMissionText` (1944), `Start` (364) |
| `PlaySummaryPublisher` | `.ctor` (100), `FixedUpdate` (1064), `PressedBackButton` (84), `PressedDifficultyArrowLeft` (180), `PressedDifficultyArrowRight` (180), `PressedModeArrowLeft` (184), `PressedModeArrowRight` (184), `PressedPlayButton` (96), `Refresh` (800), `Start` (728), `TestForUltraHard` (188), `UpdateTrackIcon` (448) |
| `RaceResultsPublisher` | `.ctor` (60), `AnimateCoinsCoroutine` (88), `AnimatePlaceResultsCoroutine` (88), `AnimateScreenCoroutine` (88), `CheckForRewindTutorial` (88), `FillRank` (920), `FillRanks` (2940), `NeedMoreCoins` (848), `PressedDone` (704), `PressedRetry` (156), `PressedRewind` (188), `Start` (620) |
| `RaceResultsPublisher/<AnimateCoinsCoroutine>c__Iterator8A` | `.ctor` (44), `Dispose` (56), `MoveNext` (3616), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `RaceResultsPublisher/<AnimatePlaceResultsCoroutine>c__Iterator89` | `.ctor` (44), `Dispose` (56), `MoveNext` (1588), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `RaceResultsPublisher/<AnimateScreenCoroutine>c__Iterator87` | `.ctor` (44), `Dispose` (56), `MoveNext` (1724), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `RaceResultsPublisher/<CheckForRewindTutorial>c__Iterator88` | `.ctor` (44), `Dispose` (56), `MoveNext` (440), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `RaceResultsPublisher/<FillRank>c__AnonStoreyA6` | `.ctor` (44), `<>m__35` (76) |
| `RaceResultsPublisher/CharacterIcon` | `.ctor` (44) |

### Vehículo: física, input PC, animación — 146 métodos, 52.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `AnimationDriver` | ✅ `.cctor` (516) ⚠Etapa 2, ✅ `.ctor` (76) ⚠Etapa 2, ✅ `Blend` (224), ✅ `CrossFadeToNewAnimation` (104), ✅ `Lean` (400), ✅ `Play` (320) ⚠Etapa 1, ✅ `SetAnimationTarget` (1136) ⚠Etapa 2, ✅ `Update` (344) ⚠Etapa 2, ✅ `get_Item` (72) |
| `AnimationDriver/<CrossFadeToNewAnimation>c__Iterator1B` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (660), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `AnimationTire` | `.ctor` (52), `Start` (144), `Update` (984) |
| `CarCollider` | `.ctor` (268), `ApplyAcceleration` (372), `ApplyDrift` (252), `ApplyTurning` (640), `CarUpdatePump` (72), `CheckForCatchUp` (508), `CheckForStall` (584), `DecrementInputBlock` (60), `DoAcceleration` (948), `DoGimpedMovement` (296), `DoGroundCollision` (2880), `DoMovement` (4984), `DoPowerSlideCheck` (1560), `DoResetCarOnTrack` (84), `DoResetCarOnTrack` (884), `DoRoadBoundaries` (2308), `DoTireDrag` (340), `DoWrongWayCheck` (548), `FixedUpdate` (176), `GetAccel` (108), `GetActualAcceleration` (432), `GetActualCollisionMass` (124), `GetActualCollisionRestitution` (124), `GetActualHandling` (176), `GetActualMaxSpeed` (432), `GetVelocity` (108), `IncrementInputBlock` (60), `InputBlocked` (64), `IsShielded` (108), `OnDisable` (144), `OnDrawGizmos` (880), `OnEnable` (252), `PauseSounds` (152), `PlayRandomCollisionSound` (164), `RaceInitFinished` (60), `SetEngineSoundState` (220), `SetupAudioStuff` (168), `Start` (1016), `TransformVelocity` (164), `Update` (844), `get_EffectMgr` (52), `get_EngineAudioSource` (52), `get_PowerSlideTimer` (64), `get_isCarLocked` (100), `get_isDrifting` (52), `get_isInAir` (120), `get_isPowerSlideQueued` (52), `set_isCarLocked` (60) |
| `CarCollider/<CarUpdatePump>c__Iterator1C` | `.ctor` (44), `Dispose` (56), `MoveNext` (428), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `CarMetrics` | `.ctor` (104), `CleanupCopiedMetrics` (312), `CloneToObject` (236), `CopyMetrics` (260), `DebugDump` (968), `Signal` (228), `Signal` (88), `Start` (88), `Update` (496) |
| `CatchupNotify` | `.ctor` (52), `DeathCount` (72), `Start` (80) |
| `CatchupNotify/<DeathCount>c__Iterator76` | `.ctor` (44), `Dispose` (56), `MoveNext` (216), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `DriftButton` | `.ctor` (52), `ApplyDrift` (140), `OnButtonDown` (56), `OnButtonHeld` (56), `OnButtonUp` (56) |
| `PlayerControlLinker` | `.ctor` (52), `Start` (140) |
| `PlayerKeyboardControl` | `.cctor` (92), `.ctor` (52), `Awake` (848), `FixedUpdate` (624), `GetKey` (144), `GetKeyDown` (144), `Update` (400) |
| `PlayerKeyboardControl/KeyEventBinding` | `.ctor` (44), `Key` (316), `KeyDown` (316) |
| `ReverseButton` | `.ctor` (52), `ApplyReverse` (140), `OnButtonDown` (56), `OnButtonHeld` (56), `OnButtonUp` (56) |
| `ShadowBlob` | `.ctor` (52), `OnDisable` (88), `OnEnable` (88), `Start` (124), `Update` (1116), `get_ShadowPosition` (180) |
| `SpringConnection` | `.ctor` (316), `FixedUpdate` (2068), `Start` (264) |
| `TriFoot` | `.ctor` (672), `FixedUpdate` (780), `GimpedTrifootCoroutine` (72), `OnDrawGizmos` (44), `Start` (100), `TriFootTest` (6924), `UpsideDownTest` (176), `get_forward` (312), `get_leadFoot` (156), `get_leftFoot` (156), `get_right` (312), `get_rightFoot` (156), `get_up` (312), `set_forward` (136), `set_leadFoot` (136), `set_leftFoot` (136), `set_right` (136), `set_rightFoot` (136), `set_up` (136) |
| `TriFoot/<GimpedTrifootCoroutine>c__Iterator4A` | `.ctor` (44), `Dispose` (56), `MoveNext` (204), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |

### Gestión de carrera — 108 métodos, 30.8 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CarProgress` | `.ctor` (88), `GetProgressCopy` (140) |
| `DebugTrackStrapper` | `.ctor` (268), `Start` (364) |
| `ObjectTrackDistanceLogic` | `.ctor` (52), `CalculateTrackDistance` (120), `OnDisable` (144), `OnEnable` (144), `Start` (44), `Update` (44) |
| `RaceManager` | ✅ `.cctor` (36), `.ctor` (60), `<CalculateCarPositions>m__12` (216), `<EndRace>m__14` (352), `<EndRace>m__15` (92), `<Init>m__13` (96), `AdvanceCarLap` (2164), `CalculateCarPositionPump` (72), `CalculateCarPositions` (1640), `CleanupRace` (340), `DoFinishLineEffect` (92), `EliminateCar` (88), `EndRace` (2372), `GetCarInPosition` (152), `GetCarIsActive` (140), `GetCarLap` (92), `GetCarLastProgressTrigger` (132), `GetCarLastTrackDistance` (184), `GetCarPosition` (120), `GetOrderedCarList` (208), `GetPlayerCar` (44), `Init` (5264), `InitRace` (136) ⚠Etapa 2, `IsPlayerCar` (60), `PauseRace` (596), `PlayAmbientNoise` (316), `PlayRandomAnimation` (332), `PostRaceCountdown` (88), `PreLaunchCoroutine` (72), `PreraceCountdown` (72), `RaceOutCoroutine` (64), `RaceRewind` (1788), `RecordSnapshot` (1484), `SetCarProgressTrigger` (92), `SpawnCoins` (56), `SpawnCoins` (488), `StartMusic` (684), `StartRaceRewind` (76), ✅ `add_raceInitFinishedEvent` (160), ✅ `get_Exists` (64), ✅ `get_Instance` (460), `get_allCars` (84), `get_elapsedTime` (316), ✅ `get_isPaused` (72) ⚠Etapa 1, `get_lastWaypoint` (84), `get_leadCar` (44), `get_totalNumLaps` (44), `get_totalTrackLength` (120), ✅ `remove_raceInitFinishedEvent` (160) |
| `RaceManager/<CalculateCarPositionPump>c__Iterator41` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (204), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceManager/<DoFinishLineEffect>c__Iterator43` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (1484), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceManager/<EliminateCar>c__Iterator46` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (1180), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceManager/<PostRaceCountdown>c__Iterator44` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (1404), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceManager/<PreLaunchCoroutine>c__Iterator45` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (328), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceManager/<PreraceCountdown>c__Iterator42` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (688), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceManager/<RaceOutCoroutine>c__Iterator40` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (480), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceManager/<StartRaceRewind>c__Iterator47` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (204), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `RaceResults` | `.ctor` (60) |

### Pista: waypoints, vueltas, respawn, superficies — 38 métodos, 18.3 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CausticsManager` | `.ctor` (268), `Start` (560), `UpdateCausticsCoroutine` (72) |
| `CausticsManager/<UpdateCausticsCoroutine>c__Iterator28` | `.ctor` (44), `Dispose` (56), `MoveNext` (392), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `ProgressTriggerLogic` | ✅ `.ctor` (52), ✅ `CanTriggerForCar` (208), ✅ `OnTriggerEnter` (212) |
| `ResetTrigger` | `.ctor` (52), `OnTriggerEnter` (260) |
| `SpeedPoint` | `.ctor` (84), `FindClosestSpeedPoint` (432), `GetSPLine` (188), `GetSPLinePoint` (1024), `IsPointForward` (268), `OnDrawGizmos` (440), `ProjectOnSPLine` (968) |
| `SpeedPoint/SpeedBranchStruct` | `.ctor` (44) |
| `TerrainEffectTrigger` | `.ctor` (84), `OnTriggerEnter` (756), `OnTriggerExit` (148), `Start` (44) |
| `WaypointLogic` | `.ctor` (84), `FindClosestWaypoint` (488), `FindNextWaypoint` (184), `FindWallDistance` (160), `GetTrackDistanceForPoint` (1140), `GetTrackPoint` (808), `GetWallDistanceAtPoint` (1240), `GetWallOffsetForPoint` (1456), `OnDrawGizmos` (2956), `ProjectOnWPLine` (656), `WaypointPrecalculations` (2640), `get_distanceToPrev` (120) |

### Cámaras de carrera — 17 métodos, 9.4 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CameraWobble` | `.ctor` (52), `Update` (464) |
| `FollowCamera` | `.ctor` (724), `CrashCamUpdate` (184), `FixedUpdate` (804), `NoCarUpdate` (676), `SetCrashCam` (212), `Start` (176), `WithCarUpdate` (1588) |
| `PreRaceCamera` | `.ctor` (124), `Awake` (220), `FixedUpdate` (1752), `OnDrawGizmos` (268), `SetNextTargetIndex` (312), `ShutdownPreRace` (396), `StartCamera` (1548), `Update` (164) |

### Utilidades compartidas — 2 métodos, 0.9 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `Mathfx` | ✅ `Berp` (460) |
| `Vector3x` | `Berp` (440) |


---

## Etapa 4 — Sistemas completos

### Power-ups, efectos y obstáculos — 473 métodos, 99.6 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `BarrelLauncher` | `.ctor` (100), `LaunchBarrel` (300), `LaunchPump` (72), `Start` (80) |
| `BarrelLauncher/<LaunchPump>c__Iterator33` | `.ctor` (44), `Dispose` (56), `MoveNext` (328), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `BarrelSpawner` | `.ctor` (76), `OnDrawGizmos` (276), `SpawnBarrel` (764), `SpawnCheck` (72), `Start` (96), `Update` (132) |
| `BarrelSpawner/<SpawnCheck>c__Iterator34` | `.ctor` (44), `Dispose` (56), `MoveNext` (304), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `BaseEffect` | `.cctor` (36) ⚠Etapa 3, `.ctor` (56), `DebugDump` (444), `FixedUpdate` (44), `GetComboEffectType` (440), `GetEffectInstance` (932) ⚠Etapa 3, `InitComboLookup` (188) ⚠Etapa 1, `SetUpComboLookup` (404), `get_ComboLookup` (56), `get_EffectType` (52), `get_IsMultiLevel` (52), `get_PowerLevel` (52), `isBeneficial` (56) ⚠Etapa 3, `isBeneficial` (260) ⚠Etapa 3, `set_ComboLookup` (68), `set_EffectType` (60), `set_IsMultiLevel` (60), `set_PowerLevel` (60) |
| `BasePickup` | `.ctor` (52), `OnTriggerEnter` (892), `Start` (80), `Update` (328) |
| `BasketBall` | `.ctor` (112), `OnTriggerEnter` (732), `PlayBounceSound` (116), `Update` (1012) |
| `BoatAnchorEffect` | `.ctor` (72), `GetEffectSnapShot` (48), `Init` (620), `LaunchAnchor` (636), `Shutdown` (44), `Stack` (52), `Update` (44) |
| `BoosterEffect` | `.ctor` (112) ⚠Etapa 3, `GetEffectSnapShot` (48), `Init` (2088), `Shutdown` (768), `Stack` (52), `Update` (44) |
| `BoosterPickup` | `.ctor` (52), `GetTriggeredEffect` (132) |
| `BreakableObject` | `.ctor` (76), `CollideBreak` (116), `Start` (44), `Update` (44) |
| `BubbleJet` | `.ctor` (76), `OnDrawGizmos` (280), `OnTriggerStay` (232), `Start` (92) |
| `Crab` | `.ctor` (220), `FixedUpdate` (1136), `OnDrawGizmos` (140), `OnTriggerEnter` (324), `SleepRoutine` (108), `Start` (104), `Update` (544) |
| `Crab/<SleepRoutine>c__Iterator36` | `.ctor` (44), `Dispose` (56), `MoveNext` (248), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `EffectManager` | `.ctor` (104), `AddEffect` (640) ⚠Etapa 3, `FixedUpdate` (336), `GetEffect` (112) ⚠Etapa 3, `GetEffectCount` (340) ⚠Etapa 3, `GetEffectListCopy` (252), `GetHighestPoweredEffect` (352), `GetStrongestEffect` (364), `HasEffect` (356) ⚠Etapa 3, `HasEffectOfLevel` (376), `RemoveAllEffects` (448) ⚠Etapa 3, `RemoveEffect` (148) ⚠Etapa 3, `SetEffectList` (72), `Start` (44), `Update` (716) |
| `ExplodingBarrel` | `.ctor` (112), `Explode` (72), `LifeCountdown` (72), `OnCollisionEnter` (64), `OnTriggerEnter` (468), `Start` (92), `Update` (304) |
| `ExplodingBarrel/<Explode>c__Iterator38` | `.ctor` (44), `Dispose` (56), `MoveNext` (536), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `ExplodingBarrel/<LifeCountdown>c__Iterator37` | `.ctor` (44), `Dispose` (56), `MoveNext` (260), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `Explosion` | `.ctor` (52), `ExplosionDeath` (72), `Start` (172), `Update` (44) |
| `Explosion/<ExplosionDeath>c__Iterator24` | `.ctor` (44), `Dispose` (56), `MoveNext` (208), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `FlipEffect` | `.ctor` (176), `GetEffectSnapShot` (48), `Init` (1220), `Shutdown` (464), `Stack` (52), `Update` (516) |
| `GuidedJumpEffect` | `.ctor` (692), `FixedUpdate` (616), `GetEffectSnapShot` (144), `Init` (560), `Shutdown` (204), `Stack` (52), `Update` (288) |
| `GuidedJumpTrigger` | `.ctor` (52), `OnDrawGizmos` (780), `OnTriggerEnter` (364) |
| `InRaceAquirePickupListener` | `.ctor` (60), `CheckMetrics` (368), `CheckMetricsPump` (72), `IsAvailable` (72), `Postrace` (84), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `InRaceAquirePickupListener/<CheckMetricsPump>c__IteratorC` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `LaserLogic` | `.ctor` (112), `ApplyError` (216), `SetParent` (60), `SetTarget` (60), `Update` (704) |
| `MineAI` | `.ctor` (160), `ArmMine` (72), `KillAI` (88), `OnTriggerEnter` (1744), `SetOwner` (60), `Start` (80), `Update` (1496), `get_IsArmed` (52) |
| `MineAI/<ArmMine>c__Iterator3` | `.ctor` (44), `Dispose` (56), `MoveNext` (264), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `MineEffect` | `.ctor` (112), `GetEffectSnapShot` (48), `Init` (148), `Shutdown` (44), `Stack` (112), `Update` (428) |
| `MineNotifyPublisher` | `.ctor` (52), `FadeIn` (72), `FadeOut` (72), `Lifetime` (72), `SetDisplayName` (100), `Start` (80) |
| `MineNotifyPublisher/<FadeIn>c__Iterator84` | `.ctor` (44), `Dispose` (56), `MoveNext` (972), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `MineNotifyPublisher/<FadeOut>c__Iterator85` | `.ctor` (44), `Dispose` (56), `MoveNext` (692), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `MineNotifyPublisher/<Lifetime>c__Iterator83` | `.ctor` (44), `Dispose` (56), `MoveNext` (460), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `MinePickup` | `.ctor` (52), `GetTriggeredEffect` (132) |
| `MineSpreaderAI` | `.ctor` (168), `Explode` (324), `LaunchUpdate` (264), `SetOwner` (60), `SpreadMines` (628), `Start` (924), `Update` (148) |
| `ParticleLibrary` | ✅ `.cctor` (36), ✅ `.ctor` (52), ✅ `Awake` (56), ✅ `GetPrefab` (388) ⚠Etapa 2, ✅ `Start` (88), ✅ `Update` (44), ✅ `get_Instance` (248) ⚠Etapa 2 |
| `ParticleLibrary/ParticlePrefab` | ✅ `.ctor` (44) |
| `ParticleReducer` | `.ctor` (52), `Start` (572) |
| `ParticleReducer/<Start>c__AnonStorey93` | `.ctor` (44), `<>m__E` (76) |
| `ParticleReducer/PlatformProfile` | `.ctor` (44) |
| `PickupCoinsPerRaceAchievementListener` | `.ctor` (52), `CheckCarMetrics` (240), `CheckMetricsPump` (72), `IsAvailable` (72), `Postrace` (84), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `PickupCoinsPerRaceAchievementListener/<CheckMetricsPump>c__Iterator12` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PickupSpawner` | `.ctor` (84), `OnDrawGizmos` (276), `SpawnCheck` (72), `SpawnPickup` (968), `Start` (52), `Update` (132) |
| `PickupSpawner/<SpawnCheck>c__Iterator30` | `.ctor` (44), `Dispose` (56), `MoveNext` (304), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PieAttack` | `.ctor` (112), `Explode` (80), `ExplodeCoroutine` (72), `LifeCountdown` (72), `OnCollisionEnter` (64), `OnTriggerEnter` (788), `Start` (92), `Update` (304) |
| `PieAttack/<ExplodeCoroutine>c__Iterator3A` | `.ctor` (44), `Dispose` (56), `MoveNext` (168), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PieAttack/<LifeCountdown>c__Iterator39` | `.ctor` (44), `Dispose` (56), `MoveNext` (212), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PieHitEffect` | `.ctor` (76), `GetEffectSnapShot` (48), `Init` (352), `Shutdown` (44), `Stack` (52), `Update` (44) |
| `PieLauncher` | `.ctor` (100), `OnDrawGizmos` (156), `ShootPieCoroutine` (72), `Start` (72) |
| `PieLauncher/<ShootPieCoroutine>c__Iterator3C` | `.ctor` (44), `Dispose` (56), `MoveNext` (872), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PieLauncher/<Start>c__Iterator3B` | `.ctor` (44), `Dispose` (56), `MoveNext` (256), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PieSplat` | `.ctor` (76), `Start` (72) |
| `PieSplat/<Start>c__Iterator2E` | `.ctor` (44), `Dispose` (56), `MoveNext` (1700), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PowerupHolder` | `.ctor` (100), `AddEffect` (384) ⚠Etapa 3, `Awake` (112), `ClearEffectsInReserve` (96), `ExecutePowerups` (1904) ⚠Etapa 3, `HasEffect` (360), `PowerupComboCheck` (1436), `Update` (244), `get_CanTakePowerup` (92) ⚠Etapa 3, `get_Item` (128) ⚠Etapa 3, `get_numEffects` (64) |
| `PowerupMagnet` | `.ctor` (252), `FixedUpdate` (900), `GetEffectSnapShot` (48), `Init` (760), `Shutdown` (216), `Stack` (52), `Start` (44), `Update` (764) |
| `PyroTechnics` | `.ctor` (52), `OnTriggerEnter` (456), `Start` (44), `Update` (44) |
| `RandomShotEffect` | `.ctor` (96), `FixedUpdate` (44), `GetEffectSnapShot` (48), `Init` (772), `Shutdown` (148), `Stack` (52), `Start` (44), `Update` (44) |
| `RocketAI` | `.ctor` (136), `BurnUpdate` (1232), `Explode` (320), `FixedUpdate` (560), `LaunchUpdate` (572), `SetOwner` (60), `SetRiderEffect` (68), `SetTarget` (120), `Start` (1116), `StrikeTarget` (992), `Update` (140) |
| `RocketEffect` | `.ctor` (184), `GetEffectSnapShot` (48), `Init` (1024), `LaunchRocket` (588), `Shutdown` (44), `Stack` (52), `Update` (228) |
| `RocketPickup` | `.ctor` (52), `GetTriggeredEffect` (132) |
| `RocketRideEffect` | `.ctor` (132), `DetachFromRocket` (572), `GetEffectSnapShot` (48), `Init` (492), `LaunchRocket` (1064), `Shutdown` (232), `Stack` (52), `Update` (180) |
| `RocketRideRemover` | `.ctor` (52), `OnTriggerEnter` (180), `Start` (44), `Update` (44) |
| `ShieldEffect` | `.ctor` (112), `GetEffectSnapShot` (48), `Init` (972), `Shutdown` (300), `Stack` (52), `Update` (368), `get_Reflective` (64) |
| `ShieldPickup` | `.ctor` (52), `GetTriggeredEffect` (132) |
| `ShockedEffect` | `.ctor` (104), `GetEffectSnapShot` (48), `Init` (684), `Shutdown` (44), `Stack` (76), `Update` (44) |
| `ShotDroneAI` | `.ctor` (76), `FixedUpdate` (44), `SetParent` (60), `Shoot` (812), `Start` (72), `Update` (388) |
| `SkidEffect` | `.ctor` (88), `GetEffectSnapShot` (48), `Init` (92), `Shutdown` (44), `Stack` (52), `Update` (236) |
| `SlowdownEffect` | `.ctor` (104) ⚠Etapa 3, `GetEffectSnapShot` (48), `Init` (44), `Shutdown` (184), `Stack` (52), `Update` (44) |
| `SmashEffect` | `.ctor` (104), `GetEffectSnapShot` (48), `Init` (476), `Shutdown` (200), `Stack` (52), `Update` (44) |
| `SpreadMineEffect` | `.ctor` (96), `GetEffectSnapShot` (48), `Init` (52), `LaunchSpreader` (596), `Shutdown` (44), `Stack` (52), `Start` (44), `Update` (44) |
| `SpringTrigger` | `.ctor` (52), `OnDrawGizmos` (236), `OnTriggerEnter` (164) |
| `TeleportEffect` | `.ctor` (200), `GetEffectSnapShot` (48), `Init` (252), `Shutdown` (204), `Stack` (52), `Update` (496) |
| `TeleportTrigger` | `.ctor` (52), `OnDrawGizmos` (460), `OnTriggerEnter` (336) |
| `TripLine` | `.ctor` (52), `OnTriggerEnter` (240), `Start` (44), `Update` (44) |
| `TripLineEffect` | `.ctor` (96), `GetEffectSnapShot` (48), `Init` (1132), `Shutdown` (188), `Stack` (52), `Start` (44), `Update` (368) |
| `TurkeyGooShooter` | `.ctor` (116), `Start` (72) |
| `TurkeyGooShooter/<Start>c__Iterator3D` | `.ctor` (44), `Dispose` (56), `MoveNext` (480), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UFOLogic` | `.ctor` (436), `FireLaser` (1220), `FixedUpdate` (2604), `OnDrawGizmos` (144), `SetParent` (60), `SetSecondUFO` (60), `StartFlyaway` (72), `Update` (444) |
| `WhoopieCushion` | `.ctor` (52), `Explode` (72), `OnCollisionEnter` (64), `OnTriggerEnter` (428), `Start` (68) |
| `WhoopieCushion/<Explode>c__Iterator3E` | `.ctor` (44), `Dispose` (56), `MoveNext` (424), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `WipeoutEffect` | `.ctor` (192), `GetEffectSnapShot` (48), `Init` (1200), `Shutdown` (552), `Stack` (52), `Update` (576) |

### Misiones y logros internos — 472 métodos, 55.4 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `AchievementCategoryPublisher` | `.ctor` (52), `OnPressedCoins` (108), `OnPressedPowerups` (108), `OnPressedStunts` (108), `OnPressedTracks` (108), `Start` (1020) |
| `AchievementListener` | `.ctor` (52), `Achieve` (240), `Activate` (56), `Fail` (76) ⚠Etapa 1, `FilterCategory` (52), `GetUnlockName` (100), `HasAchieved` (80) ⚠Etapa 3, `get_State` (52) |
| `AchievementManager` | ✅ `.cctor` (36), ✅ `.ctor` (52), ✅ `Achieve` (976), ✅ `Awake` (56), ✅ `ChooseActiveListeners` (1212) ⚠Etapa 2, ✅ `ClearActiveListeners` (172) ⚠Etapa 2, ✅ `Fail` (120) ⚠Etapa 1, ✅ `InitFrontEndAchievements` (468) ⚠Etapa 1, ✅ `OnDisable` (332), ✅ `OnEnable` (332), ✅ `OnRaceEnd` (160), ✅ `OnRaceInit` (160), ✅ `Start` (88), ✅ `get_AllAchievements` (180), ✅ `get_Instance` (176) ⚠Etapa 1 |
| `AchievementPanelPublisher` | `.ctor` (52), `Refresh` (924), `get_Achievement` (52), `set_Achievement` (64) |
| `AchievementUI` | `.ctor` (52), `AnimatePanelInCoroutine` (96), `AnimatePanelOutCoroutine` (96), `BuildFilteredList` (488), `GetCurrentSurface` (68), `OnPressedBack` (84), `OnPressedNext` (80), `OnPressedPrev` (80), `SetPage` (1016), `Start` (372), `SwapSurface` (72) |
| `AchievementUI/<AnimatePanelInCoroutine>c__Iterator4D` | `.ctor` (44), `Dispose` (56), `MoveNext` (1500), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `AchievementUI/<AnimatePanelOutCoroutine>c__Iterator4C` | `.ctor` (44), `Dispose` (56), `MoveNext` (1492), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `AchievementWindowPublisher` | `.ctor` (52), `AnimInHelper` (72), `Awake` (116), `DestroyThis` (72), `PressedWindow` (92), `SetContent` (400), `SetNextWindow` (136), `TriggerAnimIn` (80) |
| `AchievementWindowPublisher/<AnimInHelper>c__Iterator4F` | `.ctor` (44), `Dispose` (56), `MoveNext` (396), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `AchievementWindowPublisher/<DestroyThis>c__Iterator4E` | `.ctor` (44), `Dispose` (56), `MoveNext` (588), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `BaseMission` | `.ctor` (232), `GetCurrentMissionName` (300), `GetCurrentUntranslatedMissionName` (276), `GetHasArrow` (52), `GetTaskDisplay` (284) |
| `BrakeMission` | `.ctor` (52), `Init` (80), `Shutdown` (44), `Signal` (48), `Signal` (52), `Update` (412) |
| `BuyPowerupMission` | `.ctor` (52), `Init` (44), `Shutdown` (44), `Signal` (144), `Signal` (52), `Start` (44), `Update` (44) |
| `CheckPowerupUseAchievementListener` | `.ctor` (52), `CheckMetrics` (348), `IsAvailable` (72), `Postrace` (84), `PowerupUseCheckPump` (72), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `CheckPowerupUseAchievementListener/<PowerupUseCheckPump>c__Iterator5` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `CoinBalanceAchievementListener` | `.ctor` (52), `CheckCoinBalanceCoroutine` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88) |
| `CoinBalanceAchievementListener/<CheckCoinBalanceCoroutine>c__Iterator6` | `.ctor` (44), `Dispose` (56), `MoveNext` (244), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `CollectPowerupMission` | `.ctor` (116), `Init` (56), `Shutdown` (44), `Signal` (200), `Signal` (52), `Update` (172) |
| `CombinePowerupMission` | `.ctor` (52), `Init` (44), `Shutdown` (44), `Signal` (144), `Signal` (52), `Start` (44), `Update` (44) |
| `CompleteAllMissionsAchievementListener` | `.ctor` (52), `CheckAllMissionsCoroutine` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88) |
| `CompleteAllMissionsAchievementListener/<CheckAllMissionsCoroutine>c__Iterator7` | `.ctor` (44), `Dispose` (56), `MoveNext` (824), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `CrossFinishLineBackwardsAchievementListener` | `.ctor` (52), `IsAvailable` (64), `Postrace` (252), `Prerace` (44), `Reward` (64), `Start` (56) |
| `DriftMission` | `.ctor` (52), `Init` (96), `Shutdown` (44), `Signal` (48), `Signal` (52), `Update` (344) |
| `EquipPaintJobAchievementListener` | `.ctor` (60), `CheckPaintJobs` (72), `IsAvailable` (72), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `EquipPaintJobAchievementListener/<CheckPaintJobs>c__Iterator8` | `.ctor` (44), `Dispose` (56), `MoveNext` (516), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `EquipPartSetAchievementListener` | `.ctor` (52), `CheckCartSet` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88) |
| `EquipPartSetAchievementListener/<CheckCartSet>c__Iterator9` | `.ctor` (44), `Dispose` (56), `MoveNext` (464), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `FinishTheLapMission` | `.ctor` (52), `Init` (44), `Shutdown` (44), `Signal` (144), `Signal` (52), `Update` (44) |
| `FirstPlaceAchievementListener` | `.ctor` (52), `IsAvailable` (248), `Postrace` (516), `Prerace` (44), `Reward` (64), `Start` (56) |
| `GetHitByTrackHazardAchievementListener` | `.ctor` (60), `CheckMetrics` (244), `CheckMetricsPump` (72), `IsAvailable` (148), `Postrace` (84), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `GetHitByTrackHazardAchievementListener/<CheckMetricsPump>c__IteratorA` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `HitMaxSpeedAchievementListener` | `.ctor` (52), `CheckMaxSpeedCoroutine` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88) |
| `HitMaxSpeedAchievementListener/<CheckMaxSpeedCoroutine>c__IteratorB` | `.ctor` (44), `Dispose` (56), `MoveNext` (324), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `LastPlaceAchievementListener` | `.ctor` (52), `IsAvailable` (152), `Postrace` (480), `Prerace` (44), `Reward` (64), `Start` (56), `Update` (44) |
| `LifetimeInAirAchievementListener` | `.ctor` (52), `CheckAirTimeCoroutine` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88) |
| `LifetimeInAirAchievementListener/<CheckAirTimeCoroutine>c__IteratorD` | `.ctor` (44), `Dispose` (56), `MoveNext` (296), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `LifetimeOpponentHitsAchievementListener` | `.ctor` (60), `CheckMetrics` (224), `CheckMetricsPump` (72), `IsAvailable` (72), `Postrace` (84), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `LifetimeOpponentHitsAchievementListener/<CheckMetricsPump>c__IteratorE` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `LifetimePowerupCollectionAchievementListener` | `.ctor` (60), `CheckMetrics` (208), `CheckMetricsPump` (72), `IsAvailable` (72), `Postrace` (84), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `LifetimePowerupCollectionAchievementListener/<CheckMetricsPump>c__IteratorF` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `MakePlaceAchievementListener` | `.ctor` (60), `IsAvailable` (208), `Postrace` (508), `Prerace` (44), `Reward` (64), `Start` (56) |
| `MaxCrashSpeedAchievementListener` | `.ctor` (52), `CheckMaxCrashSpeedCoroutine` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88) |
| `MaxCrashSpeedAchievementListener/<CheckMaxCrashSpeedCoroutine>c__Iterator10` | `.ctor` (44), `Dispose` (56), `MoveNext` (400), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `MetaMissionGroupAchievementListener` | `.ctor` (52), `CheckCompletionCoroutine` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88) |
| `MetaMissionGroupAchievementListener/<CheckCompletionCoroutine>c__Iterator11` | `.ctor` (44), `Dispose` (56), `MoveNext` (372), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `MissionCollection` | `.ctor` (60), `GetAreThereAnyMissionsLeft` (72), `GetCurrentMission` (100), `GetHasArrow` (104), `GetTaskDisplay` (148), `Init` (148), `Shutdown` (44), `Signal` (140), `Signal` (516), `Update` (368), `getCheckCurrentMission` (52), `setCheckCurrentMission` (60) |
| `MissionDialogPublisher` | `.ctor` (396), `FixedUpdate` (420), `PressedTab` (84), `SetRollState` (116) ⚠Etapa 3, `Start` (560), `Update` (104) |
| `MissionManager` | `.ctor` (196), `AddMission` (96), `CompleteMission` (236), `GetCurrentMission` (68), `GetHasStartedFirstMission` (52), `Signal` (332) ⚠Etapa 3, `Signal` (340) ⚠Etapa 3, `Start` (56), `Update` (1048), `WaitForNextMission` (88), `get_AllMissionsComplete` (76), `get_CurrentMissionComplete` (52) |
| `MissionManager/<WaitForNextMission>c__Iterator23` | `.ctor` (44), `Dispose` (56), `MoveNext` (432), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PauseMission` | `.ctor` (52), `Init` (44), `Shutdown` (44), `Signal` (144), `Signal` (52), `Update` (44) |
| `PlaceWithNoPowerupsAchievementListener` | `.ctor` (60), `CheckPowerupPass` (244), `IsAvailable` (72), `Postrace` (448), `Prerace` (44), `Reward` (64), `Start` (56), `Update` (44) |
| `PowerSlideBoostAchievementListener` | `.ctor` (60), `CheckMetrics` (188), `CheckMetricsPump` (72), `IsAvailable` (64), `Postrace` (84), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (136) |
| `PowerSlideBoostAchievementListener/<CheckMetricsPump>c__Iterator13` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PowerupHitInAirAchievementListener` | `.ctor` (60), `CheckMetrics` (232), `CheckMetricsPump` (72), `IsAvailable` (72), `Postrace` (84), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `PowerupHitInAirAchievementListener/<CheckMetricsPump>c__Iterator14` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `SpendCoinsOverLifetimeAchievementListener` | `.ctor` (52), `CheckSpentCoinsCoroutine` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (136), `Start` (80) |
| `SpendCoinsOverLifetimeAchievementListener/<CheckSpentCoinsCoroutine>c__Iterator15` | `.ctor` (44), `Dispose` (56), `MoveNext` (304), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `TimeInAirAchievementListener` | `.ctor` (52), `CheckAirTimeCoroutine` (72), `IsAvailable` (64), `Postrace` (44), `Prerace` (44), `Reward` (64), `Start` (88) |
| `TimeInAirAchievementListener/<CheckAirTimeCoroutine>c__Iterator16` | `.ctor` (44), `Dispose` (56), `MoveNext` (324), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `TurnMission` | `.ctor` (52), `Init` (652), `Shutdown` (44), `Signal` (100), `Signal` (52), `Update` (44) |
| `UnlockAchievementListener` | `.ctor` (52), `CheckUnlocks` (72), `IsAvailable` (72), `Postrace` (44), `Prerace` (44), `Reward` (140), `Start` (88), `UnlockCheck` (264), `Update` (44) |
| `UnlockAchievementListener/<CheckUnlocks>c__Iterator17` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UseAPowerupAchievementListener` | `.ctor` (52), `CheckCarMetrics` (352), `IsAvailable` (72), `Postrace` (44), `PowerupUseCheckPump` (72), `Prerace` (44), `Reward` (304), `Start` (88), `Update` (44) |
| `UseAPowerupAchievementListener/<PowerupUseCheckPump>c__Iterator18` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UsePowerupAgainstOpponentAchievementListener` | `.ctor` (60), `CheckMetrics` (300), `CheckMetricsPump` (72), `IsAvailable` (72), `Postrace` (84), `Prerace` (44), `Reward` (64), `Start` (88), `Update` (44) |
| `UsePowerupAgainstOpponentAchievementListener/<CheckMetricsPump>c__Iterator19` | `.ctor` (44), `Dispose` (56), `MoveNext` (224), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UsePowerupMission` | `.ctor` (52), `Init` (44), `Shutdown` (44), `Signal` (144), `Signal` (52), `Update` (44) |

### IA de rivales — 136 métodos, 41.9 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `BaseCarAIState` | `.ctor` (44) |
| `CarAI` | `.ctor` (1016), `AIEvaluationPump` (72), `AddState` (488), `ClearStates` (352) ⚠Etapa 3, `DriveTowardPoint` (144), `DriveWithFacing` (848), `EvaluateStates` (1900), `FixedUpdate` (112), `OnDrawGizmos` (1432), `Start` (512), `StateDone` (216), `TestForAvoidBadTerrain` (364), `TestForHarassCar` (244), `TestForHitBeneficialTerrain` (544), `TestForNoticePickup` (620), `TestForPowerupUsage` (180), `Update` (120) |
| `CarAI/<AIEvaluationPump>c__Iterator0` | `.ctor` (44), `Dispose` (56), `MoveNext` (284), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `CarAI/<EvaluateStates>c__AnonStorey8F` | `.ctor` (44), `<>m__1` (80) |
| `CarAIPath` | `.ctor` (44), `GetSizeEstimate` (64) |
| `CarAIPath/PathPoint` | `.ctor` (44) |
| `CarAIPathManager` | `.cctor` (36) ⚠Etapa 3, `.ctor` (52), `AddPath` (220), `GetPathByIndex` (168), `GetPathCount` (108), `GetPathIndex` (228), `GetRandomPath` (196), `OnDisable` (68), `OnDrawGizmos` (644), `OnEnable` (104), `ProduceInstance` (168) |
| `CarAIPathManager/<GetPathIndex>c__AnonStorey8E` | `.ctor` (44), `<>m__0` (72) |
| `CarAIPathRecorder` | `.ctor` (104), `DeltaCompressPath` (800), `DistanceCompressPath` (500), `DistanceCompressPathWithGroundChecking` (2232), `FinishRecording` (160) ⚠Etapa 3, `StartRecording` (112) ⚠Etapa 3, `Update` (300) |
| `CarAIPersonality` | `.ctor` (376), `Start` (144), `get_stateWeightMap` (768) |
| `CarAIPersonality/PersonalityTrait` | `.ctor` (68) |
| `DriveAvoidTerrainAIState` | `.ctor` (84), `FixedUpdate` (1004), `GetAIStateEnum` (48), `Init` (580), `Shutdown` (44), `Update` (548) |
| `DriveHitBeneficialAIState` | `.ctor` (84), `FixedUpdate` (432), `GetAIStateEnum` (48), `Init` (716), `Shutdown` (44), `Update` (536) |
| `DrivePickupAIState` | `.ctor` (44), `FixedUpdate` (136), `GetAIStateEnum` (48), `Init` (848), `Shutdown` (44), `Update` (452) |
| `DriveWaypointsCarAIState` | `.ctor` (84), `FixedUpdate` (104), `GetAIStateEnum` (48), `Init` (112), `Shutdown` (44), `Update` (988) |
| `ForwardForceAI` | `.ctor` (160), `FixedUpdate` (248), `Start` (192) |
| `GimpedCarAI` | `.ctor` (504) ⚠Etapa 3, `AggressionTherapyCoroutine` (72), `Bump` (320), `DoCarCollisions` (1340), `DoRoadBoundaries` (1336), `FixedUpdate` (2804) ⚠Etapa 3, `GetGimpedSnapShot` (92) ⚠Etapa 3, `PowerupUseEvaluationCoroutinue` (72), `SetGimpedSnapShot` (604), `SetNewPath` (556), `SetNextPoint` (580), `SetToClosestPathHead` (456) ⚠Etapa 3, `Start` (568) ⚠Etapa 3, `Update` (60) ⚠Etapa 3, `get_Direction` (216), `get_IsInAir` (200), `get_LinearVelocity` (64), `get_Velocity` (64), `set_LinearVelocity` (68) |
| `GimpedCarAI/<AggressionTherapyCoroutine>c__Iterator2` | `.ctor` (44), `Dispose` (56), `MoveNext` (532), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `GimpedCarAI/<PowerupUseEvaluationCoroutinue>c__Iterator1` | `.ctor` (44), `Dispose` (56), `MoveNext` (468), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `PathMoverAI` | `.ctor` (244), `FixedUpdate` (752), `Start` (164), `StartTransition` (296) |
| `SphereMoverAI` | `.ctor` (76), `CollisionReflect` (1020), `DoMovement` (148), `FixedUpdate` (52), `OnDrawGizmos` (44), `Start` (212), `Update` (44), `UpdateTarget` (276) |
| `SphereMoverCollider` | `.ctor` (52), `OnTriggerEnter` (144), `Start` (44), `Update` (44) |
| `UsePowerupAIState` | `.ctor` (116), `DoMineEffectExecute` (584), `DoRocketEffectExecute` (264), `DoShieldEffectExecute` (868), `FixedUpdate` (44), `GetAIStateEnum` (48), `Init` (44), `Shutdown` (44), `Update` (356) |

### Personalización del kart — 90 métodos, 30.4 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CartCustomizerPublisher` | `.ctor` (196), `BuyPart` (892), `CameraWaitAndRefresh` (88), `CloseLockedMenu` (156), `EquipPart` (748), `GetPaintMenuIsOut` (52), `InitialWaitForLoadCoroutine` (72), ✅ `IsTemporaryInSlot` (288) ⚠Etapa 2, `OnBikeToggleChanged` (56), `OnBodyToggleChanged` (56), `OnDisable` (88), `OnScoopToggleChanged` (56), `OnSpoilerToggleChanged` (56), `OnThrusterToggleChanged` (56), `OnTrikeToggleChanged` (56), `OnTruckToggleChanged` (56), `OnWheelToggleChanged` (56), `OpenBuyPaint` (804), `OpenPaintIsLocked` (304), `PopulatePaintMenu` (1056), `PressedAction` (184), `PressedBikeForm` (76), `PressedBodySlot` (76), `PressedBuyPaint` (1280), `PressedClosePaint` (208), `PressedDownArrow` (644), `PressedLeftArrow` (516), `PressedOkPaint` (208), `PressedPaint` (264), `PressedRightArrow` (696), `PressedScoopSlot` (76), `PressedSpoilerSlot` (76), `PressedThrusterSlot` (76), `PressedTrikeForm` (76), `PressedTruckForm` (76), `PressedUpArrow` (644), `PressedWheelsSlot` (76), `Refresh` (172) ⚠Etapa 1, `RefreshDisplay` (2552), `RefreshFormToggles` (552), `RefreshNavBlips` (1700), `RefreshStatBars` (1380), `RefreshToggles` (372), `ResetPaintInSlot` (244), `ResetPreviewSlot` (160), `SetCameraToSlot` (472), `SetStatBar` (1064), `SetToSpecificPart` (456), `SetViewingPaintIndex` (504), `SlideBodyFormBox` (88), `Start` (72), `SwitchFormType` (468), `SwitchSlot` (952), `Update` (1896), `get_CurrentSlot` (52) |
| `CartCustomizerPublisher/<CameraWaitAndRefresh>c__Iterator50` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (220), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `CartCustomizerPublisher/<InitialWaitForLoadCoroutine>c__Iterator52` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (360), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `CartCustomizerPublisher/<PressedDownArrow>c__AnonStorey9F` | ✅ `.ctor` (44), ✅ `<>m__22` (84) |
| `CartCustomizerPublisher/<PressedUpArrow>c__AnonStorey9E` | ✅ `.ctor` (44), ✅ `<>m__21` (84) |
| `CartCustomizerPublisher/<SetCameraToSlot>c__AnonStorey9D` | ✅ `.ctor` (44), ✅ `<>m__20` (136) |
| `CartCustomizerPublisher/<SlideBodyFormBox>c__Iterator51` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (984), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `CartCustomizerPublisher/<Start>c__Iterator53` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (2932), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `PaintSlotPublisher` | `.ctor` (52), `OnDestroy` (80), `PressedPaintButton` (144), `SetPaint` (1148), `Start` (140) |

### Audio (música, SFX, voces) — 120 métodos, 17.3 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `AudioManager` | ✅ `.cctor` (36), ✅ `.ctor` (84), ✅ `OnDisable` (68), ✅ `OnEnable` (68), ✅ `get_SoundEffectsVolume` (144) ⚠Etapa 1, ✅ `get_instance` (248) ⚠Etapa 1, ✅ `set_SoundEffectsVolume` (108) |
| `CharacterVOController` | ✅ `.ctor` (196), ✅ `PickClip` (336), ✅ `PlayCelebrate` (72) ⚠Etapa 3, ✅ `PlayCharacterSelect` (72) ⚠Etapa 2, ✅ `PlayClip` (156), ✅ `PlayPout` (72) ⚠Etapa 3 |
| `CharacterVOControllerGameObjectExtender` | ✅ `GetVOController` (132) ⚠Etapa 2 |
| `ClipReference` | `.ctor` (44) |
| `MusicPlayer` | `.cctor` (36), `.ctor` (52), `Awake` (56), `HijackMusicPlayerForSoundStings` (276) ⚠Etapa 3, `PlayMusic` (72) ⚠Etapa 1, `PlayMusic` (288) ⚠Etapa 1, `RestoreVolumeAfterSound` (72), `Start` (104), `StopMusic` (92), `Update` (152), `UpdateVolume` (100) ⚠Etapa 1, `get_Exists` (64), `get_Instance` (248) ⚠Etapa 1 |
| `MusicPlayer/<RestoreVolumeAfterSound>c__Iterator25` | `.ctor` (44), `Dispose` (56), `MoveNext` (172), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `SoundLibrary` | `.cctor` (36), `.ctor` (52), `Awake` (388), `ButtonClickPlay` (116) ⚠Etapa 1, `GetClip` (108), `GetClipHash` (108), `GetClipName` (112), `GetInstanceOfSource` (468), `ManuallyAddClip` (184), `ManuallyRemoveClip` (160), `PauseCameraSound` (348), `PlayClipOnSource` (312), `PlayOneShotClipOnSource` (164), `PlayRandomWhoosh` (188) ⚠Etapa 1, `PlaySoundOnCamera` (248), `PlaySoundOnPlayer` (172) ⚠Etapa 3, `StopClipOnSource` (76), `StopSoundOnCamera` (176), `Update` (76), `get_HashToNameBank` (52), `get_Instance` (248), `get_NameToHashBank` (52), `get_Present` (64), `get_SoundBank` (52) |
| `SoundLibrary/ClipHashDictionary` | `.ctor` (188), `get_Item` (112), `set_Item` (164) |
| `SoundLibrary/HashClipDictionary` | `.ctor` (188), `get_Item` (112), `set_Item` (160) |
| `SoundLibrary/SoundClipDictionary` | `.ctor` (188), `get_Count` (64), `get_Item` (112), `set_Item` (224) |
| `SoundLibrary/SoundClipReference` | `.ctor` (44) |
| `SoundLibraryAddendum` | `.ctor` (52), `Dispose` (52) ⚠Etapa 3, `OnDisable` (128), `OnEnable` (132) |
| `SoundPackage` | `.ctor` (52) |
| `SoundPackageLoadReference` | `.ctor` (44) |
| `SoundPackageManager` | `.cctor` (36), `.ctor` (136), `CleaningPass` (780), `GetClip` (112), `IsClipLoaded` (72), `IsPackageLoaded` (232), `LoadPackage` (304), `LoadPackageCoroutine` (88), `UnloadPackage` (228), `get_Instance` (248), `get_Present` (64) |
| `SoundPackageManager/<IsPackageLoaded>c__AnonStorey96` | `.ctor` (44), `<>m__11` (76) |
| `SoundPackageManager/<LoadPackage>c__AnonStorey94` | `.ctor` (44), `<>m__F` (76) |
| `SoundPackageManager/<LoadPackageCoroutine>c__Iterator31` | `.ctor` (44), `Dispose` (56), `MoveNext` (732), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `SoundPackageManager/<UnloadPackage>c__AnonStorey95` | `.ctor` (44), `<>m__10` (76) |
| `SoundPackageReference` | `.ctor` (44) |
| `SoundSequencer` | `.ctor` (124), `Awake` (180), `DetermineSoundsToPlay` (512), `GetNewSourceAndPlay` (256), `PauseSounds` (364), `Recycle` (72), `RequestPlay` (180) ⚠Etapa 3, `RequestPlayLoop` (108), `SearchUsedList` (500), `SetPriority` (88), `StopLoopingSound` (388), `StopSounds` (352), `UnpauseSounds` (364), `Update` (124), `get_isPaused` (52) |
| `SoundSequencer/<Recycle>c__Iterator26` | `.ctor` (44), `Dispose` (56), `MoveNext` (220), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |

### Utilidades compartidas — 84 métodos, 14.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `AnimatedTexture` | ✅ `UpdateTexture` (72) |
| `AudioCrumb` | ✅ `.ctor` (96) |
| `AudioSourcex` | ✅ `.ctor` (44), ✅ `PlayClipAtTransform` (568), ✅ `PlayClipAtTransform` (112), ✅ `PlayCrumbAtTransform` (84) |
| `DrawArea3D` | ✅ `.ctor` (180) |
| `EdgePixels` | ✅ `.ctor` (44), ✅ `get_xSum` (76), ✅ `get_ySum` (76) |
| `Mathfx` | ✅ `.ctor` (44), ✅ `Bounce` (688), ✅ `ClampAngle` (284), ✅ `Coserp` (240), ✅ `DragBounce` (256), ✅ `Exponential` (196), ✅ `Exponential` (160), ✅ `Hermite` (196), ✅ `Lerp` (124), ✅ `Parameter` (340), ✅ `Sinerp` (212) |
| `MiniJSON` | ✅ `.ctor` (44), ✅ `getLastErrorIndex` (56), ✅ `getLastErrorSnippet` (256), ✅ `lastDecodeSuccessful` (72), ✅ `serializeObjectOrArray` (340) |
| `PIDVectorController` | `.ctor` (432), `.ctor` (360), `CalculateOutput` (692) |
| `ParticleSystemDestroy` | `.ctor` (52), `Start` (72) |
| `ParticleSystemDestroy/<Start>c__Iterator27` | `.ctor` (44), `Dispose` (56), `MoveNext` (492), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `Rangef` | ✅ `InverseLerp` (132), ✅ `get_Range` (76), ✅ `get_random` (108) |
| `Script` | ✅ `<ConvertObjectArray`1>m__3` (68), ✅ `AddAnimation` (124), ✅ `AddAnimation` (120), ✅ `AddComponent` (112), ✅ `AddComponentTo` (96), ✅ `AddComponentTo` (116), ✅ `AddDelayed` (96), ✅ `AnimationHelper` (152), ✅ `ConvertObjectArray` (116), ✅ `CreateLoop` (88), ✅ `CreateLoop` (84), ✅ `CreateLoop` (204), ✅ `DelayedHelper` (116), ✅ `FindNameRecursive` (120), ✅ `FindNameRecursive` (772), ✅ `GetComponentFrom` (96), ✅ `GetComponentFrom` (96), ✅ `GetComponentUpwards` (80), ✅ `GetComponentUpwardsFrom` (140), ✅ `GetComponentUpwardsFrom` (84), ✅ `GetComponentsFrom` (96), ✅ `GetComponentsInChildrenFrom` (96), ✅ `GetComponentsInChildrenFrom` (96), ✅ `InstantiateIfNotPresent` (320), ✅ `InstantiateIfNotPresent` (260), ✅ `SendMessageToGameObjects` (56), ✅ `SendMessageToGameObjects` (232), ✅ `SendMessageToObjectsOfType` (72), ✅ `SendMessageToObjectsOfType` (196) |
| `Script/<AnimationHelper>c__Iterator0` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (420), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `Script/<DelayedHelper>c__Iterator1` | ✅ `.ctor` (44), ✅ `Dispose` (56), ✅ `MoveNext` (216), ✅ `Reset` (64), ✅ `System.Collections.Generic.IEnumerator<object>.get_Current` (52), ✅ `System.Collections.IEnumerator.get_Current` (52) |
| `Vector3x` | `Coserp` (440), `Hermite` (440), `Sinerp` (440) |

### Tutorial — 56 métodos, 12.7 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `FrontEndTutorialHandler` | `.ctor` (68), `ChangedShifterUISlot` (292), `GetNextTutorial` (160), `OnDisable` (144), `Start` (156), `TriggerNext` (588), `Update` (84), `get_ActiveTutorial` (52), `set_ActiveTutorial` (60) |
| `FrontEndTutorialHandler/TutorialSettings` | `.ctor` (92) |
| `FrontEndTutorialPublisher` | `.ctor` (96), `FadeInCoroutine` (72), `OnDisabled` (76), `OnEnabled` (44), `OnPressedDismiss` (144), `OnTargetButtonPressed` (56), `OnTargetTogglePressed` (72), `PulseArrowCoroutine` (72), `RegisterControlListeners` (1484), `Resize` (2736), `SetAnchorPoint` (252), `SetTargetControls` (68), `SetText` (108), `Start` (332), `StartHelper` (72), `UnregisterControlListeners` (872) |
| `FrontEndTutorialPublisher/<FadeInCoroutine>c__Iterator5B` | `.ctor` (44), `Dispose` (56), `MoveNext` (1104), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `FrontEndTutorialPublisher/<PulseArrowCoroutine>c__Iterator5A` | `.ctor` (44), `Dispose` (56), `MoveNext` (1032), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `FrontEndTutorialPublisher/<StartHelper>c__Iterator5C` | `.ctor` (44), `Dispose` (56), `MoveNext` (796), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `TutorialLauncherPublisher` | `.ctor` (52), `PressedNo` (88), `PressedYes` (268), `Start` (44), `StartTutLoad` (72), `Update` (44) |
| `TutorialLauncherPublisher/<StartTutLoad>c__Iterator73` | `.ctor` (44), `Dispose` (56), `MoveNext` (200), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |

### Monedas en pista — 11 métodos, 8.6 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `Coin` | `.ctor` (52), `OnTriggerEnter` (628), `Start` (288) |
| `CoinPoint` | `.ctor` (100), `OnDrawGizmos` (1508), `ProperCoinNum` (212), `SpawnCircleHelper` (4180), `SpawnCoins` (100), `SpawnTrailHelper` (1600), `get_ShapeType` (52), `set_ShapeType` (60) |

### Progresión, bono diario, rewind — 33 métodos, 6.2 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `CarSnapShot` | `.ctor` (172) ⚠Etapa 3, `AddEffectToPowerUpholder` (72) ⚠Etapa 3, `AddToEffectList` (72) ⚠Etapa 3 |
| `LifetimeMetrics` | ✅ `.cctor` (36) ⚠Etapa 1, ✅ `.ctor` (44), ✅ `ContainsKey` (84) ⚠Etapa 3, ✅ `DebugDump` (676), ✅ `Load` (756) ⚠Etapa 1, ✅ `Save` (616) ⚠Etapa 1, ✅ `SetMetric` (260) ⚠Etapa 3, ✅ `Signal` (324) ⚠Etapa 2, ✅ `Signal` (80) ⚠Etapa 2, ✅ `get_Item` (172) ⚠Etapa 2 |
| `RewindDialogPublisher` | `.ctor` (52), `DestroyThis` (72), `FinalizedRewind` (132), `MoneyCheck` (84), `NeedMoreCoins` (168), `PressedBuy` (404), `PressedExit` (100), `Start` (396), `get_RewindCost` (40) |
| `RewindDialogPublisher/<DestroyThis>c__Iterator8B` | `.ctor` (44), `Dispose` (56), `MoveNext` (340), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `RewindLapSlotPublisher` | `.ctor` (52), `PressedRewind` (108) |
| `SnapShotInfo` | `.ctor` (100), `AddCarSnap` (72) ⚠Etapa 3, `DebugDump` (620) |


---

## Port Android (después de la Fase 4)

### Input táctil/inclinación (Android) — 8 métodos, 1.2 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `PlayerAccelControl` | `.ctor` (52), `ApplyReverse` (60), `FixedUpdate` (812), `Start` (44), `Update` (92), `get_isReversing` (52), `set_isReversing` (60) |
| `TouchTurnTrack` | `.ctor` (52) |


---

## Opcional — herramientas de depuración del equipo original

### Depuración (herramientas del equipo original) — 19 métodos, 2.6 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `ApplyEffectDebugUtility` | `.ctor` (92), `Update` (240) |
| `DebugLapButtonPublisher` | `.ctor` (52), `OnButtonPressed` (116), `Start` (44), `Update` (44) |
| `DebugRaceResultPublisher` | `.ctor` (52), `PressedDoneButton` (80), `PressedRewindButton` (72), `Start` (760) |
| `DebugRewindDialogPublisher` | `.ctor` (52), `OnCancelPressed` (56), `OnRewindPressed` (104), `Start` (684), `Update` (44) |
| `RuntimeEditorUtils` | `.ctor` (52) |
| `StreamTest` | `.ctor` (52), `Start` (44), `Update` (44) |


---

## Sin uso detectado (no se traducen salvo que aparezcan en el log)

### Utilidades compartidas — 269 métodos, 77.9 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `<PrivateImplementationDetails>` | `.ctor` (44) |
| `ActiveObjectListSwtich` | `.ctor` (52), `Fire` (276), `OnTriggerEnter` (80), `Start` (68) |
| `AutoDestructParticleSystem` | `.ctor` (52), `LateUpdate` (112), `Start` (44), `Update` (44) |
| `BillboardRemover` | `.ctor` (52), `RemoveBillboards` (72), `Start` (128), `Update` (44) |
| `BillboardRemover/<RemoveBillboards>c__Iterator35` | `.ctor` (44), `Dispose` (56), `MoveNext` (536), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `ByteStream` | `.ctor` (136), `.ctor` (140), `Serialize` (148), `Serialize` (124), `Serialize` (124), `Serialize` (124), `Serialize` (136), `Serialize` (136), `Serialize` (292), `Serialize` (368), `Serialize` (124), `Serialize` (336), `get_Bytes` (68) |
| `DrawArea` | `.ctor` (472), `DrawDiamond` (980), `DrawLine` (236), `DrawRect` (836), `Point` (740) |
| `DrawArea3D` | `Point` (576) |
| `EnumerableScript` | `.ctor` (44) |
| `EnumerableScript`1` | `.cctor` (92), `.ctor` (52), `All` (68), `GetEnumerator` (152), `OnDisable` (180), `Start` (180) |
| `FractalNoise` | `.ctor` (172), `.ctor` (132), `.ctor` (428), `BrownianMotion` (712), `HybridMultifractal` (828), `PrecalculateNOoise` (44), `RidgedMultifractal` (728) |
| `FractalNoiseParams` | `.ctor` (212) |
| `GUIx` | `.cctor` (292), `.ctor` (44), `AutoScaleText` (160), `AutoScaleText` (1964), `BeginGroupShadow` (140), `BeginGroupShadow` (940), `ButtonShadow` (152), `ButtonShadow` (136), `ButtonShadow` (184), `ButtonShadow` (140), `ButtonShadow` (176), `ButtonShadow` (924), `EndGroupShadow` (40), `LabelShadow` (192), `LabelShadow` (216), `LabelShadow` (140), `LabelShadow` (176), `LabelShadow` (204), `LabelShadow` (208), `LabelShadow` (156), `LabelShadow` (752), `RepeatButtonShadow` (156), `RepeatButtonShadow` (144), `RepeatButtonShadow` (184), `RepeatButtonShadow` (140), `RepeatButtonShadow` (924), `ScreenScale` (304), `ScreenScaleBig` (304), `TextRect` (164), `TextRect` (160), `TextRect` (2124), `TextRectShadow` (188), `TextRectShadow` (184), `TextRectShadow` (140), `TextRectShadow` (192), `TextRectShadow` (752), `ToggleShadow` (168), `ToggleShadow` (152), `ToggleShadow` (156), `ToggleShadow` (1720), `get_screenMargin` (296) |
| `Inputx` | `.ctor` (44), `InputDown` (192), `InputDownStart` (180), `InputPosition` (256), `InputUp` (204) |
| `Matrix4x4x` | `.ctor` (44), `AdjustToIPhone` (208), `AdjustToIPhone` (1132), `AdjustToIPhone` (448), `CropMatrix` (1592), `Rotate` (108), `RotateAtOrigin` (980), `Scale` (208), `ScaleAtOrigin` (964), `Translate` (208) |
| `Messenger` | `.cctor` (76), `AddListener` (272), `Broadcast` (72), `Broadcast` (216), `RemoveListener` (284) |
| `MessengerInternal` | `.cctor` (116), `CreateBroadcastSignatureException` (108), `OnBroadcasting` (184), `OnListenerAdding` (360), `OnListenerRemoved` (124), `OnListenerRemoving` (484) |
| `MessengerInternal/BroadcastException` | `.ctor` (60) |
| `MessengerInternal/ListenerException` | `.ctor` (60) |
| `Messenger`1` | `.cctor` (96), `AddListener` (212), `Broadcast` (104), `Broadcast` (200), `RemoveListener` (220) |
| `Messenger`2` | `.cctor` (96), `AddListener` (212), `Broadcast` (112), `Broadcast` (208), `RemoveListener` (220) |
| `Messenger`3` | `.cctor` (96), `AddListener` (212), `Broadcast` (124), `Broadcast` (220), `RemoveListener` (220) |
| `MiniJsonExtensions` | `arrayListFromJson` (112), `hashtableFromJson` (112), `toJson` (52), `toJson` (52) |
| `ObjectGroupList` | `.ctor` (68), `Awake` (56), `get_CurrentState` (52), `set_CurrentState` (348) |
| `PIDController` | `.ctor` (236), `.ctor` (168), `CalculateOutput` (268), `SetPoint` (68) |
| `PIDVectorController` | `SetPoint` (88) |
| `Perlin` | `.cctor` (120), `.ctor` (44), `Noise` (1544), `Noise` (2964), `NoiseNormalized` (180), `fade` (168), `grad` (324), `grad2` (328), `lerp` (104) |
| `Quaternionx` | `.ctor` (44), `QuaternionToMatrix4x4` (1260) |
| `Rectx` | `.ctor` (44), `AddScreenMargin` (412), `DoesContain` (436), `GetBottomLeft` (280), `GetCenter` (356), `WillFitIn` (244) |
| `RewbieShimmer` | `.ctor` (52), `Shimmer` (72), `Update` (672) |
| `RewbieShimmer/<Shimmer>c__Iterator2F` | `.ctor` (44), `Dispose` (56), `MoveNext` (252), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `Screenx` | `.cctor` (84), `.ctor` (44), `ScaleGUI` (444), `ScaleGUIToHeight` (408), `ScaleGUIToWidth` (408), `TouchToScreenCords` (124), `TouchToiPadScreenCoords` (412), `get_aspectRatio` (92), `get_baseAspectRatio` (112), `get_bottomCenter` (204), `get_bottomLeft` (184), `get_bottomRight` (184), `get_center` (248), `get_middleCenter` (92), `get_middleLeft` (204), `get_middleRight` (204), `get_scale` (308), `get_scaleWithCutoff` (312), `get_topCenter` (200), `get_topLeft` (176), `get_topRight` (176) |
| `SmoothFollower` | `.ctor` (196), `.ctor` (192), `GetPosition` (108), `GetVelocity` (108), `Update` (884), `Update` (316) |
| `SmoothRandom` | `.ctor` (44), `Get` (300), `Get` (248), `GetVector3` (744) |
| `TransformGizmo` | `.ctor` (52), `OnDrawGizmosSelected` (536) |
| `UVScroller` | `.ctor` (52), `Start` (152), `Update` (460) |
| `UVScroller/UVScroll` | `.ctor` (76) |
| `Util` | `.ctor` (44), `Bezier` (524), `Clamp` (300), `ConstantLerp` (240), `ConstantLerp` (176), `ConstantSlerp` (368), `ConstantSlerp` (424), `Create3dText` (592), `CreateMatrix` (484), `CreateMatrixPosition` (220), `CyclicDiff` (296), `CyclicDiff` (128), `CyclicDiff` (136), `CyclicDiff` (72), `CyclicDiff` (140), `CyclicDiff` (68), `CyclicIsLower` (364), `CyclicIsLower` (160), `CyclicIsLower` (144), `CyclicIsLower` (72), `CyclicLerp` (408), `FatalError` (56), `Find` (728), `GetCornerPointsFromBounds` (2908), `GetHighest` (276), `GetLineSphereIntersections` (1100), `GetLowest` (276), `GetTimeString` (364), `IsSaneNumber` (308), `MD5` (300), `MatrixFromQuaternion` (360), `MatrixFromQuaternionPosition` (272), `MatrixSlerp` (896), `Mod` (196), `Mod` (84), `Mod` (112), `Mod` (56), `ProjectOntoPlane` (196), `QuaternionFromMatrix` (1564), `RelativeMatrix` (352), `SetHeight` (264), `Split` (120), `TransformFromMatrix` (336), `TransformVector` (260), `TransformVector` (256), `TranslateMatrix` (244), `toMinuteSeconds` (288), `toMinuteSubSeconds` (448) |
| `Vector3x` | `.cctor` (220), `.ctor` (44), `FromString` (452), `Inverse` (268) |
| `WindowIDs` | `.cctor` (36), `.ctor` (52), `FetchID` (84), `OnDisable` (68) |


---

## Sin uso (scripts UnityScript sin referencias)

### Framework UI: componentes sin instancias ni llamadas en el juego — 145 métodos, 39.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `Dialog` | `.ctor` (260), `Activate` (92), `ActivateHelper` (72), `Awake` (80), `Deactivate` (92), `DeactivateHelper` (72), `DoWindow` (48), `OnActivateUpdate` (664), `OnActivated` (64), `OnActivating` (44), `OnDeactivateUpdate` (44), `OnDeactivated` (64), `OnDeactivating` (44), `OnDraw` (308), `OnDrawUnderlay` (44), `OnGUI` (44), `OnStart` (296), `RenderGUI` (2176), `Start` (72), `get_On` (52) |
| `Dialog/<ActivateHelper>c__Iterator3` | `.ctor` (44), `Dispose` (56), `MoveNext` (596), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `Dialog/<DeactivateHelper>c__Iterator4` | `.ctor` (44), `Dispose` (56), `MoveNext` (584), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `Dialog/<Start>c__Iterator2` | `.ctor` (44), `Dispose` (56), `MoveNext` (268), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `LEDScroller` | `.ctor` (184), `AddText` (120), `CheckForNewText` (240), `ClearText` (64), `OnDisable` (256), `OnEnable` (256), `OnFlash` (80), `OnFlashHelper` (72), `OnNewTextCheck` (104), `OnResetScroller` (112), `OnScroll` (80), `OnScrollHelper` (72), `OnStaticText` (264), `RemoveText` (116), `ReplaceText` (172), `SetUpNewStringForDisplayHelper` (308), `Start` (108), `TextStringCount` (64), `Update` (340), `add_HandleNewTextCheck` (160), `get_CurrentString` (52), `get_EndofSentence` (52), `remove_HandleNewTextCheck` (160), `set_CurrentString` (60), `set_EndofSentence` (60) |
| `LEDScroller/<OnFlashHelper>c__Iterator27` | `.ctor` (44), `Dispose` (56), `MoveNext` (504), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `LEDScroller/<OnScrollHelper>c__Iterator26` | `.ctor` (44), `Dispose` (56), `MoveNext` (764), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `LEDScroller/TextString` | `.ctor` (80), `get_Flash` (52), `get_Scroll` (52), `get_Text` (52), `set_Flash` (60), `set_Scroll` (60), `set_Text` (60) |
| `UghScrollView` | `.ctor` (188), `Awake` (208), `ForceSnapScrolling` (140), `HandleExplicitScrolling` (72), `HandleSnapScrolling` (72), `HandleVelocityScrolling` (72), `OnScrollPositionChanged` (940), `OnUghInputDown` (72), `ScrollToPosition` (536), `SnapScroll` (140), `SnapScrollByShift` (556), `SnapScrollToIndex` (1540), `UpdateRealDeltaTime` (132), `add_ScrollSnapped` (148), `add_ScrollSoftSnapped` (148), `get_HorizontalContents` (52), `get_ScrollPosition` (108), `get_SnapSpacing` (108), `get_VerticalContents` (52), `get_ViewSize` (108), `remove_ScrollSnapped` (148), `remove_ScrollSoftSnapped` (148), `set_HorizontalContents` (64), `set_ScrollPosition` (188), `set_SnapSpacing` (88), `set_VerticalContents` (64), `set_ViewSize` (88) |
| `UghScrollView/<ForceSnapScrolling>c__Iterator21` | `.ctor` (44), `Dispose` (56), `MoveNext` (264), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UghScrollView/<HandleExplicitScrolling>c__Iterator1E` | `.ctor` (44), `Dispose` (56), `MoveNext` (4524), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UghScrollView/<HandleSnapScrolling>c__Iterator20` | `.ctor` (44), `Dispose` (56), `MoveNext` (5184), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UghScrollView/<HandleVelocityScrolling>c__Iterator1F` | `.ctor` (44), `Dispose` (56), `MoveNext` (4908), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UghScrollView/<OnUghInputDown>c__Iterator1D` | `.ctor` (44), `Dispose` (56), `MoveNext` (1536), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `UghScrollView/<SnapScroll>c__Iterator22` | `.ctor` (44), `Dispose` (56), `MoveNext` (3024), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |

### Sin uso (UnityScript, 0 referencias) — 10 métodos, 10.5 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `Car_Script` | `.ctor` (468), `FixedUpdate` (2800), `Main` (484), `SetWheelParams` (540), `Start` (1416) |
| `Plane_Script` | `.ctor` (244), `Main` (484), `Start` (188), `Update` (4036) |
| `WheelData` | `.ctor` (44) |


---

## Eliminados (servicios iOS/externos)

### ELIMINADO (servicio iOS/externo) — 635 métodos, 124.9 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `AgeGatePopup` | `.ctor` (76), `<Start>m__1E` (124), `<Start>m__1F` (52), `AddCharacterToAnswer` (236), `CalcAnswer` (384), `ExecuteOperator` (156), `GetOperatorSymbol` (204), `SetupButton` (328), `SetupProblem` (2000), `Start` (1388), `TestAnswer` (184), `Update` (132) |
| `AgeGatePopup/<SetupButton>c__AnonStorey9B` | `.ctor` (44), `<>m__1C` (68) |
| `AgeGatePopup/<Start>c__AnonStorey9C` | `.ctor` (44), `<>m__1D` (76) |
| `BurstlyBinding` | `CacheInterstitial` (52), `HideBanner` (40), `Init` (52), `PlaceFakeBanner` (204), `RemoveFakeBanner` (40), `SetInterstitialAutoCache` (60), `SetRefreshInterval` (68), `ShowBanner` (268), `ShowInterstitial` (52) |
| `DebugMoreCoinsPublisher` | `.ctor` (52), `AddButtonsToLegalControls` (412), `CancelPressed` (96), `CoinPackOnePressed` (96), `CoinPackThreePressed` (96), `CoinPackTwoPressed` (96), `DestroyThis` (72), `GetInstance` (132), `ReBuyHelper` (164), `Start` (48) |
| `DebugMoreCoinsPublisher/<DestroyThis>c__Iterator4B` | `.ctor` (44), `Dispose` (56), `MoveNext` (340), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `Email` | `.ctor` (44), `EscapeText` (108), `Send` (128) |
| `GDMOBinding` | `.ctor` (44), `FlushAnalyticsQueue` (40), `InitWithAppKey` (60), `InitWithAppKey` (68), `LogAnalyticsEvent` (52), `LogAnalyticsEventWithContext` (68) |
| `GDMOManager` | `.cctor` (36), `.ctor` (52), `Flush` (44), `Init` (228), `OnApplicationPause` (48), `Send` (56), `SendWithContext` (64), `Start` (88) |
| `GameCenterAchievement` | `.ctor` (816), `ToString` (424), `fromJSON` (720) |
| `GameCenterAchievementMetadata` | `.ctor` (628), `ToString` (320), `fromJSON` (720) |
| `GameCenterBinding` | `.ctor` (44), `authenticateLocalPlayer` (52), `getAchievements` (52), `isGameCenterAvailable` (60), `isPlayerAuthenticated` (60), `isUnderage` (60), `loadLeaderboardTitles` (52), `loadPlayerData` (92), `loadProfilePhotoForLocalPlayer` (52), `playerAlias` (76), `playerIdentifier` (76), `reportAchievement` (88), `reportScore` (80), `resetAchievements` (52), `retrieveAchievementMetadata` (52), `retrieveFriends` (64), `retrieveScores` (88), `retrieveScores` (104), `retrieveScoresForPlayerId` (64), `retrieveScoresForPlayerId` (72), `showAchievements` (52), `showCompletionBannerForAchievements` (52), `showLeaderboardWithTimeScope` (64), `showLeaderboardWithTimeScopeAndLeaderboard` (72) |
| `GameCenterEventListener` | `.ctor` (52), `OnDisable` (1732), `Start` (1808), `achievementMetadataLoaded` (328), `achievementsLoaded` (328), `categoriesLoaded` (328), `loadAchievementsFailed` (76), `loadCategoryTitlesFailed` (76), `loadPlayerDataFailed` (76), `playerAuthenticated` (64), `playerDataLoaded` (328), `playerFailedToAuthenticate` (76), `playerLoggedOut` (64), `profilePhotoFailed` (76), `profilePhotoLoaded` (76), `reportAchievementFailed` (76), `reportAchievementFinished` (76), `reportScoreFailed` (76), `reportScoreFinished` (76), `resetAchievementsFailed` (76), `resetAchievementsFinished` (64), `retrieveAchievementMetadataFailed` (76), `retrieveScoresFailed` (76), `retrieveScoresForPlayerIdFailed` (76), `scoresForPlayerIdLoaded` (328), `scoresLoaded` (328) |
| `GameCenterGUIManager` | `.ctor` (52), `<Start>m__0` (60), `<Start>m__1` (60), `<Start>m__2` (40), `OnGUI` (4152), `Start` (348) |
| `GameCenterLeaderboard` | `.ctor` (72), `ToString` (76), `fromJSON` (888) |
| `GameCenterManager` | `.ctor` (52), `Awake` (108), `Start` (88), `achievementMetadataDidLoad` (124), `achievementsDidLoad` (124), `add_achievementMetadataLoaded` (160), `add_achievementsLoaded` (160), `add_categoriesLoaded` (160), `add_loadAchievementsFailed` (160), `add_loadCategoryTitlesFailed` (160), `add_loadPlayerDataFailed` (160), `add_playerAuthenticated` (160), `add_playerDataLoaded` (160), `add_playerFailedToAuthenticate` (160), `add_playerLoggedOut` (160), `add_profilePhotoFailed` (160), `add_profilePhotoLoaded` (160), `add_reportAchievementFailed` (160), `add_reportAchievementFinished` (160), `add_reportScoreFailed` (160), `add_reportScoreFinished` (160), `add_resetAchievementsFailed` (160), `add_resetAchievementsFinished` (160), `add_retrieveAchievementMetadataFailed` (160), `add_retrieveScoresFailed` (160), `add_retrieveScoresForPlayerIdFailed` (160), `add_scoresForPlayerIdLoaded` (160), `add_scoresLoaded` (160), `categoriesDidLoad` (124), `loadAchievementsDidFail` (112), `loadCategoryTitlesDidFail` (112), `loadPlayerDataDidFail` (112), `loadPlayerDataDidLoad` (124), `loadProfilePhotoDidFail` (112), `loadProfilePhotoDidLoad` (112), `playerAuthenticationFailed` (112), `playerDidAuthenticate` (104), `playerDidLogOut` (104), `remove_achievementMetadataLoaded` (160), `remove_achievementsLoaded` (160), `remove_categoriesLoaded` (160), `remove_loadAchievementsFailed` (160), `remove_loadCategoryTitlesFailed` (160), `remove_loadPlayerDataFailed` (160), `remove_playerAuthenticated` (160), `remove_playerDataLoaded` (160), `remove_playerFailedToAuthenticate` (160), `remove_playerLoggedOut` (160), `remove_profilePhotoFailed` (160), `remove_profilePhotoLoaded` (160), `remove_reportAchievementFailed` (160), `remove_reportAchievementFinished` (160), `remove_reportScoreFailed` (160), `remove_reportScoreFinished` (160), `remove_resetAchievementsFailed` (160), `remove_resetAchievementsFinished` (160), `remove_retrieveAchievementMetadataFailed` (160), `remove_retrieveScoresFailed` (160), `remove_retrieveScoresForPlayerIdFailed` (160), `remove_scoresForPlayerIdLoaded` (160), `remove_scoresLoaded` (160), `reportAchievementDidFail` (112), `reportAchievementDidFinish` (112), `reportScoreDidFail` (112), `reportScoreDidFinish` (112), `resetAchievementsDidFail` (112), `resetAchievementsDidFinish` (108), `retrieveAchievementsMetadataDidFail` (112), `retrieveScoresDidFail` (112), `retrieveScoresDidLoad` (124), `retrieveScoresForPlayerIdDidFail` (112), `retrieveScoresForPlayerIdDidLoad` (124) |
| `GameCenterPlayer` | `.ctor` (488), `ToString` (136), `fromJSON` (720) |
| `GameCenterScore` | `.ctor` (1352), `ToString` (400), `fromJSON` (720) |
| `GravCloudBinding` | `DoesFileExist` (60), `GetFile` (92), `HasCloudAccess` (40), `Init` (40), `PutFile` (68) |
| `GravCloudPrefs` | `.cctor` (244), `.ctor` (52), `DeleteAll` (112), `DeleteGravCloudFile` (164), `EditorDeleteAll` (156), `GetBool` (200), `GetDictionary` (208), `GetFloat` (228), `GetInt` (176), `GetInt64` (212), `GetLong` (208), `GetString` (172), `HasKey` (104), `Init` (284), `Load` (108), `LoadFromFileStream` (1080), `OnApplicationPause` (64), `OnApplicationQuit` (44), `OnGravCloudPrefsFileCallback` (452), `RemoveKey` (148), `Save` (36), `Serialize` (36), `SetBool` (260), `SetDictionary` (244), `SetFloat` (252), `SetInt` (236), `SetInt64` (240), `SetLong` (248), `SetString` (200), `WaitForLoadCoroutine` (72), `get_IsLoaded` (56) |
| `GravCloudPrefs/<WaitForLoadCoroutine>c__Iterator7` | `.ctor` (44), `Dispose` (56), `MoveNext` (1456), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudData` | `.cctor` (128), `.ctor` (52), `DeleteAll` (116), `DeleteKey` (132), `GetFloat` (232), `GetFloat` (96), `GetInt` (164), `GetInt` (56), `GetString` (188), `GetString` (72), `HasKey` (356), `KeyValueStoreDidChangeExternally` (964), `PollCloudDataAvailability` (116), `RegisterCloudDataExternalChanges` (456), `Save` (116), `SetFloat` (176), `SetInt` (144), `SetString` (144), `UnregisterCloudDataExternalChanges` (272) |
| `JCloudDictionary` | `.cctor` (128), `.ctor` (52), `DeleteAll` (116), `DeleteKey` (132), `GetFloat` (232), `GetFloat` (96), `GetInt` (164), `GetInt` (56), `GetString` (188), `GetString` (72), `HasKey` (132), `KeyValueStoreDidChangeExternally` (964), `PollCloudDictionaryAvailability` (116), `RegisterCloudDictionaryExternalChanges` (448), `Save` (116), `SetFloat` (176), `SetInt` (144), `SetString` (144), `UnregisterCloudDictionaryExternalChanges` (272) |
| `JCloudDocument` | `.cctor` (60), `.ctor` (52), `DirectoryCopy` (500), `DirectoryCreate` (320), `DirectoryDelete` (300), `DirectoryExists` (304), `DirectoryGetDirectories` (604), `DirectoryGetFiles` (604), `DirectoryModificationDate` (672), `DirectoryMove` (500), `DismissCloudDocument` (60), `FileCopy` (500), `FileDelete` (300), `FileExists` (304), `FileModificationDate` (672), `FileMove` (500), `FileReadAllBytes` (432), `FileWriteAllBytes` (348), `NewCloudDocument` (76), `PollCloudDocumentAvailability` (116) |
| `JCloudDocumentAsync` | `.cctor` (60), `.ctor` (52), `DirectoryCopy` (136), `DirectoryCopyOperation` (124), `DirectoryCreate` (120), `DirectoryCreateOperation` (92), `DirectoryDelete` (120), `DirectoryDeleteOperation` (92), `DirectoryExists` (120), `DirectoryExistsOperation` (92), `DirectoryGetDirectories` (120), `DirectoryGetDirectoriesOperation` (92), `DirectoryGetFiles` (120), `DirectoryGetFilesOperation` (92), `DirectoryModificationDate` (120), `DirectoryModificationDateOperation` (92), `DirectoryMove` (136), `DirectoryMoveOperation` (124), `DismissCloudDocument` (68), `FileCopy` (136), `FileCopyOperation` (124), `FileDelete` (120), `FileDeleteOperation` (92), `FileExists` (120), `FileExistsOperation` (92), `FileModificationDate` (120), `FileModificationDateOperation` (92), `FileMove` (136), `FileMoveOperation` (124), `FileReadAllBytes` (120), `FileReadAllBytesOperation` (92), `FileWriteAllBytes` (128), `FileWriteAllBytesOperation` (108), `NewCloudDocument` (76), `PollCloudDocumentAvailability` (116) |
| `JCloudDocumentAsync/<DirectoryCopyOperation>c__Iterator17` | `.ctor` (44), `Dispose` (56), `MoveNext` (996), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<DirectoryCreateOperation>c__Iterator11` | `.ctor` (44), `Dispose` (56), `MoveNext` (748), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<DirectoryDeleteOperation>c__Iterator13` | `.ctor` (44), `Dispose` (56), `MoveNext` (748), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<DirectoryExistsOperation>c__Iterator12` | `.ctor` (44), `Dispose` (56), `MoveNext` (756), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<DirectoryGetDirectoriesOperation>c__Iterator15` | `.ctor` (44), `Dispose` (56), `MoveNext` (1240), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<DirectoryGetFilesOperation>c__Iterator14` | `.ctor` (44), `Dispose` (56), `MoveNext` (1240), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<DirectoryModificationDateOperation>c__Iterator16` | `.ctor` (44), `Dispose` (56), `MoveNext` (1072), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<DirectoryMoveOperation>c__Iterator18` | `.ctor` (44), `Dispose` (56), `MoveNext` (996), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<FileCopyOperation>c__IteratorF` | `.ctor` (44), `Dispose` (56), `MoveNext` (996), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<FileDeleteOperation>c__IteratorB` | `.ctor` (44), `Dispose` (56), `MoveNext` (748), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<FileExistsOperation>c__IteratorA` | `.ctor` (44), `Dispose` (56), `MoveNext` (756), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<FileModificationDateOperation>c__IteratorE` | `.ctor` (44), `Dispose` (56), `MoveNext` (1072), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<FileMoveOperation>c__Iterator10` | `.ctor` (44), `Dispose` (56), `MoveNext` (996), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<FileReadAllBytesOperation>c__IteratorD` | `.ctor` (44), `Dispose` (56), `MoveNext` (888), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsync/<FileWriteAllBytesOperation>c__IteratorC` | `.ctor` (44), `Dispose` (56), `MoveNext` (784), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudDocumentAsyncOperation` | `.ctor` (44) |
| `JCloudExtern` | `.cctor` (436), `.ctor` (44) |
| `JCloudManager` | `.cctor` (316), `.ctor` (52), `CheckDocumentLock` (256), `CheckManagerStatus` (320), `CopyDirectory` (400), `DocumentResultDidChange` (468), `DocumentStateDidChange` (328), `GetDocumentLock` (412), `GetDocumentResult` (260), `GetDocumentState` (208), `GetSharedManager` (60), `PathListFromBytes` (324), `ReleaseDocumentLock` (332), `UnwatchDocument` (632), `WatchAsyncDocument` (356), `WatchDocument` (356) |
| `JCloudManager/DocumentLock` | `.ctor` (72) |
| `JCloudRoutine` | `.cctor` (80), `.ctor` (44), `Cancel` (56), `Create` (112), `Execute` (88), `Run` (80), `add_Cancelled` (148), `add_Finished` (148), `remove_Cancelled` (148), `remove_Finished` (148) |
| `JCloudRoutine/<Execute>c__Iterator19` | `.ctor` (44), `Dispose` (56), `MoveNext` (580), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `JCloudRoutineReturn` | `.ctor` (44), `get_cancel` (52), `get_finished` (52), `set_cancel` (60), `set_finished` (60) |
| `MoreDisneyLogic` | `.ctor` (52), `Start` (260), `WaitForDestroy` (64) |
| `MoreDisneyLogic/<WaitForDestroy>c__Iterator64` | `.ctor` (44), `Dispose` (56), `MoveNext` (388), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `MoreGamesBinding` | `.ctor` (44), `HideWindow` (40), `Init` (40), `IsShowingWindow` (40), `ShowWindow` (40) |
| `P31CloudFile` | `.cctor` (176), `.ctor` (44), `delete` (84), `exists` (84), `listAllFiles` (72), `readAllBytes` (84), `readAllLines` (84), `writeAllBytes` (96), `writeAllText` (96) |
| `P31CloudFile/CloudFileManager` | `.ctor` (60), `writeAllBytes` (120), `writeAllText` (120) |
| `P31CloudFile/LocalFileManager` | `.ctor` (60), `delete` (72), `exists` (68), `listAllFiles` (56), `readAllBytes` (96), `readAllLines` (96), `writeAllBytes` (80), `writeAllText` (80) |
| `P31Prefs` | `.cctor` (228), `.ctor` (44), `<P31Prefs>m__9` (84), `HasKey` (96), `getBool` (108), `getDictionary` (108), `getFloat` (128), `getInt` (96), `getString` (96), `get_iCloudAvailable` (60), `get_iCloudDocumentStoreAvailable` (60), `removeObjectForKey` (92), `setBool` (136), `setDictionary` (116), `setFloat` (140), `setInt` (104), `setString` (104), `synchronize` (84) |
| `ResultLogger` | `.ctor` (44), `addArraylistToString` (896), `addHashtableToString` (1056), `logArraylist` (704), `logHashtable` (108), `logObject` (300) |
| `StoreKitBinding` | `.ctor` (44), `canMakePayments` (60), `getAllSavedTransactions` (112), `purchaseProduct` (72), `requestProductData` (84), `restoreCompletedTransactions` (52), `validateAutoRenewableReceipt` (80), `validateReceipt` (72) |
| `StoreKitEventListener` | `.ctor` (52), `OnDisable` (820), `OnEnable` (820), `productListReceived` (420), `productListRequestFailed` (76), `purchaseCancelled` (76), `purchaseFailed` (76), `purchaseSuccessful` (76), `receiptValidationFailed` (76), `receiptValidationRawResponseReceived` (76), `receiptValidationSuccessful` (64), `restoreTransactionsFailed` (76), `restoreTransactionsFinished` (64) |
| `StoreKitGUIManager` | `.ctor` (52), `<Start>m__5` (132), `OnGUI` (3084), `Start` (144) |
| `StoreKitManager` | `.ctor` (52), `Awake` (108), `Start` (88), `add_productListReceived` (160), `add_productListRequestFailed` (160), `add_purchaseCancelled` (160), `add_purchaseFailed` (160), `add_purchaseSuccessful` (160), `add_receiptValidationFailed` (160), `add_receiptValidationRawResponseReceived` (160), `add_receiptValidationSuccessful` (160), `add_restoreTransactionsFailed` (160), `add_restoreTransactionsFinished` (160), `productPurchaseCancelled` (112), `productPurchaseFailed` (112), `productPurchased` (128), `productsReceived` (128), `productsRequestDidFail` (112), `remove_productListReceived` (160), `remove_productListRequestFailed` (160), `remove_purchaseCancelled` (160), `remove_purchaseFailed` (160), `remove_purchaseSuccessful` (160), `remove_receiptValidationFailed` (160), `remove_receiptValidationRawResponseReceived` (160), `remove_receiptValidationSuccessful` (160), `remove_restoreTransactionsFailed` (160), `remove_restoreTransactionsFinished` (160), `restoreCompletedTransactionsFailed` (112), `restoreCompletedTransactionsFinished` (108), `validateReceiptFailed` (112), `validateReceiptFinished` (240), `validateReceiptRawResponse` (112) |
| `StoreKitProduct` | `.ctor` (44), `ToString` (264), `productFromHashtable` (712), `productsFromJson` (696) |
| `StoreKitTransaction` | `.ctor` (44), `ToString` (136), `transactionFromHashtable` (348), `transactionFromJson` (56), `transactionsFromJson` (696) |
| `iCloudBinding` | `.ctor` (44), `addFile` (72), `boolForKey` (72), `dictionaryForKey` (168), `documentStoreAvailable` (60), `documentsDirectory` (76), `doubleForKey` (108), `evictFile` (64), `hasKey` (72), `intForKey` (72), `isFileDownloaded` (72), `isFileInCloud` (72), `isiCloudAvailable` (60), `removeObjectForKey` (64), `setBool` (72), `setDictionary` (72), `setDouble` (88), `setInt` (72), `setString` (72), `stringForKey` (88), `synchronize` (60) |
| `iCloudEventListener` | `.ctor` (52), `OnDisable` (288), `OnEnable` (288), `documentStoreUpdatedEvent` (308), `entitlementsMissingEvent` (64), `keyValueStoreDidChangeEvent` (644) |
| `iCloudGUIManager` | `.ctor` (72), `OnGUI` (5304) |
| `iCloudManager` | `.ctor` (52), `Awake` (108), `add_documentStoreUpdatedEvent` (160), `add_entitlementsMissingEvent` (160), `add_keyValueStoreDidChangeEvent` (160), `documentStoreUpdated` (124), `entitlementsMissing` (108), `keyValueStoreDidChange` (124), `remove_documentStoreUpdatedEvent` (160), `remove_entitlementsMissingEvent` (160), `remove_keyValueStoreDidChangeEvent` (160) |
| `iCloudManager/iCloudDocument` | `.ctor` (252), `ToString` (128), `fromJSON` (740) |

### Guardado local y datos globales — 29 métodos, 5.2 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `DataUtility` | `.ctor` (204), `<ProductListRecieved>m__4` (220), `FinalizePurchase` (104), `FinalizeStore` (80), `JCloudDataDidChangeExternally` (96), `ProductListRecieved` (876), `ProductListRequestFailed` (88), `PurchaseCoinsFromStoreKit` (216), `PurchaseFailed` (100), `PurchaseSuccessful` (96), `SetupItemsForPurchase` (180), `StartStorePurchase` (72), `gcDisplayReportedAchievement` (92), `gcPlayerAuthenticateFailed` (76), `gcPlayerAuthenticated` (68), `gcReportAchievementFailed` (76), `iCloudDataChanged` (56) |
| `DataUtility/<FinalizePurchase>c__Iterator22` | `.ctor` (44), `Dispose` (56), `MoveNext` (1600), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |
| `DataUtility/<StartStorePurchase>c__Iterator21` | `.ctor` (44), `Dispose` (56), `MoveNext` (532), `Reset` (64), `System.Collections.Generic.IEnumerator<object>.get_Current` (52), `System.Collections.IEnumerator.get_Current` (52) |


---

## Sin código nativo (abstract / extern)

### ELIMINADO (servicio iOS/externo) — 124 métodos, 0.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `BurstlyBinding` | `_CacheInterstitial` (0), `_HideBanner` (0), `_Init` (0), `_PlaceFakeBanner` (0), `_RemoveFakeBanner` (0), `_SetInterstitialAutoCache` (0), `_SetRefreshInterval` (0), `_ShowBanner` (0), `_ShowInterstitial` (0) |
| `GDMOBinding` | `_GDMOFlushAnalyticsQueue` (0), `_GDMOInitWithAppKey` (0), `_GDMOInitWithAppKeyEx` (0), `_GDMOLogAnalyticsEvent` (0), `_GDMOLogAnalyticsEventWithJSON` (0) |
| `GameCenterBinding` | `_gameCenterAuthenticateLocalPlayer` (0), `_gameCenterGetAchievements` (0), `_gameCenterIsGameCenterAvailable` (0), `_gameCenterIsPlayerAuthenticated` (0), `_gameCenterIsUnderage` (0), `_gameCenterLoadLeaderboardLeaderboardTitles` (0), `_gameCenterLoadPlayerData` (0), `_gameCenterLoadProfilePhotoForLocalPlayer` (0), `_gameCenterPlayerAlias` (0), `_gameCenterPlayerIdentifier` (0), `_gameCenterReportAchievement` (0), `_gameCenterReportScore` (0), `_gameCenterResetAchievements` (0), `_gameCenterRetrieveAchievementMetadata` (0), `_gameCenterRetrieveFriends` (0), `_gameCenterRetrieveScores` (0), `_gameCenterRetrieveScoresForLeaderboard` (0), `_gameCenterRetrieveScoresForPlayerId` (0), `_gameCenterRetrieveScoresForPlayerIdAndLeaderboard` (0), `_gameCenterShowAchievements` (0), `_gameCenterShowCompletionBannerForAchievements` (0), `_gameCenterShowLeaderboardWithTimeScope` (0), `_gameCenterShowLeaderboardWithTimeScopeAndLeaderboardId` (0) |
| `GravCloudBinding` | `_GravCloudDoesFileExist` (0), `_GravCloudGetFile` (0), `_GravCloudHasCloudAccess` (0), `_GravCloudInit` (0), `_GravCloudPutFile` (0) |
| `JCloudExtern` | `CloudDataDeleteAll` (0), `CloudDataDeleteKey` (0), `CloudDataGetFloat` (0), `CloudDataGetInt` (0), `CloudDataGetString` (0), `CloudDataHasKey` (0), `CloudDataSave` (0), `CloudDataSetCallbackPointer` (0), `CloudDataSetFloat` (0), `CloudDataSetInt` (0), `CloudDataSetShouldMessage` (0), `CloudDataSetString` (0), `CloudDictionaryDocumentDeleteAll` (0), `CloudDictionaryDocumentDeleteKey` (0), `CloudDictionaryDocumentGetFloat` (0), `CloudDictionaryDocumentGetInt` (0), `CloudDictionaryDocumentGetString` (0), `CloudDictionaryDocumentHasKey` (0), `CloudDictionaryDocumentSave` (0), `CloudDictionaryDocumentSetCallbackPointer` (0), `CloudDictionaryDocumentSetFloat` (0), `CloudDictionaryDocumentSetInt` (0), `CloudDictionaryDocumentSetShouldMessage` (0), `CloudDictionaryDocumentSetString` (0), `CopyCloudItem` (0), `CopyCloudItemSync` (0), `CreateOrOpenCloudItem` (0), `CreateOrOpenCloudItemSync` (0), `DeleteCloudItem` (0), `DeleteCloudItemSync` (0), `DismissCloudItem` (0), `FreeMemory` (0), `GetCloudDirectoryPath` (0), `GetCloudItemExistence` (0), `GetCloudItemExistenceSync` (0), `GetCloudItemModificationDate` (0), `GetCloudItemModificationDateSync` (0), `GetCloudItemState` (0), `GetUbiquitousContainerAvailability` (0), `GetUbiquitousStoreAvailability` (0), `IsJailbroken` (0), `MoveCloudItem` (0), `MoveCloudItemSync` (0), `OpenCloudItem` (0), `OpenCloudItemSync` (0), `PrepareCloudItem` (0), `ReadCloudItemContents` (0), `SetPersistentDataPath` (0), `SetResultChangeCallbackPointer` (0), `SetStateChangeCallbackPointer` (0), `WriteCloudItemContents` (0) |
| `MoreGamesBinding` | `_MoreGamesHideWindow` (0), `_MoreGamesInit` (0), `_MoreGamesIsShowingWindow` (0), `_MoreGamesShowWindow` (0) |
| `StoreKitBinding` | `_storeKitCanMakePayments` (0), `_storeKitGetAllSavedTransactions` (0), `_storeKitPurchaseProduct` (0), `_storeKitRequestProductData` (0), `_storeKitRestoreCompletedTransactions` (0), `_storeKitValidateAutoRenewableReceipt` (0), `_storeKitValidateReceipt` (0) |
| `iCloudBinding` | `_iCloudAddFile` (0), `_iCloudBoolForKey` (0), `_iCloudDictionaryForKey` (0), `_iCloudDocumentStoreAvailable` (0), `_iCloudDocumentsDirectory` (0), `_iCloudDoubleForKey` (0), `_iCloudEvictFile` (0), `_iCloudHasKey` (0), `_iCloudIntForKey` (0), `_iCloudIsFileDownloaded` (0), `_iCloudIsFileInCloud` (0), `_iCloudIsiCloudAvailable` (0), `_iCloudRemoveObjectForKey` (0), `_iCloudSetBool` (0), `_iCloudSetDictionary` (0), `_iCloudSetDouble` (0), `_iCloudSetInt` (0), `_iCloudSetString` (0), `_iCloudStringForKey` (0), `_iCloudSynchronize` (0) |

### Framework UI propio (Ugh) — 4 métodos, 0.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `UghStretch/MPDirtyAlignHandler` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |

### Framework UI: componentes sin instancias ni llamadas en el juego — 12 métodos, 0.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `LEDScroller/NewTextCheckHandler` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |
| `UghScrollView/ScrollSnappedHandler` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |
| `UghScrollView/ScrollSoftSnappedHandler` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |

### Gestión de carrera — 4 métodos, 0.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `RaceManager/RaceInitHandler` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |

### IA de rivales — 9 métodos, 0.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `BaseCarAIState` | `FixedUpdate` (0), `GetAIStateEnum` (0), `Init` (0), `Shutdown` (0), `Update` (0) |
| `CarAI/TestActionDelegate` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |

### Misiones y logros internos — 9 métodos, 0.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `AchievementListener` | `IsAvailable` (0), `Postrace` (0), `Prerace` (0), `Reward` (0) |
| `BaseMission` | `Init` (0), `Shutdown` (0), `Signal` (0), `Signal` (0), `Update` (0) |

### Power-ups, efectos y obstáculos — 6 métodos, 0.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `BaseEffect` | `GetEffectSnapShot` (0), `Init` (0), `Shutdown` (0), `Stack` (0), `Update` (0) |
| `BasePickup` | `GetTriggeredEffect` (0) |

### Utilidades compartidas — 20 métodos, 0.0 KB ARM

| Clase | Métodos (bytes ARM) |
|---|---|
| `Callback` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |
| `Callback`1` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |
| `Callback`2` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |
| `Callback`3` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |
| `Script/AnimationDelegate` | `.ctor` (0), `BeginInvoke` (0), `EndInvoke` (0), `Invoke` (0) |
