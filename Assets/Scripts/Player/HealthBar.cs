using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] Slider _slider;
    [SerializeField] TMP_Text _text;

    private void Start()
    {
        _text.text = _player.MaxHealth.ToString();
        _slider.value = 1;
    }

    private void OnEnable()
    {
        _player.ChangedHealth += OnChangedHealt;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnChangedHealt;
    }

    public void OnChangedHealt(float _currentHealth, float _maxhealth)
    {
        _slider.value = _currentHealth / _maxhealth ;
        _text.text = _currentHealth.ToString();
    }
}
