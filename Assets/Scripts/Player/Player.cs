using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxhealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private List<Skill> _skills;
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] private CoinMenu _coinMenu;
    [SerializeField] private SkilllBar _skilllBar;
   
    private SpriteRenderer _renderer;

    [SerializeField] private int _money;

    public int Money => _money;

    public float MaxHealth => _maxhealth;
    public float CurrentHealth => _currentHealth;

    public int IndexSkils { get; private set; } = 0;

    private Skill _currentSkill;

    public Skill CurrentSkill => _currentSkill;

    public event UnityAction<float, float> ChangedHealth;

    public event UnityAction Dying;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _currentSkill = _skills[0];
        _skilllBar.ShowCurrentSkill(_currentSkill);
        _coinMenu.ChangeMoney(_money);
    }

    public void NextSkill()
    {
        if (_skills.Count > 0)
        {
            IndexSkils++;

            if (IndexSkils < _skills.Count)
            {
                _currentSkill = _skills[IndexSkils];
            }
            else
            {
                IndexSkils = 0;
                _currentSkill = _skills[IndexSkils];
            }

            _skilllBar.ShowCurrentSkill(_currentSkill);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0 )
        {
            Dying?.Invoke();
        }

        ChangedHealth?.Invoke(_currentHealth ,_maxhealth);
    }

    public void WillHeal(float health)
    {
        _currentHealth += health;
        ChangedHealth?.Invoke(_currentHealth, _maxhealth);
    }

    public void AppleDamage(AnimationManager animator )
    {
        _currentSkill.Action(ShootPoint, animator);
    }

    public void AddMoney(int money)
    {
        _money += money;
        DisplayCurrentBalance();
    }

    public void BuySkill(Skill skill)
    {
        SpendMoney(skill.Pryce);
        DisplayCurrentBalance();
        _skills.Add(skill);
    }

    public void LearnNewSkillRank(Skill updatedSkill)
    {
        for (int i = 0; i < _skills.Count; i++)
        {
            if (updatedSkill.Equals(_skills[i]))
            {
                _skills[i] = updatedSkill;
                SpendMoney(_skills[i].Pryce);
                DisplayCurrentBalance();
            }
        }
    }

    public void ChangedColor()
    {
        _renderer.color = Color.red;
    }

    public void ChangedStartColor()
    {
        _renderer.color = Color.white;
    }

    public void SetPosition(Transform pos)
    {
        gameObject.transform.position = pos.position;
    }

    private void DisplayCurrentBalance()
    {
        _coinMenu.ChangeMoney(_money);
    }

    private void SpendMoney(int money)
    {
        _money -= money;
    }
}
