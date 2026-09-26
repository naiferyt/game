#!/bin/sh
# Type-checks the game scripts without Unity: mcs against the ORIGINAL Unity 4.3 UnityEngine.dll plus U6Shim.cs.
# It catches C# errors in translated code; Unity 6-only API gaps show up as errors to add to the shim, or, when
# they cannot be shimmed (nested types, instance properties of Unity types), to u6_only_errors.txt, whose matches
# are reported as ignored instead of failing. Final authority is the Unity 6.6 editor (local
# forensics/scripts/compile_check.py compiles against the real Unity 6.6 assemblies).
# Usage: sh forensics/scripts/mcs_check/compile_check.sh   (needs mono-mcs)
HERE=$(cd "$(dirname "$0")" && pwd)
ROOT=$HERE/../../..
A=$ROOT/recovery/DSSRacer_U6/Assets
U4=$ROOT/phase1_analysis/ipa_unpacked/Payload/DSSRacing.app/Data/Managed/UnityEngine.dll
OUT=${TMPDIR:-/tmp}/dss_compile_check; mkdir -p "$OUT"
# Unity 6-only compatibility code (uses APIs absent from Unity 4.3): not checkable here.
U6ONLY=LegacyLightmapRestorer.cs
NOWARN=-nowarn:0108,0114,0162,0168,0169,0219,0414,0618,0649,0672
IGNORE=$(grep -v '^#' "$HERE/u6_only_errors.txt" | paste -sd'|' -)
check() {   # $1 = log; prints real errors, returns 1 if any
	grep 'error CS' "$1" | grep -Ev "$IGNORE" > "$1.real"
	n=$(grep -c 'error CS' "$1"); r=$(wc -l < "$1.real")
	[ "$n" -gt "$r" ] && echo "  ($((n - r)) Unity 6-only API errors ignored, see u6_only_errors.txt)"
	[ "$r" -eq 0 ] || { cat "$1.real"; return 1; }
}
mcs -target:library $NOWARN -r:"$U4" -out:"$OUT/shim.dll" "$HERE/U6Shim.cs" || exit 1
mcs -target:library $NOWARN -r:"$U4" -r:"$OUT/shim.dll" -out:"$OUT/Assembly-CSharp-firstpass.dll" \
	$(find "$A/Plugins" -name '*.cs' -not -path '*/Editor/*') > "$OUT/fp.log" 2>&1
echo "firstpass:"; check "$OUT/fp.log" || exit 1
# A firstpass assembly is needed to check the rest: if it was not emitted (ignored errors only), rebuild it
# without the per-file failures being fatal is not possible with mcs, so fall back to the previous build.
[ -f "$OUT/Assembly-CSharp-firstpass.dll" ] || { echo "no firstpass assembly"; exit 1; }
mcs -target:library $NOWARN -r:"$U4" -r:"$OUT/shim.dll" -r:"$OUT/Assembly-CSharp-firstpass.dll" -out:"$OUT/Assembly-CSharp.dll" \
	$(find "$A" -name '*.cs' -not -path "$A/Plugins/*" -not -path '*/Editor/*' -not -name "$U6ONLY") > "$OUT/cs.log" 2>&1
echo "Assembly-CSharp:"; check "$OUT/cs.log" || exit 1
echo "compile_check: OK"
