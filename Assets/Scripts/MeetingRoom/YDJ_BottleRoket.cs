using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class YDJ_BottleRoket : AnomalyBase
{
    [SerializeField] private WaterJet _waterJetParticles;
    private Animator _animator;
    private WaitForSeconds _delay = new WaitForSeconds(0.01f);
    
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    
    private void Awake()
    { 
        _animator = GetComponent<Animator>();
    }
    
    void Start()
    { 
        _animator.SetBool("isWatter", false); 
        _animator.enabled = false;
        _originalPosition = transform.localPosition;
        _originalRotation = transform.localRotation;
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
    
    /*
    void EndAni()
    {
        gameObject.SetActive(false);
    }
    */

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
        
        _animator.enabled = false;
        transform.localPosition = _originalPosition;
        transform.localRotation = _originalRotation;

        yield return _delay;
        
        WaterJetStop();
        yield break;
    }

    IEnumerator SSS()
    {
        yield return _delay;
        
        _animator.enabled = true;
        transform.localPosition = _originalPosition;
        transform.localRotation = _originalRotation;
        WaterJetStop();
    }

    protected override void OnAnomalyStart()
    {
        StartCoroutine(SSS());
    }

    protected override void OnAnomalyEnd()
    {
        if (_animator != null)
        {
            _animator.Play("Idle2");
            _animator.SetBool("isWatter", false);
        }
        
        StartCoroutine(EndSequens());
    }
}
