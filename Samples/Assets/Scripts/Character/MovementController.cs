using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private GameInput _gameInput;

    private void Awake()
    {
        _gameInput = new GameInput();
    }

    private void OnEnable()
    {
        _gameInput.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

    private void Update()
    {
        Vector2 moveDirection = _gameInput.Player.Move.ReadValue<Vector2>();
        Move(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _speed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);
        transform.position += moveDirection * scaledMoveSpeed;
    }
}
