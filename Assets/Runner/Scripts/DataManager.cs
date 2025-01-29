using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Coin Text")]
    [SerializeField] TextMeshProUGUI[] coinsTexts;
    int coins;

    private void Awake() {
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
        }
        coins = PlayerPrefs.GetInt("coins", 0);
    }

    void Start()
    {
        UpdateCoinsTexts();
    }

    void UpdateCoinsTexts(){
        foreach (TextMeshProUGUI coinText in coinsTexts)
        {
            coinText.text = coins.ToString();
        }
    }

    public void AddCoins(int amount){
        coins += amount;
        UpdateCoinsTexts();
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.Save();
    }
}
