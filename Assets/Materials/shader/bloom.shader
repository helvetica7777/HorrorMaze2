Shader "Custom/bloom"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Bloom("Bloom",2D)="black"{}
        _LuminanceThreshold("Luminance Threshold",Float)=0.5
        _BlurSize("Blur Size",Float)=1.0
    }
    SubShader
    {
        // No culling or depth
       // #include "UnityCG.cginc"
        CGINCLUDE
          
            sampler2D _MainTex;
            half4 _MainTex_TexelSize;
            sampler2D _Bloom;
            float _LuminanceThreshold;
            float _BlurSize;

            struct appdata_img
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
            };

            v2f vertExtractBright (appdata_img v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed luminance(fixed4 color){
                return 0.2125 * color.r + 0.7154 * color.g + 0.0721 * color.b;
   			}

            fixed4 fragExtractBright (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                fixed val = clamp(luminance(col)-_LuminanceThreshold,0,1);
                return col*val;
            }

            struct v2fBloom{
                float4 pos:SV_POSITION;
                half4 uv:TEXCOORD0;
			};
            v2fBloom vertBloom(appdata_img v){
                v2fBloom o;
                o.pos=UnityObjectToClipPos(v.vertex);
                o.uv.xy=v.texcoord;
                o.uv.zw=v.texcoord;

                #if UNITY_UV_STARTS_AT_TOP
                if (_MainTex_TexelSize.y<0.0)
                    o.uv.w=1.0-o.uv.w;
                #endif
                return o;
			}

            fixed4 fragBloom(v2fBloom i):SV_Target{
                return tex2D(_MainTex,i.uv.xy)+tex2D(_Bloom,i.uv.zw);       
			}

            struct v2fBlur{
                float4 pos:SV_POSITION;
                half2 uv[5]:TEXCOORD0;
			};
            v2fBlur vertBlurVertical(appdata_img v){
                v2fBlur o;
                o.pos=UnityObjectToClipPos(v.vertex);
                float2 blurUv=v.texcoord;

                o.uv[0]=blurUv;
                o.uv[1] = blurUv + float2( 0.0, _MainTex_TexelSize.y * 1.0) * _BlurSize; 
                o.uv[2] = blurUv - float2( 0.0, _MainTex_TexelSize.y * 1.0) * _BlurSize; 
                o.uv[3] = blurUv + float2( 0.0, _MainTex_TexelSize.y * 2.0) * _BlurSize; 
                o.uv[4] = blurUv - float2( 0.0, _MainTex_TexelSize.y * 2.0) * _BlurSize;	
                return o;
                }
            v2fBlur vertBlurHorizontal(appdata_img v){
                v2fBlur o;
                o.pos=UnityObjectToClipPos(v.vertex);
                half2 blurUv=v.texcoord;

                o.uv[0]=blurUv;
                o.uv[1] = blurUv + float2(_MainTex_TexelSize.x * 1.0, 0.0) * _BlurSize; 
                o.uv[2] = blurUv - float2(_MainTex_TexelSize.x * 1.0, 0.0) * _BlurSize; 
                o.uv[3] = blurUv + float2(_MainTex_TexelSize.x * 2.0, 0.0) * _BlurSize; 
                o.uv[4] = blurUv - float2(_MainTex_TexelSize.x * 2.0, 0.0) * _BlurSize;	
                return o;
                }
            fixed4 fragBlur(v2fBlur i):SV_Target{
                float weight[3]={0.4026, 0.2442, 0.0545};
                fixed3 sum = tex2D(_MainTex,i.uv[0]).rgb*weight[0];
                for (int it=1;it<3;it++)
                {
                 sum += tex2D(_MainTex, i.uv[it]).rgb * weight[it]; 
                 sum += tex2D(_MainTex, i.uv[2*it]).rgb * weight[it];      
				}
                return fixed4(sum,1.0);
			}
        ENDCG
         Cull Off ZWrite Off ZTest Always
        Pass
        {
          // 
            CGPROGRAM
            #pragma vertex vertExtractBright
            #pragma fragment fragExtractBright
   
            ENDCG
        }
        Pass
        {
            CGPROGRAM 
            #pragma vertex vertBlurVertical
            #pragma fragment fragBlur
            ENDCG
        }
        Pass
        {
            CGPROGRAM 
            #pragma vertex vertBlurHorizontal
            #pragma fragment fragBlur
            ENDCG
        }
        Pass
        {
            CGPROGRAM
            #pragma vertex vertBloom
            #pragma fragment fragBloom
            
            ENDCG
		}
      
    }
      Fallback Off
}
