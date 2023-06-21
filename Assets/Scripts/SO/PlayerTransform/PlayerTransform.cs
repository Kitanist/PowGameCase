using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Transform", menuName = "Events/Transform")]
public class PlayerTransform : ScriptableObject
{
    [SerializeField] private Vector2 playertransform;
    public Vector2 Playertransform
    {
        get { return playertransform; }
        set
        {
            playertransform = value;
        }
    }
}
