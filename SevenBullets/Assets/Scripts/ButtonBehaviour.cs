using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    Sprite[] aButton;
    Sprite[] bButton;
    Sprite[] xButton;
    Sprite[] yButton;

    Sprite[][] allButton;

    Sprite basicSprite;

    SpriteRenderer buttonRenderer;

    private void Start()
    {
        allButton = new Sprite[4][];
        allButton[0] = aButton;
        allButton[1] = bButton;
        allButton[2] = xButton;
        allButton[3] = yButton;

        buttonRenderer = GetComponent<SpriteRenderer>();
    }
}
