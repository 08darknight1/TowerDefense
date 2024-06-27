using UnityEngine;

public class PlayerHQ : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something enterred the collider!");

        if(other.tag == "Enemy")
        {
            Debug.Log("An Enemy has enterred my collider!");
            
            var collidedEnemy = other.gameObject.GetComponent<EnemyBehaviour>();

            switch(collidedEnemy.ReturnEnemyData()._enemyType)
            {
                case EnemyType.Bomber:
                    collidedEnemy.SetNewAiState(4);
                break;
            }
        }
    }
}
