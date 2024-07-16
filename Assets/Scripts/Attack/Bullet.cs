using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float Damage;
    public float Speed;

    private Vector3 dir;

    public UnityAction OnSelfDamage;


    private void Start()
    {
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var victim = other.gameObject.GetComponent<IVictim>();
        if (victim == null)
        {
            return;
        }
        // Debug.Log("99");
        victim.OnGotAttack(Damage);
        OnSelfDamage?.Invoke();
    }

    public void StartMove(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;
        this.dir = dir;
    }

    private void Update()
    {
        transform.position += Speed * Time.deltaTime * dir;
    }
}
