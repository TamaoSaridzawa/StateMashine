using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BomberEnemy : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _particleSystem;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Expand();
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            var partSystem = Instantiate(_particleSystem, transform.position, Quaternion.identity);
            partSystem.Play();
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void Expand()
    {
        if (transform.position.x < Target.transform.position.x)
        {
            _spriteRenderer.flipX = true;
        }

        if (transform.position.x > Target.transform.position.x)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
