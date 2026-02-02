using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBono : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            PlayerMovement _playerMovement = other.GetComponent<PlayerMovement>();
            Debug.Log("player entered");
            _seeBono = true;
        }
    }

    protected virtual void OnAnomalyStart()
    {
        if (_seeBono)
        {
            _mirrorBono.SetActive(true);
            // _playerMovement._isSeeBono = true;
        }
    }

    protected virtual void OnAnomalyEnd()
    {
        _mirrorBono.SetActive(false);
    }
}
