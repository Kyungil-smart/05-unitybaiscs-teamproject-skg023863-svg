using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private GameManager _gameManager;
    //private AnimatorControllerParameter _parameter;

    [SerializeField] private TextMeshProUGUI _textMeshPro;

    bool isClose;
    //[SerializeField] private GameObject

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        isClose = _animator.GetBool("isClose");
        //_parameter = _animator.GetParameter(0);
        //isClose = _animator.GetBool(_parameter.name);
    }

    private void Start()
    {
        //_textMeshPro.SetText(_gameManager.);
    }

    //Todo : 엘리베이터 버튼 연속으로 누를 때 예외처리 필요
    public void ElevatorSequense()
    {
        if (isClose)
        {
            _animator.SetBool("isClose", false);
            isClose = false;
        }
        else
        {
            _animator.SetBool("isClose", true);
            isClose = true;
        }

    }
}
