using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float speed;
    
        private PlayerInput _playerInput;
        private CharacterController _characterController;
        private float _moveModifier = 1f;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _characterController = GetComponent<CharacterController>();

            _playerInput.Player.Sprint.performed += _ => _moveModifier = 3f;
            _playerInput.Player.Sprint.canceled += _ => _moveModifier = 1f;
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void Update()
        {
            var direction = _playerInput.Player.Move.ReadValue<Vector2>();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            var scaledMoveSpeed = speed * _moveModifier * Time.deltaTime;
            var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
            _characterController.Move(move * scaledMoveSpeed);
        }
    }
}
