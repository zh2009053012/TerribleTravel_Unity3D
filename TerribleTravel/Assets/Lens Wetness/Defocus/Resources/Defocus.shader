Shader "Hidden/Defocus" {
	Properties {
		_MainTex ("MainTex", 2D) = "gray" {}
	
	}

	CGINCLUDE
	
	#include "UnityCG.cginc"
	
	//Receive parameters
	uniform sampler2D		_MainTex, 							 
							_CameraDepthTexture,
							_BlurTex,
							_zBlurred;
	
	float					_EdgeSpread,
							_Blur;
					
	
	float4					 
							_Offset,
							_zOffset,
							_MainTex_TexelSize;	
	
	struct v2f {
		float4 pos : POSITION;
		float2 uv : TEXCOORD0;
		 #if UNITY_UV_STARTS_AT_TOP
				half2 uv2 : TEXCOORD1;
		#endif
		
	};
	
	//Common Vertex Shader
	v2f vert( appdata_img v )
	{
	v2f o;
	o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
	o.uv = v.texcoord;		
        	
        #if UNITY_UV_STARTS_AT_TOP
        	o.uv2 = v.texcoord;				
        	if (_MainTex_TexelSize.y < 0.0)
        		o.uv.y = 1.0 - o.uv.y;
        #endif
        	        	
			return o; 
	
	} 
	
	struct v2f_blur {
		half4 pos : POSITION;
		half2 uv : TEXCOORD0;
		half4 uv01 : TEXCOORD1;
		half4 uv23 : TEXCOORD2;
		half4 uv45 : TEXCOORD3;
		half4 uv67 : TEXCOORD4;
	};

	v2f_blur vertWithMultiCoords2 (appdata_img v) {
		v2f_blur o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv.xy = v.texcoord.xy;
		o.uv01 =  v.texcoord.xyxy + _Offset.xyxy * half4(1,1, -1,-1);
		o.uv23 =  v.texcoord.xyxy + _Offset.xyxy * half4(1,1, -1,-1) * 2.0;
		o.uv45 =  v.texcoord.xyxy + _Offset.xyxy * half4(1,1, -1,-1) * 3.0;
		o.uv67 =  v.texcoord.xyxy + _Offset.xyxy * half4(1,1, -1,-1) * 4.0;
		
		return o;  
	}
	
	half4 GetZ(v2f_blur i) : COLOR 
	{
		
		half z = length(DECODE_EYEDEPTH(tex2D(_CameraDepthTexture, i.uv).r));
		z = step(z, 0.9)*5.0;
		return z.xxxx;
	} 


	half4 fragGaussBlur (v2f_blur i) : COLOR 
	{
		half4 color = half4 (0,0,0,0);
		color += 0.225 * tex2D (_MainTex, i.uv);
		color += 0.150 * tex2D (_MainTex, i.uv01.xy);
		color += 0.150 * tex2D (_MainTex, i.uv01.zw);
		color += 0.110 * tex2D (_MainTex, i.uv23.xy);
		color += 0.110 * tex2D (_MainTex, i.uv23.zw);
		color += 0.075 * tex2D (_MainTex, i.uv45.xy);
		color += 0.075 * tex2D (_MainTex, i.uv45.zw);	
		color += 0.0525 * tex2D (_MainTex, i.uv67.xy);
		color += 0.0525 * tex2D (_MainTex, i.uv67.zw);
		return color;
	} 

	half4 Compose(v2f IN) : COLOR
	{				
		half2 ScreenUV = IN.uv;
		float4 Final=1;
		
		half Z = tex2D(_zBlurred, ScreenUV).x;
		
		#if UNITY_UV_STARTS_AT_TOP
		float4 Scene = tex2D(_MainTex, IN.uv2);
		#else
		float4 Scene = tex2D(_MainTex, ScreenUV);
		#endif
		float4 SceneBlur = tex2D(_BlurTex, ScreenUV);
		Final.rgb = lerp(Scene.rgb, SceneBlur.rgb, min(1.0, Z));
		//Final = Z;
	  
		return Final;
	}

	ENDCG 
	
Subshader {

	ZTest Off
	Cull Off
	ZWrite Off
	Fog { Mode off }
  
  //Pass 0
   Pass {     

      CGPROGRAM      
      #pragma fragmentoption ARB_precision_hint_fastest
	  #pragma target 3.0
      #pragma exclude_renderers flash
      #pragma vertex vertWithMultiCoords2
      #pragma fragment fragGaussBlur
      
      ENDCG
  } 
 Pass 
 {
      CGPROGRAM
	  #pragma fragmentoption ARB_precision_hint_fastest	 
	  #pragma target 3.0 
      #pragma vertex vert
      #pragma fragment Compose
      ENDCG
  }


 Pass 
 {
      CGPROGRAM
	  #pragma fragmentoption ARB_precision_hint_fastest	  
	  #pragma target 3.0
      #pragma vertex vert
      #pragma fragment GetZ
      ENDCG
  }
 
}

Fallback off
	
}