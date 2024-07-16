using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[Serializable]
public struct EnemyConfig
{
    public GameObject EnemyPrefab;
    public float RefreshCooldown;

    [HideInInspector]
    public float RefreshTimeout;

    [HideInInspector]
    public ObjectPool<GameObject> pool;
}

public class EnemyGenerator : MonoBehaviour
{
    public EnemyConfig[] enemyConfigs;
    public Transform StartPos;
    public Transform EndPos;

    private void Start()
    {
        gameObject.SetActive(false);
        WorldEvents.Instance.OnStart += Open;
        WorldEvents.Instance.OnDead += Close;
        WorldEvents.Instance.OnRestart += Close;
    }

    private void Open()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < enemyConfigs.Length; i++)
        {
            enemyConfigs[i].RefreshTimeout = 0.2f * i;
            int id = i;
            enemyConfigs[i].pool = new(() => CreateEnemy(id), OnGetEnemy);
        }
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        for (int i = 0; i < enemyConfigs.Length; i++)
        {
            if (enemyConfigs[i].RefreshTimeout > 0)
            {
                enemyConfigs[i].RefreshTimeout -= Time.deltaTime;
            }
            else
            {
                enemyConfigs[i].RefreshTimeout = enemyConfigs[i].RefreshCooldown;
                enemyConfigs[i].pool.Get();
            }
        }
    }

    private GameObject CreateEnemy(int id)
    {
        var go = Instantiate(enemyConfigs[id].EnemyPrefab);
        go.SetActive(false);
        var e = go.GetComponent<Enemy>();
        if (!e)
        {
            return go;
        }
        e.OnGotAttack += () =>
        {
            go.SetActive(false);
            enemyConfigs[id].pool.Release(go);
        };
        return go;
    }

    private void OnGetEnemy(GameObject go)
    {
        go.SetActive(true);
        float rad = UnityEngine.Random.Range(0f, 1f);
        Vector3 pos = EndPos.position + (StartPos.position - EndPos.position) * rad;
        go.transform.position = pos;
    }
}
