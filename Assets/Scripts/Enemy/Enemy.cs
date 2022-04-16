using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _reward;
     private Player _target;

    public int Reward => _reward;

    public Player Target => _target; 

    public void Init(Player target)
    {
        _target = target;
    }

    public event UnityAction<Enemy> Dying;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
