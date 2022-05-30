using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Skill/NormalAttack", order = 51)]
public class NormalAttack : Skill
{
    //[SerializeField] private Transform _pointAtack;
    //private Transform _curentPos;
    public override void Action(Transform pos)
    {
        LogicSkill.Use(pos);
    }

    public override string ShowInfo()
    {
        return Description = $"Мощный удар ближнего боя наносящий {CurrentSkillPower} урона одиночным целям";
    }

    //private void OnDrawGizmosSelected()
    //{
    //    if (_curentPos == null)
    //    {
    //        return;
    //    }
    ////    Gizmos.DrawSphere(_curentPos.position, _distanceAtack);
    //}
}
