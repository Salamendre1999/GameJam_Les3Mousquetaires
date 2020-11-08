using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private bool stopSpawning = false;
    [SerializeField] private float spawningTime;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Transform _transform;
    [SerializeField] private int maxCounter;
    private int _counter = 0;

    private void Awake()
    {
        _transform = transform;
        InvokeRepeating(nameof(SpawnEnemy), spawningTime, spawnDelay);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, _transform.position, _transform.rotation);
        _counter++;
        if (_counter == maxCounter)
        {
            stopSpawning = true;
            CancelInvoke(nameof(SpawnEnemy));
        }
    }

}
