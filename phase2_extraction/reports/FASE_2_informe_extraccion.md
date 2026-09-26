# FASE 2 - Informe de extraccion

## Estado

FASE 2 completada.

Se uso AssetRipper oficial `1.3.14` descargado desde GitHub Releases:

`C:\Users\STEEP\Documents\game\tools\AssetRipper_1.3.14_win_x64\AssetRipper.GUI.Free.exe`

Entrada usada:

`C:\Users\STEEP\Documents\game\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app`

AssetRipper cargo correctamente la estructura Unity mixta y detecto:

- `level0` a `level15`
- `mainData`
- `resources.assets`
- `sharedassets0.assets` a `sharedassets16.assets`
- `unity default resources`
- `unity_builtin_extra`
- backend de scripting Mono
- 8 assemblies managed durante inicializacion

## Carpetas generadas

Proyecto Unity reconstruido:

`C:\Users\STEEP\Documents\game\phase2_extraction\AssetRipperUnityProject\ExportedProject`

Archivos auxiliares / assemblies originales copiados por AssetRipper:

`C:\Users\STEEP\Documents\game\phase2_extraction\AssetRipperUnityProject\AuxiliaryFiles`

Volcado adicional de contenido primario:

`C:\Users\STEEP\Documents\game\phase2_extraction\AssetRipperPrimaryContent`

Inventarios CSV:

- `C:\Users\STEEP\Documents\game\phase2_extraction\reports\fase2_file_inventory.csv`
- `C:\Users\STEEP\Documents\game\phase2_extraction\reports\fase2_resource_inventory.csv`
- `C:\Users\STEEP\Documents\game\phase2_extraction\reports\fase2_scene_inventory.csv`
- `C:\Users\STEEP\Documents\game\phase2_extraction\reports\fase2_primary_content_inventory.csv`

Log de AssetRipper:

`C:\Users\STEEP\Documents\game\phase2_extraction\assetripper_1.3.14.log`

## Resultado del proyecto Unity exportado

Total:

| Metrica | Valor |
|---|---:|
| Archivos totales, incluyendo `.meta` | 6003 |
| Tamano total | 271.728 MB |
| Assets exportados por AssetRipper | 2662/2662 |

Conteo principal sin `.meta`:

| Tipo | Cantidad |
|---|---:|
| `.asset` | 874 |
| `.prefab` | 579 |
| `.png` | 482 |
| `.cs` | 355 |
| `.mat` | 328 |
| `.anim` | 231 |
| `.mp3` | 85 |
| `.wav` | 37 |
| `.shader` | 20 |
| `.unity` | 17 |
| `.bytes` | 3 |
| `.dll` | 2 |
| `.otf` | 2 |
| `.json` | 2 |
| `.txt` | 2 |
| `.texture2D` | 1 |

## Organizacion por carpetas del proyecto

Dentro de `ExportedProject\Assets`:

| Carpeta | Archivos sin `.meta` | MB |
|---|---:|---:|
| `AnimationClip` | 231 | 11.105 |
| `AudioClip` | 122 | 8.762 |
| `Font` | 3 | 0.184 |
| `GameObject` | 481 | 2.858 |
| `LightProbes` | 1 | 0.730 |
| `Material` | 328 | 0.250 |
| `Mesh` | 690 | 31.691 |
| `MonoBehaviour` | 149 | 0.148 |
| `Plugins` | 101 | 0.169 |
| `Resources` | 240 | 18.694 |
| `Scenes` | 75 | 103.907 |
| `Scripts` | 256 | 0.219 |
| `Shader` | 20 | 0.013 |
| `TextAsset` | 1 | 0.031 |
| `Texture2D` | 305 | 90.482 |

## Escenas recuperadas

AssetRipper reconstruyo 17 escenas:

- `Assets\Scenes\CloudStrap.unity`
- `Assets\Scenes\Front End\FrontEndTest.unity`
- `Assets\Scenes\Front End\Loading.unity`
- `Assets\Scenes\Front End\RaceResults.unity`
- `Assets\Scenes\MoreDisney.unity`
- `Assets\Scenes\PreFrontEnd.unity`
- `Assets\Scenes\Test Scenes\Pranksgiving Test.unity`
- `Assets\Scenes\Tracks\Fish Hooks Track 1.unity`
- `Assets\Scenes\Tracks\Fish Hooks Track 2.unity`
- `Assets\Scenes\Tracks\Fish Hooks Track 3.unity`
- `Assets\Scenes\Tracks\Kick Butt Track 1.unity`
- `Assets\Scenes\Tracks\Kick Butt Track 2.unity`
- `Assets\Scenes\Tracks\Kick Butt Track 3.unity`
- `Assets\Scenes\Tracks\Phineas Track 1.unity`
- `Assets\Scenes\Tracks\Phineas Track 2.unity`
- `Assets\Scenes\Tracks\Phineas Track 3.unity`
- `Assets\Scenes\Tracks\Tutorial Track.unity`

