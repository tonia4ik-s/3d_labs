using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State targetState;

    public State TargetState => targetState;
    
    public bool NeedTransit { get; protected set; }

    protected PlayerPrime Target { get; set; }

    protected virtual void OnDisable()
    {
        if(NeedTransit)
            NeedTransit = false;
    }

    public void TrySetTarget(PlayerPrime target)
    {
        if(Target != null) return;

        Target = target;
    }
}
