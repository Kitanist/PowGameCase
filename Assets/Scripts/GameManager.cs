using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public enum UnitType
{
    Normal,
    Speeder,

}
public class GameManager : MonoSingeleton<GameManager>
{
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    [SerializeField] private float gold = 0;

    public UnityEvent Time, LevelUpPlayer;

    public TextMeshProUGUI timeText;

    public float Timer = 300;

    public bool isGameContinue = true;

    Adios EventSystem;

    public float Gold
    {
        get { return gold; }
        set
        {
            if (value < 0)
                gold = 0;
            else
                gold = value;

        }
    }
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
        if (gold >= 100)
        {
            LevelUpPlayer.AddListener(EventSystem.LevelUpUIOpen);
            LevelUpPlayer.Invoke();
        }
        if (gold >= 200)
        {
            EventSystem.SetActiveSkills();
        }
        else
            EventSystem.SetDeActiveSkills();
    }
    void Load()
    {
        timeText = GameObject.Find("Debugger").GetComponentInChildren<TextMeshProUGUI>();
        EventSystem = GameObject.Find("EventSystem").GetComponent<Adios>();
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
