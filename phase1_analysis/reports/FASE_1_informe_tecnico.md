# FASE 1 - Informe tecnico

## Alcance

Archivo analizado:

`C:\Users\STEEP\Downloads\ddsracer\DSSRACER\com.disney.DSSRacer-iOS6.0-(Clutch-2.0.4).ipa`

Carpeta de trabajo de analisis:

`C:\Users\STEEP\Documents\game\phase1_analysis\ipa_unpacked`

No se ha ejecutado extraccion de assets con AssetRipper ni descompilacion completa de C#. Esta fase solo inspecciona el contenedor IPA, metadatos, binarios, assemblies y archivos Unity relevantes.

## Resumen ejecutivo

- Version Unity detectada en los archivos serializados: **Unity 4.3.4f1**.
- El archivo `Data\unity default resources` declara `4.3.0b5`, pero los archivos del juego (`mainData`, `level*`, `sharedassets*`, `resources.assets`) declaran `4.3.4f1`. La version de proyecto mas probable es **Unity 4.3.4f1**.
- La app es iOS antigua, **ARMv7 32-bit**, no ARM64.
- Backend de scripting: **Mono/MSIL**, no IL2CPP. Los assemblies managed estan presentes y son legibles.
- El ejecutable nativo contiene `LC_ENCRYPTION_INFO` con `cryptid=0`, por lo que este dump no esta cifrado con FairPlay en reposo.
- No hay evidencia de ofuscacion fuerte de nombres C#: los tipos tienen nombres descriptivos (`CarAI`, `RaceManager`, `AchievementManager`, `StoreKitBinding`, etc.).
- No existe `globalgamemanagers` como archivo separado. En esta estructura Unity 4/iOS, el equivalente practico para managers globales esta en `Data\mainData`.
- No se encontraron AssetBundles standalone como archivos separados en el IPA. Si existen bundles, no estan como `.unity3d` fisicos dentro del paquete.
- Si hay referencias a AssetBundles `.unity3d` dentro de assets serializados y codigo (`AssetBundle`, `WWW`, `StartBundleLoads`, `WaitForAssetBundles`). Esto debe investigarse en FASE 2 porque puede implicar contenido dinamico o nombres logicos de bundles.

## Identificacion de app

Datos leidos desde `Info.plist`:

| Campo | Valor |
|---|---|
| CFBundleIdentifier | `com.disney.DSSRacer` |
| CFBundleDisplayName | `Speedway` |
| CFBundleName | `DSSRacer` |
| CFBundleExecutable | `DSSRacing` |
| CFBundleVersion | `1.3` |
| CFBundleShortVersionString | `1.3` |
| MinimumOSVersion | `6.0` |
| DTPlatformVersion | `7.1` |
| DTSDKName | `iphoneos7.1` |
| DTXcode | `0511` |
| DTXcodeBuild | `5B1008` |
| Device families | iPhone + iPad |
| Orientaciones | Landscape Left + Landscape Right |
| Capacidades requeridas | `armv7`, `gamekit` |

## Tamano y estructura general

| Metrica | Valor |
|---|---:|
| Tamano IPA | 80,085,941 bytes / 76.376 MB |
| SHA256 IPA | `5630012A777BFCF8257999A22C4777D6F0144378E24F593DE9BAB6803491621A` |
| Archivos desempaquetados | 98 |
| Tamano desempaquetado | 181,678,517 bytes / 173.262 MB |

Distribucion por categoria:

| Categoria | Archivos | MB |
|---|---:|---:|
| Unity Data | 37 | 144.007 |
| Ejecutable/metadatos app | 5 | 16.456 |
| PNG/iconos/launch images | 42 | 10.494 |
| Managed DLL/config | 9 | 1.559 |
| Plugin nativo/analytics | 4 | 0.738 |
| Firma de codigo | 1 | 0.008 |

## Binario nativo iOS

Archivo:

`Payload\DSSRacing.app\DSSRacing`

Resultado:

| Propiedad | Valor |
|---|---|
| Formato | Mach-O executable |
| Arquitectura | ARM |
| Subtipo | ARMv7 |
| 64-bit | No |
| Load commands | 57 |
| Min iOS declarado | 6.0.0 |
| SDK declarado | 7.1.0 |
| Encriptacion | `LC_ENCRYPTION_INFO`, `cryptid=0` |
| Rango historico cifrado | `cryptoff=16384`, `cryptsize=15908864` |

