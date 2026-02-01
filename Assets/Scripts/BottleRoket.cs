using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BottleRoket : AnomalyBase
{
    private Animator _animator;
    private WaitForSeconds _delay = new WaitForSeconds(0.01f);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }

    void Start()
    {
        _animator.SetBool("isWatter", false);
        _animator.enabled = false;
    }

    void EndAni()
    {
        gameObject.SetActive(false);
    }

    IEnumerator EndSequens()
    {
        yield return _delay;
        _animator.Play("Idle");
        _animator.SetBool("isWatter", false);
        yield return _delay;
        _animator.enabled = false;
        yield break;
    }

    // player lockon 구현 후 추가 구현 필요

    protected override void OnAnomalyStart()
    {
        _animator.enabled = true;
    }

    protected override void OnAnomalyEnd()
    {
        gameObject.SetActive(true);
        StartCoroutine(EndSequens());
    }
}
