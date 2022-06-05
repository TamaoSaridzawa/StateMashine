using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Sword", order = 51)]

public class Sword : Skill
{
    public override void Action(Transform startPointShoot)
    {
        LogicSkill.Use(startPointShoot);

    }

    public override string ShowInfo()
    {
        return Description = $"Взмах мечом создающий волну, наносящая {CurrentSkillPower} урона одиночным целям";
    }

}
