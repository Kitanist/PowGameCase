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

    private void Start()
    {  
        InvokeRepeating(nameof(PingTime), 50, 50);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive));
        StartCoroutine(TimeControl());
        
    }
  
    public IEnumerator TimeControl()
    {
         tiktak.Raise();
    yield return new WaitForSeconds(1);
        timer.Time--;
        if (gold.Golds >= 100)
        {
            levelUpPlayer.Raise();
        }
        if (gold.Golds >= 200 && !timer.isSkillCooldown)
        {
            setActiveSkill.Raise();
        }
        if (!timer.isGameContinue)
        {
            Win.Raise();
            Time.timeScale = 0f;
        }
        if (PData.Health <= 0)
        {
            Lose.Raise();
            Time.timeScale = 0f;
        }
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
