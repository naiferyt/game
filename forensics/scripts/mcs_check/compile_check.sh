#!/bin/sh
# Type-checks the game scripts without Unity: mcs against the ORIGINAL Unity 4.3 UnityEngine.dll plus U6Shim.cs.
# It catches C# errors in translated code; Unity 6-only API gaps show up as errors to add to the shim.
# Final authority is still the Unity 6.6 editor (run recovery/AbrirUnity.bat).
# Usage: sh forensics/scripts/mcs_check/compile_check.sh   (needs mono-mcs)
set -e
HERE=$(cd "$(dirname "$0")" && pwd)
ROOT=$HERE/../../..
A=$ROOT/recovery/DSSRacer_U6/Assets
U4=$ROOT/phase1_analysis/ipa_unpacked/Payload/DSSRacing.app/Data/Managed/UnityEngine.dll
OUT=${TMPDIR:-/tmp}/dss_compile_check; mkdir -p "$OUT"
# Unity 6-only compatibility code (uses APIs absent from Unity 4.3): not checkable here.
U6ONLY=LegacyLightmapRestorer.cs
NOWARN=-nowarn:0108,0114,0162,0168,0169,0219,0414,0618,0649,0672
mcs -target:library $NOWARN -r:"$U4" -out:"$OUT/shim.dll" "$HERE/U6Shim.cs"
mcs -target:library $NOWARN -r:"$U4" -r:"$OUT/shim.dll" -out:"$OUT/Assembly-CSharp-firstpass.dll" $(find "$A/Plugins" -name '*.cs' -not -path '*/Editor/*')
mcs -target:library $NOWARN -r:"$U4" -r:"$OUT/shim.dll" -r:"$OUT/Assembly-CSharp-firstpass.dll" -out:"$OUT/Assembly-CSharp.dll" $(find "$A" -name '*.cs' -not -path "$A/Plugins/*" -not -path '*/Editor/*' -not -name "$U6ONLY")
echo "compile_check: OK"
