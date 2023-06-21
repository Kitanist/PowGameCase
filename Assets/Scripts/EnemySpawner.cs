using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Timerstuff timer;
    [SerializeField] GameEvent SpawnEnemyEvent;
    public GameObject Player;
    [SerializeField] private float SpawnTime,second;
    private float SpawnDis = 2f;
    private bool isPlayerNear;
    [Range(0, 100)]
    [SerializeField] private int ChangeToSpawn, EnemyChange;

    private void Update()
    {
        if (timer.isGamePaused)
        {
            return;
        }
        float dis = Vector2.Distance(Player.transform.position, transform.position);
        if (dis > SpawnDis || !Player.activeInHierarchy)
        {
            // oyuncu uzakta 

            isPlayerNear = false;
        }
        else
        {
            isPlayerNear = true;
            return;
        }
    }
    public void ping()
    {
        second--;
        if (second <= 0)
        {
            second = SpawnTime;
            SpawnEnemyEvent.Raise();
        }
    }
    public void SpawnEnemy()
    {
        if (isPlayerNear)
        {
            return;
        }


        if (ChangeToSpawn > Random.Range(0, 100))
        {
            if (EnemyChange > Random.Range(0, 100))
            {
                GameObject EnemySlow = ObjectPool.Instance.GetPooledObject(2);
                EnemySlow.transform.position = transform.position;
            }
            else
            {
                GameObject Enemy = ObjectPool.Instance.GetPooledObject(1);
                Enemy.transform.position = transform.position;
            }
        }


    }
    public void PowerUpSpawner()
    {
        SpawnTime -= 1;
        ChangeToSpawn += 5;

    }
}
