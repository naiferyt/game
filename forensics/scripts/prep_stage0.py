# Stage 0.6 prep — Unity-friendly data for the editor tools + restoration of the 4 custom shaders.
#  * _Recovery/Data/shader_remap.json      : AssetRipper dummy shader GUID -> Unity 6 built-in shader name
#  * _Recovery/Data/legacy_particles_u6.json: flat records for DSSRecovery.LegacyParticleConverter
#  * _Recovery/Data/lightmaps_u6.json       : per scene lightmap textures + renderer index/scale-offset
#  * Assets/Shader/<custom>.shader          : original ShaderLab text (3 fixed-function verbatim, RECUPERADO)
#                                             + GLSL->CG port of "Unlit Under The Sea" (ADAPTADO-U6)
import os, re, json, glob
HERE = os.path.dirname(os.path.abspath(__file__))
PROJ = os.path.join(HERE, '..', '..', 'recovery', 'DSSRacer_U6')
A = os.path.join(PROJ, 'Assets'); DATA = os.path.join(A, '_Recovery', 'Data')
ORIG = os.path.join(HERE, '..', 'output', 'shaders_original')

# Unity 4 built-in shader name -> Unity 6 built-in shader name (legacy shaders were moved under "Legacy Shaders/")
BUILTIN = {
    'Transparent/Diffuse': 'Legacy Shaders/Transparent/Diffuse',
    'Transparent/VertexLit': 'Legacy Shaders/Transparent/VertexLit',
    'Self-Illumin/Diffuse': 'Legacy Shaders/Self-Illumin/Diffuse',
    'Self-Illumin/VertexLit': 'Legacy Shaders/Self-Illumin/VertexLit',
    'Mobile/Diffuse': 'Mobile/Diffuse',
    'Mobile/Unlit (Supports Lightmap)': 'Mobile/Unlit (Supports Lightmap)',
    'Mobile/Particles/Additive': 'Mobile/Particles/Additive',
    'Mobile/Particles/VertexLit Blended': 'Mobile/Particles/VertexLit Blended',
    'Mobile/Particles/Alpha Blended': 'Mobile/Particles/Alpha Blended',
    'Mobile/Particles/Multiply': 'Mobile/Particles/Multiply',
    'Mobile/Skybox': 'Mobile/Skybox',
    'Mobile/VertexLit': 'Mobile/VertexLit',
    'Particles/Additive': 'Legacy Shaders/Particles/Additive',
    'Particles/Alpha Blended Premultiply': 'Legacy Shaders/Particles/Alpha Blended Premultiply',
    'Unlit/Transparent': 'Unlit/Transparent',
    'Unlit/Texture': 'Unlit/Texture',
}
CUSTOM_FF = {'Transparent And Color Unlit.shader': 'Transparent And Color Unlit',
             'Transparent Color Shift Unlit.shader': 'Transparent Color Shift Unlit',
             'Double Texture Additive Unlit.shader': 'Double Texture Additive Unlit'}

UNDER_THE_SEA = r'''// ADAPTADO-U6: hand port of the original GLES program of "Mobile/Unlit Under The Sea (Supports Lightmap)"
// (source text: forensics/output/shaders_original/Underwater Unlit.shader.txt). Same math:
//   rgb = albedo * (2 * lightmap)  [dLDR, as the original]  + caustic(worldXZ + v.xy)*0.005 + caustic(worldXZ + v.zw)*0.008
//   a   = albedo.a
// _CausticVector is animated at runtime by CausticsManager (original script).
Shader "Mobile/Unlit Under The Sea (Supports Lightmap)" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _CausticTex ("Caustic 1 (RGB)", 2D) = "black" {}
}
SubShader {
 LOD 100
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "FORWARD"
  Tags { "LightMode"="ForwardBase" "RenderType"="Opaque" }
  CGPROGRAM
  #pragma vertex vert
  #pragma fragment frag
  #pragma multi_compile_fwdbase
  #include "UnityCG.cginc"
  #include "Lighting.cginc"
  sampler2D _MainTex; float4 _MainTex_ST;
  sampler2D _CausticTex;
  float4 _CausticVector;
  struct v2f {
    float4 pos : SV_POSITION;
    float2 uv : TEXCOORD0;
    float3 wpos : TEXCOORD1;
  #ifdef LIGHTMAP_ON
    float2 lmuv : TEXCOORD2;
  #else
    fixed3 vlight : TEXCOORD2;
  #endif
  };
  v2f vert (appdata_full v) {
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
    o.wpos = mul(unity_ObjectToWorld, v.vertex).xyz;
  #ifdef LIGHTMAP_ON
    o.lmuv = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
  #else
    // original non-lightmapped variant: Lambert with SH ambient (surface shader "Unlit" = albedo only lit by ambient + main light)
    float3 n = UnityObjectToWorldNormal(v.normal);
    o.vlight = ShadeSH9(float4(n, 1.0)) + _LightColor0.rgb * max(0, dot(n, _WorldSpaceLightPos0.xyz));
  #endif
    return o;
  }
  fixed4 frag (v2f i) : SV_Target {
    fixed4 c = tex2D(_MainTex, i.uv);
    fixed3 caustic = tex2D(_CausticTex, (i.wpos.xz + _CausticVector.xy) * 0.005).rgb
                   + tex2D(_CausticTex, (i.wpos.xz + _CausticVector.zw) * 0.008).rgb;
  #ifdef LIGHTMAP_ON
    fixed3 rgb = c.rgb * (2.0 * UNITY_SAMPLE_TEX2D(unity_Lightmap, i.lmuv).rgb);
  #else
    fixed3 rgb = c.rgb * i.vlight;
  #endif
    return fixed4(rgb + caustic, c.a);
  }
  ENDCG
 }
}
Fallback "Mobile/Unlit (Supports Lightmap)"
}
'''


