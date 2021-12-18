using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Weapon.Base
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private new string name;
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected Transform shootPoint;
        [SerializeField] private bool isSingle;
        [SerializeField] private float timeBetweenAttacks;
        [SerializeField] private int bulletCount;
        
        public UnityAction<int> BulletCountChanged { get; set; }

        public string Name => name;

        public int BulletCount => bulletCount;
        public bool IsSingle => isSingle;
        protected bool CanShoot { get; set; } = true;

        private bool HasBullets => bulletCount > 0;

        private void OnDisable()
        {
            CanShoot = true;
        }

        public abstract void Shoot(Vector3 targetPoint);

        protected bool TryCreateBullet(Vector3 targetPoint)
        {
            if (!HasBullets) return false;

            var transform1 = shootPoint.transform;
            var createdBullet = Instantiate(bullet, transform1.position, transform1.rotation);
            var direction = (targetPoint - createdBullet.transform.position).normalized;
            createdBullet.Init(direction);
            SetBulletCount(--bulletCount);

            return true;
        }

        public void SetBulletCount(int count)
        {
            bulletCount = count;
            BulletCountChanged?.Invoke(bulletCount);
        }

        protected IEnumerator WaitForPauseEnd()
        {
            yield return new WaitForSeconds(timeBetweenAttacks);
            CanShoot = true;
        }
    }
}
