using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Collectible
{
    //player gameobject, will be set in OnTriggerEnter
    PlayerController player;

    //dash reset, set in inspector can adjust this to determine how quickly the new dash can be used
    float dashReset = 0;

    //oncollect is called when the user picks up the dash
    public override void OnCollect()
    {
        Debug.Log("Dash collected");
        if(player != null){
            player.remainingDashCooldown = dashReset;
            player.remainingDashDuration = dashReset;

            player.dashUsed = false;
        }   
    }

    //when the player enters the trigger, set the player gameobject and call oncollect
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            OnCollect();

            //wait 5 seconds, then respawn
            StartCoroutine(Timer(5));
        }
    }
}
