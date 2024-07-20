using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

// Можно создавать скрипт через ПКМ в редакторе Unity
[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject
{
    private GameInput _gameInput;
    private PlayerInputReader _playerInputReader = new PlayerInputReader();
    private UiInputReader _uiInputReader = new UiInputReader();

    public event Action<Vector2> MoveEvent;
    public event Action JumpEvent;
    public event Action JumpCancelledEvent;
    public event Action PauseEvent;
    public event Action ResumeEvent;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();

            _gameInput.Player.SetCallbacks(_playerInputReader);
            _gameInput.UI.SetCallbacks(_uiInputReader);

            SetPlayer();
        }
        observeActions();
    }

    private void OnDisable()
    {
        disableActions();
    }

    public void SetPlayer()
    {
        _gameInput.Player.Enable();
        _gameInput.UI.Disable();
    }

    public void SetUI()
    {
        _gameInput.Player.Disable();
        _gameInput.UI.Enable();
    }

    private void observeActions()
    {
        _playerInputReader.MoveEvent += handleMove;
        _playerInputReader.JumpEvent += handleJump;
        _playerInputReader.JumpCancelledEvent += handleJumpCancelled;
        _playerInputReader.PauseEvent += handlePause;

        _uiInputReader.ResumeEvent += handleResume;
    }

    private void disableActions()
    {
        _playerInputReader.MoveEvent -= handleMove;
        _playerInputReader.JumpEvent -= handleJump;
        _playerInputReader.JumpCancelledEvent -= handleJumpCancelled;
        _playerInputReader.PauseEvent -= handlePause;

        _uiInputReader.ResumeEvent -= handleResume;
    }

    private void handleMove(Vector2 direction)
    {
        MoveEvent?.Invoke(direction);
    }

    private void handleJump()
    {
        handleAction(JumpEvent);
    }

    private void handleJumpCancelled()
    {
        handleAction(JumpCancelledEvent);
    }

    private void handlePause()
    {
        handleAction(PauseEvent);
        SetUI();
    }

    private void handleResume()
    {
        handleAction(ResumeEvent);
        SetPlayer();
    }

    private void handleAction(Action action)
    {
        action?.Invoke();
    }
}
