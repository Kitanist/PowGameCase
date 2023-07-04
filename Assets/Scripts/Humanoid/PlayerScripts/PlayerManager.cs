using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] Weapon Weapon; 
    public GameObject Weapon1, Weapon2;
    [SerializeField] private Slider HealthBar;
    [SerializeField] PlayerData PData;
    
    private void Start()
    {
        ChangeSliderValue(PData.Health); // bunu eventli havalý biþi yap
        LevelUp();
    }
    public void ChangeSliderValue(float value) // ayrý class event deðiþtir
    {
        HealthBar.DOValue(PData.Health / PData.MaxHealth, 0.5f, false);
    }
    public void SaveGame()
    {
        PData.SaveGame();
    }
    public void LoadGame()
    {
        PData.LoadGame();
        
    }
    public void LevelUp()
    {
        switch (PData.currentLevelofFireRate)
        {
            case 0:
                Weapon.FireRate = 2;
                break;
            case 1:
                Weapon.FireRate = 1.9f;
                break;
            case 2:
                Weapon.FireRate = 1.8f;
                break;
            case 3:
                Weapon.FireRate = 1.7f;
                break;
            case 4:
                Weapon.FireRate = 1.6f;
                break;
            case 5:
                Weapon.FireRate = 1.5f;
                break;
            case 6:
                Weapon.FireRate = 1.4f;
                break;
            case 7:
                Weapon.FireRate = 1.3f;
                break;
            case 8:
                Weapon.FireRate = 1.2f;
                break;
            case 9:
                Weapon.FireRate = 1.1f;
                break;
            case 10:
                Weapon.FireRate = 1;
                break;
            case 11:
                Weapon.FireRate = 0.9f;
                break;
            default:
                break;
        }
        switch (PData.currnetLevelofDamage)
        {
            case 0:
                Weapon.Damage = 10;
                PData.isDamageUpg = true;
                break;
            default:
                break;

        }
        if (!PData.isDamageUpg)
        {
            PData.isDamageUpg = true;
            Weapon.Damage *= 1.1f;

        }
        switch (PData.currentLevelofFireAmount)
        {
            case 0:
                PData.FireAmount = 1;
                break;
            case 1:
                PData.FireAmount = 2;
                break;
            case 2:
                PData.FireAmount = 3;
                break;
            case 3:
                PData.FireAmount = 4;
                break;
            default:
                break;
        }
        switch (PData.currentLevelofWeaponAmount)
        {
            case 0:
                Weapon1.SetActive(false);
                Weapon2.SetActive(false);
                break;
            case 1:
                Weapon1.SetActive(true);
                Weapon2.SetActive(true);
                break;
            default:
                break;
        }
    }
}
