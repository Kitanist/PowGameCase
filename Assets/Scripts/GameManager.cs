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

    [SerializeField] GameEvent setActiveSkill, deActiveSkill,levelUpPlayer,tiktak;


   

    private float Second = 1;
    private void Start()
    {  
        InvokeRepeating("PingTime", 50, 50);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive));
    }
    private void Update()
    {
        if (timer.isGamePaused)
        {
            return;
        }
        if (Second <= 0)
        {
            Second = 1;
            tiktak.Raise();
            Debug.Log("SANÝYE");
            return;
        }
        Second -= Time.deltaTime;
    }
    public void TimeControl()
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
        
    }
   
}
