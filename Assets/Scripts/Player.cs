using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            transform.Translate(axis * moveSpeed * Time.deltaTime);
            moving = axis != Vector2.zero;
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