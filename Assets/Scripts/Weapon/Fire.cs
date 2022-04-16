using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Skill
{
    [SerializeField ]private int _numberCharges = 10;
    private bool directionTraectory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
        }
    }

    public override void Shoot(Transform startPointShoot, bool direction)
    {
        Instantiate(gameObject, startPointShoot.position, Quaternion.identity);
    }

    private void Update()
    {
        
       if (directionTraectory == false)
       {
           gameObject.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
       }
       else
        {
            gameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
        }
    }
}
