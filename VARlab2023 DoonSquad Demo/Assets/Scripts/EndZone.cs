using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public bool zoneReached = false;

    // When player Collides with EndZone SFX is played, and
    // zoneReached is set to true so that it can't be reactivated
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            if (!zoneReached)
            {
                AudioManager.instance.PlaySFX("LevelComplete");
                zoneReached = true;
            }
                
    }
}
