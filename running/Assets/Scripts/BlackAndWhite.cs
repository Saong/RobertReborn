using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackAndWhite : MonoBehaviour
{
    Material material;
    public Shader shader;
    [Range(0, 1.0f)]
    public float GrayFactor;
    // Use this for initialization
    void Start()
    {
        material = new Material(shader);
    }

    // Update is called once per frame
    void Update()
    {
        if (GrayFactor < 1)
            GrayFactor += Time.deltaTime * 0.5f;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (material != null)
        {
            //设置shader中的_GrayFactor参数
            material.SetFloat("_GrayFactor", GrayFactor);
            Graphics.Blit(src, dest, material);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}