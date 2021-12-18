using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Weapon.Base.Weapon initialWeapon;
        [SerializeField] private List<Weapon.Base.Weapon> weapons;
        [SerializeField] private Transform crosshair;
        [SerializeField] private new Camera camera;
    
        [SerializeField] private UnityEvent<Weapon.Base.Weapon> fired;
        [SerializeField] private UnityEvent<Weapon.Base.Weapon> weaponChanged;
    
        private const float PointDistance = 150f;
        private Weapon.Base.Weapon _weaponNow;
        private int _currentIndex;
        private PlayerInput _playerInput;
    
        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.Fire.performed += (ctx) =>
            {
                if(_weaponNow.IsSingle)
                    Fire();
            };
        }

        private void Start()
        {
            ChangeWeapon(initialWeapon);
            _currentIndex = weapons.IndexOf(initialWeapon);
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
            var scrollValue = _playerInput.Player.Scroll.ReadValue<float>();

            if (scrollValue > 0)
            {
                if(_currentIndex + 1 < weapons.Count)
                    ChangeWeapon(weapons[++_currentIndex]);
            } else if (scrollValue < 0)
            {
                if(_currentIndex - 1 >= 0)
                    ChangeWeapon(weapons[--_currentIndex]);
            }

            var mouseClickValue = _playerInput.Player.Fire.ReadValue<float>();
        
            if(Math.Abs(mouseClickValue - 1) < 0.01 && !_weaponNow.IsSingle)
                Fire();
        }

        private void ChangeWeapon(Weapon.Base.Weapon nextWeapon)
        {
            if (_weaponNow != null) 
                _weaponNow.gameObject.SetActive(false);
        
            _weaponNow = nextWeapon;
            _weaponNow.gameObject.SetActive(true);
            weaponChanged?.Invoke(_weaponNow);
        }

        private void Fire()
        {
            Ray ray = camera.ScreenPointToRay(crosshair.transform.position);
            Vector3 point = ray.GetPoint(PointDistance);
            _weaponNow.Shoot(point);  
            fired?.Invoke(_weaponNow);
        }

        public void AddBulletsToCurrentWeapon(int count)
        {
            _weaponNow.SetBulletCount(_weaponNow.BulletCount + count);
        }
    }
}
