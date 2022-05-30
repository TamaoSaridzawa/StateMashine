using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
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
    //private void Start()
    //{
    //    _rb.GetComponent<Rigidbody2D>();
    //}

   // Update is called once per frame
   private void FixedUpdate()
   {
       //var _direction = _target.transform.position - gameObject.transform.position;
        _rb.AddForce(_direction * _speed);
        //_rb.velocity = transform.forward * _speed;
   }

    public void AppleDamage(Transform shot, Player player)
    {
        Instantiate(gameObject, shot.position, Quaternion.identity);
       _direction = player.transform.position - shot.position;
    }

    //private IEnumerator Movemented(Transform shot, Transform target)
    //{
    //    var direction = target.position - shot.position;
    //    //yield return new WaitForSeconds(1f);

    //    _rb.AddForce(direction);
    //    yield return null;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
