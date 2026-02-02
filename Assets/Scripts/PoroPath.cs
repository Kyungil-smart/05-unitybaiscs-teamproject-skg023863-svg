using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoroPath : AnomalyBase
{
    [SerializeField] private List<Vector3> _path = new List<Vector3>();
    [SerializeField] private float _poroSpeed;
    [SerializeField] private float _poroRotateSpeed;
    
    private int _currentWaypoint;
    private bool _isSelectPORO = false;
    private Vector3 _startPos;

    private void Awake()
    {
        var vector3 = _path;
        _currentWaypoint = 0;
        _startPos = transform.position;
        transform.position = _path[0];
    }

    private void Update()
    {
        if (_path == null || !_isSelectPORO) return;
        Move();
    }

    private void Move()
    {
        if(_path.Count == 0) return;
        Vector3 seePos = _path[_currentWaypoint]; 
        
        if (Vector3.Distance(_path[_currentWaypoint], transform.position) <= 0.05f)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _path.Count;
            seePos = _path[_currentWaypoint];
        }
        
        Vector3 dirSeePos = (seePos - transform.position).normalized;

        if (dirSeePos != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dirSeePos), Time.deltaTime * _poroRotateSpeed);
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _path[_currentWaypoint], Time.deltaTime * _poroSpeed);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _path.Count - 1; i++)
        { 
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_path[i], _path[i + 1]);
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(_path[i], 0.3f);
        }
    }

    protected override void OnAnomalyStart()
    {
        gameObject.SetActive(true);
        _isSelectPORO = true;
    }

    protected override void OnAnomalyEnd()
    {
        gameObject.SetActive(false);
        _isSelectPORO = false;
        
        transform.position = _startPos;
        _currentWaypoint = 0;
    }
}
