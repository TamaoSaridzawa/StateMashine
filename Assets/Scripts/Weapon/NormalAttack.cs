using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : Skill
{

    [SerializeField] private Transform _distanceAtack;

    public override void Shoot(Transform position, bool direction)
    {
        Instantiate(gameObject, position.position, Quaternion.identity);
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
        gameObject.transform.position = Vector3.MoveTowards(transform.position, _distanceAtack.position , Speed);
        Destroy(gameObject);
    }
}