Interpretacion:

- `cryptid=0` indica que el binario de este IPA ya esta descifrado.
- El nombre del archivo IPA incluye `Clutch-2.0.4`, consistente con un dump descifrado.
- No hay `libil2cpp`, `global-metadata.dat` ni estructura IL2CPP.

Frameworks/dylibs enlazados mas relevantes:

- `GameKit.framework`
- `StoreKit.framework`
- `OpenGLES.framework`
- `OpenAL.framework`
- `AVFoundation.framework`
- `iAd.framework`
- `Social.framework`
- `Twitter.framework`
- `AdSupport.framework`
- `Security.framework`
- `CoreMotion.framework`
- `SystemConfiguration.framework`
- `libsqlite3.dylib`
- `libxml2.2.dylib`
- `libz.1.dylib`

## Managed assemblies

Carpeta:

`Payload\DSSRacing.app\Data\Managed`

| Archivo | Tamano | Assembly | Version | Tipos | Metodos aprox. |
|---|---:|---|---|---:|---:|
| `Assembly-CSharp.dll` | 217,088 | Assembly-CSharp | 0.0.0.0 | 478 | 2,435 |
| `Assembly-CSharp-firstpass.dll` | 120,832 | Assembly-CSharp-firstpass | 0.0.0.0 | 182 | 1,352 |
| `Assembly-UnityScript.dll` | 5,120 | Assembly-UnityScript | 0.0.0.0 | 3 | 7 |
| `UnityEngine.dll` | 151,040 | UnityEngine | 0.0.0.0 | 260 | 1,933 |
| `mscorlib.dll` | 878,592 | mscorlib | 2.0.5.0 | n/d | n/d |
| `System.dll` | 57,344 | System | 2.0.5.0 | 2,364 | 15,412 |
| `System.Core.dll` | 11,264 | System.Core | 2.0.5.0 | 1,175 | 7,168 |
| `System.Xml.dll` | 165,376 | System.Xml | 2.0.5.0 | n/d | n/d |
| `mono\2.0\machine.config` | 27,626 | config Mono | n/a | n/a | n/a |

Tipos representativos de `Assembly-CSharp.dll`:

- `CarAI`, `BaseCarAIState`, `DriveWaypointsCarAIState`
- `RaceManager`, `RaceSettings`, `RaceResults`
- `AchievementManager`, `AchievementListener`
- `CartAttributes`, `CartPart`, `PaintJob`, `PreviewCart`
- `MusicPlayer`, `SoundLibrary`, `SoundPackageManager`
- `EffectManager`, `RocketEffect`, `MineEffect`, `ShieldEffect`
- `FrontEndLogic`, `CharacterSelectPublisher`, `TrackSelectPublisher`
- `HUDLogic`, `PausePublisher`, `RaceResultsPublisher`

Tipos representativos de `Assembly-CSharp-firstpass.dll`:

- `GameCenterBinding`, `GameCenterManager`
- `StoreKitBinding`, `StoreKitManager`
- `GDMOBinding`, `BurstlyBinding`, `MoreGamesBinding`
- `AudioManager`, `Inputx`, `GUIx`, `Mathfx`
- `Localize`, `LanguageAsset`, `LocalizedString`
- `UghButton`, `UghSprite`, `UghText`, `UghPublisher`
- `P31CloudFile`, `iCloudBinding`, `iCloudManager`
- `MiniJSON`, `Messenger`, `SingletonScript`

Tipos de `Assembly-UnityScript.dll`:

- `Plane_Script`
- `WheelData`
- `Car_Script`

## Diagnostico de ofuscacion/protecciones

### Ofuscacion C#

No se detecta ofuscacion fuerte de nombres:

- `Assembly-CSharp.dll`: 478 tipos, 167 tipos generados por compilador, 0 tipos de una sola letra.
- `Assembly-CSharp-firstpass.dll`: 182 tipos, 44 tipos generados por compilador, 0 tipos de una sola letra.
- Los tipos generados con formato `<Metodo>c__IteratorXX` y `<Metodo>c__AnonStoreyXX` son normales en Unity/Mono antiguo por coroutines y lambdas.

Conclusion: **muy buena probabilidad de decompilacion legible en FASE 3**.

### Cifrado/DRM

