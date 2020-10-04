Shader "Unlit/3DMetaBalls"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _MetaBall1_EllipseXRotation("MetaBall1_EllipseXRotation", Range(0.0, 360.0)) = 0.0
        _MetaBall1_EllipseYRotation("MetaBall1_EllipseXRotation", Range(0.0, 360.0)) = 0.0
        _MetaBall1_EllipseZRotation("MetaBall1_EllipseXRotation", Range(0.0, 360.0)) = 0.0

        _MetaBall2_EllipseXRotation("MetaBall1_EllipseXRotation", Range(0.0, 360.0)) = 0.0
        _MetaBall2_EllipseYRotation("MetaBall1_EllipseXRotation", Range(0.0, 360.0)) = 0.0
        _MetaBall2_EllipseZRotation("MetaBall1_EllipseXRotation", Range(0.0, 360.0)) = 0.0

        _MetaBall1_EllipseARadius  ("MetaBall1_EllipseARadius", Range(0.0, 5.0)) = 1.0
        _MetaBall1_EllipseBRadius  ("MetaBall1_EllipseBRadius", Range(0.0, 5.0)) = 1.0
  
        _MetaBall2_EllipseARadius  ("MetaBall1_EllipseARadius", Range(0.0, 5.0)) = 1.0
        _MetaBall2_EllipseBRadius  ("MetaBall1_EllipseBRadius", Range(0.0, 5.0)) = 1.0
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha 

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

            float _MetaBall1_EllipseXRotation;
            float _MetaBall1_EllipseYRotation;
            float _MetaBall1_EllipseZRotation;
            float _MetaBall2_EllipseXRotation;
            float _MetaBall2_EllipseYRotation;
            float _MetaBall2_EllipseZRotation;
            float _MetaBall1_EllipseARadius;
            float _MetaBall1_EllipseBRadius;
            float _MetaBall2_EllipseARadius;
            float _MetaBall2_EllipseBRadius;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                
                //col = float4(i.uv.y, i.uv.y, i.uv.y, abs(distance(i.uv.y, 0.5) )* 2.0);

                return col;
            }
            ENDCG
        }
    }
}
