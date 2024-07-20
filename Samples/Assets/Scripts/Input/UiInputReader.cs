using System;
using UnityEngine.InputSystem;

public class UiInputReader : GameInput.IUIActions
{
    public event Action ResumeEvent;

    public void OnResume(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ResumeEvent?.Invoke();
        }
    }
}
