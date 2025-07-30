Shader "UI/UIOutline"
{
    Properties
    {
        [PerRendererData] _MainTex("Main Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        
        [Header(Outline Settings)]
        _OutlineColor("Outline Color", Color) = (1,1,1,1)
        _OutlineWidth("Outline Width", Range(0, 10)) = 2
        _AlphaThreshold("Alpha Threshold", Range(0, 1)) = 0.01
        [Toggle]_GlobalOutlineEnable("Global Outline Enable", Float) = 1
        
        [Header(Stencil Settings)]
        _StencilComp("Stencil Comparison", Float) = 8
        _Stencil("Stencil ID", Float) = 0
        _StencilOp("Stencil Operation", Float) = 0
        _StencilWriteMask("Stencil Write Mask", Float) = 255
        _StencilReadMask("Stencil Read Mask", Float) = 255
        
        [Header(Rendering Settings)]
        _ColorMask("Color Mask", Float) = 15
        [Toggle]_UseVertexControl("Use Vertex Control", Float) = 1
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }

        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask [_ColorMask]

        Pass
        {
            Name "OUTLINE_PASS"
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile __ UNITY_UI_CLIP_RECT
            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1; // 用于控制参数
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color     : COLOR;
                float2 texcoord  : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                half2  control   : TEXCOORD2;
            };

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _OutlineColor;
            float _OutlineWidth;
            float _AlphaThreshold;
            float4 _MainTex_TexelSize;
            float _GlobalOutlineEnable;
            float _UseVertexControl;
            float4 _ClipRect;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.worldPosition = IN.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color * _Color;
                OUT.control = IN.texcoord1.xy; // 使用第二组UV传递控制参数
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                // 基础颜色采样
                half4 color = tex2D(_MainTex, IN.texcoord) * IN.color;
                
                // 裁剪矩形处理
                #ifdef UNITY_UI_CLIP_RECT
                color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                #endif

                // 计算描边开关
                float outlineEnable = _GlobalOutlineEnable;
                if(_UseVertexControl > 0.5)
                    outlineEnable *= IN.control.r; // 使用R通道控制

                // 提前退出条件
                if(color.a > 1 - _AlphaThreshold || outlineEnable < 0.1)
                    return color;

                // 边缘检测采样
                float2 offset = _MainTex_TexelSize.xy * _OutlineWidth;
                
                half alphaSum = 0;
                const int samples = 8;
                float2 offsets[samples] = {
                    float2(0, 1),    // 上
                    float2(0, -1),   // 下
                    float2(-1, 0),   // 左
                    float2(1, 0),     // 右
                    float2(-1, 1)*0.7,// 左上
                    float2(1, 1)*0.7, // 右上
                    float2(-1, -1)*0.7,// 左下
                    float2(1, -1)*0.7 // 右下
                };

                UNITY_UNROLL
                for(int i = 0; i < samples; i++)
                {
                    alphaSum += tex2D(_MainTex, IN.texcoord + offsets[i] * offset).a;
                }

                // 计算描边强度
                half outlineFactor = saturate(alphaSum * 0.5); // 8次采样平均
                
                // 混合颜色
                half4 result = color;
                result.rgb = lerp(_OutlineColor.rgb, color.rgb, color.a);
                result.a = max(color.a, outlineFactor * _OutlineColor.a * outlineEnable);

                return result;
            }
            ENDCG
        }
    }

    FallBack "UI/Default"
    CustomEditor "AdvancedOutlineShaderGUI"
}