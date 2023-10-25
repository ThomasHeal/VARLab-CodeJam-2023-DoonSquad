using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : Surface
{
    PlayerController player;

    public override void OnEnter()
    {
        player.isBouncing = true;
    }

    public override void OnExit()
    {
        player.isBouncing = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            OnEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            OnExit();
        }
    }
}
