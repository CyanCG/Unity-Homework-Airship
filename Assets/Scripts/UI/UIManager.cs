using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        WorldEvents.Instance.OnResume += OnWorldResume;
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
