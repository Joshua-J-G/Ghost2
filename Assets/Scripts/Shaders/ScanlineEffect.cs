using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


internal class ScanlineEffect : ScriptableRendererFeature
{
    public Shader m_Shader;
    public float m_Intensity;

    Material m_Material;

    [SerializeField]
    private Texture2D scanlineTex = null;

    [SerializeField]
    private float strength = 0.1f;

    [SerializeField]
    private int size = 8;

    ColorBlitPass m_RenderPass = null;

    public override void AddRenderPasses(ScriptableRenderer renderer,
                                    ref RenderingData renderingData)
    {
            renderer.EnqueuePass(m_RenderPass);
    }

    public override void SetupRenderPasses(ScriptableRenderer renderer,
                                        in RenderingData renderingData)
    {
   
            // Calling ConfigureInput with the ScriptableRenderPassInput.Color argument
            // ensures that the opaque texture is available to the Render Pass.
            m_RenderPass.ConfigureInput(ScriptableRenderPassInput.Color);
            m_RenderPass.SetTarget(renderer.cameraColorTargetHandle, m_Intensity);
        
    }

    public override void Create()
    {
        if (scanlineTex == null)
        {
            scanlineTex = Texture2D.whiteTexture;
        }

        m_Material = CoreUtils.CreateEngineMaterial(m_Shader);
        m_Material.SetTexture("_ScanlineTex", scanlineTex);
        m_Material.SetFloat("_Strength", strength);
        m_Material.SetInt("_Size", size);
        m_RenderPass = new ColorBlitPass(m_Material);
    }

    protected override void Dispose(bool disposing)
    {
        CoreUtils.Destroy(m_Material);
    }
}
