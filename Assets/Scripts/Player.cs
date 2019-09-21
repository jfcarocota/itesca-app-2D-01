using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.BasicInput;
using Core.Movements;
using UnityEngine.SceneManagement;

public class Player : NPC
{
    [SerializeField]
    bool isNPC;
    [SerializeField]
    bool isLeader;

    void Update()
    {
        Movement();
        base.Update();
    }

    public override void Movement()
    {
        if(!isNPC)
        {
            Movements.PlayerBasicMovement(transform, BasicInput.AxisNormDeltaTime, moveSpeed);
            moving = BasicInput.AxisNormalized != Vector2.zero;
            if(moving)
            {
                animator.SetFloat("move-X", BasicInput.AxisNormalized.x);
                animator.SetFloat("move-Y", BasicInput.AxisNormalized.y);
            }
        }
        else
        {
            base.Movement();
        }
    }

    public bool IsLeader
    {
        get => isLeader;
        set => isLeader = value;
    }

    public bool IsNPC
    {
        get => isNPC;
        set => isNPC = value;
    }

    void OnTriggerEnter2D(Collider2D other) {
       if(other.CompareTag("Enemy"))
       {
           SceneManager.LoadScene("combatScene");
       } 
    }
}
