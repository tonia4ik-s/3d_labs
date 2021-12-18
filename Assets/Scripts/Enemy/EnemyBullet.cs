using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float liveTime;
    
    private Vector3 _lastPosition;
    
    public void Init(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        _lastPosition = transform.position;
        StartCoroutine(DestroyIfLifeTimeEnd());
    }
    
    private void Update()
    {
        if (Physics.Linecast(_lastPosition, transform.position, out var hit, layerMask))
        {
            if (hit.collider.TryGetComponent(out PlayerPrime playerBase))
            {
                playerBase.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyIfLifeTimeEnd()
    {
        yield return new WaitForSeconds(liveTime);
        Destroy(gameObject);
    }
}
