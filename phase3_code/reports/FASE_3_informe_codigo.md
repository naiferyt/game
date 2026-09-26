# FASE 3 - Informe de codigo

## Estado

FASE 3 completada hasta el limite tecnicamente recuperable desde los assemblies managed.

Se uso ILSpy/ilspycmd oficial `10.1.1.8388`.

Herramienta:

`C:\Users\STEEP\Documents\game\tools\ilspycmd_10.1.1.8388\tools\net10.0\any\ilspycmd.dll`

Assemblies de entrada:

`C:\Users\STEEP\Documents\game\phase1_analysis\ipa_unpacked\Payload\DSSRacing.app\Data\Managed`

## Salida generada

Proyectos C# descompilados:

`C:\Users\STEEP\Documents\game\phase3_code\ILSpyProjects`

IL crudo exportado:

`C:\Users\STEEP\Documents\game\phase3_code\ILSpyIL`

Reportes:

- `C:\Users\STEEP\Documents\game\phase3_code\reports\fase3_csharp_file_inventory.csv`
- `C:\Users\STEEP\Documents\game\phase3_code\reports\fase3_type_inventory.csv`
- `C:\Users\STEEP\Documents\game\phase3_code\reports\fase3_method_body_inventory.csv`
- `C:\Users\STEEP\Documents\game\phase3_code\reports\fase3_missing_method_body_markers_by_file.csv`
- `C:\Users\STEEP\Documents\game\phase3_code\reports\fase3_macho_symbols_game_candidates.txt`

## Assemblies descompilados

| Assembly | Archivos C# | Lineas | Proyecto |
|---|---:|---:|---|
| `Assembly-CSharp.dll` | 252 | 8737 | `ILSpyProjects\Assembly-CSharp` |
| `Assembly-CSharp-firstpass.dll` | 99 | 5313 | `ILSpyProjects\Assembly-CSharp-firstpass` |
| `Assembly-UnityScript.dll` | 4 | 83 | `ILSpyProjects\Assembly-UnityScript` |

Total:

- 355 archivos `.cs`
- 3 `.csproj`
- 14,133 lineas de C# descompilado

## Tipos recuperados

| Assembly | Tipos | Clases | Enums | Structs | Delegates | Interfaces | Eventos |
|---|---:|---:|---:|---:|---:|---:|---:|
| `Assembly-CSharp.dll` | 478 | 458 | 18 | 0 | 2 | 0 | 2 |
| `Assembly-CSharp-firstpass.dll` | 182 | 162 | 7 | 4 | 9 | 0 | 42 |
| `Assembly-UnityScript.dll` | 3 | 3 | 0 | 0 | 0 | 0 | 0 |

Se conservaron:

- nombres originales de clases
- clases anidadas
- enums
- delegates
- eventos
- campos
- propiedades
- herencia
- interfaces implementadas cuando existen
- atributos visibles
- `DllImport("__Internal")` de plugins iOS

Ejemplos confirmados:

- `RaceManager`
- `CarAI`
- `AchievementManager`
- `StoreKitBinding`
- `GameCenterBinding`
- `iCloudBinding`
- `UghInput`
- `UghPublisher`
- `MissionManager`
- `CartAttributes`
- `TrackUnlockHelper`
- `HUDLogic`
- `Car_Script` desde `Assembly-UnityScript.dll`, convertido a C# por ILSpy

## Hallazgo critico: los cuerpos de metodo no estan en los DLL

Los assemblies contienen metadata casi completa, pero **no contienen IL funcional de gameplay**.

Inventario de cuerpos de metodo:

| Assembly | Metodos | Sin cuerpo | Solo `ret` | Solo `ret` sospechoso en metodo no-void | IL util |
|---|---:|---:|---:|---:|---:|
| `Assembly-CSharp.dll` | 2435 | 26 | 2409 | 1009 | 0 |
| `Assembly-CSharp-firstpass.dll` | 1352 | 151 | 1201 | 605 | 0 |
| `Assembly-UnityScript.dll` | 7 | 0 | 7 | 0 | 0 |

Interpretacion:

