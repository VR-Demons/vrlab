Shader "TCL987/3D/Side-By-Side URP"
{
    Properties
    {
        _ScreenTexture("Screen Texture", 2D) = "white" {}
        [Toggle(_)] _SwapEyes("Swap-Eyes", Int) = 0
        [HideInInspector] _dirty("", Int) = 1
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry+0" "IsEmissive" = "true" }
        Cull Back
        Pass
        {
            CGPROGRAM
            #pragma target 3.5
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 vertexToFrag60 : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _ScreenTexture;
            int _SwapEyes;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float2 temp_cast_0 = float2(0.5, 0.5);
                float2 uv_TexCoord37 = v.texcoord * temp_cast_0;
                float2 temp_cast_2 = float2(0.5, 0.5);
                float2 uv_TexCoord36 = v.texcoord * temp_cast_2;
                float localStereoEyeIndex61 = unity_StereoEyeIndex;
                float lerpResult65 = lerp(localStereoEyeIndex61, (-localStereoEyeIndex61 + 1.0), _SwapEyes);
                float lerpResult34 = lerp(uv_TexCoord37.x, uv_TexCoord36.x, lerpResult65);
                o.vertexToFrag60 = float2(lerpResult34, v.texcoord.y);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 col = tex2D(_ScreenTexture, i.vertexToFrag60);
                return half4(col.rgb, 1);
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
    CustomEditor "ASEMaterialInspector"
}
