using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData/BaseData")]
public class PlayerData : ScriptableObject
{
    public float attackRadius = 1;
    public int FireAmount = 1;
    public float movementSpeed;
    public int currentLevelofFireRate = 0  ;
    public int currnetLevelofDamage = 0;
    public int currentLevelofFireAmount = 0;
    public int currentLevelofWeaponAmount = 0;
    public float MaxHealth;
    public bool isDamageUpg;
    [SerializeField] private float _Health;
    [SerializeField] private Vector2 playertransform;
    
    public Vector2 Playertransform
    {
        get { return playertransform; }
        set
        {
            playertransform = value;
        }
    }
    public float Health
    {
        get { return _Health; }
        set
        {
            _Health = value;
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
        _Health = data._Health;
        playertransform.x = data.playertransform[0];
        playertransform.y = data.playertransform[1];

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