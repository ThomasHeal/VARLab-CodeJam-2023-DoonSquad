using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    //selected level
    public int level = 1;
    //if the player enters the portal, they will be teleported to the other portal
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //teleport player to other portal
            // other.gameObject.transform.position = new Vector3(-other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            //debug for player stepping in portal
            Debug.Log("Player stepped in portal");

            SceneManager.Instance.LoadScene(level);

        }

    }

    //function to set the level
    public void SetLevel(int level)
    {
        this.level = level;
    }
}
