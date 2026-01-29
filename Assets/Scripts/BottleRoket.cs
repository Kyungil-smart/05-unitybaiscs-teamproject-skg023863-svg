using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRoket : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        
    }

    private void EndRoket()
    {
        gameObject.SetActive(false);
    }
}
