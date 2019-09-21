using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField]
    List<CharacterSelected> characters;

    void Start()
    {
        characters[0].Selected();
    }
}
