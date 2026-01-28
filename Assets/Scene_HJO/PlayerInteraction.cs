using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _rayLength;
    private Ray _ray;
    private void Update()
    {
        RayShot();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(_ray.origin, _ray.direction);
    }

    private void RayShot()
    {
        _ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(_ray, out hit))
        {
            Debug.Log($"{hit.transform.name} 감지, 거리 : {hit.distance}, 감지 좌표 : {hit.point}");
        }
    }
}
