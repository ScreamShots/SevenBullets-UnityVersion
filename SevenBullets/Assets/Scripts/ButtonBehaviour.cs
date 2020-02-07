using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] Sprite[] aButton;
    [SerializeField] Sprite[] bButton;
    [SerializeField] Sprite[] xButton;
    [SerializeField] Sprite[] yButton;

    Sprite[][] allButton;

    [SerializeField] Sprite basicSprite;

    Image buttonRenderer;

    [HideInInspector] public int randomButtonId;

    private void Start()
    {
        allButton = new Sprite[4][];
        allButton[0] = aButton;
        allButton[1] = bButton;
        allButton[2] = xButton;
        allButton[3] = yButton;

        buttonRenderer = GetComponent<Image>();
    }

    public void ButtonRandom()
    {
        randomButtonId = Random.Range(0, 4);

        buttonRenderer.sprite = allButton[randomButtonId][0];
    }

    public void ValidateButton()
    {
        buttonRenderer.sprite = allButton[randomButtonId][1];
    }

    public void FailButton()
    {
        buttonRenderer.sprite = allButton[randomButtonId][2];
    }
}
