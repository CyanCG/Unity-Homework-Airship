using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletEmitter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform[] EmitterTrans;

    private ObjectPool<GameObject> pool;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateBullet, OnGetBullet);
    }

    private GameObject CreateBullet()
    {
        var go = Instantiate(BulletPrefab);
        go.SetActive(false);
        var bu = go.GetComponent<Bullet>();
        if (!bu)
        {
            return go;
        }
        bu.OnSelfDamage += () =>
        {
            pool.Release(go);
            go.SetActive(false);
        };
        return go;
    }

    private void OnGetBullet(GameObject go)
    {
        go.SetActive(true);
    }

    public void Emit()
    {
        foreach (var et in EmitterTrans)
        {
            var bulletGo = pool.Get();
            bulletGo.SetActive(true);
            var bu = bulletGo.GetComponent<Bullet>();
            if (bu)
            {
                bu.StartMove(et.position, et.forward);
            }
        }
    }
}
