using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void CreateSkill(Transform pos, bool isAerial)
    {
        Instantiate(gameObject, pos.position, pos.rotation);
        _isAerial = isAerial;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_sword.Power);
            Destroy(gameObject);
        }
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
}
