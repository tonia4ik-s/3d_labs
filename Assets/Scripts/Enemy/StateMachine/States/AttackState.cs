using UnityEngine;

public class AttackState : State
{
    [SerializeField] private EnemyWeapon weapon;

    private void Update()
    {
        weapon.TryShoot(Target.transform.position);
    }
}
