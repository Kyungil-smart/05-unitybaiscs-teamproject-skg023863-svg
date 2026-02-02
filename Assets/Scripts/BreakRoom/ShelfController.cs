using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController : AnomalyBase
{
    private Animator _animator;
    private bool _isPlayerInRoom;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRoom = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRoom = false;
        }
    }

    protected virtual void OnAnomalyStart()
    {
        if (_isPlayerInRoom)
        { 
            _animator.SetTrigger("isPlayerInRoom");
        }
    }

    protected virtual void OnAnomalyEnd()
    {
        if (!_isPlayerInRoom)
        { 
            _animator.ResetTrigger("isPlayerInRoom");
        }
        
    }
}
