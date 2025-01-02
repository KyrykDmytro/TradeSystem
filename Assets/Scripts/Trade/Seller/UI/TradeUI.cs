using TMPro;
using UnityEngine;

public class TradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _sellerName;
    [SerializeField] private OfferTaskUI _offerTaskUI;

    private Seller _currentSeller;

    private void Refresh()
    {
        _sellerName.text = _currentSeller.Name;
        _offerTaskUI.Refresh(_currentSeller);
        gameObject.SetActive(true);
    }

    private void Clean()
    {
        _offerTaskUI.Clean();
        if (_sellerName != null)
            _sellerName.text = "";
    }

    public void StartTrade(Seller seller)
    {
        _currentSeller = seller;
        Refresh();
    }

    public void StopTrade()
    {
        _currentSeller?.StopTrade();
        _currentSeller = null;
        gameObject.SetActive(false);
        Clean();
    }
}
