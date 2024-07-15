using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject StartPannel;
    public GameObject HUDPannel;
    public GameObject DeadPannel;

    private void Start()
    {
        OnWorldRestart();

        WorldEvents.Instance.OnStart += OnGameStart;
        WorldEvents.Instance.OnRestart += OnWorldRestart;
        WorldEvents.Instance.OnDead += OnHeroDead;
    }

    private void OnGameStart()
    {
        StartPannel.SetActive(false);
        HUDPannel.SetActive(true);
        DeadPannel.SetActive(false);
    }

    private void OnWorldRestart()
    {
        StartPannel.SetActive(true);
        HUDPannel.SetActive(false);
        DeadPannel.SetActive(false);
    }
    private void OnHeroDead()
    {
        StartPannel.SetActive(false);
        HUDPannel.SetActive(false);
        DeadPannel.SetActive(true);
    }
}
