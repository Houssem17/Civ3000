using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory1 : MonoBehaviour
{
    public int coinCount;
    //public int goldCount;
    public static Inventory1 instance;
    public Text coinsCountText1;
    //public Text goldCountText;
    public GameObject Wincont;
    public int targetValue=1;
    //public int goldvalue=3;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il ya deja une autre instance");
            return;
        }
        instance = this;
    }

    public void FixedUpdate(){
     if(coinCount>=targetValue ){
         Wincont.SetActive(true);
         SceneManager.LoadScene("MenuScene");

     }
    }
    public void addCoins(int count)
    {
        coinCount += count;
        coinsCountText1.text = coinCount.ToString();
        
       

    }


}
