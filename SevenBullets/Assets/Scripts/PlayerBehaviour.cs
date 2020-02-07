using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    enum playerChoice { Player1, Player2};

    [SerializeField] playerChoice playerID;
    string currentPlayer;
    [SerializeField] GameObject[] buttonCurrentPlayer;

    [HideInInspector] public bool onRound;

    int targetedButtonId;

    private void OnValidate()
    {
        currentPlayer = playerID.ToString();
        
        if(currentPlayer == playerChoice.Player1.ToString())
        {
            buttonCurrentPlayer = GameManager.instance.playerOneButton;
        }
        else if (currentPlayer == playerChoice.Player2.ToString())
        {
            buttonCurrentPlayer = GameManager.instance.playerTwoButton;
        }
    }

    void Update()
    {
        if (onRound)
        {
            if (Input.GetButtonDown(currentPlayer + "_A"))
            {
                TestInputCorrect(0);
            }
            if (Input.GetButtonDown(currentPlayer + "_B"))
            {
                TestInputCorrect(1);
            }
            if (Input.GetButtonDown(currentPlayer + "_X"))
            {
                TestInputCorrect(2);
            }
            if (Input.GetButtonDown(currentPlayer + "_Y"))
            {
                TestInputCorrect(3);
            }
        }
    }

    void TestInputCorrect(int inputID)
    {
        Debug.Log("Input" + inputID);

        if (buttonCurrentPlayer[targetedButtonId].GetComponent<ButtonBehaviour>().randomButtonId == inputID)
        {
            buttonCurrentPlayer[targetedButtonId].GetComponent<ButtonBehaviour>().ValidateButton();
            targetedButtonId += 1;
        }
        else
        {
            buttonCurrentPlayer[targetedButtonId].GetComponent<ButtonBehaviour>().FailButton();
        }
    }

   
}
