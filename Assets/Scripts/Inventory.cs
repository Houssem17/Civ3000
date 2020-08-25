using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int coinCount;
    public int goldCount;
    public static Inventory instance;
    public Text coinsCountText;
    public Text goldCountText;
    public GameObject Wincont;
    public int targetValue=50;
    public int goldvalue=3;
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
     if(coinCount>=targetValue && goldCount<goldvalue){
         Wincont.SetActive(true);
         SceneManager.LoadScene("Level2");

     }else{
         if(coinCount>=targetValue && goldCount>=goldvalue){
              Wincont.SetActive(true);
               SceneManager.LoadScene("PuzzleScene");
         }
     }
    }
    public void addCoins(int count)
    {
        coinCount += count;
        coinsCountText.text = coinCount.ToString();
        
       

    }

    public void addGold (int count)
    {
       goldCount += count;
        goldCountText.text = goldCount.ToString(); 
    }

}
