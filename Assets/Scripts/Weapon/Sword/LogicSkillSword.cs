using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="LogicSkill/LogicSword", order = 51)]
public class LogicSkillSword : LogicSkill
{
    [SerializeField] private SwordDamage _sword;
   /* [SerializeField]*/ bool isAerial = true;

    public override void Use(Transform position)
    {
        _sword.CreateSkill(position, isAerial);
    }
}
