using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Fire", order = 51)]
public class Fire : Skill
{
    public override void Action(Transform startPointShoot, AnimationManager animator)
    {
        animator.FireBall();
        LogicSkill.Use(startPointShoot);
    }

    public override string ShowInfo()
    {
       return Description = $"Шар огня, наносящий {CurrentSkillPower} урона множествам целям";
    }

}
