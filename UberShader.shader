Shader "hidden/preview"
{
	Properties
	{
				[NoScaleOffset] Texture_C84B49A3("_MainTex", 2D) = "white" {}
				[NoScaleOffset] Texture_43E7D7BE("_NormalMap", 2D) = "white" {}
				Float_19181232("DissolveAmount", Float) = 0.6
	}
	CGINCLUDE
	#include "UnityCG.cginc"
			inline float unity_noise_randomValue (float2 uv)
			{
			    return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453);
			}
			inline float unity_noise_interpolate (float a, float b, float t)
			{
			    return (1.0-t)*a + (t*b);
			}
			inline float unity_valueNoise (float2 uv)
			{
			    float2 i = floor(uv);
			    float2 f = frac(uv);
			    f = f * f * (3.0 - 2.0 * f);
			    uv = abs(frac(uv) - 0.5);
			    float2 c0 = i + float2(0.0, 0.0);
			    float2 c1 = i + float2(1.0, 0.0);
			    float2 c2 = i + float2(0.0, 1.0);
			    float2 c3 = i + float2(1.0, 1.0);
			    float r0 = unity_noise_randomValue(c0);
			    float r1 = unity_noise_randomValue(c1);
			    float r2 = unity_noise_randomValue(c2);
			    float r3 = unity_noise_randomValue(c3);
			    float bottomOfGrid = unity_noise_interpolate(r0, r1, f.x);
			    float topOfGrid = unity_noise_interpolate(r2, r3, f.x);
			    float t = unity_noise_interpolate(bottomOfGrid, topOfGrid, f.y);
			    return t;
			}
			void Unity_SimpleNoise_float(float2 UV, float Scale, out float Out)
			{
			    float t = 0.0;
			    for(int i = 0; i < 3; i++)
			    {
			        float freq = pow(2.0, float(i));
			        float amp = pow(0.5, float(3-i));
			        t += unity_valueNoise(float2(UV.x*Scale/freq, UV.y*Scale/freq))*amp;
			    }
			    Out = t;
			}
			void Unity_Step_float(float A, float B, out float Out)
			{
			    Out = step(A, B);
			}
			struct GraphVertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 texcoord0 : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			struct SurfaceInputs{
				half4 uv0;
			};
			struct SurfaceDescription{
				float4 PreviewOutput;
			};
			float Float_362F5DF0;
			UNITY_DECLARE_TEX2D(Texture_C84B49A3);
			UNITY_DECLARE_TEX2D(Texture_43E7D7BE);
			float Float_19181232;
			float4 _SimpleNoise_33CDF08A_UV;
			float _SimpleNoise_33CDF08A_Scale;
			float4 _SampleTexture2D_C2E704C2_UV;
			float4 _SampleTexture2D_D4A1438C_UV;
			GraphVertexInput PopulateVertexData(GraphVertexInput v){
				return v;
			}
			SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
				SurfaceDescription surface = (SurfaceDescription)0;
				half4 uv0 = IN.uv0;
				float _SimpleNoise_33CDF08A_Out;
				Unity_SimpleNoise_float(uv0.xy, _SimpleNoise_33CDF08A_Scale, _SimpleNoise_33CDF08A_Out);
				if (Float_362F5DF0 == 0) { surface.PreviewOutput = half4(_SimpleNoise_33CDF08A_Out, _SimpleNoise_33CDF08A_Out, _SimpleNoise_33CDF08A_Out, 1.0); return surface; }
				float _Property_FACB1280_Out = Float_19181232;
				float _Step_30CE32A1_Out;
				Unity_Step_float(_SimpleNoise_33CDF08A_Out, _Property_FACB1280_Out, _Step_30CE32A1_Out);
				if (Float_362F5DF0 == 1) { surface.PreviewOutput = half4(_Step_30CE32A1_Out, _Step_30CE32A1_Out, _Step_30CE32A1_Out, 1.0); return surface; }
				float4 _SampleTexture2D_C2E704C2_RGBA = UNITY_SAMPLE_TEX2D(Texture_C84B49A3,uv0.xy);
				float _SampleTexture2D_C2E704C2_R = _SampleTexture2D_C2E704C2_RGBA.r;
				float _SampleTexture2D_C2E704C2_G = _SampleTexture2D_C2E704C2_RGBA.g;
				float _SampleTexture2D_C2E704C2_B = _SampleTexture2D_C2E704C2_RGBA.b;
				float _SampleTexture2D_C2E704C2_A = _SampleTexture2D_C2E704C2_RGBA.a;
				if (Float_362F5DF0 == 2) { surface.PreviewOutput = half4(_SampleTexture2D_C2E704C2_RGBA.x, _SampleTexture2D_C2E704C2_RGBA.y, _SampleTexture2D_C2E704C2_RGBA.z, 1.0); return surface; }
				float4 _SampleTexture2D_D4A1438C_RGBA = UNITY_SAMPLE_TEX2D(Texture_43E7D7BE,uv0.xy);
				float _SampleTexture2D_D4A1438C_R = _SampleTexture2D_D4A1438C_RGBA.r;
				float _SampleTexture2D_D4A1438C_G = _SampleTexture2D_D4A1438C_RGBA.g;
				float _SampleTexture2D_D4A1438C_B = _SampleTexture2D_D4A1438C_RGBA.b;
				float _SampleTexture2D_D4A1438C_A = _SampleTexture2D_D4A1438C_RGBA.a;
				if (Float_362F5DF0 == 3) { surface.PreviewOutput = half4(_SampleTexture2D_D4A1438C_RGBA.x, _SampleTexture2D_D4A1438C_RGBA.y, _SampleTexture2D_D4A1438C_RGBA.z, 1.0); return surface; }
				return surface;
			}
	ENDCG
	SubShader
	{
	    Tags { "RenderType"="Opaque" }
	    LOD 100
	    Pass
	    {
	        CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag
	        #include "UnityCG.cginc"
	        struct GraphVertexOutput
	        {
	            float4 position : POSITION;
	            half4 uv0 : TEXCOORD;
	        };
	        GraphVertexOutput vert (GraphVertexInput v)
	        {
	            v = PopulateVertexData(v);
	            GraphVertexOutput o;
	            o.position = UnityObjectToClipPos(v.vertex);
	            o.uv0 = v.texcoord0;
	            return o;
	        }
	        fixed4 frag (GraphVertexOutput IN) : SV_Target
	        {
	            float4 uv0  = IN.uv0;
	            SurfaceInputs surfaceInput = (SurfaceInputs)0;;
	            surfaceInput.uv0 = uv0;
	            SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
	            return surf.PreviewOutput;
	        }
	        ENDCG
	    }
	}
}
