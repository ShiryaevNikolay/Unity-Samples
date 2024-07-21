using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : GameInput.IPlayerActions
{

    public event Action<Vector2> MoveEvent;
    public event Action JumpEvent;
    public event Action JumpCancelledEvent;
    public event Action PauseEvent;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            JumpEvent?.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            JumpCancelledEvent?.Invoke();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseEvent?.Invoke();
        }
    }
}
