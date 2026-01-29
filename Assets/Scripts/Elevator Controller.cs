using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private float _speed;

     private Animator _animator;
    private RuntimeAnimatorController _aniController;
    //private AnimatorControllerParameter _parameter;
    private WaitForSeconds _doorClose;
    private WaitForSeconds _doorOpen;

    bool isClose;
    //[SerializeField] private GameObject

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _aniController = _animator.runtimeAnimatorController;
        isClose = _animator.GetBool("isClose");
        //_parameter = _animator.GetParameter(0);
        //isClose = _animator.GetBool(_parameter.name);

        _doorClose = new WaitForSeconds(_aniController.animationClips[0].length);
        _doorOpen = new WaitForSeconds(_aniController.animationClips[1].length);
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

    /*IEnumerator SequenseExecute(bool state)
    {
        
        yield break;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
    */
}
