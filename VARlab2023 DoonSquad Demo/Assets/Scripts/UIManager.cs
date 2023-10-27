using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator startMenu;
    public Animator settingsMenu;

    public void SettingsMenuOn()
    {
        startMenu.SetBool("isHidden", true);
        settingsMenu.SetBool("isHidden", false);
    }

    public void SettingsMenuOff()
    {
        startMenu.SetBool("isHidden", false);
        settingsMenu.SetBool("isHidden", true);
    }
}
