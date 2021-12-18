using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject particle;
    [SerializeField] private float lifeTime;
    
    private Vector3 _direction;
    private Vector3 _lastPosition;

    public void Init(Vector3 direction)
    {
        _direction = direction;
        _lastPosition = transform.position;
        StartCoroutine(DestroyIfLifeTimeEnd());
        GetComponent<Rigidbody>().AddForce(_direction * speed, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(DestroyIfLifeTimeEnd));
    }

    private void Update()
    {
        if (Physics.Linecast(_lastPosition, transform.position, out var hit, layerMask))
        {
            if (hit.collider.TryGetComponent(out Target target))
            {
                target.ApplyDamage(damage);
            }
            
            Instantiate(particle, hit.point, Quaternion.LookRotation(-hit.normal));
            Destroy(particle, 2);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyIfLifeTimeEnd()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
