Shader"Newbase/Background/Tools/Indicator" {
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        [NoScaleOffset]_MainTex ("Base (RGB)", 2D) = "white" {}
        [NoScaleOffset]_BumpMap ("Bumpmap", 2D) = "bump" {}
		//[NoScaleOffset] _MREMap ("Metallic, Roughness, Emission, (Occlusuion) RGB(A)", 2D) = "white" {}
        _IndicatorColor ("Silhouette Color", Color) = (1,0,1,1)
    }
    SubShader
    {
        Tags { "Queue" = "Geometry+1" "RenderType" = "Opaque" }
        ZWrite On

        Stencil
        {
            Ref 2
            Pass Replace 
        }

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows 
        #pragma target 3.0
        
        uniform fixed4 _Color;
        uniform sampler2D _MainTex, _BumpMap/*, _MREMap*/;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = tex2D ( _MainTex, IN.uv_MainTex).rgb * _Color;
            o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_MainTex));
            
			//half2 mr = tex2D(_MREMap, IN.uv_MainTex);
			//o.Metallic = mr.r;
			//o.Smoothness = (1 - mr.g) * (1.0f - 0);
            
			o.Metallic = 0;
			o.Smoothness = 0.5;
        }
        ENDCG


        ZWrite Off
        ZTest NotEqual 
		Cull Front 
        Blend OneMinusDstColor One
        
        Stencil
        {
            Ref 1
            Comp Greater
			Pass Replace	
			ZFail Zero	
        }

        CGPROGRAM
        #pragma surface surf NoLighting// Standard noforwardadd nolightmap noambient noshadow
        
        fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            return fixed4(0, 0, 0, 1); //half4(s.Albedo, s.Alpha);
        }
        
        struct Input 
        { 
            float4 color : COLOR; 
        };
        
        fixed4 _IndicatorColor;
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _IndicatorColor.rgb;
        }

        ENDCG
    }
    FallBack "Diffuse"
}