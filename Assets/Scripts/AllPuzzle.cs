using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class AllPuzzle : MonoBehaviour
{
    PuzzleGame puzzleGame;
    int initialPuzzle = 0;
    int allPuzzle = 9;
    public GameObject gameObject;
    public GameObject loseObject;
    public GameObject etat;
    private int saveEtat = 0;
    




    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void IncrementPuzzle()
    {
        initialPuzzle++;
    }
   
    // Update is called once per frame
    void Update()
    {

        float timer = PlayerPrefs.GetFloat("timer");
      
        if (initialPuzzle == allPuzzle)
        {
            gameObject.SetActive(true);

            Invoke("loadScene", 2);
            PlayerPrefs.SetInt("win", 1);
            // loseObject.SetActive(true);
        }

        else
        {
            if (timer <= 0)
            {
                loseObject.SetActive(true);
                gameObject.SetActive(false);
               
                
                PlayerPrefs.SetInt("win", 0);
                
            }
        }

        
    }

   void loadScene()
    {
        SceneManager.LoadScene("Level2");
    }

   
}