## Prefabs

Se recuperaron 579 prefabs Unity.

Ejemplos relevantes:

- `+AchievementManager.prefab`
- `+DataUtility.prefab`
- `+Localize.prefab`
- `+PlayerInstance.prefab`
- `+StreamManager.prefab`
- `+TrackUnlockHelper.prefab`
- multiples partes de kart/bike/truck
- prefabs de personajes, HUD, powerups, pickups y elementos de pistas

## Modelos / Meshes

En el proyecto Unity:

- 690 archivos `Mesh/*.asset`.

En el volcado adicional `PrimaryContent`:

- 1296 archivos `.glb`.

Esto cubre tanto la integracion Unity como una representacion portable de modelos cuando AssetRipper pudo generarla.

## Texturas / Sprites

En el proyecto Unity:

- 482 `.png`
- 305 archivos en `Assets\Texture2D` sin contar `.meta`
- 240 archivos en `Assets\Resources`

En `PrimaryContent`:

- 526 `.png`

Las texturas fueron exportadas principalmente como PNG. Los sprites quedan representados como assets YAML/Unity dentro del proyecto, no necesariamente como archivos separados por cada sprite.

## Audio

En el proyecto Unity:

- 85 `.mp3`
- 37 `.wav`

En `PrimaryContent`:

- 85 `.mp3`
- 37 `.wav`

## Fuentes

Se recuperaron:

- 2 `.otf`
- assets Unity adicionales de font en `Assets\Font`

## Animaciones

Se recuperaron:

- 231 `.anim`

## Materiales y shaders

Se recuperaron:

- 328 `.mat`
- 20 `.shader`

Nota: AssetRipper fue ejecutado con la configuracion por defecto de esta version free, que usa `ShaderExportMode: Dummy`. Por tanto, algunos shaders pueden estar como stubs/dummies y deberan revisarse en FASE 4/5.

## Scripts dentro del export

El proyecto Unity contiene:

- 355 `.cs` dentro del proyecto exportado.
- Los assemblies originales tambien quedaron en `AuxiliaryFiles\GameAssemblies`.
- El volcado `PrimaryContent` genero 1701 `.cs`, principalmente por contenido primario/descompilado auxiliar de AssetRipper.

La reconstruccion completa del codigo se trata formalmente en FASE 3.

## Warnings y perdidas conocidas

AssetRipper completo la exportacion sin errores fatales:

- Errores: 0
- Warnings: 10

Warnings registrados:

- `Resource file 'Assembly-CSharp-Editor.dll' hasn't been found`
- `Assembly 'Assembly-CSharp-Editor' hasn't been found`
- 8 veces: `Could not read MonoBehaviour structure for MultilayerTextureBundleDef. Reason: Script ID is invalid`

Interpretacion:

- La falta de `Assembly-CSharp-Editor.dll` normalmente no afecta runtime; es una assembly editor-only que no se distribuye con builds finales.
- Los warnings de `MultilayerTextureBundleDef` son el principal punto pendiente. Estan vinculados con definiciones de bundles/texturas multicapas. Hay que revisar esos assets al reconstruir referencias en FASE 4.
- No se detectaron archivos fallidos mediante pagina de fallos; el endpoint de fallos devolvio 404 y el log no contiene errores.

## Estado de recursos solicitados

| Recurso | Estado |
|---|---|
| Escenas | Recuperadas, 17 `.unity` |
| Prefabs | Recuperados, 579 `.prefab` |
| Materiales | Recuperados, 328 `.mat` |
| Modelos | Recuperados como `Mesh/*.asset` y 1296 `.glb` en PrimaryContent |
| Texturas | Recuperadas principalmente como `.png` |
| Audio | Recuperado como `.mp3` y `.wav` |
| Fuentes | Recuperadas, 2 `.otf` mas assets de Font |
| Animaciones | Recuperadas, 231 `.anim` |
| Shaders | Recuperados, 20 `.shader`, probablemente dummy/stub |
| Sprites | Recuperados como metadata/assets Unity y texturas asociadas |

## Proxima fase

Continuar con FASE 3:

- Descompilar `Assembly-CSharp.dll`.
- Descompilar `Assembly-CSharp-firstpass.dll`.
- Descompilar `Assembly-UnityScript.dll`.
- Preservar nombres, clases, herencia, interfaces y eventos.
- Guardar codigo C# reconstruido separado del export de AssetRipper para no mezclar resultados.
