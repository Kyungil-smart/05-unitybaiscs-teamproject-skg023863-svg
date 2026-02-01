using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditAnimation : MonoBehaviour
{
    [Header("크레딧 진행 속도")]
    [SerializeField] private float _creditSpeed;
    private bool _isInCredit =  true;
    private SceneFlowManager _sceneFlowManager;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _sceneFlowManager = GetComponent<SceneFlowManager>();
    }

    private void Update()
    {
        CreditUp();
        
        // Y 좌표값이 3000 이 넘어가면  자동으로 메인화면으로 넘어간다? vs 특정 버튼을 눌러야 움직인다\
        
        if (gameObject.transform.position.y > 3300f)
        {
            Debug.Log("크레딧 끝");
            _isInCredit = false;
            // 자동으로 씬을 메인화면 씬으로 전환 시켜주는 기능을 넣어야함 
            EndCredit();
        }
    }

    private void EndCredit()
    {
        if (_sceneFlowManager != null && Input.anyKeyDown)
        {
            _sceneFlowManager.LoadTitle();
        }
    }

    private void CreditUp()
    {
        
        // 유저가 크레딧 버튼을 누르거나 게임을 클리어시 크레딧 씬으로 전환하여 동작
        if(_isInCredit)
        {
            transform.Translate(Vector3.up * _creditSpeed * Time.deltaTime);
        }
    }
}
