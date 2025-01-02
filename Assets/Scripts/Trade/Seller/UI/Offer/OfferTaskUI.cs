using System.Collections.Generic;
using UnityEngine;

public class OfferTaskUI : MonoBehaviour
{
    [SerializeField][Min(0)] private float _sizeBetweenOffers;
    [SerializeField] private GameObject _offerPrefab;
    [SerializeField] private Transform _startPositionOffers;

    private Stack<GameObject> _cerrentOfferts = new Stack<GameObject>();

    public void Clean(){
        while (_cerrentOfferts.Count != 0)
            Destroy(_cerrentOfferts.Pop());
    }
            
    public void Refresh(Seller seller)
    {
        Clean();
        int countOfferts = 0;
        foreach (var offer in seller.Offers)
        {
            var newPosition = _startPositionOffers.position;
            newPosition.y -= _sizeBetweenOffers * countOfferts;

            var newOffer = Instantiate(_offerPrefab, gameObject.transform);
            newOffer.transform.position = newPosition;

            newOffer.GetComponent<OffertUI>().SetOffer(offer, seller);

            _cerrentOfferts.Push(newOffer);
            countOfferts++;
        }    
    }

}