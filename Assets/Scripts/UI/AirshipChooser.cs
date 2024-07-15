using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipChooser : MonoBehaviour
{
    public GameObject[] AirshipSpirtes;

    private int index;

    private void Start()
    {
        index = 0;
        Choose(index);
    }

    public void Next()
    {
        index = (index + 1) % AirshipSpirtes.Length;
        Choose(index);
    }

    public void Previous()
    {
        index = (index - 1 + AirshipSpirtes.Length) % AirshipSpirtes.Length;
        Choose(index);
    }

    private void Choose(int index)
    {
        for (int i = 0; i < AirshipSpirtes.Length; i++)
        {
            AirshipSpirtes[i].SetActive(i == index);
        }
        WorldEvents.Instance.RaiseChangeAirship(index);
    }
}
