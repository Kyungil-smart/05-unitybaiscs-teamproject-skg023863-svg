using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyChairSpin : MonoBehaviour
{
    [SerializeField] [Range(0, 1000)]private float _SpinSpeed = 300f;
    void Update()
    {
        ChairSpin();
    }

    private void ChairSpin()
    {
        transform.Rotate(Vector3.up * _SpinSpeed * Time.deltaTime);
    }
}
