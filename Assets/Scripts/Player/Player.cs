using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerScaler))]
[RequireComponent(typeof(WaterDrawer))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerScaler _playerScaler;
    private WaterDrawer _waterDrawer;

    public event UnityAction Finished;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerScaler = GetComponent<PlayerScaler>();
        _waterDrawer = GetComponent<WaterDrawer>();
    }

    private void OnEnable()
    {
        _playerMover.RoadEnded += OnRoadEnded;
    }

    private void OnDisable()
    {
        _playerMover.RoadEnded -= OnRoadEnded;
    }

    private void OnRoadEnded()
    {
        Finished?.Invoke();
        _playerScaler.ChangeAtEnd();
        _waterDrawer.SetStartPosition(transform.position);
    }

    public void OnPowerUpPicked(PowerUp powerUp)
    {
        _playerScaler.IncreaseAllAxis();
        powerUp.PickedUp -= OnPowerUpPicked;
    }
}
