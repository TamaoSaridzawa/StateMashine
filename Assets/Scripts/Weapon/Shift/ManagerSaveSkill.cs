using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSaveSkill : MonoBehaviour
{
    [SerializeField] ShiftTeleport _shift;
    [SerializeField] WoundDressingHealth _dressingHealth;
    [SerializeField] private Transform _teleportPoint;
    [SerializeField] private Player _player;
    //[SerializeField] private Player _player;

    //void Update()
    //{
    //    _shift.SetTeleportPoint(_teleportPoint);
    //}

    public void InitTeleport()
    {
        _shift.SetTeleportPoint(_teleportPoint, _player);
        //_player.SetPosition(_teleportPoint);
        //_player = player;
    }

    public void InitDressingHealth()
    {
        _dressingHealth.SetPlayer(_player);
    }
}
