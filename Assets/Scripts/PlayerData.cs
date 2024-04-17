using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _money;

    [SerializeField] private int _life = 3;

    public int ReturnPlayerLife()
    {
        return _life;
    }

    public int ReturnPlayerMoney()
    {
        return _money;
    }

    public void ChangePlayerMoney(int money)
    {
        _money += money;
    }
}
