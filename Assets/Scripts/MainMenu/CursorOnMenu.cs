using System;
using UnityEngine;

public class CursorOnMenu : MonoBehaviour
{
    [Header("커서")]
    [SerializeField] private Texture2D _cursor;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        Cursor.SetCursor(_cursor, Vector2.zero, CursorMode.Auto);
    }
}
