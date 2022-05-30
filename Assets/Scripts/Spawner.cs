using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Wave> _waves;
    //[SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] Player _player;

    private Wave _currenWave;
    private int _numberWave = 0;
    private int _spawned;
    private float _timeWave;
    private float _timeLastSpawn;
    private int testRang = 1;
    private int CurengRang = 1;

    private void Start()
    {
        SetNumber(_numberWave);
    }

    private void Update()
    {
        _timeWave += Time.deltaTime;
        //Debug.Log(testRang);

        if (_currenWave == null)
            return;

        _timeLastSpawn += Time.deltaTime;

        if (_numberWave < _waves.Count)
        {
            if (_spawned < _waves[_numberWave].CounteEnemy)
            {
                if (_timeLastSpawn >= _currenWave.Delay)
                {
                    Enemy enemy = Instantiate(_currenWave.Template, _waves[_numberWave]._spawnWave[Random.Range(0, _waves[_numberWave]._spawnWave.Count)].position, Quaternion.identity).GetComponent<Enemy>();
                    enemy.Init(_player);
                    enemy.Dying += OnEnemyDying;
                    _spawned++;
                    _timeLastSpawn = 0;
                }
            }
            else
            {
                if (_numberWave + 1 < _waves.Count && _timeWave > _currenWave.timekill)
                {
                    NextWaves();
                    _spawned = 0;
                    _timeWave = 0;
                }
               
            }
        }
        else
        {
            _currenWave = null;
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        _player.AddMoney(enemy.Reward);
        enemy.Dying -= OnEnemyDying;
    }

    private void NextWaves()
    {
        _currenWave = _waves[++_numberWave];
    }

    private void SetNumber(int index)
    {
        _currenWave = _waves[index];
    }
}

[System.Serializable]
public class Wave
{
    public float timekill;
    public List<Transform> _spawnWave; 
    public GameObject Template;
    public float Delay;
    public float CounteEnemy;
}
