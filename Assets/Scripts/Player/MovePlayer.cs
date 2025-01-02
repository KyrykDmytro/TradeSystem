using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var shiftVector = new Vector3(x, y);
        transform.position += shiftVector * _speed * Time.deltaTime;   
    }
}
      