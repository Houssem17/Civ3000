using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpi : MonoBehaviour
{
    public PlayerPlatformerController playerPlatformerController;
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            // Player hit Spikes
            playerPlatformerController.Damage(20);
        }
    }

}
