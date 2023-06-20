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

    [SerializeField] GameEvent setActiveSkill, deActiveSkill,levelUpPlayer;

    public UnityEvent Time;

    public TextMeshProUGUI timeText;

    public float Timer = 300;

    public bool isGameContinue = true;

    

    
    private void Start()
    {
        InvokeRepeating("TimeControl", 2.1f, 1f);
        InvokeRepeating("PingTime", 50, 50);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive));
        Invoke("Load", 2);
    }
    void TimeControl()
    {
        Timer--;
        timeText.text = Timer.ToString();
        if (Timer == 0 || Timer < 0)
        {
            isGameContinue = false;
        }
        if (gold.Golds >= 100)
        {

            levelUpPlayer.Raise();
        }
        if (gold.Golds >= 200)
        {
            setActiveSkill.Raise();
        }
        else
            deActiveSkill.Raise();
    }
    void Load()
    {
        timeText = GameObject.Find("Debugger").GetComponentInChildren<TextMeshProUGUI>();
       
    }
    void PingTime()
    {
        Time.Invoke();
    }
    public IEnumerator EnemyDyingEnum(GameObject Efect)
    {
        yield return new WaitForSeconds(0.5f);
        Efect.SetActive(false);
    }
}
