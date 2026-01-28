using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _viewPoint;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _pitchMin;
    [SerializeField] private float _pitchMax;


    private float _pitch;

    private void Update()
    {
        Roatation();
        Move();
    }

    private void Roatation()
    {
        float x = Input.GetAxisRaw("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxisRaw("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        // 좌우 회전
        transform.Rotate(Vector3.up, x);

        _pitch -= y;
        _pitch = Mathf.Clamp(_pitch, _pitchMin, _pitchMax);
        
        // 상하회전
        _viewPoint.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = (transform.right * x + transform.forward * z).normalized;
        transform.position += movement * (_moveSpeed * Time.deltaTime);
    }
}
