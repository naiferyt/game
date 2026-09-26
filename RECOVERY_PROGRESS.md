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

### Etapa 1 — Boot → Menú  ·  Etapa 2 — Menú → Carrera  ·  Etapa 3 — Carrera mínima  ·  Etapa 4 — Sistemas completos
- [ ] (pendiente)

## RECOVERED FROM ORIGINAL
| Elemento | Etiqueta | Evidencia |
|---|---|---|
| 17 escenas, 579 prefabs, materiales, texturas, audio, animaciones | RECUPERADO | export AssetRipper de los `.assets` originales |
| 365 mallas comprimidas | RECUPERADO | decodificadas con UnityPy desde los `.assets` originales; verificadas contra su AABB |
| 3 shaders fixed-function custom | RECUPERADO | texto ShaderLab original del build |
| Matriz de colisión de capas | RECUPERADO | `PhysicsManager` en `mainData` |
| `ProgressTriggerLogic.CanTriggerForCar/OnTriggerEnter`, `DrawArea3D..ctor` | RECUPERADO-AOT | listados en `recovery/aot_listings/` |

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
| 16 shaders built-in → equivalentes Unity 6 (`Legacy Shaders/...`) | ADAPTADO-U6 | mismos shaders de Unity, renombrados |

## ELIMINATED (decisión del usuario, 2026-09-26)
StoreKit, Game Center, iCloud/JCloud/GravCloud/P31, Burstly, GDMO/Tapalytics, MoreGames/More Disney, Email, Age Gate, enlaces legales/web de Disney.
Detalle: `forensics/output/removed_service_scripts.json`, `forensics/output/service_cleanup_report.json` y comentarios `ELIMINADO` en `DataUtility.cs` y `ShiftUIPublisher.cs`.

## KNOWN ISSUES
- `dirt_road2` (Kick Butt Track 2 / Bus Jumper) era un MeshCollider cóncavo *trigger*: PhysX 2.8 lo admitía y los raycasts de suelo lo detectaban; Unity 5+ no soporta triggers cóncavos. Pasa a collider normal (ADAPTADO-U6). Sin ello, la parrilla de salida no tenía suelo.
- Unity añadió 23 componentes por `[RequireComponent]` del código original (SoundSequencer en 20 prefabs de ruedas, 1 Rigidbody en un botón, 2 MeshRenderer en TextMesh).
- Fish Hooks se ve muy luminosa en las capturas del editor (posible efecto de cáusticos sin animar): revisar en ejecución.
- `Plane_003` (Phineas Track 2): la malla separada mide 200×200, su collider 2×2 (sin explicar; original).
- Parámetros de partículas convertidas son aproximación (fuerzas, damping, `tangentVelocity`): revisar visualmente.
- 151 mallas de UI sin nombre tienen AABB desactualizado desde el original (no afecta).
- Unity inyecta paquetes por defecto (compras/analytics) al abrir un proyecto "antiguo": el manifest se limitó a módulos integrados.
- En esta máquina Unity necesita `DOTNET_gcServer=0` y `DOTNET_GCHeapHardLimit` para que sus compiladores .NET arranquen (memoria comprometible libre ~5 GB).

## STILL UNKNOWN
- Valores de coste de piezas (`PartCosts.epa.xml` era remoto).
- Contenido exacto del interruptor remoto de Pranksgiving (se sustituye por interruptor local activado).
