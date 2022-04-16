using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Skill
{
    [SerializeField ]private int _numberCharges = 10;
    //[SerializeField] private  MovementController _controller;
    private Rigidbody2D _rigidbody2D;
    private bool directionTraectory;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //var player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
        }
    }

    public override void Shoot(Transform startPointShoot, bool direction)
    {
        Instantiate(gameObject, startPointShoot.position, Quaternion.identity);

        //if (_numberCharges > 0)
        //{
        //    directionTraectory = direction;
        //    Debug.Log("FIRE" +  directionTraectory);
        //    //_numberCharges--;
        //    //StartCoroutine(Flyi(fireBall, direction));
        //}
    }

    private void Update()
    {
        
       if (directionTraectory == false)
       {
           gameObject.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
           Debug.Log("Работает удар влево");
       }
       else
        {
            Debug.Log("Работает удар вправо");
            gameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
        }
    }

   // private void Fly(bool direction)
   // {
   //     gameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
   // }

   //private void FlyLeft()
   //{
   //    gameObject.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
   //}

   // private IEnumerator Flyi(GameObject fireBall, bool direction)
   // {
   //     if (direction)
   //     {
   //         Debug.Log("Работает удар вправо");
   //         fireBall.transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
   //         yield return null;
   //     }
   //     else
   //     {
   //         Debug.Log("Работает удар влево");
   //         fireBall.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
   //         yield return null;
   //     }
      
   // }
}
