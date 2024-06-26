using TMPro;
using UnityEngine;

public class MainUIController : MonoBehaviour
{
    private TextMeshProUGUI _playerMoneyText, _playerLifeText;

    void Start()
    {
        _playerMoneyText = gameObject.transform.Find("PlayerMoneyText").GetComponent<TextMeshProUGUI>();
        _playerLifeText = gameObject.transform.Find("PlayerLifeText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _playerMoneyText.text = "Money: " + PlayerData.Money.ToString();
        _playerLifeText.text = "Life: " + PlayerData.Life.ToString();
    }
}
