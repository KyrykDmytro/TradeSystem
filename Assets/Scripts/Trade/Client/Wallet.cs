using System;
using UnityEngine;

[Serializable] 
public class Wallet
{
    [field: SerializeField] public int Balance { get; private set; }
    
    public bool IsEnoughMoney(int money) => Balance >= money;

    public void AddMoney(int money)
    {
        Balance += money;
    }

    public void ReduceMoney(int money)
    {
        if (!IsEnoughMoney(money)) 
            Debug.LogException(new InvalidOperationException("Not enough money"));
        Balance -= money;
    }
}
