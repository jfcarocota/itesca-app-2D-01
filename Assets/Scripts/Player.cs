using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.BasicInput;
using Core.Movements;

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
}