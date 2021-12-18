using UnityEngine;

public class TargetReachDistanceTransition : Transition
{
    [SerializeField] private float distance;
    
    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) > distance) return;

        NeedTransit = true;
    }
}
