using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LogicSkill/LogicShift", order = 51)]

public class LogicSkillShift : LogicSkill
{
    [SerializeField] private ShiftTeleport _shift;

    public override void Use(Transform position)
    {
        _shift.Teleport();
    }
}
