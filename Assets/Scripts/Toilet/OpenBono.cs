using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBono : AnomalyBase
{
    [Header("이상현상 오브젝트")]
    [SerializeField] private GameObject _bonoPrefab;
    [SerializeField] private GameObject _anomalyDoorPrefab;
    [SerializeField] private GameObject _nomalDoorPrefab;
    
    [Header("이상현상 제어속도")]
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;
    private WaitForSeconds _oneSec = new WaitForSeconds(1.5f);

    private bool _isDoorOpen;
    private float _doorRotateMax = -75f;
    private float _currentDoorRotate = 0f;
    private float _bonoMoveMax = 0.6f;
    private float _currentBonoMove = 0f;
    
    /*
    private void Awake()
    {
        _bonoPrefab.SetActive(false);
        _anomalyDoorPrefab.SetActive(false);
    }
    */

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
            Debug.Log("이상현상이 있는 문 감지됨");
            StartCoroutine(OpenDelay());
        }
    }

    protected override void OnAnomalyStart()
    {
        _bonoPrefab.SetActive(true);
        _anomalyDoorPrefab.SetActive(true);
        _nomalDoorPrefab.SetActive(false);
        gameObject.SetActive(true);
        
        _currentDoorRotate = _anomalyDoorPrefab.transform.localEulerAngles.z;
        _currentBonoMove = _bonoPrefab.transform.localPosition.x;
    }

    protected override void OnAnomalyEnd()
    {
        _isDoorOpen = false;
        _bonoPrefab.SetActive(false);
        _anomalyDoorPrefab.SetActive(false);
        _nomalDoorPrefab.SetActive(true);
        gameObject.SetActive(false);
        _currentBonoMove = 2.61f;
        
        _bonoPrefab.transform.localPosition = new Vector3(_currentBonoMove,2.28f, 0.4913295f);
    }
}
