using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{   

    //mesh for the collectible
    public MeshRenderer mesh;


    //method called when the player picks up the collectible
    public abstract void OnCollect();


    //coroutine that disables the mesh and collider and then waits for a set amount of time then reenables the mesh and collider
    public IEnumerator Timer(float time)
    {
        //disable mesh and collider
        DisableMeshAndCollider();

        //wait for 5 seconds
        yield return new WaitForSeconds(time);

        //reenable mesh and collider
        EnableMeshAndCollider();
    }

    //disable mesh and collider
    public void DisableMeshAndCollider()
    {
        //disable mesh
        mesh.enabled = false;

        //disable collider
        GetComponent<Collider>().enabled = false;
    }

    //enable mesh and collider
    public void EnableMeshAndCollider()
    {
        //enable mesh
        mesh.enabled = true;

        //enable collider
        GetComponent<Collider>().enabled = true;
    }


    

}
