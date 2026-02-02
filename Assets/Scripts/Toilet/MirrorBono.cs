using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBono : AnomalyBase
{
    [SerializeField] private GameObject _mirrorBono;
    [SerializeField] private GameObject _mirror;
    private bool _seeBono;

    private void Awake()
    {
        _mirrorBono.SetActive(false);
        _mirror.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _seeBono)
        {
            // PlayerMovement _playerMovement = other.GetComponent<PlayerMovement>();
            Debug.Log("플레이어가 들어왔으니 보노보노를 내보내자");
            _mirrorBono.SetActive(true);
            // _playerMovement._isSeeBono = true;
        }
    }

    protected override void OnAnomalyStart()
    {
        _seeBono = true;
    }

    protected override void OnAnomalyEnd()
    {
        _mirrorBono.SetActive(false);
        _seeBono = false;
    }
}
