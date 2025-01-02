using UnityEngine;

public class TriggerTrade : MonoBehaviour
{
    private Seller _seller;

    private void Start()
    {
        _seller = gameObject.GetComponent<Seller>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (collision.TryGetComponent(out Client client))
                if(!client.IsTrade)
                    _seller.TryStartTrade(client);
    }
}
