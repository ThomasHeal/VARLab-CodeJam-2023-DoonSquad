using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Collectible
{
    //player gameobject, will be set in OnTriggerEnter
    PlayerController player;

    //dash reset, set in inspector can adjust this to determine how quickly the new dash can be used
    float jumpReset = 0; //reset the jump cooldown

    //oncollect is called when the user picks up the dash
    public override void OnCollect()
    {
        Debug.Log("Jump collected");
        if(player != null){
            player.remainingJumpCooldown = jumpReset;
            player.boostedHeight = true;
            player.doubleJumpUsed = false;
        }   
    }

    //when the player enters the trigger, set the player gameobject and call oncollect
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            OnCollect();
            Destroy(gameObject);
        }
    }
}
