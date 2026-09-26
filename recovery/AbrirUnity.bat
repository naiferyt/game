@echo off
rem Abre el proyecto de recuperacion en Unity 6.6 con los ajustes que necesita esta maquina.
rem (Los compiladores .NET de Unity fallan con "GC heap initialization failed" si no se limita su GC.)
set DOTNET_gcServer=0
set DOTNET_GCHeapHardLimit=0x30000000
start "" "C:\Program Files\Unity\Hub\Editor\6000.6.3f1\Editor\Unity.exe" -projectPath "%~dp0DSSRacer_U6"
