using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkilllBar : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public void ShowCurrentSkill(Skill skill)
    {
        _icon.sprite = skill.Icon;
    }
}
