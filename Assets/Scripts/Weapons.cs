using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform firepoint;
    public float damage;
    public PlayerAttack PA;
    public float fireForce = 20f;
    private int poolIndex = 0;

    public void Fire()
    {
        if (firepoint)
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject(poolIndex);
            bullet.transform.position = GetComponentInParent<Transform>().position;

            LookAt2D(bullet, PA.target.transform.position);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * fireForce;


        }


    }
    static void LookAt2D(GameObject mainObject, Vector3 objectToLookAt)
    {
        Vector3 diff = objectToLookAt - mainObject.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        mainObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
