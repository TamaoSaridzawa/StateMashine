using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class FireDamage : MonoBehaviour
{
    [SerializeField] private Fire _fire;

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
            enemy.TakeDamage(_fire.Power);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.right * _fire.Speed;
    }
}
