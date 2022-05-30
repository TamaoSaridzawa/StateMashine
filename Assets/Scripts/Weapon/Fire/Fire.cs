using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Fire", order = 51)]
public class Fire : Skill
{
    [SerializeField ]private int _numberCharges = 10;
   

    public override void Action(Transform startPointShoot)
    {
        LogicSkill.Use(startPointShoot);
    }

    public override string ShowInfo()
    {
       return Description = $"Шар огня, наносящий {CurrentSkillPower} урона множествам целям";
    }

}
