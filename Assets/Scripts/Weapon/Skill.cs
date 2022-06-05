using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : ScriptableObject
{
    [SerializeField] protected LogicSkill LogicSkill;
    [SerializeField] private int _increasedPower;
    [SerializeField] private int _valueAddition;
    [SerializeField] private Sprite _icon; 
    [SerializeField] private bool _isStudied ;
    [SerializeField] private float _speed;
    [SerializeField] private int _price;
    [SerializeField] private int _startRang;
    [SerializeField] private int _skillPower;
    [SerializeField] private int _maxRang;

    protected string Description;
    protected float CurrentTime;
    protected int CurrentSkillPower;
    protected int CurrentRang;
    protected int CurrentPryce;
    protected bool CurrentState;

    public int Pryce => CurrentPryce;
    public int Power => CurrentSkillPower;
    public int Rang => CurrentRang;
    public Sprite Icon => _icon;
    public float Speed => _speed;
    public int MaxRang => _maxRang;
    public bool IsStudied => CurrentState;

    private void OnEnable()
    {
        CurrentState = _isStudied;
        CurrentSkillPower = _skillPower;
        CurrentRang = _startRang;
        CurrentPryce = _price;
    }

    public abstract void Action(Transform position, AnimationManager animator);

    public abstract string ShowInfo();
   
    public void RaiseRang()
    {
        CurrentRang++;
        CurrentSkillPower += _increasedPower;
        CurrentPryce += _valueAddition;
    }

    public void Studied()
    {
        CurrentState = true;
    }
}
