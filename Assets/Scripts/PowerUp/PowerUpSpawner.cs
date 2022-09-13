using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private PowerUp _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _particlesContainer;
    [SerializeField] private float _interval;
    [SerializeField] private Player _player;
    [SerializeField] private UI _ui;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        foreach (SpawnPoint _point in _spawnPoints)
        {
            for (int i = 0; i < _point.Amount; i++)
            {
                PowerUp powerUp = Instantiate(_prefab);
                powerUp.transform.parent = _point.transform;
                powerUp.Init(_particlesContainer);
                float xPosition = _point.transform.position.x + _interval * i;
                powerUp.transform.position = new Vector3(xPosition, _point.transform.position.y, _point.transform.position.z);
                powerUp.PickedUp += _player.OnPowerUpPicked;
                powerUp.PickedUp += _ui.OnPowerUpPicked;
            }
        }
    }
}
