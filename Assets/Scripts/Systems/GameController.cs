using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameStage {LOADING, MAINMENU, PAUSE, GAMEPLAY, GAMEOVER}
public class GameController : MonoBehaviour
{
    private GameStage gameStage;

    public GameObject EnemyPrefab;

    public void DebugAddMoneyToPlayer(int ammount)
    {
        PlayerData.Money += ammount;
    }

    public void DebugSpawnNewEnemy()
    {
        var zeroQuaternion = new Quaternion(0, 0, 0, 0);
        Instantiate(EnemyPrefab, Vector3.zero, zeroQuaternion);
    }
}
