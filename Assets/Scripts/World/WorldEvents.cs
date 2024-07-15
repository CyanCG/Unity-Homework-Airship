using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WorldEvents : MonoBehaviour
{
    // Singleton
    public static WorldEvents Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public bool Pause { get; private set; } = true;

    public UnityAction OnResume;
    public UnityAction OnPause;
    public UnityAction OnRestart;
    public UnityAction OnDead;

    public void RaiseResume()
    {
        Pause = false;
        OnResume?.Invoke();
    }
    public void RaisePause()
    {
        Pause = true;
        OnPause?.Invoke();
    }

    public void TogglePause()
    {
        if (!Pause)
        {
            RaisePause();
        }
        else
        {
            RaiseResume();
        }
    }
    public void RaiseRestart() => OnRestart?.Invoke();
    public void RaiseDead() => OnDead?.Invoke();
}
