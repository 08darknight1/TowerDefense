using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private EnemyData _enemyData;

    private NavMeshAgent _navMeshAgent;


    void Start()
    {
        _enemyData = gameObject.GetComponent<EnemyData>();
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_enemyData._enemyType)
        {
            case EnemyType.Saboteur:

            break;

            default:
                var playerBase = GameObject.FindGameObjectWithTag("PlayerHQ");
                _navMeshAgent.SetDestination(playerBase.transform.position);
            break;
        }
    }

    public EnemyData ReturnEnemyData()
    {
        return _enemyData;
    }
}
