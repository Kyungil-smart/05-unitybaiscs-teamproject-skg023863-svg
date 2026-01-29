using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodhands : MonoBehaviour, IAnomaly
{
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
