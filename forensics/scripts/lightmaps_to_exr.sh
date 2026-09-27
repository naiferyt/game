#!/bin/bash
# Swaps the Unity 4 lightmap PNGs for the HDR EXRs written by DSSRecovery.LightmapHdrConverter (recovery/logs/lm_exr).
# The .png.meta is kept as the .exr.meta (same GUID, texture type Lightmap), so scenes and LegacyLightmapRestorer keep
# their references. The original PNGs remain in phase2_extraction/ (AssetRipper export).
cd "$(dirname "$0")/../.."
P=recovery/DSSRacer_U6
n=0
while IFS= read -r -d '' exr; do
  rel="${exr#recovery/logs/lm_exr/}"; base="$P/${rel%.exr}"
  [ -f "$base.png" ] || { echo "no png for $rel"; continue; }
  mv "$base.png.meta" "$base.exr.meta"
  cp "$exr" "$base.exr"
  git rm -q --cached "$base.png" "$base.png.meta" 2>/dev/null
  rm -f "$base.png"
  n=$((n+1))
done < <(find recovery/logs/lm_exr -name "*.exr" -print0)
echo "swapped $n"
