using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region variables
    
    public Collider2D[] targets, targetsForUlti;
    public LayerMask EnemyMask;
    public Weapons Weapon;
    [SerializeField] Weapon WP;
    public Transform target;
    protected bool reset = true;
    private float shortDis;
    [SerializeField] Timerstuff timer;
    [SerializeField] PlayerData PData;
    private void Awake()
    {
        InvokeRepeating("UpdateTarget", 1, 1);
    }
    #endregion
    private void Update()
    {
        if (timer.isGamePaused)
        {
            return;
        }
        
        if (reset && target)
        {
            reset = false;
            for (int i = 0; i < PData.FireAmount; i++)
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
            if (dis > PData.attackRadius || !target.gameObject.activeInHierarchy)
            {
                target = null;
            }
            else
                return;
        }
        else
        {
            targets = Physics2D.OverlapCircleAll(this.transform.position, PData.attackRadius, EnemyMask);
            shortDis = PData.attackRadius;

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
        UpdateTarget();
    }
}
