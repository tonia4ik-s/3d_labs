using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLeftRayTransition : Transition
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
            var hit = Physics.Raycast(rayStartPoint.position, rayStartPoint.forward, 
                out RaycastHit hitInfo, rayDistance, layerMask);

            if (!hit) NeedTransit = true;
        }
    }
}
