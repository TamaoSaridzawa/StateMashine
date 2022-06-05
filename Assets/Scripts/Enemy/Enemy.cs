using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _reward;
     private Player _target;

    public int Reward => _reward;

    public Player Target => _target;

    public float MaxHealth => _maxHealth;

    public event UnityAction<Enemy> Dying;

    public event UnityAction<float, float> _changedHealth;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _changedHealth?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
