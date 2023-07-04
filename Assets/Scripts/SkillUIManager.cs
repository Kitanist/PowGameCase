using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SkillUIManager : MonoBehaviour
{
    public TextMeshProUGUI damageLevel, fireRateLevel, shotsLevel, weaponsLevel;
    [SerializeField] Gold gold;
    [SerializeField] PlayerData PData;
    [SerializeField] GameEvent LevelUp;
    public GameObject LevelUpUI;
    public Button skillDamage, skillFireRate, skillFireAmo, skillWeaponAmo;

    public void LevelUpUIOpen()
    {
        LevelUpUI.SetActive(true);
    }
    public void DamageUpg()
    {
        if (PData.currnetLevelofDamage >= 41)
        {
            damageLevel.text = "LvL : " + "Max";
            LevelUpUI.SetActive(false);
            skillDamage.interactable = false;
            return;

        }
        PData.currnetLevelofDamage++;
        PData.isDamageUpg = false;
        LevelUp.Raise();
        damageLevel.text = "LvL : " + PData.currnetLevelofDamage.ToString();
        LevelUpUI.SetActive(false);
        gold.Golds -= 100;

    }
    public void FireRateUpg()
    {
        if (PData.currentLevelofFireRate >= 11)
        {
            fireRateLevel.text = "LvL : " + "Max";
            LevelUpUI.SetActive(false);
            skillFireRate.interactable = false;
            return;
        }
        PData.currentLevelofFireRate++;
        LevelUp.Raise();
        fireRateLevel.text = "LvL : " + PData.currentLevelofFireRate.ToString();
        LevelUpUI.SetActive(false);
        gold.Golds -= 100;
    }
    public void FireAmoUpg()
    {
        if (PData.currentLevelofFireAmount >= 2)
        {
            shotsLevel.text = "LvL : " + "Max";
            LevelUpUI.SetActive(false);
            skillFireAmo.interactable = false;
            return;
        }
        PData.currentLevelofFireAmount++;
        LevelUp.Raise();
        shotsLevel.text = "LvL : " + PData.currentLevelofFireAmount.ToString();
        LevelUpUI.SetActive(false);
        gold.Golds -= 100;
    }
    public void WeaponAmoUpg()
    {
        if (PData.currentLevelofWeaponAmount > 0)
        {
            weaponsLevel.text = "LvL : " + "Max";
            LevelUpUI.SetActive(false);
            skillWeaponAmo.interactable = false;
            return;
        }
        PData.currentLevelofWeaponAmount++;
        LevelUp.Raise();
        weaponsLevel.text = "LvL : " + PData.currentLevelofWeaponAmount.ToString();
        LevelUpUI.SetActive(false);
        gold.Golds -= 100;
    }
  
}
