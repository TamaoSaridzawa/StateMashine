using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Shift", order = 51)]
public class Shift : Skill
{
    public override void Action(Transform pos, AnimationManager animator)
    {
        animator.Shift();
        LogicSkill.Use(pos);
    }

    public override string ShowInfo()
    {
        return Description = $"����� ������������, ������� ��������� ����������� ��������� �� �������� ���������";
    }
}
