using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Skill> _skills;
    [SerializeField] private Player _player;
    [SerializeField] private ShopView _shopView;
    [SerializeField] GameObject _skillsContainer;

    private void Start()
    {
        for (int i = 0; i < _skills.Count; i++)
        {
            AddSkills(_skills[i]);
        }
    }

    public void AddSkills(Skill skill)
    {
        ShopView view = Instantiate(_shopView, _skillsContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(skill);
    }

    private void OnSellButtonClick(Skill skill, ShopView view)
    {
        if (_player.Money >= skill.Pryce)
        {
            if (skill.IsStudied)
            {
                BuyRankSkill(skill, view);
            }
            else
            {
                BuySkill(skill, view);
            }

            view.DescriptionChange(skill);
        }
    }

    private void BuySkill(Skill skill, ShopView view)
    {
            _player.BuySkill(skill);
            skill.Studied();
    }

    private void BuyRankSkill(Skill skill, ShopView view)
    {
        if (skill.Rang > skill.MaxRang)
        {
            view.SellButtonClick -= OnSellButtonClick;
        }
        else
        {
            _player.LearnNewSkillRank(skill);
        }
    }
}
