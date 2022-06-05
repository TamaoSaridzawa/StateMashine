using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialEnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private Vector2 _direction;
    private Player _target;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    public void InitTarget(Player target)
    {
        _target = target;
    }
  
   private void FixedUpdate()
   {
        _rb.AddForce(_direction * _speed);
   }

    public void AppleDamage(Transform shot, Player player)
    {
        Instantiate(gameObject, shot.position, Quaternion.identity);
       _direction = player.transform.position - shot.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
