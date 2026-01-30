using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditAnimation : MonoBehaviour
{
    [Header("크레딧 진행 속도")]
    [SerializeField] private float _creditSpeed;
    private Animator _animator;
    private Animation _animation;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _animator = GetComponent<Animator>();
        _animation = GetComponent<Animation>();
    }

    private void Update()
    {
        CreditUp();
        
        /*
        Y 좌표값이 3000 이 넘어가면  자동으로 메인화면으로 넘어간다? vs 특정 버튼을 눌러야 움직인다\
        if ()
        {
            
        }
        */
    }

    private void CreditUp()
    {
        /*
        유저가 크레딧 버튼을 누르거나 게임을 클리어시 크레딧 씬으로 전환하여 동작
        if(?)
        {
            
        }
        */
        transform.Translate(Vector3.up * _creditSpeed * Time.deltaTime);
    }
}
