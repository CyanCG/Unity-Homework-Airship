using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    public Renderer BackgroundRenderer;

    public float Speed = 0.5f;

    private Vector2 offset;
    private const string texName = "_MainTex";
    private bool pause;

    private void Start()
    {
        pause = true;
        offset = BackgroundRenderer.material.GetTextureOffset(texName);

        WorldEvents.Instance.OnPause += Pause;
        WorldEvents.Instance.OnDead += Pause;
        WorldEvents.Instance.OnRestart += Pause;
        WorldEvents.Instance.OnResume += Resume;
        WorldEvents.Instance.OnStart += Resume;
    }

    private void Pause() => pause = true;
    private void Resume() => pause = false;

    private void Update()
    {
        if (pause)
        {
            return;
        }

        offset += Vector2.up * Time.deltaTime * Speed;
        BackgroundRenderer.material.SetTextureOffset(texName, offset);
    }
}
