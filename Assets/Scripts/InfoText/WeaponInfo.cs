using System;
using Player.Weapon.Base;
using UnityEngine;
using UnityEngine.UI;

namespace InfoText
{
    public class WeaponInfo : MonoBehaviour
    {
        [SerializeField] private Text nameText;
        [SerializeField] private Text bulletCountText;
        
        private Weapon _currentWeapon;

        private void OnDisable()
        {
            _currentWeapon.BulletCountChanged -= OnWeaponBulletCountChanged;
        }

        public void OnWeaponChanged(Weapon weapon)
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.BulletCountChanged -= OnWeaponBulletCountChanged;
            }
            
            SetInfo(weapon);
            
            _currentWeapon = weapon;
            _currentWeapon.BulletCountChanged += OnWeaponBulletCountChanged;
        }

        private void SetInfo(Weapon weapon)
        {
            nameText.text = $"weapon: {weapon.Name}";
            bulletCountText.text = $"Bullets: {weapon.BulletCount}";
        }

        private void OnWeaponBulletCountChanged(int count)
        {
            bulletCountText.text = $"Bullets: {count}";
        }
    }
}
