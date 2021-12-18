using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReachRayTransition : Transition
{
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected float rayDistance;
    [SerializeField] protected Transform rayStartPoint;

    private List<RaycastHit2D> _hitResults;

    private void Start()
    {
        _hitResults = new List<RaycastHit2D>();
    }
    
    private void Update()
    {
        {
            Debug.DrawRay(rayStartPoint.position, rayStartPoint.forward * 100);
            var hit = Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, 
                out RaycastHit hitInfo, rayDistance, layerMask);

            if(!hit) return;
            
            Debug.Log(hitInfo.collider.gameObject.name);
            if (hitInfo.collider.gameObject.Equals(Target.gameObject))
            {
                NeedTransit = true;
            }
        }
    }
}
