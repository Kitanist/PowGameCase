using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Time" , fileName = "Time")]
public class Timerstuff : ScriptableObject
{
    [SerializeField] private float time = 300;
    public bool isGameContinue = true;
    public bool isSkillCooldown=false;

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
