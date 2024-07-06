using UnityEngine;

[RequireComponent(typeof(InputController), typeof(Movement))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private InputController _inputController;

    private void OnEnable()
    {
        _inputController.InputAction += _movement.Move;
    }

    private void OnDisable()
    {
        _inputController.InputAction -= _movement.Move;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
