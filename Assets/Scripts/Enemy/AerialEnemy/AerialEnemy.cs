using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialEnemy : Enemy
{
    [SerializeField] private AerialEnemyBullet _bullet;
    [SerializeField] private List<Transform> _patrulPoint;
    [SerializeField] private float _timeLastAttack;

    private int _indexPoint;
    private float _currentTime = 0;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _patrulPoint[_indexPoint].position, 10f * Time.deltaTime);

        if (transform.position == _patrulPoint[_indexPoint].position)
        {
            if (_indexPoint + 1 < _patrulPoint.Count)
            {
                _indexPoint++;
            }
            else
            {
                _indexPoint = 0;
            }
        }

        if (_currentTime >= _timeLastAttack)
        {
            _bullet.AppleDamage(transform, Target);
            _currentTime = 0;
        }
    }
}
