using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinWindow : MonoBehaviour {

    private static CoinWindow instance;
    private Text coinText;

    private void Awake() {
        instance = this;
        coinText = transform.Find("coinText").GetComponent<Text>();
        SetCoinCount(0);
    }

    public static void SetCoinCount(int coinCount) {
        instance.coinText.text = coinCount.ToString();
    }

}
