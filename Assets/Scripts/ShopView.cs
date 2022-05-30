using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _sellButton;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _rang;

    public event UnityAction<Skill, ShopView> SellButtonClick;

    private Skill _skill;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Skill skill)
    {
        _icon.sprite = skill.Icon;
        _description.text = skill.ShowInfo();
        _price.text = "Цена -" + skill.Pryce.ToString();
        _rang.text = "Ранг -" + skill.Rang;
        _skill = skill;
    }

   public void DescriptionChange(Skill skill)
   {
        if (skill.Rang > skill.MaxRang - 1)
        {
            DisableSalesButton();
        }
        else
        {
            skill.RaiseRang();
            Render(skill);
        }
   }

    private void DisableSalesButton()
    {
        _sellButton.gameObject.SetActive(false);
        _rang.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        SellButtonClick?.Invoke(_skill, this);
    }
}
