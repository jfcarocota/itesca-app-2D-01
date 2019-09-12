using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NPC
{
    [SerializeField]
    bool isLeader;
    [SerializeField]
    bool isNPC;
    
    new void Update()
    {
        base.Update();
        Move();
    }

    public override void Move()
    {   
        if(!isNPC)
        {
            transform.Translate(Axis * moveSpeed * Time.deltaTime);
            moving = Axis != Vector2.zero;

            if(moving)
            {
                animator.SetFloat("move-X", Axis.x);
                animator.SetFloat("move-Y", Axis.y);
            }

            animator.SetBool("moving", moving);  
        }
        else
        {
            base.Move();
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
}
