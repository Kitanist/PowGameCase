using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRadius = 1;

  

    public int FireAmount = 1;
    public Collider2D[] targets, targetsForUlti;

    public LayerMask EnemyMask;

    public Weapons Weapon;

    [SerializeField] Weapon WP;

    public Transform target;

    protected bool reset = true;

    private float shortDis;

    private void Update()
    {
        UpdateTarget();
        if (reset && target)
        {
            reset = false;
            for (int i = 0; i < FireAmount; i++)
            {
                Weapon.Fire();
            }

            StartCoroutine(ResetAttack());
        }
    }
    public virtual void UpdateTarget()
    {
        if (target)
        {
            float dis = Vector2.Distance(target.transform.position, transform.position);
            if (dis > attackRadius || !target.gameObject.activeInHierarchy)
            {
                target = null;
            }
            else
                return;
        }
        else
        {
            targets = Physics2D.OverlapCircleAll(this.transform.position, attackRadius, EnemyMask);
            shortDis = attackRadius;

            foreach (var obj in targets)
            {
                if (Vector2.Distance(obj.transform.position, transform.position) < shortDis)
                {
                    target = obj.transform;
                    shortDis = Vector2.Distance(obj.transform.position, transform.position);

                }
            }
        }




    }
    public void skillActiveBam()
    {
        targetsForUlti = Physics2D.OverlapCircleAll(this.transform.position, 10f, EnemyMask);
        for (int i = 0; i < targetsForUlti.Length; i++)
        {
            targetsForUlti[i].gameObject.GetComponent<Enemy>().GetDamage(3f);
        }
    }
    IEnumerator ResetAttack()
    {

        yield return new WaitForSeconds(WP.FireRate);

        reset = true;
    }
}
