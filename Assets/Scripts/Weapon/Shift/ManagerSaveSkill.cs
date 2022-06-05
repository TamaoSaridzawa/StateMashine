using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSaveSkill : MonoBehaviour
{
    [SerializeField] ShiftTeleport _shift;
    [SerializeField] WoundDressingHealth _dressingHealth;
    [SerializeField] private Transform _teleportPoint;
    [SerializeField] private Player _player;

    public void InitTeleport()
    {
        _shift.SetTeleportPoint(_teleportPoint, _player);
    }

    public void InitDressingHealth()
    {
        _dressingHealth.SetPlayer(_player);
    }
}
