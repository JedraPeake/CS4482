Shader "Custom/Test" 
{
	Properties
	{
		_BackColor ("Background Image", 2D) = "white" {}
		_BackColor2 ("Background Image2", 2D) = "white" {}
		_NoiseTex ("Noise Texture", 2D) = "white" {}
	}
    SubShader 
	{
        Pass 
		{
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #pragma target 3.0

            #include "UnityCG.cginc"
	
			sampler2D _NoiseTex;

			sampler2D _BackColor;
			sampler2D _BackColor2;
            
            float4 frag(v2f_img i) : SV_Target 
			{
                float2 mcoord;
                float2 coord = float2(0.0,0.0);
                mcoord.x = ((1.0-i.uv.x)*3.5)-2.5;
                mcoord.y = (i.uv.y*2.0)-1.0;
                float iteration = 0.0;
                const float _MaxIter = 29.0;
                const float PI = 3.14159;
                float xtemp;

				for ( iteration = 0.0; iteration < _MaxIter; iteration += 1.0) 
				{
                    if ( coord.x*coord.x + coord.y*coord.y > 2.0*(cos(fmod(_Time.y,2.0*PI))+1.0) )
                    break;
                    
					xtemp = coord.x*coord.x - coord.y*coord.y + mcoord.x;
                    coord.y = 2.0*coord.x*coord.y + mcoord.y;
                    coord.x = xtemp;
                }

				float4 randomValue = tex2D(_NoiseTex, i.uv + _Time.x);
				float displacement = randomValue.r;

				float noiseLevel = randomValue.r / 10.0;
				if(noiseLevel > 0.05)
				{
					noiseLevel -= 0.05;
				}
				displacement *= noiseLevel;
                
				float val = fmod((iteration/_MaxIter)+_Time.x,1.0);

				float4 color = tex2D(_BackColor, i.uv + displacement);

				color.r = clamp((3.0*abs(fmod(2.0*val,1.0)-0.5)),0.0,1.0);
                color.g = clamp((3.0*abs(fmod(2.0*val+(1.0/3.0),1.0)-0.5)),0.0,1.0);
                color.b = clamp((3.0*abs(fmod(2.0*val-(1.0/3.0),1.0)-0.5)),0.0,1.0);
				color.a = 1.0;
                
				float4 color2 = tex2D(_BackColor2, i.uv + displacement);
				color *= float4(color2.r, color2.g, color2.b, 0.0);
				return color;
            }
            ENDCG
        }
    }
}