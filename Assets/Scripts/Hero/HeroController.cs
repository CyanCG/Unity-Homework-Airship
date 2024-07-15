using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HeroInput))]
public class HeroController : MonoBehaviour
{
    public Transform StartPosition;

    public GameObject[] AirshipSpirtes;
    public float Speed = 5.0f;
    public float FireCooldown = 0.2f;

    private int currAirship;
    private Rigidbody2D rb;
    private HeroInput input;
    private float fireTimeout;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<HeroInput>();
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
        fireTimeout = 0;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        rb.velocity = input.Move * Speed;
    }

    private void Fire()
    {
        if (fireTimeout > 0)
        {
            fireTimeout -= Time.deltaTime;
        }
        if (!input.Fire || fireTimeout > 0)
        {
            return;
        }
        fireTimeout = FireCooldown;
        Debug.Log("Fire");
    }
}
