using UnityEngine.AI;

public class FollowState : State
{
    private NavMeshAgent _navMeshAgent;
    
    private void OnDisable()
    {
        _navMeshAgent.ResetPath();
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(Target.transform.position);
    }
}
