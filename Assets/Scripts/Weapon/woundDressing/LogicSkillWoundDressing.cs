using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LogicSkill/LogicWoundDressing", order = 51)]
public class LogicSkillWoundDressing : LogicSkill
{
    [SerializeField] private WoundDressingHealth _woundDressing;
  
    public override void Use(Transform position)
    {
        _woundDressing.Health();
    }


}
