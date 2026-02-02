using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class YDJ_BottleRoket : AnomalyBase
{
    private Animator _animator;
    private WaitForSeconds _delay = new WaitForSeconds(0.01f);
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    // private bool _isFly;
    [SerializeField] private WaterJet _waterJetParticles;

    private void Awake()
    { 
        _animator = GetComponent<Animator>();
        _originalPosition = transform.localPosition;
        _originalRotation = transform.localRotation;
    }
    
    void Start()
    { 
        _animator.SetBool("isWatter", false);
        _animator.enabled = false;
        // _isFly = false;
        WaterJetStop();
    }
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (!_isFly)
    //     {
    //         return;
    //     }
    //     if (other.CompareTag("Player"))
    //     {
    //         WaterJetStart();
    //     }
    // }
    
    void EndAni()
    {
        gameObject.SetActive(false);
    }

    void WaterJetStart()
    {
        _waterJetParticles.StartWaterJet();
    }

    void WaterJetStop()
    {
        _waterJetParticles.StopWaterJet();
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

    protected override void OnAnomalyStart()
    {
        _animator.enabled = true;
        // _isFly = true;
        WaterJetStart();
    }

    protected override void OnAnomalyEnd()
    {
        gameObject.SetActive(true);
        StartCoroutine(EndSequens());
    }
}
