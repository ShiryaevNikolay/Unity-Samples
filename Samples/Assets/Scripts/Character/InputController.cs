using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<Vector3> InputAction;

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
        Vector2 inputDirection = _gameInput.Player.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(inputDirection.x, 0f, inputDirection.y);
        InputAction?.Invoke(moveDirection);
    }
}
