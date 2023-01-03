Shader"Newbase/Background/Tools/Flicker"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        [NoScaleOffset] _MainTex ("Base (RGB)", 2D) = "white" {}
        [NoScaleOffset] _BumpMap ("Bumpmap", 2D) = "bump" {}
		//[NoScaleOffset] _MREMap ("Metallic, Roughness, Emission, (Occlusuion) RGB(A)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
        _RimColor("Color",Color) = (0,0.5,0.25,1)
        
        [Space(10)]
        _Speed("Speed", Range(0, 3)) = 0.7
        _Magnitude ("Magnitude", Range(0, 3)) = 1.5
    }
    SubShader
    {
        Tags { "Queue" = "Geometry" "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #include "UnityCG.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #pragma target 3.0

        uniform sampler2D _MainTex, _BumpMap/*, _MREMap*/;
        uniform fixed4 _Color;
        
        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            fixed3 Normal;   
        };

        float _Speed, _Magnitude;
        half _Glossiness, _Metallic;
        fixed4 _RimColor;
        
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            
            half flicker = abs(frac(_Time.y * _Speed) - 0.5) * _Magnitude;
            
            o.Albedo = lerp(c, _RimColor, flicker);
            o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_MainTex));
            
            o.Emission = lerp(0, _RimColor, flicker);
            
			//half2 mr = tex2D(_MREMap, IN.uv_MainTex);
			//o.Metallic = mr.r;
			//o.Smoothness = (1 - mr.g) * (1.0f - 0);
            
			o.Metallic = 0;
			o.Smoothness = 0.5;
            
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
