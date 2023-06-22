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

    [SerializeField] GameEvent setActiveSkill, deActiveSkill,levelUpPlayer,tiktak, Win, Lose;

    [SerializeField] PlayerData PData;

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
        if (!timer.isGameContinue && Time.timeScale > 0)
        {
            Win.Raise();
            Time.timeScale = 0f;
            Debug.Log("Zamaný yedim afied");
        }

        if (PData.Health <= 0 && Time.timeScale > 0)
        {
            Lose.Raise();
            Time.timeScale = 0f;
            Debug.Log("Zamaný yedim");
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
        PData.SaveGame();
    }
    public void increaseGoldSlow()
    {

        gold.Golds += 50;
        PData.SaveGame();
    }
    
    void PingTime()
    {
        
    }
  
   
}
