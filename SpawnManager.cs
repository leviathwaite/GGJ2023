using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _enemyPrefabs;
    [SerializeField]
    private Transform _spawnPosition;
    [SerializeField]
    private int _maxPopulation = 4;
    [SerializeField]
    private float _spawnCoolDownDuration = 2;
    [SerializeField]
    private float _spawnCoolDownTimer;

    private GameObject[] _spawnedEnemies;

    // Start is called before the first frame update
    void Start()
    {
        // setup array
        _spawnedEnemies = new GameObject[_maxPopulation];
    }

    // Update is called once per frame
    void Update()
    {
        TickCoolDownTimer();
    }

    private void TickCoolDownTimer()
    {
        _spawnCoolDownTimer -= Time.deltaTime;
        if(_spawnCoolDownTimer < 0)
        {
            _spawnCoolDownTimer = _spawnCoolDownDuration;
        }
    }

    private void SpawnEnemy()
    {
        // create new if array not full
        if(_spawnedEnemies.Length < _maxPopulation - 1)
        {
            int availableIndex = EmptyIndex();
            if(availableIndex == -1)
            {
                return;
            }

            GameObject temp = Instantiate(RandomEnemy(), _spawnPosition.position, _spawnPosition.rotation);
            _spawnedEnemies[availableIndex] = temp;

        }
        else
        {
            // reset old one
            for(int i = 0; i < _spawnedEnemies.Length - 1; i++)
            {
                if(_spawnedEnemies[i].activeInHierarchy == false)
                {
                    _spawnedEnemies[i].transform.position = _spawnPosition.position;
                    _spawnedEnemies[i].SetActive(true);
                }
            }
        }
    }

    private int EmptyIndex()
    {
        for(int i = 0; i < _spawnedEnemies.Length - 1; i++)
            {
                if(_spawnedEnemies[i].activeInHierarchy == false)
                {
                    return i;
                }
            }

        return -1;
    }

    private GameObject RandomEnemy()
    {
        int randomIndex = Random.Range(0, _enemyPrefabs.Length - 1);
        return _enemyPrefabs[randomIndex];
    }
}
