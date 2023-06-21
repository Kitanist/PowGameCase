using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Time" , fileName = "Time")]
public class Timerstuff : ScriptableObject
{
    [SerializeField] private float time = 300;
    [SerializeField] GameEvent pauseGame,continueGame;
    public bool isGameContinue = true;
    public bool isGamePaused = false;
    public bool isSkillCooldown=false;

    public bool IsGamePaused
    {
        get { return isGamePaused; }
        set
        {
            if (isGamePaused)
            {
                pauseGame.Raise();
            }
            else
                continueGame.Raise();
        }
    }
    public float Time 
    {
        get { return time; }
        set
        {
            if (value <= 0) 
            { 
                time = 0;
            isGameContinue = false;
            }
            else
            { 
                time = value;
                isGameContinue = true;
            }
        }
    }
    private void OnEnable()
    {
        time = 300;
    }
}
