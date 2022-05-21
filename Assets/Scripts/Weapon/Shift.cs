using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Shift", order = 51)]
public class Shift : Skill
{
    [SerializeField] private Transform _teleportPoint;
    [SerializeField] private Player _player;

    public override void Action(Transform pos)
    {
        _player.transform.position = _teleportPoint.position;
    }
}
