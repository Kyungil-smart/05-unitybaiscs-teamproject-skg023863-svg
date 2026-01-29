using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _rayLength;
    [SerializeField] private Transform _origin;
    [SerializeField] private LayerMask _targeLayer;
    
    private Ray _ray;
    private IInteractable _currentTarget;

    private void Update()
    {
        RayShot();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_currentTarget != null)
            _currentTarget.Interact();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_ray.origin, _ray.direction * _rayLength);
    }

    private void RayShot()
    {
        if (_origin == null) return;

        _ray = new Ray(_origin.position, _origin.forward);

        RaycastHit hit;
        _currentTarget = null;

        // 시점 기준으로 레이를 쏴서 레이 거리 안에 있는 오브젝트 맞춤
        if(Physics.Raycast(_ray, out hit, _rayLength, _targeLayer))
        {
            // 맞능 오브젝트 확인해서 상호작용 가능한지 판단
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();
            
            if(Physics.Raycast(_ray, out hit, _rayLength, _targeLayer))
            {
                _currentTarget = interactable;
                Debug.Log($"{hit.transform.name} 감지, 거리 : {hit.distance}, 감지 좌표 : {hit.point}");
            }
        }
    }
}
