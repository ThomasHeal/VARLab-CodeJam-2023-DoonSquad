using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //instance of the game manager
    public static GameManager instance;

    //state
    public enum State { Playing, Paused, Inventory, Dialogue, Cutscene, MainMenu };

    public GameObject pauseMenu;

    //list of spawn points
    public List<Transform> spawnPoints = new List<Transform>();

    //selected spawn point
    public Transform selectedSpawnPoint;

    //state
    public State state;

    //dpnt destroy on load
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }else Destroy(gameObject);
    }



    

    //start
    void Start()
    {
        //set instance to this
        instance = this;


    }

    //public void playstate
    public void PlayState()
    {
        //set state to playing
        state = State.Playing;
        Time.timeScale = 1;
    }

    //public void pausestate
    public void PauseState()
    {
        //set state to paused
        state = State.Paused;
        Time.timeScale = 0;

    }

    public void MainMenu(){
        //set state to main menu
        state = State.MainMenu;
    }

    //update
    void Update()
    {

        //if the state is paused unlock the mouse
        if (state == State.Paused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;

        }else if(state == State.MainMenu){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            //if the state is not paused lock the mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
}
