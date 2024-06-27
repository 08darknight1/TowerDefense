using UnityEngine;
using UnityEngine.AI;

public enum EnemyAiState {Idle, Walk, Attack, Sabotage, Die}


public class EnemyBehaviour : MonoBehaviour
{
    private EnemyData _enemyData;

    private NavMeshAgent _navMeshAgent;

    private EnemyAiState _enemyAiState;

    private NewTimer _timer;

    void Start()
    {
        _enemyData = gameObject.GetComponent<EnemyData>();
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _timer = gameObject.GetComponent<NewTimer>();

        SetNewAiState(1);
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteAiState();
    }

    private void ExecuteAiState()
    {
        switch (_enemyAiState)
        {
            case EnemyAiState.Idle:

                break;
            case EnemyAiState.Walk:
                //Precisaria ver pra selecionar outra target no caso dos sabotadores!
                var playerBase = GameObject.FindGameObjectWithTag("PlayerHQ");

                _navMeshAgent.SetDestination(playerBase.transform.position);
            break;
            case EnemyAiState.Attack:

            break;
            case EnemyAiState.Sabotage:

            break;
            case EnemyAiState.Die:
                _timer.Iniciar(1.5f);

                if (_timer.Sinalizar())
                {
                    PlayerData.Life -= _enemyData._enemyDamage;
                    Destroy(gameObject);
                }
            break;
        }
    }

    public void SetNewAiState(int stateIndex)
    {
        switch (stateIndex)
        {
            case 0: //IDLE
                Debug.Log(gameObject.name + " is gonna idle about...");
                _enemyAiState = EnemyAiState.Idle;
                break;
            case 1: //WALK
                Debug.Log(gameObject.name + " is gonna walk to player HQ!");
                _enemyAiState = EnemyAiState.Walk;
                break;
            case 2: //ATTK
                Debug.Log(gameObject.name + " is gonna attack the player HQ!");
                _enemyAiState = EnemyAiState.Attack;
                break;
            case 3: //SABO
                Debug.Log(gameObject.name + " is gonna sabotage a turret!");
                _enemyAiState = EnemyAiState.Sabotage;
                break;
            case 4: //DIES
                Debug.Log(gameObject.name + " is gonna die...");
                _enemyAiState = EnemyAiState.Die;
                break;
        }
    }

    public EnemyData ReturnEnemyData()
    {
        return _enemyData;
    }
}
