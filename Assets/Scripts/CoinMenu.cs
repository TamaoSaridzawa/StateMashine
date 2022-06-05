using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _coin;

    public void ChangeMoney(int money)
    {
        _coin.text = money.ToString();
    }
}
