using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _timeCounter;

    private Wave _currenWave;
    private int _numberWave = 0;
    private int _spawned;
    private float _timeLastSpawn;

    private void Start()
    {
        SetNumber(_numberWave);
    }

    private void Update()
    {
        if (_currenWave == null)
            return;

        if (_currenWave.timekill > 0)
        {
            _currenWave.timekill -= Time.deltaTime;
        }
       
       
        ShowWaveInfo(_currenWave.timekill);

        _timeLastSpawn += Time.deltaTime;

        if (_numberWave < _waves.Count)
        {
            if (_spawned < _waves[_numberWave].CounteEnemy)
            {
                if (_timeLastSpawn >= _currenWave.Delay)
                {
                    Enemy enemy = Instantiate(_currenWave.Templates[Random.Range(0, _currenWave.Templates.Count)], _waves[_numberWave]._spawnWave[Random.Range(0, _waves[_numberWave]._spawnWave.Count)].position, Quaternion.identity)
                        .GetComponent<Enemy>();
                    enemy.Init(_player);
                    enemy.Dying += OnEnemyDying;
                    _spawned++;
                    _timeLastSpawn = 0;
                }
            }
            else
            {
                if (_numberWave + 1 < _waves.Count && _currenWave.timekill <= 0 )
                {
                    NextWaves();
                    _spawned = 0;
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

    private void ShowWaveInfo( float time)
    {
        _timeCounter.text = $"До следующей волны  : {time} \n Волна № {_numberWave + 1}";
    }
}

[System.Serializable]
public class Wave
{
    public float timekill;
    public List<Transform> _spawnWave; 
    public List <GameObject> Templates;
    public float Delay;
    public float CounteEnemy;
}
