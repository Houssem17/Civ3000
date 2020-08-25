using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGame : MonoBehaviour
{
    Camera camera;
    Vector2 vector2;
    GameObject[] puzzlePiece;
    AllPuzzle allPuzzle;
    public float timeStart =60;
    public Text textBox;
    
    void OnMouseDrag()
    {
        Vector3 vector3 = camera.ScreenToWorldPoint(Input.mousePosition);
        vector3.z = 0;
        transform.position = vector3;
    }
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        vector2 = transform.position;
        puzzlePiece = GameObject.FindGameObjectsWithTag("Piece");
        allPuzzle = GameObject.Find("AllPuzzle").GetComponent<AllPuzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
        PlayerPrefs.SetFloat("timer", timeStart);
        if (Input.GetMouseButtonUp(0))
        {
            foreach(GameObject kutu in puzzlePiece)
            {
              
                if (kutu.name == gameObject.name)
                {
                    float ofs = Vector3.Distance(kutu.transform.position, transform.position);

                    if (ofs <= 1)
                    {
                        transform.position = kutu.transform.position;
                        allPuzzle.IncrementPuzzle();
                       
                        this.enabled = false;
                    }
                    else
                    {
                        transform.position = vector2;
                    }
                }
            }
        }
    }
}
