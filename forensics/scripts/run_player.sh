#!/bin/bash
# usage: run_player.sh <name> <width> <height> <seconds> "<clicks>" "<shots>"   (built player, windowed)
# output: recovery/build/Windows/recovery_tests/<name>.log + <name>_<t>.png ; the real save is backed up and restored
B="/c/Users/STEEP/Documents/game work/recovery/build/Windows"
SAVE="C:/Users/STEEP/AppData/LocalLow/Walt Disney/Speedway/DSSRacer_save.txt"
BK="$B/../save_backup.txt"
[ -f "$SAVE" ] && cp "$SAVE" "$BK"
"$B/DSSRacer.exe" -recoveryTest -rtName "$1" -rtSeconds "$4" -rtClicks "$5" -rtShots "$6" -screen-width "$2" -screen-height "$3" -screen-fullscreen 0 -logFile "$B/recovery_tests/$1_player.log" >/dev/null 2>&1
[ -f "$BK" ] && cp "$BK" "$SAVE"
cat "$B/recovery_tests/$1.log" 2>/dev/null | grep -v "^      " | head -${7:-60}
