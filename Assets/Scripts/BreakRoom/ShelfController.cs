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
        if (other.CompareTag("Player") && _isPlayerInRoom)
        {
            Debug.Log("플레이어가 왔데요!");
            _animator.SetTrigger("isPlayerInRoom");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !_isPlayerInRoom)
        {
            _animator.ResetTrigger("isPlayerInRoom");
        }
    }

    protected override void OnAnomalyStart()
    {
        gameObject.SetActive(true);
       _isPlayerInRoom = true;
    }

    protected override void OnAnomalyEnd()
    {
        gameObject.SetActive(false);
        _isPlayerInRoom = false;
    }
}
