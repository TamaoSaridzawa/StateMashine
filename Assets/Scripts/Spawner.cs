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
    private Coroutine _spawnJob;

    private void Start()
    {
        SetNumber(_numberWave);
       _spawnJob = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_currenWave != null)
        {
            _timeLastSpawn += Time.deltaTime;
            _currenWave.Timekill -= Time.deltaTime;

            ShowWaveInfo(_currenWave.Timekill);

            if (_numberWave < _waves.Count)
            {
                if (_spawned < _waves[_numberWave].CounteEnemy)
                {
                    if (_timeLastSpawn >= _currenWave.Delay)
                    {
                        Enemy enemy = Instantiate(_currenWave.Templates[Random.Range(0, _currenWave.Templates.Count)]
                            , _waves[_numberWave].SpawnWaves[Random.Range(0, _waves[_numberWave].SpawnWaves.Count)].position
                            , Quaternion.identity).GetComponent<Enemy>();
                        enemy.Init(_player);
                        enemy.Dying += OnEnemyDying;
                        _spawned++;
                        _timeLastSpawn = 0;
                    }
                }
                else
                {
                    if (_numberWave + 1 < _waves.Count && _currenWave.Timekill <= 0)
                    {
                        Debug.Log("Волна переключилась");
                        NextWaves();
                        _spawned = 0;
                    }
                }

                yield return null;
            }

            if (_numberWave + 1 == _waves.Count)
            {
                StopSpawnJob();
            }
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

    private void StopSpawnJob()
    {
        StopCoroutine(_spawnJob);
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
    public float Timekill;
    public List<Transform> SpawnWaves; 
    public List <GameObject> Templates;
    public float Delay;
    public float CounteEnemy;
}
