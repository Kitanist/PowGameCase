using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Adios : MonoBehaviour
{
    public GameObject Win, Lose, LevelUpUI;
    [SerializeField] Gold gold;
    [SerializeField] Timerstuff timer;
    [SerializeField] Weapon WP;
    [SerializeField] PlayerData PData;
    [SerializeField] GameEvent LevelUp,LoadGameEvent,SavegameEvent;
    public Button skillDamage, skillFireRate, skillFireAmo, skillWeaponAmo, skillActiveBum, skillActiveRatata;
    public TextMeshProUGUI money, health, damage, fireRate, damageLevel, fireRateLevel, shotsLevel, weaponsLevel,Timer;
    PlayerAttack PA;
    Weapons weapon;
    public VariableJoystick joystick;
    void Start()
    {
        
       
        PA = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        if (timer.isGamePaused)
        {
            return;
        }
        health.text = "HP :" + PData.Health.ToString();
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
    public void SaveGame()
    {
        SavegameEvent.Raise();
    }
    public void LoadGame()
    {
        LoadGameEvent.Raise();
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
        LevelUp.Raise();
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
