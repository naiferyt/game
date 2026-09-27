#!/bin/bash
# usage: build_windows.sh [development]   -> recovery/build/Windows/DSSRacer.exe  (log: recovery/logs/unity_build_windows.log)
export DOTNET_gcServer=0 DOTNET_GCHeapHardLimit=0x30000000
R="/c/Users/STEEP/Documents/game work/recovery"
DEV=""; [ "$1" = "development" ] && DEV="-development"
"/c/Program Files/Unity/Hub/Editor/6000.6.3f1/Editor/Unity.exe" -batchmode -quit -projectPath "C:/Users/STEEP/Documents/game work/recovery/DSSRacer_U6" \
  -executeMethod DSSRecovery.BuildTools.BuildWindows $DEV -logFile "C:/Users/STEEP/Documents/game work/recovery/logs/unity_build_windows.log" >/dev/null 2>&1
echo "exit $?"
grep -E "error CS|\[build\]|Build Finished|Error building" "$R/logs/unity_build_windows.log" | head -20
