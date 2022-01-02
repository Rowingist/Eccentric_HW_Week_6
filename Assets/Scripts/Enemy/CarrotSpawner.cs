using UnityEngine;

public class CarrotSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _carrotPrafab;
    [SerializeField] private Transform _spawnPoint;

    public void Spawn()
    {
        Instantiate(_carrotPrafab, _spawnPoint.position, Quaternion.identity);
    }
}
