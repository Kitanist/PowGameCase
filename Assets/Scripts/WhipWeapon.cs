using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour // tasarlanan ama vaz geçilen mekanik
{
    [SerializeField] float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftWhipObject;
    [SerializeField] GameObject rightWhipObject;

    PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }


    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }
    private void Attack()
    {
        timer = timeToAttack;

        if (playerMovement.movement.x > 0) 
        {
            rightWhipObject.SetActive(true);
        }
        else
        {
            leftWhipObject.SetActive(true);
        }
    }
}
