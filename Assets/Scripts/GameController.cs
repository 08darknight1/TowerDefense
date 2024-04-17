using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameStage {LOADING, MAINMENU, PAUSE, GAMEPLAY, GAMEOVER}
public class GameController : MonoBehaviour
{
    private GameStage gameStage;

    public void DebugAddMoneyToPlayer(int ammount)
    {
        PlayerData.Money += ammount;
    }
}
