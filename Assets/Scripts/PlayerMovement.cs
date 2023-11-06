using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] [Range(0f, 100f)] private float speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        MoveToDirection();
    }
    
    private void OnMovement(InputValue value)
    {
        _direction = value.Get<Vector2>();
    }

    private void MoveToDirection()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction * (speed * Time.fixedDeltaTime));
    }
}
