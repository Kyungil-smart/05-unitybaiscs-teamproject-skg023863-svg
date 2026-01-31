using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBono : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
    }
}
