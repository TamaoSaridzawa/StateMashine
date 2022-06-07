using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundDressingHealth : MonoBehaviour
{
    [SerializeField] private Skill _woundDressing;
    private float _maxProcetnt = 100;

    private Player _player;

    private float _amountHealth;

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void Health()
    {
        _amountHealth = (_player.MaxHealth - _player.CurrentHealth) / _maxProcetnt * _woundDressing.Power;
        _player.WillHeal(_amountHealth);
    }
}
