using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelected : MonoBehaviour
{
    [SerializeField]
    Text selectArrow;

    Text playerName;

    void Awake()
    {
        playerName = GetComponent<Text>();
    }

    public void Selected()
    {
        selectArrow.gameObject.SetActive(true);
    }

    public void Deselected()
    {
        selectArrow.gameObject.SetActive(false);
    }
}
