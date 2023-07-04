using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData/BaseData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float attackRadius = 1;
    [SerializeField] private int fireAmount = 1;
    [SerializeField] private float health;
    [SerializeField] private Vector2 playerpos;

    public float movementSpeed;
    public int currentLevelofFireRate = 0  ;
    public int currnetLevelofDamage = 0;
    public int currentLevelofFireAmount = 0;
    public int currentLevelofWeaponAmount = 0;
    public float MaxHealth;
    public bool isDamageUpg;
    
    public GameEvent UpdateVariables,UpdateTransform;

    public Vector2 Playerpos 
    {
        get { return playerpos; }
        set
        {
            playerpos = value;
            UpdateTransform.Raise();
        }
    }
    public float Health
    {
        get { return health; }
        set
        {
            UpdateVariables.Raise();
            health = value;
        }
    }

    public float AttackRadius { get => attackRadius;
        set
        {
            attackRadius = value;
            UpdateVariables.Raise();
        }
    }
    public int FireAmount { get => fireAmount;
        set
        {
            fireAmount = value;
            UpdateVariables.Raise();
        }
    }

    private void OnEnable()
    {
        Health = MaxHealth;
    }
    public void SaveGame()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadGame()
    {
        PlayerDataSave data = SaveSystem.LoadPlayer();

        FireAmount = data.fireAmount;
        currentLevelofFireRate = data.currentLevelofFireRate;
        currnetLevelofDamage = data.currnetLevelofDamage;
        currentLevelofFireAmount = data.currentLevelofFireAmount;
        currentLevelofWeaponAmount = data.currentLevelofWeaponAmount;
        health = data._Health;
        playerpos.x = data.playertransform[0];
        playerpos.y = data.playertransform[1];
        UpdateVariables.Raise();
    }
    public void DecreaseHealth(float Damage)
    {
        if (Health < Damage)
        {
            return;
        }
        Health -= Damage;

    }
}