using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class HeroController : MonoBehaviour
{
    public Transform StartPosition;

    public GameObject[] AirshipSpirtes;

    private int currAirship;
    private Rigidbody2D rd;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currAirship = 0;
        WorldEvents.Instance.OnChangeAirship += (id) => currAirship = id;
        WorldEvents.Instance.OnStart += Show;
        WorldEvents.Instance.OnDead += Hide;
        WorldEvents.Instance.OnRestart += Hide;
        Hide();
    }

    private void Show()
    {
        transform.position = StartPosition.position;
        gameObject.SetActive(true);
        for (int i = 0; i < AirshipSpirtes.Length; i++)
        {
            AirshipSpirtes[i].SetActive(i == currAirship);
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {

    }
}
