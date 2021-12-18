using System;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class CameraLook : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Vector2 _rotation;
    
    [SerializeField] private UnityEvent<Vector3> look;
    [SerializeField] private float lookSpeed;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rotation = new Vector2();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var looking = _playerInput.Camera.Look.ReadValue<Vector2>();
        Look(looking);
    }
    
    private void Look(Vector2 direction)
    {
        if(direction.sqrMagnitude < 0.2) return;
        direction *= lookSpeed * Time.deltaTime;

        _rotation.x -= direction.y;
        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);
        
        transform.localRotation = Quaternion.Euler(_rotation.x, 0f, 0f);
        look?.Invoke(Vector3.up * direction.x);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
