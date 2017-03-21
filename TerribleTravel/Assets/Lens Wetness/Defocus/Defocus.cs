using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Defocus")]

public class Defocus : MonoBehaviour
{
    private Shader Shader_Defocus;
	[SerializeField]
    private Material Material_Defocus;
    private int ScreenX = 1280, ScreenY = 720; 
    
    [SerializeField]
    [Range (1,6)]
    int Iterations = 4, Downsampling = 4;
    enum Pass
    {
        Gaussian = 0,
        Compose = 1,
        GetZ = 2,
        
    };
    [SerializeField]
    [Range(0,5)]
    float _EdgeSpread = 1.0f;
    [SerializeField]
    [Range(0,2)]
    float _Blur = 1.0f;

    void OnEnable()
    {
        //Create Material
        Shader_Defocus = Shader.Find("Hidden/Defocus");
        if (Shader_Defocus == null)
            Debug.Log("#ERROR# Hidden/Defocus Shader not found");
        //Material_Defocus = new Material(Shader_Defocus);
        //Material_Defocus.hideFlags = HideFlags.HideAndDontSave;
    }

    void Update()
    {

    }

    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Set();
    }
    #endif

    void Start()
    {
        Set();
    }

    void Set()
    {
       if (GetComponent<Camera>().depthTextureMode == DepthTextureMode.None)
           GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Material_Defocus.SetTexture("_MainTex", source);
        ScreenX = source.width;
        ScreenY = source.height;
        int RTT_Width = ScreenX;
        int RTT_Height = ScreenY;

        //Send Parameters
        Material_Defocus.SetFloat("_EdgeSpread", _EdgeSpread);
        Material_Defocus.SetFloat("_Blur", _Blur);        

        Material_Defocus.SetVector("_Offset", new Vector4(1f / ScreenX, 1f / ScreenY, 0, 0));

        //Color Blur
       
            RTT_Width /= Downsampling;
            RTT_Height /= Downsampling;

            RenderTexture RTT_Blur_1 = RenderTexture.GetTemporary(RTT_Width, RTT_Height, 0, source.format);
            Graphics.Blit(source, RTT_Blur_1, Material_Defocus, (int)Pass.Gaussian);

            for (int iteration = 1; iteration <= Iterations; iteration++)
            {
                float OffsetX = (_Blur + iteration / Iterations) / ScreenX;
                float OffsetY = (_Blur + iteration / Iterations) / ScreenY;

                RenderTexture RTT_Blur_2 = RenderTexture.GetTemporary(RTT_Width, RTT_Height, 0, source.format);

                Material_Defocus.SetVector("_Offset", new Vector4(0, OffsetY * _Blur, 0, 0));
                Graphics.Blit(RTT_Blur_1, RTT_Blur_2, Material_Defocus, (int)Pass.Gaussian);
                RenderTexture.ReleaseTemporary(RTT_Blur_1);
                RTT_Blur_1 = RTT_Blur_2;

                RTT_Blur_2 = RenderTexture.GetTemporary(RTT_Width, RTT_Height, 0, source.format);
                Material_Defocus.SetVector("_Offset", new Vector4(OffsetX * _Blur, 0, 0, 0));
                Graphics.Blit(RTT_Blur_1, RTT_Blur_2, Material_Defocus, (int)Pass.Gaussian);
                RenderTexture.ReleaseTemporary(RTT_Blur_1);
                RTT_Blur_1 = RTT_Blur_2;
            }
            RenderTexture.ReleaseTemporary(RTT_Blur_1);
            Material_Defocus.SetTexture("_BlurTex", RTT_Blur_1);

            //Z blur
            RenderTexture RTT_ZBlur_1 = RenderTexture.GetTemporary(RTT_Width, RTT_Height, 0, RenderTextureFormat.RFloat);
            Graphics.Blit(null, RTT_ZBlur_1, Material_Defocus, (int)Pass.GetZ);

            for (int iteration = 1; iteration <= Iterations; iteration++)
            {
                float OffsetX = (_EdgeSpread + iteration / Iterations) / ScreenX;
                float OffsetY = (_EdgeSpread + iteration / Iterations) / ScreenY;

                RenderTexture RTT_ZBlur_2 = RenderTexture.GetTemporary(RTT_Width, RTT_Height, 0, RenderTextureFormat.RFloat);

                Material_Defocus.SetVector("_Offset", new Vector4(0, OffsetY, 0, 0));
                
                Graphics.Blit(RTT_ZBlur_1, RTT_ZBlur_2, Material_Defocus, (int)Pass.Gaussian);                
                RenderTexture.ReleaseTemporary(RTT_ZBlur_1);
                RTT_ZBlur_1 = RTT_ZBlur_2;

                RTT_ZBlur_2 = RenderTexture.GetTemporary(RTT_Width, RTT_Height, 0, RenderTextureFormat.RFloat);
                Material_Defocus.SetVector("_Offset", new Vector4(OffsetX, 0, 0, 0));
                
                Graphics.Blit(RTT_ZBlur_1, RTT_ZBlur_2, Material_Defocus, (int)Pass.Gaussian);                
                RenderTexture.ReleaseTemporary(RTT_ZBlur_1);
                RTT_ZBlur_1 = RTT_ZBlur_2;

            }
            RenderTexture.ReleaseTemporary(RTT_ZBlur_1);
            Material_Defocus.SetTexture("_zBlurred", RTT_ZBlur_1);
                
        Graphics.Blit(source, destination, Material_Defocus, (int)Pass.Compose);
        

    }

   
}
