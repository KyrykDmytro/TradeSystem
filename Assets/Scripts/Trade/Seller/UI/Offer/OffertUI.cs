using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OffertUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private TextMeshProUGUI _commodity;
    [SerializeField] private Button _buy;

    //private

    private Offer _offer;

    public void SetOffer(Offer offer, Seller seller)
    {
        _offer = offer;
        _buy.onClick.AddListener(() => { 
            seller.TrySellOffer(_offer.ID);
            Refresh();
        });  
        Refresh();
    }
    private void Refresh()
    {
        _commodity.text = "text";
        _cost.text = string.Format("Cost: {0}", _offer.Cost);
        _count.text = string.Format("In stock: {0}", _offer.Count);
    }
}
