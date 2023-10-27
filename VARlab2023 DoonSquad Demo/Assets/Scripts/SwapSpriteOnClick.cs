using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapSpriteOnClick : MonoBehaviour
{
    public Button thisButton;
    public Sprite OriginalSprite;
    public Sprite NewSprite;
    [SerializeField] private bool isOriginalSprite = true;

    public void SwapSprite()
    {
        if (isOriginalSprite)
        {
            thisButton.GetComponent<Image>().sprite = NewSprite;
            isOriginalSprite = false;
        }
        else if (!isOriginalSprite)
        {
            thisButton.GetComponent<Image>().sprite = OriginalSprite;
            isOriginalSprite = true;
        }
    }
}
