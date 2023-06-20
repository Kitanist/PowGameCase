using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    
    
    
    public Slider healtBar;
    GameObject player;
    PlayerMovement PM;
    public PlayerSO PlayerHealth;
    private float damageAmount;
    [SerializeField] float speed;
    [SerializeField] float Health, maxHealth;
    [SerializeField] float damage, price;
    Rigidbody2D rb;
    [SerializeField] private bool isSlow;

    private void Start()
    {
        PM = GameObject.Find("Player").GetComponent<PlayerMovement>() ;
        if (isSlow)
        {
            speed = 0.2f;
            maxHealth = 100;
            Health = 100;
            damage = 15;
            price = 50;
        }
        else
        {
            speed = 0.5f;
            maxHealth = 29;
            Health = 29;
            damage = 10;
            price = 25;
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        Health = maxHealth;
    }
    private void FixedUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            Attack();
        }
    }
    private void Attack()
    {
        PM.ChangeSliderValue(damage);
        PlayerHealth.healthChangeEvent.Invoke(damage);
        EnemyDying();
    }
   
    public void GetDamage(float extra)
    {
        damageAmount = player.GetComponent<Weapons>().damage * extra;
        if (Health > damageAmount && Health > 0)
        {

            Health -= damageAmount;

            healtBar.DOValue(Health / maxHealth, .5f, false);

            return;
        }
        healtBar.DOValue(0, .5f, false);
        EnemyDying();

    }
    public void EnemyDying()
    {
        GameManager.Instance.Gold += price;
        GameObject DieEffect = ObjectPool.Instance.GetPooledObject(3);
        DieEffect.transform.position = transform.position;
        StartCoroutine(GameManager.Instance.EnemyDyingEnum(DieEffect));
        gameObject.SetActive(false);
    }

    public void PowerUpEnemy()
    {
        damage += 5;
        maxHealth += 10;
        Health += 10;
        price += 10;
    }
    
}
