using UnityEngine.UI;
using UnityEngine;

public class UIActiveSkillManager : MonoBehaviour
{
    public Button skillActiveBum, skillActiveRatata;
    [SerializeField] Gold gold;
    [SerializeField] PlayerData PData;
    [SerializeField] Timerstuff timer;
    [SerializeField] Weapon WP;
    [SerializeField] GameEvent LevelUp, BumSkillUsing;
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
        BumSkillUsing.Raise();
        Invoke("DeBum", 5f);
        SetDeActiveSkills();
        timer.isSkillCooldown = true;
        gold.Golds -= 200;
    }
    public void DeBum()
    {
        timer.isSkillCooldown = false;
    }
}
