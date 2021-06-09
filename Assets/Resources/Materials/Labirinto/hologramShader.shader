Shader "Unlit/hologramShader"
{
	Properties
	{
		_Color("Color", Color) = (0, 1, 1, 1)
		_MainTex("Base", 2D) = "white" {}
		_AlphaTexture("Alpha Texture", 2D) = "white" {}
		_ScrollSpeed("scroll Speed", Range(0, 200.0)) = 1.0//speed texture
		_GlowIntensity("Glow Intensity", Range(0.01, 1.0)) = 0.5// Glow

	}

		SubShader
		{

			Pass
			{
				Blend SrcAlpha One

				CGPROGRAM

					#pragma vertex vert
					#pragma fragment frag

					#include "UnityCG.cginc"

					struct appdata {
						float4 vertex : POSITION;
						float2 uv : TEXCOORD0;
						float3 normal : NORMAL;
					};

					struct v2f {
						float4 position : SV_POSITION;
						float2 uv : TEXCOORD0;
						float3 grabPos : TEXCOORD1;
						float3 viewDir : TEXCOORD2;
						float3 wrlNormal : NORMAL;
					};

					fixed4 _Color, _MainTex_ST;
					sampler2D _MainTex, _AlphaTexture;
					float _ScrollSpeed, _GlowIntensity;

					v2f vert(appdata IN) {
						v2f OUT;

						OUT.position = UnityObjectToClipPos(IN.vertex);
						OUT.uv = IN.uv;
						OUT.grabPos = UnityObjectToViewPos(IN.vertex);
						OUT.grabPos.y += _Time * _ScrollSpeed;// scroling effect
						OUT.wrlNormal = UnityObjectToWorldNormal(IN.normal);
						OUT.viewDir = normalize(UnityWorldSpaceViewDir(OUT.grabPos.xyz));

						return OUT;
					}

					fixed4 frag(v2f IN) : SV_Target{

						fixed4 alphaColor = tex2D(_AlphaTexture,  IN.grabPos.xy);
						fixed4 pxlColor = tex2D(_MainTex, IN.uv);
						pxlColor.w = alphaColor.w;
						half rim = 1.0 - saturate(dot(IN.viewDir, IN.wrlNormal));
						return pxlColor * _Color * (rim + _GlowIntensity);
					}
				ENDCG
			}
		}
}
