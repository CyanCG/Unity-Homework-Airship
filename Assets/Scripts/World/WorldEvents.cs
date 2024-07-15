using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Singleton
public class WorldEvents : MonoBehaviour
{
    public static WorldEvents Instance { get; private set; }

    private void Awake()
    {
        Debug.Log("!!");

        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        Debug.Log("??");
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
