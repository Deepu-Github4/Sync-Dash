Shader "Custom/GlowingShader"
{
    Properties
    {
        _Color("Base Color", Color) = (1, 1, 1, 1)
        _GlowColor("Glow Color", Color) = (0, 1, 1, 1)
        _GlowIntensity("Glow Intensity", Range(1, 5)) = 2.0
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
            };

            float4 _Color;
            float4 _GlowColor;
            float _GlowIntensity;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.position = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float glow = max(0, dot(i.worldNormal, float3(0,1,0))); // Simulated glow effect
                return _Color + (_GlowColor * _GlowIntensity * glow);
            }
            ENDCG
        }
    }
}
