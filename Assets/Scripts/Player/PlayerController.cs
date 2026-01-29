using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        CursorLock(true);
    }
    
    // 커서 잠금 / 해제 처리
    private void CursorLock(bool isLocked)
    {
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isLocked;
    }
}
