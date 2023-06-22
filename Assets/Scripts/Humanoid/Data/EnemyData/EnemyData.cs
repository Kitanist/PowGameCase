using UnityEngine;
[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/EnemyData/BaseData")]
public class EnemyData : ScriptableObject
{
    public float StartSpeed;
    public float  maxHealth;
    public float StartDamage;
    public GameEvent EnemyGoldGainTypeEvent;
    
}
