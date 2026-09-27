#!/bin/sh
# Prepares a cloud session (no Unity install) to run forensics/scripts/compile_check.py the same way as on the local PC:
# Roslyn (Microsoft.Net.Compilers.Toolset, run with `dotnet`) against Unity reference assemblies and netstandard 2.1.
# The Unity download servers are not reachable from the cloud, so the references are the closest ones on NuGet:
# UnityEngine.Modules 2021.3.33. Differences with Unity 6.6 (APIs added after 2021.3 report as errors) are listed in
# forensics/scripts/cloud_u6_only.txt. Roslyn 4.12 (net8.0) instead of the local 4.14 (net9.0): Ubuntu only ships .NET 8.
# Usage: sh forensics/scripts/cloud_refs.sh   (then: python3 forensics/scripts/compile_check.py)
set -e
D=${DSSR_CLOUD_REFS:-/opt/dssr_ref}
mkdir -p "$D"; cd "$D"
command -v dotnet >/dev/null 2>&1 || { apt-get update -qq && DEBIAN_FRONTEND=noninteractive apt-get install -y -qq dotnet-sdk-8.0; }
get() {   # $1 = NuGet id, $2 = version, $3 = folder
	[ -d "$3" ] && return 0
	curl -sSf -m 600 -o "$1.nupkg" "https://api.nuget.org/v3-flatcontainer/$1/$2/$1.$2.nupkg"
	unzip -qo "$1.nupkg" -d "$3"; rm -f "$1.nupkg"
}
get unityengine.modules 2021.3.33 unity
get microsoft.net.compilers.toolset 4.12.0 roslyn
get netstandard.library.ref 2.1.0 nsref
echo "cloud references ready in $D"
