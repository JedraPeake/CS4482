Shader "Custom/GradShader"
{
	Properties 
	{
        _MainTex ("Base (RGB)", 2D) = "white" {}

		_Color1 ("Color1", Color) = (0, 0, 0.5, 1)
		_Color2 ("Color2", Color) = (0, 0, 0.1, 1)
		_Color3 ("Color3", Color) = (0, 0, 0.15, 1)
		_Color4 ("Color4", Color) = (0, 0, 0.2, 1)
		_Color5 ("Color5", Color) = (0, 0, 0.25, 1)
		_Color6 ("Color6", Color) = (0, 0, 0.3, 1)
		_Color7 ("Color7", Color) = (0, 0, 0.35, 1)
		_Color8 ("Color8", Color) = (0, 0, 0.4, 1)
		_Color9 ("Color9", Color) = (0, 0, 0.45, 1)
		_Color10 ("Color10", Color) = (0, 0, 0.5, 1)
		_Color11 ("Color11", Color) = (0, 0, 0.55, 1)
		_Color12 ("Color12", Color) = (0, 0, 0.6, 1)
		_Color13 ("Color13", Color) = (0, 0, 0.65, 1)
		_Color14 ("Color14", Color) = (0, 0, 0.7, 1)
		_Color15 ("Color15", Color) = (0, 0, 0.75, 1)
		_Color16 ("Color16", Color) = (0, 0, 0.8, 1)
		_Color17 ("Color17", Color) = (0, 0, 0.85, 1)
		_Color18 ("Color18", Color) = (0, 0, 0.9, 1)
		_Color19 ("Color19", Color) = (0, 0, 0.95, 1)
		_Color20 ("Color20", Color) = (0, 0, 0.1, 1)
     }
	 SubShader 
	 {
		Pass 
		{
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
     
            #include "UnityCG.cginc"
     
            uniform sampler2D _MainTex;
            float4 _Color1, _Color2, _Color3, _Color4, _Color5, _Color6, _Color7, _Color8, _Color9, _Color10, _Color11, _Color12, _Color13, _Color14, _Color15, _Color16, _Color17, _Color18, _Color19, _Color20;
     
            float4 frag(v2f_img i) : COLOR 
			{
                float4 c = tex2D(_MainTex, i.uv);
                float lum = c.r*.3 + c.g*.59 + c.b*.11;

				if(lum > 0.95)
				{
                    return _Color20;
                }
                else if(lum > 0.90)
				{
                    return _Color19;
                }
				else if (lum > 0.85)
				{
                    return _Color18;
                }
				else if (lum > 0.80)
				{
					return _Color17;
                }
				else if (lum > 0.75)
				{
                    return _Color16;
                }
				else if( lum > 0.70)
				{
                    return _Color15;
                }
				else if( lum > 0.65)
				{
                    return _Color14;
                }
				else if( lum > 0.60)
				{
                    return _Color13;
                }
				else if( lum > 0.55)
				{
                    return _Color12;
                }
				else if( lum > 0.50)
				{
                    return _Color11;
                }
				else if( lum > 0.45)
				{
                    return _Color10;
                }
				else if( lum > 0.40)
				{
                    return _Color9;
                }
				else if( lum > 0.35)
				{
                    return _Color8;
                }
				else if( lum > 0.30)
				{
                    return _Color7;
                }
				else if( lum > 0.25)
				{
                    return _Color6;
                }
				else if( lum > 0.20)
				{
                    return _Color5;
                }
				else if( lum > 0.15)
				{
                    return _Color4;
                }
				else if( lum > 0.10)
				{
                    return _Color3;
                }
				else if( lum > 0.05)
				{
                    return _Color2;
                }
				else
				{
                    return _Color1;
                }
            }
            ENDCG
        }
     }
}
