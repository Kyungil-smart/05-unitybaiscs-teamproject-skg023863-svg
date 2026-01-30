using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorButton : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerChoice choose;

    private ElevatorController _elevatorController;
    private GameManager _gamemanager;

    private void Start()
    {
        _elevatorController = GetComponentInParent<ElevatorController>();
        _gamemanager = FindObjectOfType<GameManager>();
    }

    public void Interact()
    {
        _elevatorController.ElevatorSequense();
        _gamemanager.OnPlayerChoice(choose);
    }
}