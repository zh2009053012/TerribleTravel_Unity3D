
Shader "FX/LensWetness" {
    Properties {
        _MainTex ("MainTex", 2D) = "gray" {}
        _Refraction ("Refraction", Range(-0.1, 0.1)) = 0
		_Color("Color", Color) = (1,1,1,1)
		_R("R", 2D) = "black"{}
		_G("R", 2D) = "black"{}
		_B("R", 2D) = "black"{}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
//            "Queue"="AlphaTest"
//            "RenderType"="TransparentCutout"
				"Queue" = "Transparent"
				"RenderType"="TransparentCutout"
        }
        ZWrite off
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Refraction;
            uniform sampler2D _R; uniform float4 _R_ST;
            uniform sampler2D _G; uniform float4 _G_ST;
            uniform sampler2D _B; uniform float4 _B_ST;
			float4 _Color;

            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = ComputeScreenPos(o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
               
              
                float2 sceneUVs = i.screenPos.xy / i.screenPos.w;

                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip((_MainTex_var.a*i.vertexColor.a) - 0.5);


                float node_3220 = (_Refraction*i.vertexColor.a*_MainTex_var.a);
                float2 node_2803 = (_MainTex_var.rgb*2.0+-1.0).rg;
                float2 node_9521 = sceneUVs.rg;
                float2 node_1986 = ((node_3220*node_2803)+node_9521);
                float4 R = tex2D(_R,TRANSFORM_TEX(node_1986, _R));
                float2 node_7401 = (node_9521+(node_2803*node_3220*1.1));
                float4 G = tex2D(_G,TRANSFORM_TEX(node_7401, _G));
                float2 node_3073 = (node_9521+(node_2803*node_3220*1.2));
                float4 B = tex2D(_B,TRANSFORM_TEX(node_3073, _B));
                float3 emissive = float3(float2(R.r,G.g),B.b);
                float3 finalColor = emissive * _Color;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip((_MainTex_var.a*i.vertexColor.a) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        
    }
    FallBack "Diffuse"
   
}
