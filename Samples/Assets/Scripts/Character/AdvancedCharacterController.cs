using UnityEngine;

[RequireComponent(typeof(InputController))]
public class AdvancedCharacterController : MonoBehaviour
{
    private Movement _movement;
    [SerializeField] private InputController _inputController;

    private void Awake()
    {
        _movement = new Movement(
            gameObject: transform,
            speed: 10
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _moveDirection = _inputController.MoveDirection;
        Vector2 _lookDirection = _inputController.LookDirection;
        _movement.Move(_moveDirection);
    }
}
