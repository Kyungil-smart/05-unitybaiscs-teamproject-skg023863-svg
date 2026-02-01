using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBono : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement _playerMovement = other.GetComponent<PlayerMovement>();
            Debug.Log("player entered");
            // _playerMovement._isSeeBono = true;
        }
    }

    

    
}
