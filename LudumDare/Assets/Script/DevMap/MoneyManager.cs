using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int money;
    [SerializeField] private GameObject moneyText;

    void Start()
    {
        ChangeMoneyText();
    }

    void ChangeMoneyText()
    {
        moneyText.GetComponent<TMPro.TextMeshProUGUI>().text = money.ToString();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        ChangeMoneyText();
    }

    public void SubtractMoney(int amount)
    {
        money -= amount;
        ChangeMoneyText();
    }
}
