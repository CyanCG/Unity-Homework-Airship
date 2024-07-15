using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        if (!WorldEvents.Instance)
        {
            Debug.Log("No");
        }
        // WorldEvents.Instance.OnResume += OnWorldResume;
        // WorldEvents.Instance.OnPause += OnWorldPause;
        // WorldEvents.Instance.OnRestart += OnWorldRestart;
        // WorldEvents.Instance.OnDead += OnHeroDead;
    }

    private void OnDisable()
    {
        // WorldEvents.Instance.OnResume -= OnWorldResume;
        // WorldEvents.Instance.OnPause -= OnWorldPause;
        // WorldEvents.Instance.OnRestart -= OnWorldRestart;
        // WorldEvents.Instance.OnDead -= OnHeroDead;
    }

    private void OnWorldResume()
    {

    }
    private void OnWorldPause()
    {

    }
    private void OnWorldRestart()
    {

    }
    private void OnHeroDead()
    {

    }
}
