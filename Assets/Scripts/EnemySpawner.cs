using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    
    [SerializeField] private float SpawnTime,second;
    private bool isPlayerNear;
    [Range(0, 100)]
    [SerializeField] private int ChangeToSpawn, EnemyChange;

    private void Start()
    {
        second = SpawnTime;
    }
    public void StopSpawn()
    {
        isPlayerNear = true;
    }
    public void StartSpawn()
    {
        isPlayerNear = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out _))
        {
            isPlayerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out _))
        {
            isPlayerNear = false;
        }
    }
    public void ping()
    {
        second--;
        
        if (second <= 0)
        {
            second = SpawnTime;
            
            SpawnEnemy();
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
