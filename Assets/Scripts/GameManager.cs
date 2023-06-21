using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public enum UnitType
{
    Normal,
    Speeder

}
public class GameManager : MonoSingeleton<GameManager>
{
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    [SerializeField] Gold gold;

    [SerializeField] Timerstuff timer;

    [SerializeField] GameEvent setActiveSkill, deActiveSkill,levelUpPlayer;

    public UnityEvent Time;  
    private void Start()
    {
        InvokeRepeating("TimeControl", 1f, 1f);
        InvokeRepeating("PingTime", 50, 50);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive));
    }
    void TimeControl()
    {
        timer.Time--;
       
        if (gold.Golds >= 100)
        {
            levelUpPlayer.Raise();
        }
        if (gold.Golds >= 200 && !timer.isSkillCooldown)
        {
            setActiveSkill.Raise();
        }
       // else
       //     deActiveSkill.Raise();
    }
   
    public void increaseGold()
    {
        gold.Golds += 25;
    }
    public void increaseGoldSlow()
    {

        gold.Golds += 50;
    }
    void PingTime()
    {
        Time.Invoke();
    }
   
}
