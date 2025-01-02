using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Seller : MonoBehaviour
{
    [field: SerializeField] public string Name { get; private set; }

    [SerializeField] private TradeUI _tradeUI;
    [SerializeField] private List<Offer> _offers;

    private Client _currentClient;

    public IEnumerable<Offer> Offers => _offers;

    public bool TryStartTrade(Client client)
    {
        if (_currentClient != null) return false;
        _currentClient = client;
        _currentClient.IsTrade = true;
        _tradeUI.StartTrade(this);
        return true;
    }
    
    public void StopTrade()
    {
        _currentClient.IsTrade = false;
        _currentClient = null;
    }

    public TransactionResult TrySellOffer(int idOffer)
    {
        var offer = _offers.Where(offer => offer.ID == idOffer).FirstOrDefault();

        if (offer == null) Debug.LogException(new ArgumentException());
        if (!_currentClient.Wallet.IsEnoughMoney(offer.Cost)) return TransactionResult.NotEnoughCost;
        if (offer.Count <= 0) return TransactionResult.NotEnoughCost;

        _currentClient.Wallet.ReduceMoney(offer.Cost);
        offer.Work?.Invoke();
        offer.Count--;
        return TransactionResult.Successful;
    }
}
