// Editor-only data contracts for the Stage 0 recovery tools (JsonUtility schemas of Assets/_Recovery/Data/*.json).
using System;
using UnityEngine;

namespace DSSRecovery
{
	[Serializable] public class V3 { public float x, y, z; public Vector3 V { get { return new Vector3(x, y, z); } } }
	[Serializable] public class V4 { public float x, y, z, w; public Vector4 V { get { return new Vector4(x, y, z, w); } } }

	[Serializable] public class ShaderRemapEntry { public string guid, path, originalName, unity6Name; }
	[Serializable] public class ShaderRemapFile { public ShaderRemapEntry[] entries; }

	[Serializable]
	public class LegacyParticle
	{
		public string file; public long goFileID;
		public int enabled, emit;
		public float minSize, maxSize, minEnergy, maxEnergy, minEmission, maxEmission;
		public V3 worldVelocity, localVelocity, rndVelocity; public float emitterVelocityScale; public V3 tangentVelocity;
		public float angularVelocity, rndAngularVelocity; public int rndRotation, worldSpace, oneShot;
		public V3 ellipsoid; public float minEmitterRange;
		public int animateColor; public long[] colors;
		public V3 worldRotationAxis, localRotationAxis; public float sizeGrow; public V3 rndForce, force; public float damping; public int autodestruct;
		public string materialGuid; public long materialFileID;
		public int renderMode; public float lengthScale, velocityScale, cameraVelocityScale, maxParticleSize;
		public int uvTilesX, uvTilesY; public float uvCycles; public int castShadows, receiveShadows;
	}
	[Serializable] public class LegacyParticleFile { public LegacyParticle[] systems; }

	[Serializable] public class LightmappedRenderer { public long fileID; public int index; public V4 so; }
	[Serializable] public class LightmapScene { public string scene; public string[] lightmapGuids; public LightmappedRenderer[] renderers; }
	[Serializable] public class LightmapFile { public LightmapScene[] scenes; }
}
