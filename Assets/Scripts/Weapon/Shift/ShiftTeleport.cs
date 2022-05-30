using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftTeleport : MonoBehaviour
{
    //[SerializeField] Shift _shift;
    private Transform _initTeleportPoint;
     private Player _player;

    public void SetTeleportPoint(Transform teleport, Player player)
    {
        _initTeleportPoint = teleport;
        _player = player;
        //_player.SetPosition(_teleportPoint);
        //_player = player;
    }

    public void Teleport()
    {
        _player.SetPosition(_initTeleportPoint);
    }
}
