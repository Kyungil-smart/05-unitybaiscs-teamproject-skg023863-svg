using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBono : MonoBehaviour
{
    [SerializeField] private GameObject _bonoPrefab;
    [SerializeField] private GameObject _anomalyDoorPrefab;
    [SerializeField] private GameObject _nomalDoorPrefab;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;
    private WaitForSeconds _oneSec = new WaitForSeconds(3f);

    private bool _isDoorOpen;
    private float _doorRotateMax = -75f;
    private float _currentDoorRotate = 0f;
    private float _bonoMoveMax = 0.6f;
    private float _currentBonoMove = 0f;

    private void Awake()
    {
        _bonoPrefab.SetActive(false);
        _anomalyDoorPrefab.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        _currentDoorRotate = _anomalyDoorPrefab.transform.localEulerAngles.z;
        _currentBonoMove = _bonoPrefab.transform.localPosition.x;
    }

    private void Update()
    {
        if (_isDoorOpen)
        {
            if (_currentDoorRotate > _doorRotateMax)
            {
                _currentDoorRotate -= _rotateSpeed * Time.deltaTime;
                _anomalyDoorPrefab.transform.localRotation = Quaternion.Euler(0f, 0f, _currentDoorRotate);
            }
        }

        if (_isDoorOpen)
        {
            if (_currentBonoMove > _bonoMoveMax)
            {
                _currentBonoMove -= _moveSpeed * Time.deltaTime;
                _bonoPrefab.transform.localPosition = new Vector3(_currentBonoMove,2.28f, 0.4913295f);
            }
        }
        else
        {
            _isDoorOpen = false;
        }
    }

    private IEnumerator OpenDelay()
    {
        yield return _oneSec;
        _isDoorOpen = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            StartCoroutine(OpenDelay());
        }
    }

    protected virtual void OnAnomalyStart()
    {
        _bonoPrefab.SetActive(true);
        _anomalyDoorPrefab.SetActive(true);
        _nomalDoorPrefab.SetActive(false);
        gameObject.SetActive(true);
    }

    protected virtual void OnAnomalyEnd()
    {
        _bonoPrefab.SetActive(false);
        _anomalyDoorPrefab.SetActive(false);
        _nomalDoorPrefab.SetActive(true);
        gameObject.SetActive(false);
    }
}
