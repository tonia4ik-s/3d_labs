using UnityEngine;

namespace Player.Weapon
{
    public class Rifle : Base.Weapon
    {
        public override void Shoot(Vector3 targetPoint)
        {
            if(!CanShoot) return;

            if (!TryCreateBullet(targetPoint)) return;
            
            CanShoot = false;
            StartCoroutine(WaitForPauseEnd());
        }
    }
}
