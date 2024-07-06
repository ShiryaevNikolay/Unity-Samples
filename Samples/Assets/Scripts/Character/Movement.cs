using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        float distance = _speed * Time.deltaTime;
        transform.position += direction * distance;
    }
}
