using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Skill/NormalAttack", order = 51)]
public class NormalAttack : Skill
{
    public override void Action(Transform pos, AnimationManager animator)
    {
        animator.Attack();
        LogicSkill.Use(pos);
    }

    public override string ShowInfo()
    {
        return Description = $"Мощный удар ближнего боя наносящий {CurrentSkillPower} урона одиночным целям";
    }
}
