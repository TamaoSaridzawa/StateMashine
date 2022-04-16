using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Skill
{

    public override void Shoot(Transform startPointShoot, bool direction)
    {
        Instantiate(gameObject, startPointShoot.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector2.left * Speed * Time.deltaTime , Space.World);
    }
}
