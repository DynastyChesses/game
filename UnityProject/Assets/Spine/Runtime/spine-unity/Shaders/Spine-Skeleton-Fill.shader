// - Unlit
// - Premultiplied Alpha Blending (Optional straight alpha input)
// - Double-sided, no depth

Shader "Spine/Skeleton Fill" {
	Properties {
		_FillColor ("FillColor", Color) = (1,1,1,1)
		_FillPhase ("FillPhase", Range(0, 1)) = 0
		[NoScaleOffset] _MainTex ("MainTex", 2D) = "white" {}
		_Cutoff ("Shadow alpha cutoff", Range(0,1)) = 0.1
		[Toggle(_STRAIGHT_ALPHA_INPUT)] _StraightAlphaInput("Straight Alpha Texture", Int) = 0
		[HideInInspector] _StencilRef("Stencil Reference", Float) = 1.0
		[HideInInspector][Enum(UnityEngine.Rendering.CompareFunction)] _StencilComp("Stencil Comparison", Float) = 8 // Set to Always as default
		
		[Space(10)]
		[Toggle(_FX)] _Fx("启用特效", Int) = 0
		[Toggle(_Desaturate)] _Desaturate("去色", Int) = 0
        [PowerSlider(2)] _SizeUVScale ("模型UV缩放", Range(0.01,2)) = 1
		_BlendAdd("加方式混合", Range(0, 1)) = 1
        [HDR]_Color ("特效颜色", Color) = (1,1,1,1)
        _FxTex ("特效贴图", 2D) = "white" {}
		_RuntimeColor ("运行时修改的颜色", Color) = (1, 1, 1, 1)
        _AlphaValue ("Alpha值", Range(0,10)) = 1
        _USpeed ("Uspeed", Float ) = 0
        _VSpeed ("Vspeed", Float ) = 0
        [HDR]_LerpColor ("LerpColor", Color) = (1,1,1,1)
        _LerpValue ("LerpValue",Range(0,1)) = 1
        _DistortionTex ("扭曲贴图", 2D) = "gray" {}
        [PowerSlider(2)] _DistortionIntensity ("扭曲强度", Range(0, 1)) = 1
        _Distortion_USpeed ("扭曲_USpeed", Float ) = 0
        _Distortion_VSpeed ("扭曲_VSpeed", Float ) = 0

		// Outline properties are drawn via custom editor.
		[HideInInspector] _OutlineWidth("Outline Width", Range(0,8)) = 3.0
		[HideInInspector] _OutlineColor("Outline Color", Color) = (1,1,0,1)
		[HideInInspector] _OutlineReferenceTexWidth("Reference Texture Width", Int) = 1024
		[HideInInspector] _ThresholdEnd("Outline Threshold", Range(0,1)) = 0.25
		[HideInInspector] _OutlineSmoothness("Outline Smoothness", Range(0,1)) = 1.0
		[HideInInspector][MaterialToggle(_USE8NEIGHBOURHOOD_ON)] _Use8Neighbourhood("Sample 8 Neighbours", Float) = 1
		[HideInInspector] _OutlineMipLevel("Outline Mip Level", Range(0,3)) = 0
	}
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
		Blend One OneMinusSrcAlpha
		Cull Off
		ZWrite Off
		Lighting Off

		Stencil {
			Ref[_StencilRef]
			Comp[_StencilComp]
			Pass Keep
		}

		Pass {
			Name "Normal"

			CGPROGRAM
			#pragma shader_feature_local _ _STRAIGHT_ALPHA_INPUT
			#pragma multi_compile_local _ _FX
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			sampler2D _MainTex;
			float4 _FillColor;
			float _FillPhase;
			
            uniform half _AlphaValue;
            uniform half _SizeUVScale;
            uniform half _BlendAdd;
            uniform half4 _Color;
            uniform sampler2D _FxTex;
            uniform half4 _FxTex_ST;
            uniform half _USpeed;
            uniform half _VSpeed;
            uniform half4 _LerpColor;
            uniform half _LerpValue;
            uniform sampler2D _DistortionTex;
            uniform half4 _DistortionTex_ST;
            uniform half _DistortionIntensity;
            uniform half _Distortion_USpeed;
            uniform half _Distortion_VSpeed;
			uniform int _Desaturate;
			uniform float4 _RuntimeColor;


			struct VertexInput {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 vertexColor : COLOR;
			};

			struct VertexOutput {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 vertexColor : COLOR;
				#if _FX
				float2 fxUV1 : TEXCOORD1;
				float2 fxUV2 : TEXCOORD2;
				#endif
				
			};

			VertexOutput vert (VertexInput v) {
				VertexOutput o = (VertexOutput)0;
				o.uv = v.uv;
				o.vertexColor = v.vertexColor;
				o.pos = UnityObjectToClipPos(v.vertex);

				#if _FX
				float2 modelXY = v.vertex.xy * _SizeUVScale.xx;
				modelXY *= float2(unity_ObjectToWorld[0][0], unity_ObjectToWorld[1][1]);
				o.fxUV1 = TRANSFORM_TEX(modelXY, _FxTex);
                o.fxUV1 += half2(_USpeed, _VSpeed) * _Time.y;
			
				o.fxUV2 = TRANSFORM_TEX(modelXY, _DistortionTex);
                o.fxUV2 += half2(_Distortion_USpeed, _Distortion_VSpeed) * _Time.y;
				#endif
				
				return o;
			}

			float4 frag (VertexOutput i) : SV_Target {
				float4 rawColor = tex2D(_MainTex,i.uv);
				float finalAlpha = (rawColor.a * i.vertexColor.a * _RuntimeColor.a);

				#if defined(_STRAIGHT_ALPHA_INPUT)
				rawColor.rgb *= rawColor.a;
				#endif

				float3 finalColor = lerp((rawColor.rgb * i.vertexColor.rgb * _RuntimeColor.rgb), (_FillColor.rgb * finalAlpha), _FillPhase); // make sure to PMA _FillColor.

				// 把"XSJ/VFX/FxStandard"特效shader拿来，混合到spine自身上
				#if _FX
				half2 uvDistortion = tex2D(_DistortionTex, i.fxUV2);
				half2 fxUV = i.fxUV1 + (uvDistortion * 2 -1) * _DistortionIntensity;
				half4 fxColor = tex2D(_FxTex, fxUV) * _Color;

				fxColor.rgb = lerp(fxColor.rgb, _LerpColor.rgb, saturate(1 - fxColor.a - _LerpValue));
				fxColor.a = saturate(fxColor.a * _AlphaValue);
				fxColor.rgb *= finalAlpha * fxColor.a;
				// 通过_BlendAdd控制加或alpha方式混合
				finalColor.rgb = fxColor.rgb + lerp(1 - fxColor.a, 1, _BlendAdd) * finalColor.rgb;
				#endif

				float grayscale = dot(finalColor.rgb, float3(0.299, 0.587, 0.114));
				finalColor.rgb = lerp(finalColor.rgb,float3(grayscale, grayscale, grayscale),_Desaturate);
				
				return fixed4(finalColor, finalAlpha);
			}
			ENDCG
		}

		Pass {
			Name "Caster"
			Tags { "LightMode"="ShadowCaster" }
			Offset 1, 1
			ZWrite On
			ZTest LEqual

			Fog { Mode Off }
			Cull Off
			Lighting Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_shadowcaster
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"
			sampler2D _MainTex;
			fixed _Cutoff;

			struct VertexOutput {
				V2F_SHADOW_CASTER;
				float4 uvAndAlpha : TEXCOORD1;
			};

			VertexOutput vert (appdata_base v, float4 vertexColor : COLOR) {
				VertexOutput o;
				o.uvAndAlpha = v.texcoord;
				o.uvAndAlpha.a = vertexColor.a;
				TRANSFER_SHADOW_CASTER(o)
				return o;
			}

			float4 frag (VertexOutput i) : SV_Target {
				fixed4 texcol = tex2D(_MainTex, i.uvAndAlpha.xy);
				clip(texcol.a * i.uvAndAlpha.a - _Cutoff);
				SHADOW_CASTER_FRAGMENT(i)
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
	CustomEditor "SpineShaderWithOutlineGUI"
}
