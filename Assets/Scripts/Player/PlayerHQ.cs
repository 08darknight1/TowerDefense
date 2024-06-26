using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHQ : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something enterred the collider!");

        if(other.tag == "Enemy")
        {
            var collidedEnemyData = other.gameObject.GetComponent<EnemyBehaviour>().ReturnEnemyData();

            switch(collidedEnemyData._enemyType)
            {
                case EnemyType.Bomber:
                    PlayerData.Life -= collidedEnemyData._enemyDamage;
                    Destroy(other.gameObject);
                break;

                default:
                    PlayerData.Life -= collidedEnemyData._enemyDamage;
                break;
            }
        }
    }
}
