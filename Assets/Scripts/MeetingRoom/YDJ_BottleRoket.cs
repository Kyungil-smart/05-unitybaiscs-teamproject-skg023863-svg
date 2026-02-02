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
    [SerializeField] private WaterJet _waterJetParticles;


    private void Awake()
    { 
        _animator = GetComponent<Animator>();
    }
    
    void Start()
    { 
        _animator.SetBool("isWatter", false); 
        _animator.enabled = false;
        _originalPosition = transform.position;
        WaterJetStop();
    }

    public void FireRocket()
    {
        if (!_isActive)
        {
            return;
        }
        _animator.SetBool("isWatter", true);
    }
    
    
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
        _animator.Play("Idle");
        _animator.SetBool("isWatter", false);
        yield return _delay;
        
        _animator.enabled = false;
        yield return _delay;
        
        yield break;
    }

    IEnumerator SSS()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.enabled = true;
        transform.position = _originalPosition;
    }

    protected override void OnAnomalyStart()
    {
        StartCoroutine(SSS());
        WaterJetStop();
    }

    protected override void OnAnomalyEnd()
    {
        gameObject.SetActive(true);
        // StartCoroutine(EndSequens());
        WaterJetStop();
    }
}
