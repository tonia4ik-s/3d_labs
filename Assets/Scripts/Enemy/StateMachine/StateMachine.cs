using Player;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State startState;
    [SerializeField] private PlayerPrime target;
        
    private State _currentState;

    private void Start()
    {
        ChangeState(startState);
    }

    private void Update()
    {
        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            ChangeState(nextState);
        } 
    }

    private void ChangeState(State nextState)
    {
        if(_currentState != null)
            _currentState.Exit();

        _currentState = nextState;
        
        _currentState.TrySetTarget(target);
        _currentState.Enter();
    }
}