using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMoneyScript : MonoBehaviour
{
    public static AudioClip soundMoney;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        soundMoney = Resources.Load<AudioClip>("SoundMoney");
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "SoundMoney":
                audioSource.PlayOneShot(soundMoney);
                break;
        }
            
    }
}
