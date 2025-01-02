using UnityEngine;

public class Client : MonoBehaviour
{
    [field: SerializeField] public Wallet Wallet { get; private set; }
    
    public bool IsTrade = false;
}
