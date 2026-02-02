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
    private WaitForSeconds _twoSec = new WaitForSeconds(2.5f);

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _sceneFlowManager = FindAnyObjectByType<SceneFlowManager>();
    }
    private void Update()
    {
        CreditUp();
        
        // Y 좌표값이 3000 이 넘어가면  자동으로 메인화면으로 넘어간다? vs 특정 버튼을 눌러야 움직인다\
        
        EndCredit();
        
        if (gameObject.transform.position.y > 3000f)
        {
            Debug.Log("크레딧 끝");
            _isInCredit = false;
            // 자동으로 씬을 메인화면 씬으로 전환 시켜주는 기능을 넣어야함 
            StartCoroutine(EndScene());
        }
    }

    private IEnumerator EndScene()
    {
        yield return _twoSec;
        _sceneFlowManager.LoadScene(SceneType.Title);
    }

    private void EndCredit()
    {
        // 유저가 크레딧 버튼을 누르면 메인메뉴로 이동
        if (Input.anyKeyDown)
        {
            _isInCredit = false;
            Debug.Log("멈춰!");
            _sceneFlowManager.LoadScene(SceneType.Title);
        }
    }

    private void CreditUp()
    {
        if(_isInCredit)
        {
            transform.Translate(Vector3.up * _creditSpeed * Time.deltaTime);
        }
    }
}
