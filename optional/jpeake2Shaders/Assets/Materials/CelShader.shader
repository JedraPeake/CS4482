Shader "Custom/AfterShader"
{
	Properties 
	{
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color1 ("Color1", Color) = (1, 1, 1, 1)
        _Color2 ("Color2", Color) = (1, 1, 1, 1)
        _Color3 ("Color3", Color) = (1, 1, 1, 1)
        _Color4 ("Color4", Color) = (1, 1, 1, 1)

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
            float4 _Color1, _Color2, _Color3, _Color4;
     
            float4 frag(v2f_img i) : COLOR 
			{
                float4 c = tex2D(_MainTex, i.uv);
                float lum = c.r*.3 + c.g*.59 + c.b*.11;

                if(lum > 0.75)
				{
					return _Color1;
                }
				else if (lum > 0.5)
				{
					return _Color2;
                }
				else if( lum > 0.25)
				{
					return _Color3;
                }
				else
				{
					return _Color4;
                }
            }
            ENDCG
        }
     }
}