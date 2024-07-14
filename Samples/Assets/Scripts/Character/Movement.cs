using UnityEngine;

public class Movement
{
    private float _speed;
    private Transform _object;

    public Movement(Transform gameObject, float speed)
    {
        _object = gameObject;
        _speed = speed;
    }

    public void Move(Vector2 direction)
    {
        // Обрабатываем мертвую зону
        if (direction.sqrMagnitude < 0.1f)
            return;

        float scaledMoveSpeed = _speed * Time.deltaTime;
        Vector3 offset = new Vector3(direction.x, 0f, direction.y) * scaledMoveSpeed;
        
        _object.transform.Translate(offset);
    }
}
