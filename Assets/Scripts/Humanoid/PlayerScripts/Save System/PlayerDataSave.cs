using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataSave 
{
    public int fireAmount;
    public int currentLevelofFireRate;
    public int currnetLevelofDamage;
    public int currentLevelofFireAmount;
    public int currentLevelofWeaponAmount;
    public bool isDamageUpg;
    public float _Health;
    public float[] playertransform;

    public PlayerDataSave(PlayerData Data)
    {
        fireAmount = Data.FireAmount;
        currentLevelofFireAmount = Data.currentLevelofFireAmount;
        currnetLevelofDamage = Data.currnetLevelofDamage;
        currentLevelofFireRate = Data.currentLevelofFireRate;
        currentLevelofWeaponAmount = Data.currentLevelofWeaponAmount;
        isDamageUpg = Data.isDamageUpg;
        _Health = Data.Health;
        playertransform = new float[2];
        playertransform[0] = Data.Playerpos.x;
        playertransform[1] = Data.Playerpos.y;
        

    }
}
