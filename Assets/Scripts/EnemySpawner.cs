using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Player;
    [SerializeField] private float SpawnTime;
    private float SpawnDis = 2f;
    private bool isPlayerNear;
    [Range(0, 100)]
    [SerializeField] private int ChangeToSpawn, EnemyChange;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, SpawnTime);
    }
    private void Update()
    {

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
    void SpawnEnemy()
    {
        if (isPlayerNear)
        {
            return;
        }
        else
        {

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
    }
    public void PowerUpSpawner()
    {
        SpawnTime -= 0.5f;
        ChangeToSpawn += 5;

    }
}
