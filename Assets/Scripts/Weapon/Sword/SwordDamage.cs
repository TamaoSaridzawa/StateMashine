using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class SwordDamage : MonoBehaviour
{
    [SerializeField] private Sword _sword;
    private bool _isAerial;

    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _isAerial = true;
            _sprite.flipY = true;
        }

        if (_isAerial)
        {
            _rb.velocity = transform.up * _sword.Speed;
        }
        else
        {
            _rb.velocity = transform.right * _sword.Speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_sword.Power);
            Destroy(gameObject);
        }
    }

    public void CreateSkill(Transform pos)
    {
        Instantiate(gameObject, pos.position, pos.rotation);
    }
}
