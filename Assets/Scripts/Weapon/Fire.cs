using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Fire", order = 51)]
[RequireComponent(typeof(Rigidbody2D))]
public class Fire : Skill
{
    [SerializeField ]private int _numberCharges = 10;
    [SerializeField] private GameObject _prefabs;
    //private Rigidbody2D _rb;

    //private void Start()
    //{
    //    _prefabs.GetComponent<Ri>
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
        }
    }

    public override void Action(Transform startPointShoot)
    {
        Instantiate(_prefabs, startPointShoot.position, startPointShoot.rotation);
    }

    private void FixedUpdate()
    {
        _prefabs.GetComponent<Rigidbody2D>().velocity = _prefabs.transform.right * Speed;
        //_rb.velocity = transform.right * Speed;
    }
}
