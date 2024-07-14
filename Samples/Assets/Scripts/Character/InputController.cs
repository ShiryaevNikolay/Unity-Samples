using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    public Vector2 LookDirection { get; private set; }

    private GameInput _gameInput;

    private void Awake() {
        _gameInput = new GameInput();
    }

    private void OnEnable() {
        _gameInput.Enable();
    }

    private void OnDisable() {
        _gameInput.Disable();
    }

    private void Update() {
        MoveDirection = _gameInput.Player.Move.ReadValue<Vector2>();
        LookDirection = _gameInput.Player.Look.ReadValue<Vector2>();
    }
}
