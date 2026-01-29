using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController : MonoBehaviour, IAnomaly
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // 트리거 범위 내에 플레이어 진입시 움직임 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.SetTrigger("isPlayerInRoom");
        }
    }

    // 트리거 범위 밖으로 플레이어가 나가면 멈춤
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.ResetTrigger("isPlayerInRoom");
        }
    }

    public void ActivateAnomaly()
    {
       
    }

    public void DeactivateAnomaly()
    {
       
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
