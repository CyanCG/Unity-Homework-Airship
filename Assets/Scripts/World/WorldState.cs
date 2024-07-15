using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState : MonoBehaviour
{
    // Singleton
    public static WorldState Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        WorldEvents.Instance.OnStart += () => WorldEvents.Instance.RaiseChangeScore(0);
        WorldEvents.Instance.OnChangeScore += (num) => Score = num;
    }

    public int Score { get; private set; }
}
