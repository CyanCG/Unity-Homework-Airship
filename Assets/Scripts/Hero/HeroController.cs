using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public Transform StartPosition;

    public GameObject[] AirshipFrefabs;

    private void Start()
    {
        // WorldEvents.Instance.OnRestart += Restart();
    }

    private void Restart()
    {
        transform.position = StartPosition.position;
    }
}
