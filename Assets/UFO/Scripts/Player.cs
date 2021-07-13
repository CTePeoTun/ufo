using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SimpleTouchController _controller;
    [SerializeField] private Ray ray;
    
    private readonly float _moveSpeed = 4f;

    private void Update()
    {
        Vector2 positionTouch = _controller.GetTouchPosition;
        Vector3 direction = new Vector3(positionTouch.x, 0f, positionTouch.y);
        transform.Translate(direction * Time.deltaTime * _moveSpeed);
    }


}
