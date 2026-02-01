using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyWaterBottleRocket : MonoBehaviour
{
    public class WaterRocketAnimator : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Launch()
        {
            _animator.SetBool("IsWatter", true);
        }
    }
}
