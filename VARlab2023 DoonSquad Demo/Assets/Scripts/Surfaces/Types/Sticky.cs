using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : Surface
{
    PlayerController player;

    private const float SLOW_JUMP_SPEED = 2.0f;
    private const float SLOW_WALKING_SPEED = 4.0f;
    private const float SLOW_DASH_SPEED = 10.0f;

    public override void OnEnter()
    {
        player.jumpSpeed = SLOW_JUMP_SPEED;
        player.walkingSpeed = SLOW_WALKING_SPEED;
        player.dashSpeed = SLOW_DASH_SPEED;
    }

    public override void OnExit()
    {
        player.jumpSpeed = player.BASE_JUMP_SPEED;
        player.walkingSpeed = player.BASE_WALKING_SPEED;
        player.dashSpeed = player.BASE_DASH_SPEED;
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
