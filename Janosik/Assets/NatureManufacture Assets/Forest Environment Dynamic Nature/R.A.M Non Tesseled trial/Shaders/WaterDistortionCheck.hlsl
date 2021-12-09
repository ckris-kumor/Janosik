float4 _CameraDepthTexture_TexelSize;


#if UNITY_REVERSED_Z
#if (defined(SHADER_API_GLCORE) && !defined(SHADER_API_SWITCH)) || defined(SHADER_API_GLES) || defined(SHADER_API_GLES3)
#define UNITY_Z_0_FAR_FROM_CLIPSPACE(coord) max(-(coord), 0)
#else
#define UNITY_Z_0_FAR_FROM_CLIPSPACE(coord) max(((1.0-(coord)/_ProjectionParams.y)*_ProjectionParams.z),0)
#endif
#elif UNITY_UV_STARTS_AT_TOP
#if !defined(UNITY_Z_0_FAR_FROM_CLIPSPACE)
#define UNITY_Z_0_FAR_FROM_CLIPSPACE(coord) (coord)
#endif
#else
#if !defined(UNITY_Z_0_FAR_FROM_CLIPSPACE)
#define UNITY_Z_0_FAR_FROM_CLIPSPACE(coord) (coord)
#endif
#endif



float2 AlignWithGrabTexel(float2 uvFixed)
{
#if UNITY_UV_STARTS_AT_TOP
		if (_CameraDepthTexture_TexelSize.y < 0) {
			uvFixed.y = 1 - uvFixed.y;
		}
#endif

    return
		(floor(uvFixed * _CameraDepthTexture_TexelSize.zw) + 0.5) *
		abs(_CameraDepthTexture_TexelSize.xy);
}

float Unity_Remap_float4(float In, float2 InMinMax, float2 OutMinMax)
{
    return OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
}

void ColorBelowWater(float4 screenPos, float2 uvOffset, out float2 uvFixed, out float depthDifference)
{
    float screenW = screenPos.w;
    
    uvOffset.y *= _CameraDepthTexture_TexelSize.z * abs(_CameraDepthTexture_TexelSize.y);
    uvFixed = AlignWithGrabTexel((screenPos.xy + uvOffset) / screenW);
	
    //float backgroundDepth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, uv));
    float backgroundDepth = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH(uvFixed), _ZBufferParams);
    
    float surfaceDepth = UNITY_Z_0_FAR_FROM_CLIPSPACE(screenPos.z);
    
    
    depthDifference = backgroundDepth - surfaceDepth;
   
    if (depthDifference < 0)
    {
        //uvOffset *= saturate(depthDifference);
        //uvFixed = AlignWithGrabTexel((screenPos.xy + uvOffset) / screenPos.w);
        uvFixed = AlignWithGrabTexel((screenPos.xy) / screenW);
    
    }
    
    backgroundDepth = LinearEyeDepth(SHADERGRAPH_SAMPLE_SCENE_DEPTH(uvFixed), _ZBufferParams);
   
    depthDifference = backgroundDepth - surfaceDepth;
	

}

void ColorBelowWater_float(float4 screenPos, float2 uvOffset, out float2 uvFixed, out float depthDifference)
{
    ColorBelowWater(screenPos, uvOffset, uvFixed, depthDifference);
}

