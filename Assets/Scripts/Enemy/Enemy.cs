using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(BulletEmitter))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IVictim
{
    public float FireCooldown;
    public float Damage;
    public float Speed;
    public int Score;

    public UnityAction OnGotAttack;

    private float fireTimeout;
    private BulletEmitter emitter;

    private void Start()
    {
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    private void Awake()
    {
        fireTimeout = 0;
        emitter = GetComponent<BulletEmitter>();
    }

    private void Update()
    {
        transform.position += Speed * Time.deltaTime * Vector3.down;

        if (fireTimeout > 0)
        {
            fireTimeout -= Time.deltaTime;
            return;
        }
        fireTimeout = FireCooldown;
        emitter.Emit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var victim = other.gameObject.GetComponent<IVictim>();
        if (victim == null)
        {
            return;
        }
        victim.OnGotAttack(Damage);
        OnGotAttack?.Invoke();
    }

    void IVictim.OnGotAttack(float damage)
    {
        WorldEvents.Instance.RaiseChangeScore(WorldState.Instance.Score + Score);
        OnGotAttack?.Invoke();
    }
}
