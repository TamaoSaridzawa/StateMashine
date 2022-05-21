using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : ScriptableObject
{
    [SerializeField]private string _description;
    [SerializeField] private int _damage;
    [SerializeField] private int _increasedDamage;
    [SerializeField] private int _valueAddition;
    [SerializeField] private Sprite _icon; 
    [SerializeField] private bool _isStudied = false;
    [SerializeField] private float _speed;
    [SerializeField] private int _price;
    [SerializeField] private int _rang;
    [SerializeField] private int _maxRang;

    public string Desc => _description;
    public int Damage => _damage;
    public Sprite Icon => _icon;
    public float Speed => _speed;
    public int Price => _price;
    public int MaxRang => _maxRang;
    public int Rang => _rang;
    public bool IsStudied => _isStudied;

    public abstract void Action(Transform position);

    public void RaiseRang()
    {
        _rang++;
        _damage += _increasedDamage;
        _price += _valueAddition;
    }

    public void Studied()
    {
        _isStudied = true;
    }
}