- Esta app iOS fue compilada con Mono AOT.
- Los DLL distribuidos funcionan principalmente como metadata.
- El codigo ejecutable real fue AOT-compilado al binario ARM `DSSRacing`.
- ILSpy/dnSpy no pueden reconstruir cuerpos C# que no existen en el IL.
- El C# recuperado desde DLLs sirve como esqueleto estructural completo, pero no como implementacion jugable.

Ejemplo de sintoma en ILSpy:

```csharp
public static bool canMakePayments()
{
    /*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
}
```

Esto no significa que ILSpy haya fallado; significa que el metodo en el DLL realmente no contiene IL suficiente.

## Validacion contra el ejecutable nativo

Se inspecciono `Payload\DSSRacing.app\DSSRacing`.

El ejecutable contiene estructuras Mono AOT:

- `mono_aot_full_aot`
- `mono_aot_assembly_name`
- `method_addresses`
- `method_offsets`
- `method_info`
- `class_name_table`
- referencias a `Assembly-CSharp`
- referencias a `Assembly-CSharp-firstpass`

La tabla de simbolos Mach-O tiene 1632 simbolos, pero no conserva nombres directos de metodos C# como:

- `RaceManager`
- `CarAI`
- `AchievementManager`
- `StoreKitBinding`
- `UghInput`

Se guardo un listado de candidatos nativos en:

`C:\Users\STEEP\Documents\game\phase3_code\reports\fase3_macho_symbols_game_candidates.txt`

Resultado:

- Hay codigo AOT nativo dentro del ejecutable.
- No hay mapeo simbolico suficiente para convertir automaticamente ese ARM nativo de vuelta a C# legible.
- Reconstruir cuerpos reales exigiria una fase adicional de reversing nativo ARM/AOT con herramientas tipo Ghidra/IDA, correlacionando metadata Mono AOT, no una simple descompilacion ILSpy/dnSpy.

## Marcadores de metodo no recuperado

ILSpy marco 1008 metodos no-void con cuerpo `ret` invalido para C#:

| Assembly | Archivos afectados | Marcadores |
|---|---:|---:|
| `Assembly-CSharp` | 168 | 533 |
| `Assembly-CSharp-firstpass` | 77 | 474 |
| `Assembly-UnityScript` | 1 | 1 |

Nota: este numero no incluye todos los metodos void vaciados, porque esos se descompilan como cuerpos vacios aparentemente validos. El inventario IL completo confirma 0 metodos con IL util.

## Lo recuperado en FASE 3

Recuperado:

- estructura completa de assemblies del juego
- nombres originales de tipos
- firmas de metodos
- campos serializados
- propiedades
- eventos
- delegates
- enums
- clases generadas por compilador para coroutines/lambdas
- referencias a plugins iOS
- conversion C# del pequeno assembly UnityScript

No recuperado desde DLL:

- cuerpos reales de gameplay
- logica real de IA, carreras, pickups, misiones, HUD, economia, etc.
- implementaciones de servicios/plugin wrappers
- coroutines reales mas alla de sus clases/firmas metadata

## Compilabilidad

Los proyectos ILSpy generados **no son compilables como gameplay real** por dos razones:

1. Los cuerpos de metodo estan vacios o son `ret` invalido en metodos no-void.
2. Los `.csproj` generados apuntan a `net20` y referencias Unity 4 antiguas; eso es correcto como descompilacion historica, pero no como proyecto Unity 6.

No se reemplazaron cuerpos con `return default(...)` porque eso inventaria comportamiento y violaria la regla de no modificar jugabilidad.

## Conclusion FASE 3

FASE 3 queda cerrada con recuperacion completa de metadata y esqueleto C# posible desde los DLL.

La recuperacion completa de codigo fuente con cuerpos reales **no es posible solo con `Assembly-CSharp.dll`**, porque el IL fue vaciado para AOT iOS.

Para avanzar hacia FASE 4 de forma honesta hay dos rutas:

1. Usar los scripts recuperados como esqueleto y reconstruir manualmente comportamiento a partir de escenas/assets/nativo, documentando cada sustitucion.
2. Agregar una fase intermedia de reversing nativo ARM/Mono AOT para intentar mapear funciones AOT del ejecutable `DSSRacing` contra metadata managed.

No se debe tratar el proyecto descompilado como juego funcional todavia.
