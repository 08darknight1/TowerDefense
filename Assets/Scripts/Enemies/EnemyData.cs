using UnityEngine;

public enum EnemyType {Warrior, Trooper, Saboteur, Bomber}

public class EnemyData : MonoBehaviour
{
    public string _enemyName;

    public int _enemyLife;

    public int _enemyLevel;

    public int _enemyDamage;

    public EnemyType _enemyType;
}
