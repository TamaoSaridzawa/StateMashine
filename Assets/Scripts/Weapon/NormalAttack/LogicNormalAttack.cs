using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LogicSkill/LogicNormalAttack", order = 51)]
public class LogicNormalAttack : LogicSkill
{
    [SerializeField] private NormalAttackDamage _normalAttack;

    public override void Use(Transform position)
    {
        _normalAttack.CreateSkill(position);
    }
}
