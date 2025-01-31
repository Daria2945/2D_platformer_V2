using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnerPoints;
    [SerializeField] private float _spawnDelay = 2;
    [SerializeField] private int _maxNumberItemsPerLevel;

    private int _numberItemsGreated;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSecondsRealtime(_spawnDelay);

        while (_numberItemsGreated < _maxNumberItemsPerLevel)
        {
            yield return wait;

            int index = Random.Range(0, _spawnerPoints.Length);

            if (_spawnerPoints[index].IsFreePoint)
            {
                _spawnerPoints[index].ShowItem();
                _numberItemsGreated++;
            }
        }
    }
}