using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/weapon", fileName = "weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private float damage,fireRate;
    public float Damage
    {
        get { return damage; }
        set
        {
            damage = value;
        }
    }
    public float FireRate
    {
        get { return fireRate; }
        set
        {
            fireRate = value;
        }
    }
    private void OnEnable()
    {
        damage = 10;
        fireRate = 2;
    }
}
