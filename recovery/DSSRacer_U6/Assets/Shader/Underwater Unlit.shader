// ADAPTADO-U6: hand port of the original GLES program of "Mobile/Unlit Under The Sea (Supports Lightmap)"
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
