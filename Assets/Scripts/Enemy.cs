using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
public class Enemy : MonoBehaviour
{


    [SerializeField] private GameEvent increaseGold, increaseGoldSlow;
    public Slider healtBar;
    GameObject player;
    PlayerMovement PM;
    public PlayerSO PlayerHealth;
    private float damageAmount;
    private Vector2 enemyTransform;
    [SerializeField] Animator anim;
    [SerializeField] float speed;
    [SerializeField] float Health, maxHealth;
    [SerializeField] float damage, price;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private bool isSlow;
    [SerializeField] BoxCollider2D enemyCollider;
    [SerializeField] Weapon weapon;
    [SerializeField] PlayerTransform PlayerTF;
    [SerializeField] Timerstuff timer;
    private void Start()
    {
        PM = GameObject.Find("Player").GetComponent<PlayerMovement>();
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
       
        Health = maxHealth;
    }
    private void FixedUpdate()
    {
        if (timer.isGamePaused)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        enemyTransform = gameObject.transform.position;
        Vector2 direction = (PlayerTF.Playertransform - enemyTransform).normalized;
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out _))
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
        damageAmount = weapon.Damage * extra;
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
        if (isSlow)
            increaseGold.Raise();
        else
            increaseGoldSlow.Raise();
        // þu efekti de event sisteme ata 

        StartCoroutine(EnemyDyingEnum());
       
    }
    public IEnumerator EnemyDyingEnum()
    {
        enemyCollider.enabled = false;
        anim.SetBool("isAlive", false);
        GameObject DieEffect = ObjectPool.Instance.GetPooledObject(3);
        DieEffect.transform.position = transform.position;
        yield return new WaitForSeconds(0.5f);
        DieEffect.SetActive(false);
        enemyCollider.enabled = true;
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
