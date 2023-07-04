using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Gold", menuName = "Events/Gold")]
public class Gold : ScriptableObject
{
    [SerializeField] private float gold = 0;
    public GameEvent UpdateVariables;
    private void OnEnable()
    {
        gold = 0;

    }
    public float Golds
    {
        get { return gold; }
        set
        {
            UpdateVariables.Raise();
            if (value < 0)
                gold = 0;
            else
                gold = value;

        }
    }
}
