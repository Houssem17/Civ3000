using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TigerFollow : MonoBehaviour
{
    public float speed;
    private Transform tiger;
    // Start is called before the first frame update
    void Start()
    {
        tiger = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, tiger.position, speed * Time.deltaTime);
    }

   
}