- IPA contiene `_CodeSignature\CodeResources`, normal en apps iOS.
- El ejecutable tiene `LC_ENCRYPTION_INFO`, pero `cryptid=0`.
- No se encontro cifrado de assemblies managed: los DLL son PE/MSIL normales y `AssemblyName` los lee correctamente.
- Existen referencias a `RijndaelManaged`, `MD5CryptoServiceProvider` y persistencia externa/cloud en codigo, probablemente para saves, preferencias o recursos externos, no para cifrar todo el juego.

Conclusion: **no hay bloqueo tecnico evidente para analisis managed y assets locales**, siempre que el trabajo se mantenga en un entorno autorizado/local.

## Archivos Unity principales

Todos los archivos Unity serializados importantes detectados usan formato de archivo serializado `9`.

| Archivo | Tamano | Version Unity | Rol probable |
|---|---:|---|---|
| `Data\mainData` | 153,856 | 4.3.4f1 | Managers globales/build settings/preload data |
| `Data\resources.assets` | 31,991,532 | 4.3.4f1 | Recursos en `Resources` |
| `Data\Resources\unity_builtin_extra` | 83,556 | 4.3.4f1 | Built-in extra resources |
| `Data\unity default resources` | 721,477 | 4.3.0b5 | Recursos Unity por defecto |
| `Data\level0` | 5,880 | 4.3.4f1 | Escena/nivel |
| `Data\level1` | 109,632 | 4.3.4f1 | Escena/nivel |
| `Data\level2` | 26,928 | 4.3.4f1 | Escena/nivel |
| `Data\level3` | 6,272 | 4.3.4f1 | Escena/nivel |
| `Data\level4` | 58,032 | 4.3.4f1 | Escena/nivel |
| `Data\level5` | 2,005,636 | 4.3.4f1 | Escena/nivel |
| `Data\level6` | 2,050,260 | 4.3.4f1 | Escena/nivel |
| `Data\level7` | 2,194,076 | 4.3.4f1 | Escena/nivel |
| `Data\level8` | 1,229,464 | 4.3.4f1 | Escena/nivel |
| `Data\level9` | 1,696,400 | 4.3.4f1 | Escena/nivel |
| `Data\level10` | 1,600,388 | 4.3.4f1 | Escena/nivel |
| `Data\level11` | 1,746,040 | 4.3.4f1 | Escena/nivel |
| `Data\level12` | 1,772,148 | 4.3.4f1 | Escena/nivel |
| `Data\level13` | 2,495,892 | 4.3.4f1 | Escena/nivel |
| `Data\level14` | 1,229,296 | 4.3.4f1 | Escena/nivel |
| `Data\level15` | 5,045,520 | 4.3.4f1 | Escena/nivel |
| `Data\sharedassets0.assets` | 913,256 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets1.assets` | 6,580 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets2.assets` | 25,421,372 | 4.3.4f1 | Assets compartidos; contiene muchas referencias `.unity3d` |
| `Data\sharedassets3.assets` | 7,084 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets4.assets` | 4,232 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets5.assets` | 539,668 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets6.assets` | 10,835,920 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets7.assets` | 2,446,144 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets8.assets` | 5,491,824 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets9.assets` | 5,444,448 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets10.assets` | 2,965,040 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets11.assets` | 2,901,668 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets12.assets` | 8,764,456 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets13.assets` | 4,676,764 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets14.assets` | 7,934,032 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets15.assets` | 11,836 | 4.3.4f1 | Assets compartidos |
| `Data\sharedassets16.assets` | 16,416,188 | 4.3.4f1 | Assets compartidos |

## AssetBundles

Resultado de busqueda:

- No existen archivos fisicos `.unity3d`, `.assetbundle`, `UnityFS`, `UnityWeb` o `UnityRaw` en el IPA.
- Hay referencias de texto a bundles dentro de `resources.assets`, `sharedassets2.assets` y assemblies.
- Ejemplos de nombres referenciados:
  - `Bike0Body.unity3d`
  - `Truck0Body.unity3d`
  - `Kart0Body.unity3d`
  - `AgentP.unity3d`
  - `Phineas.unity3d`
  - `Mabel.unity3d`
  - `kart5_Perry_body.unity3d`
  - `Kart6Thruster.unity3d`
  - `Truck6Wheels.unity3d`

Tambien aparece una URL de configuracion/costos:

`http://a.dolimg.com/media/en-US/games/dssr_spl_rac_disneysuperspeedwayracing/PartCosts.epa.xml`

