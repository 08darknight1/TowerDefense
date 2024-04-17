using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUIController : MonoBehaviour
{
    private TextMeshProUGUI _playerMoneyText;

    private PlayerData _playerData;

    // Start is called before the first frame update
    void Start()
    {
        _playerMoneyText = gameObject.transform.Find("PlayerMoneyText").GetComponent<TextMeshProUGUI>();
        _playerData = GameObject.Find("Player").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerMoneyText.text = _playerData.ReturnPlayerMoney().ToString();
    }
}
