using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialEnemy : Enemy
{
    [SerializeField] AerialEnemyBullet _bullet;
    [SerializeField] private List<Transform> _patrulPoint;
    private int _indexPoint;
    private Transform _currentPosition;
    private float _currentTime = 0;
    [SerializeField] private float _timeLastAttack;
   
      void Start()
      {
        _currentPosition = transform;
      }

      // Update is called once per frame
      void Update()
      {

        //_bullet.InitTarget(Target);

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

    //private void Init()
    //{

    //}


   //private void move()
   //{

   //}

   //private IEnumerator Move()
   //{
   //    while (true)
   //    {
          
   //        _bullet.AppleDamage(transform, Target.transform);
   //         yield return new WaitForSeconds(2f);

   //     }
   //}
}
