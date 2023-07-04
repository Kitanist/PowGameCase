using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    #region Variables
    [SerializeField] EnemyData enemyData;
    [SerializeField] private GameEvent increaseGold, increaseGoldSlow,changeSlider;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D enemyCollider;
    [SerializeField] Weapon weapon;
    [SerializeField] Timerstuff timer;
    [SerializeField] PlayerData PData;
    public Slider healtBar;
    private float speed;
    private float Health;
    private float damage;
    private float damageAmount;
    private Vector2 enemyTransform;
    #endregion
    private void Start()
    {
        speed = enemyData.StartSpeed;
        Health = enemyData.maxHealth;
        damage = enemyData.StartDamage;
    }
    private void FixedUpdate()
    {
        if (timer.isGamePaused)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        Vector2 direction = (PData.Playerpos - enemyTransform).normalized;
        rb.velocity = direction * speed;
    }
    public void UpdateTargetPos()
    {
        enemyTransform = gameObject.transform.position; 
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = TryGetComponent(out PlayerMovement player);
        if (isPlayer) 
        {
            Attack();
        }
    }
    private void Attack()
    {
       
        changeSlider.Raise();
        EnemyDying();
    }

    public void GetDamage(float extra)
    {
        damageAmount = weapon.Damage * extra;
        if (Health > damageAmount && Health > 0)
        {

            Health -= damageAmount;
            healtBar.DOValue(Health / enemyData.maxHealth, .5f, false);

            return;
        }
        healtBar.DOValue(0, .5f, false);
        EnemyDying();

    }
    public void EnemyDying()
    {
        enemyData.EnemyGoldGainTypeEvent.Raise();
       

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
        Health += 10;
    }

}
