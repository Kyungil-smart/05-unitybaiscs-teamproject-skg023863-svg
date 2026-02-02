using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterJet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void StartWaterJet()
    {
        _particleSystem.Play();
    }

    public void StopWaterJet()
    {
        _particleSystem.Stop();
    }
}