def guid_of(path):
    return re.search(r'guid: (\w+)', open(path + '.meta', encoding='utf8').read()).group(1)


def main():
    os.makedirs(DATA, exist_ok=True)
    # shaders
    remap = []
    for f in sorted(glob.glob(os.path.join(A, 'Shader', '*.shader'))):
        base = os.path.basename(f)
        name = re.match(r'Shader "([^"]+)"', open(f, encoding='utf8').read()).group(1)
        if base in CUSTOM_FF:
            src = open(os.path.join(ORIG, CUSTOM_FF[base] + '.shader.txt'), encoding='utf8').read()
            open(f, 'w', encoding='utf8', newline='\n').write('// RECUPERADO: original ShaderLab text from the build (fixed-function), unchanged.\n' + src)
            print('restored', base)
        elif base == 'Underwater Unlit.shader':
            open(f, 'w', encoding='utf8', newline='\n').write(UNDER_THE_SEA); print('ported', base)
        elif name in BUILTIN:
            remap.append(dict(guid=guid_of(f), path='Assets/Shader/' + base, originalName=name, unity6Name=BUILTIN[name]))
        else:
            print('UNMAPPED shader', base, name)
    json.dump(dict(entries=remap), open(os.path.join(DATA, 'shader_remap.json'), 'w'), indent=1)
    # particles
    src = json.load(open(os.path.join(DATA, 'legacy_particles.json')))
    V = lambda d: dict(x=float(d.get('x', 0)), y=float(d.get('y', 0)), z=float(d.get('z', 0)))
    out = []
    for p in src:
        e = p['EllipsoidParticleEmitter']; a = p['ParticleAnimator']; r = p['ParticleRenderer']
        mats = r.get('m_Materials') or []
        mat = mats[0] if mats and isinstance(mats[0], dict) else {}
        uva = r.get('UV Animation') or {}
        out.append(dict(
            file=p['file'], goFileID=int(p['gameObjectFileID']),
            enabled=int(e.get('m_Enabled', 1)), emit=int(e.get('m_Emit', 1)),
            minSize=float(e['minSize']), maxSize=float(e['maxSize']), minEnergy=float(e['minEnergy']), maxEnergy=float(e['maxEnergy']),
            minEmission=float(e['minEmission']), maxEmission=float(e['maxEmission']),
            worldVelocity=V(e['worldVelocity']), localVelocity=V(e['localVelocity']), rndVelocity=V(e['rndVelocity']),
            emitterVelocityScale=float(e['emitterVelocityScale']), tangentVelocity=V(e['tangentVelocity']),
            angularVelocity=float(e['angularVelocity']), rndAngularVelocity=float(e['rndAngularVelocity']), rndRotation=int(e['rndRotation']),
            worldSpace=int(e['Simulate in Worldspace?']), oneShot=int(e['m_OneShot']), ellipsoid=V(e['m_Ellipsoid']),
            minEmitterRange=float(e['m_MinEmitterRange']),
            animateColor=int(a['Does Animate Color?']), colors=[int(a['colorAnimation[%d]' % k]['rgba']) for k in range(5)],
            worldRotationAxis=V(a['worldRotationAxis']), localRotationAxis=V(a['localRotationAxis']), sizeGrow=float(a['sizeGrow']),
            rndForce=V(a['rndForce']), force=V(a['force']), damping=float(a['damping']), autodestruct=int(a['autodestruct']),
            materialGuid=mat.get('guid', ''), materialFileID=int(mat.get('fileID', 0) or 0),
            renderMode=int(r.get('m_StretchParticles', 0)), lengthScale=float(r.get('m_LengthScale', 2)), velocityScale=float(r.get('m_VelocityScale', 0)),
            cameraVelocityScale=float(r.get('m_CameraVelocityScale', 0)), maxParticleSize=float(r.get('m_MaxParticleSize', 0.25)),
            uvTilesX=int(uva.get('x Tile', 1)), uvTilesY=int(uva.get('y Tile', 1)), uvCycles=float(uva.get('cycles', 1)),
            castShadows=int(r.get('m_CastShadows', 0)), receiveShadows=int(r.get('m_ReceiveShadows', 0))))
    json.dump(dict(systems=out), open(os.path.join(DATA, 'legacy_particles_u6.json'), 'w'), indent=1)
    # lightmaps
    lm = json.load(open(os.path.join(DATA, 'lightmaps.json')))
    scenes = []
    for sc, d in lm.items():
        scenes.append(dict(scene=sc, lightmapGuids=[g or '' for g in d['lightmaps']],
                           renderers=[dict(fileID=int(r['fileID']), index=int(r['index']), so=dict(x=r['scaleOffset'][0], y=r['scaleOffset'][1], z=r['scaleOffset'][2], w=r['scaleOffset'][3])) for r in d['renderers']]))
    json.dump(dict(scenes=scenes), open(os.path.join(DATA, 'lightmaps_u6.json'), 'w'), indent=1)
    print('shader remaps', len(remap), 'particle systems', len(out), 'lightmapped scenes', len(scenes))


if __name__ == '__main__':
    main()
