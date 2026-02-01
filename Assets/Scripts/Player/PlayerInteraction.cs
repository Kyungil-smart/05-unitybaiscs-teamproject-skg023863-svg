using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _rayLength;
    [SerializeField] private Transform _origin;
    [SerializeField] private LayerMask _targeLayer;
    
    private Camera _camera;
    private Ray _ray;
    private IInteractable _currentTarget;
    private Transform _targtTransform;
    private Outline _currentOutline;



    private void Update()
    {
        RayShot();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_currentTarget != null)
            _currentTarget.Interact();
        }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _camera = Camera.main;
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_ray.origin, _ray.direction * _rayLength);
    }

    private void RayShot()
    {
        RaycastHit hit;
        if (_origin == null) return;

        _ray = new Ray(_origin.position, _origin.forward);

        if (Physics.Raycast(_ray, out hit, _rayLength, _targeLayer))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

            if (interactable == null)
            interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable == null)
        {
            if (_currentOutline != null) _currentOutline.enabled = false;
            _currentOutline = null;

            _currentTarget?.LockOn(false);
            _currentTarget = null;
            _targtTransform = null;
            return;
        }

            Transform hitTransform = ((MonoBehaviour)interactable).transform;

            if (_targtTransform == hitTransform) return;

            if (_currentOutline != null) _currentOutline.enabled = false;
            _currentOutline = null;

            _currentTarget?.LockOn(false);

            _targtTransform = hitTransform;
            _currentTarget = interactable;

            _currentOutline = hitTransform.GetComponent<Outline>();
            if (_currentOutline != null) _currentOutline.enabled = true;

            _currentTarget.LockOn(true);

            Debug.Log($"{hitTransform.name} 감지, 거리 : {hit.distance}, 감지 좌표 : {hit.point}");
        }

        else
        {
            if (_currentOutline != null) _currentOutline.enabled = false;
            _currentOutline = null;

            _currentTarget?.LockOn(false);
            _currentTarget = null;
            _targtTransform = null;
        }
    }
}
    
