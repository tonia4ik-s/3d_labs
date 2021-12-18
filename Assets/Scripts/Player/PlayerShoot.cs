using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Player.PlayerInput;

public class PlayerShoot : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Shoot.performed += OnShoot;
    }

    

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    
    private void OnShoot(InputAction.CallbackContext ctx)
    {
        
    }
}
