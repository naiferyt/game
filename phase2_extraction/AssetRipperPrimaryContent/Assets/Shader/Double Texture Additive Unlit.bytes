Shader "Additive Unlit Double Texture" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB) Trans. (Alpha)", 2D) = "white" {}
 _MainTex2 ("Base (RGB) Trans. (Alpha)", 2D) = "white" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent+1" }
 Pass {
  Tags { "QUEUE"="Transparent+1" }
  ZWrite Off
  Blend SrcAlpha One
  ColorMask RGB
  SetTexture [_MainTex] { ConstantColor [_Color] combine texture * constant quad, texture alpha * constant alpha double }
  SetTexture [_MainTex2] { ConstantColor [_Color] combine texture * previous quad, texture alpha * constant alpha double }
 }
}
}