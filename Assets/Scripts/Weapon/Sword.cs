using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Sword : Skill
{
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public override void Shoot(Transform startPointShoot)
    {
        Instantiate(gameObject, startPointShoot.position, startPointShoot.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.right * Speed;
    }
}
