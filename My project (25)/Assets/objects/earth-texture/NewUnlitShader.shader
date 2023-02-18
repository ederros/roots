Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Scale("Scale", float) = 1
        _StaticScale("StaticScale", float) = 1
        _BiasX("BiasX", float) = 0
        _BiasY("BiasY", float) = 0
        _SpeedX("SpeedX", float) = 1
        _SpeedY("SpeedY", float) = 1
        _ColMult("Color Multiplier", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Scale;
            float _BiasX;
            float _BiasY;
            float _SpeedX;
            float _SpeedY;
            float _StaticScale;
            float _ColMult;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                //v.uv *= _Scale;
                o.uv = TRANSFORM_TEX(v.uv , _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                float2 Speed_Move = float2(_WorldSpaceCameraPos.x* _SpeedX, _WorldSpaceCameraPos.y * _SpeedY);
                i.uv -= float2(0.5,0.5);
                
                i.uv += Speed_Move;
                i.uv *= _Scale;
                i.uv /= _StaticScale;
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col * _ColMult;
            }
            ENDCG
        }
    }
}
