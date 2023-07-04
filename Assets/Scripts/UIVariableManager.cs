using UnityEngine;
using TMPro;
public class UIVariableManager : MonoBehaviour
{
    [SerializeField] Gold gold;
    [SerializeField] PlayerData PData;
    [SerializeField] Weapon WP;
    public TextMeshProUGUI money, health, damage, fireRate ;
    
    public void SetVariable()
    {
        health.text = "HP :" + PData.Health.ToString();
        money.text = "Gold : " + gold.Golds.ToString();
       
        fireRate.text = "Fire Rate : " + WP.FireRate.ToString();
        damage.text = "Damage : " + WP.Damage.ToString();
    }
}
