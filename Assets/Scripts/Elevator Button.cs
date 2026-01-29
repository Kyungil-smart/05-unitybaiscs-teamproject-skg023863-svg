using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorButton : MonoBehaviour
{
    private ElevatorController _elevatorController;

    //Todo : 플레이어 완성 후 상호작용 방식에 따라 재설계 필요
    private void ButtonPushed()
    {
        _elevatorController.ElevatorSequense();
    }
}
