using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LogicSkill/LogicFire", order = 51)]
public class LogicSkillFire : LogicSkill
{
    [SerializeField] private FireDamage _fire;

    public override void Use(Transform pos)
    {
        _fire.CreateSkill(pos);
    }
}
