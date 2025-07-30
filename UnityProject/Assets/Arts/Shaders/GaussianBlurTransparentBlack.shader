Shader "Custom/TransparentBlack"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Threshold("Threshold", Range(0, 1)) = 0.1
        _Smoothness("Smoothness", Range(0, 1)) = 0.1
        _UseTransParent("_UseTransParent", Range(0, 1)) = 0.1
        [Toggle(_UseBlurTransParent)] _UseBlurTransParent("使用黑色处透明", Int) = 0
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Threshold;
            float _Smoothness;
            int _UseBlurTransParent;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                if (_UseBlurTransParent == 0)
                {
                    return col;
                }
                float grayscale = dot(col.rgb, fixed3(0.299, 0.587, 0.114));
                col.a =  smoothstep(_Threshold - _Smoothness, _Threshold + _Smoothness, grayscale);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