Interpretacion:

- Puede que el juego usara bundles descargados, bundles cacheados por plataforma, o una abstraccion interna donde los nombres `.unity3d` no corresponden necesariamente a archivos del IPA.
- Esto es un riesgo principal para FASE 2/FASE 4: hay que comprobar si AssetRipper recupera esos objetos desde los `.assets` locales o si solo existen referencias a contenido externo ya no incluido.

## Plugins y codigo nativo adicional

Carpeta:

`Payload\DSSRacing.app\DMOAnalytics`

Archivos:

- `DMOAnalytics.h`
- `GDMOBinding.h`
- `GDMOBinding.mm`
- `libtapalytics.a`

Observaciones:

- Hay bindings managed para Game Center, StoreKit, iCloud, ads/analytics y "More Games".
- En Android/Unity moderno, estos plugins iOS no deben portarse literalmente. En FASE 5/6 deben aislarse con `#if UNITY_IOS`, reemplazarse por stubs, o mapearse a servicios Android equivalentes solo si se decide mantener esas funciones.
- El juego tambien contiene URLs de redes antiguas de ads/analytics y servicios Disney. Para una reconstruccion jugable local, lo recomendable sera desactivar o stubear servicios externos obsoletos sin alterar la jugabilidad principal.

## Archivos importantes enumerados

### Obligatorios solicitados

- `Data\Managed\Assembly-CSharp.dll` - presente.
- `Data\Managed\Assembly-CSharp-firstpass.dll` - presente.
- `Data\Managed\UnityEngine.dll` - presente.
- `Data\resources.assets` - presente.
- `Data\sharedassets0.assets` a `Data\sharedassets16.assets` - presentes.
- `Data\mainData` - presente.
- `Data\level0` a `Data\level15` - presentes.
- `globalgamemanagers` - no presente como archivo separado.
- AssetBundles standalone - no presentes como archivos separados.

### Otros relevantes

- `Data\Managed\Assembly-UnityScript.dll`
- `Data\Managed\mscorlib.dll`
- `Data\Managed\System.dll`
- `Data\Managed\System.Core.dll`
- `Data\Managed\System.Xml.dll`
- `Data\Resources\unity_builtin_extra`
- `Data\unity default resources`
- `Payload\DSSRacing.app\DSSRacing`
- `Payload\DSSRacing.app\Info.plist`
- `Payload\DSSRacing.app\DMOAnalytics\libtapalytics.a`
- `Payload\DSSRacing.app\offline.html`
- Iconos y launch images PNG en la raiz de `.app`

## Riesgos para fases siguientes

1. **Salto Unity 4.3.4f1 -> Unity 6 LTS**  
   Es un salto muy grande. Habra incompatibilidades de API (`Application.LoadLevel`, `ParticleEmitter`, `iPhone`, `NotificationServices`, `WWW`, GUI legacy, input viejo, shaders legacy, audio y fisica).

2. **AssetBundles no incluidos como archivos**  
   Hay muchas referencias `.unity3d` pero no bundles fisicos. FASE 2 debe confirmar si el contenido real esta en los `.assets` locales o si faltan recursos externos.

3. **Plugins iOS antiguos**  
   StoreKit/GameCenter/iCloud/ads/analytics no son portables directamente a Android. Deben encapsularse o reemplazarse por stubs para mantener gameplay sin depender de servicios muertos.

4. **Sistema de UI propio antiguo**  
   Tipos `Ugh*` sugieren un framework UI interno/pre-UGUI. Puede necesitar restauracion cuidadosa de materiales, meshes y eventos.

5. **Codigo mixto C# + UnityScript**  
   Hay un assembly UnityScript pequeno. En Unity moderno no se compila UnityScript; debera convertirse a C# o integrarse como C# equivalente en FASE 5.

## Estado FASE 1

FASE 1 completada.

Listo para FASE 2, pero no se debe avanzar hasta confirmacion del usuario.

Recomendacion para FASE 2:

1. Instalar/usar AssetRipper compatible con assets Unity 4.x.
2. Extraer proyecto a una carpeta nueva, por ejemplo:
   `C:\Users\STEEP\Documents\game\phase2_extraction\AssetRipperExport`
3. Registrar warnings de clases faltantes, shaders, scripts y AssetBundle references.
4. Generar manifiesto de recursos recuperados y recursos no recuperables.
