using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 시점
    [SerializeField] private Transform _viewPoint;

    // 이동속도
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _runSpeed;

    // 마우스 감도
    [SerializeField] private float _mouseSensitivity;

    // 상하 회전 각도 제한
    [SerializeField] private float _pitchMin;
    [SerializeField] private float _pitchMax;

    private Rigidbody _rigidbody;
    
    // 상하 회전 각도 누적값
    private float _pitch;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Roatation();
        Move();
    }

    // 마우스 입력에 따른 시점 회전 처리
    private void Roatation()
    {
        // 마우스 입력값
        float x = Input.GetAxisRaw("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxisRaw("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        // 좌우 회전
        transform.Rotate(Vector3.up, x);

        // 상하 회전 값 누적
        _pitch -= y;

        // 상하 각도 제한
        _pitch = Mathf.Clamp(_pitch, _pitchMin, _pitchMax);
        
        // 상하회전 적용
        _viewPoint.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }

    private void Move()
    {   
        // 이동
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        // 왼쪽 Shift 누르면 달리기
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // 입력이 있을때만 달리기 속도 적용
        float speed = isRunning ? _runSpeed : _moveSpeed;

        Vector3 velocity = 
        transform.right * x * speed + transform.forward * z * speed;

        velocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = velocity;
        /*Vector3 movement = (transform.right * x + transform.forward * z).normalized;
        transform.position += movement * (speed * Time.deltaTime);*/
    }
}
