﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    [SerializeField]
    List<Player> currentParty;
    Player leader;
    [SerializeField]
    Player[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType(typeof(Player)) as Player[];

        for(int i = 0; i < players.Length; i++)
        {
            Player p = players[i];
            p.Leader = null;
            if(p.IsLeader) 
            {
                p.IsNPC = false;
                if(currentParty.Count > 0)
                {
                    currentParty.Insert(0, p);
                }
                else
                {
                    currentParty.Add(p); 
                }
            }
            else
            {
                p.IsNPC = true;
                currentParty.Add(p);   
            }         
        }

        for(int i = 1; i < currentParty.Count; i++)
        {
            currentParty[i].Leader = currentParty[i - 1];
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("myInput"))
        {
            Player currentLeader = currentParty[0];
            currentLeader.IsLeader = false;
            currentLeader.IsNPC = true;
            currentLeader.Leader = currentParty[currentParty.Count - 1];
            currentParty.RemoveAt(0);
            currentParty.Add(currentLeader);
            currentParty[0].IsLeader = true;
            currentParty[0].IsNPC = false;
            currentParty[0].Leader = null;
        }
    }
}
