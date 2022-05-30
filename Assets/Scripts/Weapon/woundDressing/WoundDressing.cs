using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/WoundDressing", order = 51)]
public class WoundDressing : Skill
{
    public override void Action(Transform position)
    {
        LogicSkill.Use(position);
    }

    public override string ShowInfo()
    {
        return Description = $"√ерой перевызывает раны, исцел€€ себ€ на {CurrentSkillPower} процентов от недостающего здоровь€";
    }
}
