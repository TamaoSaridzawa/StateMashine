using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] private Sword _sword;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void CreateSkill(Transform pos)
    {
        Instantiate(gameObject, pos.position, pos.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_sword.Power);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.right * _sword.Speed;
    }
}
