using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleTrigger : MonoBehaviour
{ 
    [SerializeField] private YDJ_BottleRoket _ydjBottleRoket;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ydjBottleRoket.FireRocket();
        }
    }
}
