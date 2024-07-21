using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputReader _inputReader;

    public Vector2 MoveDirection { get; private set; }

    private void Start()
    {
        _inputReader.MoveEvent += HandleMove;
    }

    private void Update()
    {
        Move();
    }

    private void HandleMove(Vector2 direction)
    {
        MoveDirection = direction;
    }

    public void Move()
    {
        if (MoveDirection == Vector2.zero)
            return;
        // Обрабатываем мертвую зону
        if (MoveDirection.sqrMagnitude < 0.1f)
            return;

        float scaledMoveSpeed = _speed * Time.deltaTime;
        Vector3 offset = new Vector3(MoveDirection.x, 0f, MoveDirection.y) * scaledMoveSpeed;
        
        transform.Translate(offset);
    }
}
