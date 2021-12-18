using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLeftDistanceTransition : Transition
{
    [SerializeField] private float distance;
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) < distance) return;

        NeedTransit = true;
    }
}
