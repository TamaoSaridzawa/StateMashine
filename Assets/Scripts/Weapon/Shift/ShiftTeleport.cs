using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftTeleport : MonoBehaviour
{
    private Transform _initTeleportPoint;
     private Player _player;

    public void SetTeleportPoint(Transform teleport, Player player)
    {
        _initTeleportPoint = teleport;
        _player = player;
    }

    public void Teleport()
    {
        _player.SetPosition(_initTeleportPoint);
    }
}
