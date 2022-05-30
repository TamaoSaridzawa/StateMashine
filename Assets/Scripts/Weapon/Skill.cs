using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : ScriptableObject
{
    protected string Description;
   
    [SerializeField] private int _increasedPower;
    [SerializeField] private int _valueAddition;
    [SerializeField] private Sprite _icon; 
    [SerializeField] private bool _isStudied = false;
    [SerializeField] private float _speed;
    [SerializeField] private int _price;
    [SerializeField] private int _startRang;
    [SerializeField] private int _skillPower;
    [SerializeField] private int _maxRang;
    [SerializeField] protected LogicSkill LogicSkill;
    protected int CurrentSkillPower;
    protected int CurrentRang;
    protected int CurrentPryce;

    public int Pryce => CurrentPryce;
    public int Power => CurrentSkillPower;
    public int Rang => CurrentRang;

    ////public string Desc => Description;
 
    public Sprite Icon => _icon;
    public float Speed => _speed;
    //public int Price => _price;
    public int MaxRang => _maxRang;
    //public int Rang => _startRang;
    public bool IsStudied => _isStudied;

    private void OnEnable()
    {
        CurrentSkillPower = _skillPower;
        CurrentRang = 1;
        CurrentPryce = _price;
    }

    public abstract void Action(Transform position);

    public abstract string ShowInfo();
   

    public void RaiseRang()
    {
        CurrentRang++;
        CurrentSkillPower += _increasedPower;
        CurrentPryce += _valueAddition;
    }

    public void Studied()
    {
        _isStudied = true;
    }
}
