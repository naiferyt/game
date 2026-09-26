#!/bin/bash
# usage: run_play.sh <scene path> <seconds> <name> [clicks] [shots]
export DOTNET_gcServer=0 DOTNET_GCHeapHardLimit=0x30000000
R="/c/Users/STEEP/Documents/game work/recovery"
"/c/Program Files/Unity/Hub/Editor/6000.6.3f1/Editor/Unity.exe" -batchmode -projectPath "C:/Users/STEEP/Documents/game work/recovery/DSSRacer_U6" \
  -executeMethod DSSRecovery.PlayModeRunner.Run -runScene "$1" -runSeconds "$2" -runName "$3" -runClicks "${4:-none}" -runShots "${5:-2,5,9}" \
  -logFile "C:/Users/STEEP/Documents/game work/recovery/logs/unity_play_$3.log" >/dev/null 2>&1
echo "exit $?"
grep -E "error CS" "$R/logs/unity_play_$3.log" | head -5
cat "$R/logs/playrun_$3.log" 2>/dev/null | head -${6:-120}
