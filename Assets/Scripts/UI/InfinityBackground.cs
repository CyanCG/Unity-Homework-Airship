using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    public Renderer BackgroundRenderer;

    public float Speed = 0.5f;

    private Vector2 offset;
    private const string texName = "_MainTex";


    private void Start()
    {
        offset = BackgroundRenderer.material.GetTextureOffset(texName);
    }

    private void Update()
    {
        if (WorldEvents.Instance.Pause)
        {
            return;
        }

        offset += Vector2.up * Time.deltaTime * Speed;
        BackgroundRenderer.material.SetTextureOffset(texName, offset);
    }
}
