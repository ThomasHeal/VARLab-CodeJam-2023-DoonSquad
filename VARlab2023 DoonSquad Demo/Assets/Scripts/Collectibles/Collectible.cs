using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{   
    //method called when the player picks up the collectible
    public abstract void OnCollect();


}
