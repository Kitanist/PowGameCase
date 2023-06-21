using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Adios : MonoBehaviour
{
    public GameObject Win, Lose, LevelUpUI;
    [SerializeField] Gold gold;
    [SerializeField] Timerstuff timer;
    [SerializeField] Weapon WP;
    public Button skillDamage, skillFireRate, skillFireAmo, skillWeaponAmo, skillActiveBum, skillActiveRatata;
    public TextMeshProUGUI money, health, damage, fireRate, damageLevel, fireRateLevel, shotsLevel, weaponsLevel,Timer;
    [SerializeField] PlayerSO PlayerHP;
    PlayerMovement PM;
    PlayerAttack PA;
    Weapons weapon;
    public VariableJoystick joystick;
    void Start()
    {

        PM = GameObject.Find("Player").GetComponent<PlayerMovement>();
        PA = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        if (timer.isGamePaused)
        {
            return;
        }
        health.text = "HP :" + PlayerHP.Health.ToString();
        money.text = "Gold : " + gold.Golds.ToString();
        Timer.text = "Remaining Time : " + timer.Time.ToString();
        fireRate.text = "Fire Rate : " + WP.FireRate.ToString();
        damage.text = "Damage : " + WP.Damage.ToString();
    }
    public void Winned()
    {
        Win.SetActive(true);
    }
    public void Losed()
    {
        Lose.SetActive(true);
    }
    public void LevelUpUIOpen()
    {
        LevelUpUI.SetActive(true);
    }
    public void DamageUpg()
    {
        if (PM.currnetLevelofDamage >= 41)
        {
            damageLevel.text = "LvL : " + "Max";
            LevelUpUI.SetActive(false);
            skillDamage.interactable = false;
            return;

        }
        PM.currnetLevelofDamage++;
        PM.isDamageUpg = false;
        PM.LevelUp();
        damageLevel.text = "LvL : " + PM.currnetLevelofDamage.ToString();
        LevelUpUI.SetActive(false);
        gold.Golds -= 100;

    }
    public void FireRateUpg()
    {
        if (PM.currentLevelofFireRate >= 11)
        {
            fireRateLevel.text = "LvL : " + "Max";
            LevelUpUI.SetActive(false);
            skillFireRate.interactable = false;
            return;
        }
        PM.currentLevelofFireRate++;
        PM.LevelUp();
        fireRateLevel.text = "LvL : " + PM.currentLevelofFireRate.ToString();
        LevelUpUI.SetActive(false);
        gold.Golds -= 100;
    }
    public void FireAmoUpg()
    {
        if (PM.currentLevelofFireAmount >= 2)
        {
            shotsLevel.text = "LvL : " + "Max";
            LevelUpUI.SetActive(false);
            skillFireAmo.interactable = false;
            return;
        }
        PM.currentLevelofFireAmount++;
        PM.LevelUp();
        shotsLevel.text = "LvL : " + PM.currentLevelofFireAmount.ToString();
        LevelUpUI.SetActive(false);
        gold.Golds -= 100;
    }
    public void WeaponAmoUpg()
    {
        if (PM.currentLevelofWeaponAmount > 0)
        {
            weaponsLevel.text = "LvL : " + "Max";
            LevelUpUI.SetActive(false);
            skillWeaponAmo.interactable = false;
            return;
        }
        PM.currentLevelofWeaponAmount++;
        PM.LevelUp();
        weaponsLevel.text = "LvL : " + PM.currentLevelofWeaponAmount.ToString();
        LevelUpUI.SetActive(false);
        gold.Golds -= 100;
    }
    public void SetActiveSkills()
    {
        skillActiveBum.interactable = true;
        skillActiveRatata.interactable = true;
    }
    public void SetDeActiveSkills()
    {
        skillActiveBum.interactable = false;
        skillActiveRatata.interactable = false;
    }
    
    public void Ratata()
    {
        Debug.Log("AAA");
        WP.FireRate = 0.1f;
        SetDeActiveSkills();
        Invoke("DeRatata", 5f);
        timer.isSkillCooldown = true;
        gold.Golds -= 200;
    }
    public void DeRatata()
    {
        PM.LevelUp();
        timer.isSkillCooldown = false;
    }
    public void Bum()
    {
        PA.skillActiveBam();
        Invoke("DeBum", 5f);
        SetDeActiveSkills();
        timer.isSkillCooldown = true;
        gold.Golds -= 200;
    }
    public void DeBum()
    {
        timer.isSkillCooldown = false;
    }
    public void Bye()
    {
        Application.Quit();
    }
}
