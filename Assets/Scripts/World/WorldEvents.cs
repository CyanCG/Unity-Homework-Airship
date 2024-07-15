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

    public UnityAction OnStart;
    public UnityAction OnResume;
    public UnityAction OnPause;
    public UnityAction OnRestart;
    public UnityAction OnDead;

    public void RaiseStart() => OnStart?.Invoke();
    public void RaiseResume() => OnResume?.Invoke();
    public void RaisePause() => OnPause?.Invoke();
    public void RaiseRestart() => OnRestart?.Invoke();
    public void RaiseDead() => OnDead?.Invoke();
}
