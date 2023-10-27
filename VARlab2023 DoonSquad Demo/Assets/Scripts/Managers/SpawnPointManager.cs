using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    //add myself to the list of spawn points
    void Start()
    {
        GameManager.instance.spawnPoints.Add(transform);
    }

    //on trigger enter
    private void OnTriggerEnter(Collider other)
    {
        //if the player enters the trigger
        if (other.gameObject.tag == "Player")
        {
            //set the selected spawn point to this
            GameManager.instance.selectedSpawnPoint = transform;
        }
    }

    //update
    void Update()
    {
        //if this is equal to the selected spawn point in the game manager change to the color green
        if (GameManager.instance.selectedSpawnPoint == transform)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }else{
            //else change to the color red
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }
}
