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

        WorldEvents.Instance.OnStart += () => WorldEvents.Instance.RaiseChangeHealth(100);
        WorldEvents.Instance.OnChangeHealth += (num) =>
        {
            Health = num;
            if (num <= 0)
            {
                num = 0;
                WorldEvents.Instance.RaiseDead();
            }
        };
    }

    public int Score { get; private set; }
    public float Health { get; private set; }
}
