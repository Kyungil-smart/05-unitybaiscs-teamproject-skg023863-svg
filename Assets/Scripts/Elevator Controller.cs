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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ElevatorSequense();
    }

    private void ElevatorSequense()
    {
        StartCoroutine(SequenseExecute(isClose));
    }

    IEnumerator SequenseExecute(bool state)
    {
        if (state)
        {
            
            _animator.SetBool("isClose", false);
            isClose = false;
            yield return _doorOpen;
        }
        else
        {
            _animator.SetBool("isClose", true);
            isClose = true;
            yield return _doorClose;
        }
        yield break;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
