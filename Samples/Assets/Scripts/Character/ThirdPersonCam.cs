using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] private Transform _player;

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private CameraStyle _currentStyle;

    private Mover _playerMover;
    private Transform _orientation;
    private Transform _playerObject;
    private Transform _combatLookAt;

    public enum CameraStyle
    {
        Basic,
        Combat
    }

    private void Awake()
    {
        _playerObject = _player.Find("PlayerObj");
        _playerMover = _player.GetComponent<Mover>();
        _orientation = _player.Find("Orientation");
        _combatLookAt = _orientation.Find("CombatLookAt");
    }

    private void Update()
    {
        // Ориентация поворота. Вычисляем вектор "Вперед" - вектор от камеры к игроку
        Vector3 viewDirection = _player.position - new Vector3(transform.position.x, _player.position.y, transform.position.z);
        _orientation.forward = viewDirection.normalized;

        // Поворачиваем игровой объект
        // Если стиль камеры `Basic`, то камера просто задает движение вперед для игрока.
        // Игрок при этом может смотреть на камеру
        if (_currentStyle == CameraStyle.Basic)
        {
            Vector2 inputDirection = _playerMover.MoveDirection;
            Vector3 moveDirection = _orientation.forward * inputDirection.y + _orientation.right * inputDirection.x;

            if (moveDirection != Vector3.zero)
            {
                _player.forward = Vector3.Slerp(_player.forward, moveDirection.normalized, Time.deltaTime * _rotationSpeed);
            }
        }
        // Иначе, если стиль камеры `Бой`, то игрок будет всегда смотреть в прицел
        else if (_currentStyle == CameraStyle.Combat)
        {
            Vector3 directionToCombatLookAt = _combatLookAt.transform.position - new Vector3(transform.position.x, _combatLookAt.transform.position.y, transform.position.z);
            _orientation.forward = directionToCombatLookAt.normalized;

            _playerObject.forward = directionToCombatLookAt.normalized;
        }
    }
}
