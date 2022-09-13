using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private int _amountOfPowerUps;

    public int Amount => _amountOfPowerUps;
}
