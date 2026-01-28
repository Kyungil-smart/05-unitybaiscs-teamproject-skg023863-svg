using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodhands : MonoBehaviour, IAnomaly
{
    private void EnableHands()
    {
        gameObject.SetActive(true);
    }

    public bool IsChoiceCorrect(PlayerChoice choice)
    {
        if (choice == PlayerChoice.Up)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
