using UnityEngine;
using System.Collections;
public class Bullet : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       bool isEnemy = TryGetComponent(out Enemy enemy);
        if (isEnemy)
        {
           enemy.GetDamage(1);
            gameObject.SetActive(false);
        }
    }
   
    private void OnEnable()
    {
        StartCoroutine(Destroyer());
     
    }
    public IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
