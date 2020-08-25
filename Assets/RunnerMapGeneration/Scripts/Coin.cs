using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public static int coinCount = 0;

    private void OnTriggerEnter2D(Collider2D collider) {
        Player player = collider.GetComponent<Player>();
        if (player != null) {
            coinCount++;
            CoinWindow.SetCoinCount(coinCount);
            Destroy(gameObject);
        }
    }

    public static void ResetCoinCount() {
        coinCount = 0;
    }

}
