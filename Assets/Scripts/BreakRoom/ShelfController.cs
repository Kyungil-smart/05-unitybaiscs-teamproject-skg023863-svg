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

    // 트리거 범위 내에 플레이어 진입시 움직임 
    /*
    public override void ActivateAnomaly()
    {
        base.ActivateAnomaly();

        if (_animator != null && _isPlayerInRoom)
        {
            _animator.SetTrigger("isPlayerInRoom");
        }
    }
    */

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRoom = true;
            _animator.SetTrigger("isPlayerInRoom");
        }
    }

    // 트리거 범위 밖으로 플레이어가 나가면 멈춤
    /*
    public override void DeactivateAnomaly()
    {
        if (_animator != null && !_isPlayerInRoom)
        {
            _animator.ResetTrigger("isPlayerInRoom");
        }
        
        base.DeactivateAnomaly();
    }
    */

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRoom = false;
            _animator.ResetTrigger("isPlayerInRoom");
        }
    }
}
