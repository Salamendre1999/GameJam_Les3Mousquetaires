using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Alessio
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnState spawnState = SpawnState.Counting;
        [SerializeField] private Wave[] waves;
        [SerializeField] private Transform[] spawners;
        [SerializeField] private int waveIndex = 0;
        [SerializeField] private float timeBetweenWaves;
        [SerializeField] private float waveCountDown;
        [SerializeField] private float searchAnyEnemyCountdown;
        private GameObject _gameObject;

        public void Start()
        {
            waveCountDown = timeBetweenWaves;
        }
        
        public void Update()
        {
            if (spawnState == SpawnState.Waiting)
            {
                if (!EnemyIsAlive())
                {
                    BeginTheNewWave();
                }
                else
                {
                    return;
                }
            }
            
            if (waveCountDown <= 0)
            {
                if (spawnState != SpawnState.Spawning)
                {
                    StartCoroutine(SpawnWave(waves[waveIndex]));
                }
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        }

        public void BeginTheNewWave()
        {
            spawnState = SpawnState.Counting;
            waveCountDown = timeBetweenWaves;

            if (waveIndex == waves.Length - 1)
            {
                waveIndex = 0;
            }
            else
            {
                waveIndex++;   
            }
        }
        
        public bool EnemyIsAlive()
        {
            searchAnyEnemyCountdown -= Time.deltaTime;
            if (searchAnyEnemyCountdown <= 0f)
            {
                searchAnyEnemyCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerator SpawnWave(Wave wave)
        {
            spawnState = SpawnState.Spawning;

            for (int i = 0; i < wave.numberOfEnemies; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f/wave.spawnRate);
            }

            spawnState = SpawnState.Waiting;
        }

        public void SpawnEnemy()
        {
            var randomSpawnPoint = Random.Range(0, spawners.Length);
            var randomMonster = Random.Range(0, waves[waveIndex].waveEnemies.Length);
            var spawnerTransform = spawners[randomSpawnPoint].transform;
            //Debug.Log(waves[waveIndex].waveEnemies.Length);
            var enemy = waves[waveIndex].waveEnemies[randomMonster];
            Instantiate(enemy, spawnerTransform.position, spawnerTransform.rotation);
        }
    }

    [System.Serializable]
    public struct Wave
    {
        public string waveName;
        public Transform[] waveEnemies;
        public int numberOfEnemies;
        public float spawnRate;
    }

    public enum SpawnState
    {
        Spawning,
        Waiting,
        Counting
    }
}
