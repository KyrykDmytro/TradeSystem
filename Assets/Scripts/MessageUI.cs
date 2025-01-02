using TMPro;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    private TextMeshProUGUI _message;

    private string _lastMessages;

    private void Start()
    {
        _message = gameObject.GetComponent<TextMeshProUGUI>();    
    }

    private void Clean()
    {
        _message.text = "";
    }

    private void CleanLastMessage()
    {
        if (_message.text == _lastMessages)
        {
            Clean();
            _lastMessages = "";
        }
        else
        {
            _lastMessages = _message.text;
        }
    }

    public void SendMessageUI(string message)
    {
        Clean();
        _message.text = message;
        Invoke("CleanLastMessage", 5);
    }
}
