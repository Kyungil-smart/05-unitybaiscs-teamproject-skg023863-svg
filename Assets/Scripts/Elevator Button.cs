using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorButton : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerChoice choose;

    [SerializeField] private TriggerController _elevatorPlace;

    private ElevatorController _elevatorController;

    private GameManager _gamemanager;


    private void Start()
    {
        _elevatorController = GetComponentInParent<ElevatorController>();
        _gamemanager = FindObjectOfType<GameManager>();
        Debug.Log(_gamemanager);
    }

    public void Interact()
    {
        if(!_elevatorPlace.IsPlayerInside) return;
        
        _elevatorController.ElevatorSequense();
        _gamemanager.OnPlayerChoice(choose);
    }

    public void LockOn(bool isLockOn)
    {
        
    }

}