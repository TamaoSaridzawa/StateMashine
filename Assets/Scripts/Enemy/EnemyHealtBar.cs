using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealtBar : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _text.text = _enemy.MaxHealth.ToString();
        _slider.value = 1;
    }

    private void OnEnable()
    {
        _enemy._changedHealth += OnChangedHealt;
    }

    private void OnDisable()
    {
        _enemy._changedHealth -= OnChangedHealt;
    }

    public void OnChangedHealt(float _currentHealth, float _maxhealth)
    {
        _slider.value = _currentHealth / _maxhealth;
        _text.text = _currentHealth.ToString();
    }
}
