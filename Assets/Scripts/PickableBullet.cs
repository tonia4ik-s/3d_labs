using System;
using Player;
using UnityEngine;

public class PickableBullet : MonoBehaviour
{
    [SerializeField] private int bulletCount;

    private void OnValidate()
    {
        if (bulletCount < 0)
        {
            bulletCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerAttack playerAttack))
        {
            playerAttack.AddBulletsToCurrentWeapon(bulletCount);
            Destroy(gameObject);
        }
    }
}
