// RECUPERADO: original ShaderLab text from the build (fixed-function), unchanged.
Shader "iPhone/Transparent Color Shift Unlit" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _OverTex ("Sheen (RGB) Trans (A)", 2D) = "white" {}
}
SubShader { 
 Tags { "RenderType"="Opaque" }
 Pass {
  Tags { "RenderType"="Opaque" }
  SetTexture [_MainTex] { combine texture }
 }
 Pass {
  Tags { "RenderType"="Opaque" }
  Blend SrcAlpha One
  SetTexture [_OverTex] { ConstantColor [_Color] combine texture * constant }
 }
}
}