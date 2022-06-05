using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Sword", order = 51)]

public class Sword : Skill
{
    public override void Action(Transform startPointShoot, AnimationManager animator)
    {
        animator.Sword();
        LogicSkill.Use(startPointShoot);

    }

    public override string ShowInfo()
    {
        return Description = $"����� ����� ��������� �����, ��������� {CurrentSkillPower} ����� ��������� �����";
    }

}
