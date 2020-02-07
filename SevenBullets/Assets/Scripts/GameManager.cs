using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] playerOneButton;
    public GameObject[] playerTwoButton;

    int targetedPlayerOnButton;
    int targetedPlayerTwoButton;

    [SerializeField] [Range(0,30)]
    float minTimer = 0;
    [SerializeField] [Range(0,30)]
    float maxTimer = 0;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    PlayerBehaviour player1Behaviour;
    PlayerBehaviour player2Behaviour;




    private void Start()
    {
        player1Behaviour = player1.GetComponent<PlayerBehaviour>();
        player2Behaviour = player2.GetComponent<PlayerBehaviour>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(TimerBeforeRound());
        }
      
    }

    void LaunchRound()
    {
        foreach (GameObject button in playerOneButton)
        {
            button.GetComponent<ButtonBehaviour>().ButtonRandom();
        }

        foreach (GameObject button in playerTwoButton)
        {
            button.GetComponent<ButtonBehaviour>().ButtonRandom();
        }

        player1Behaviour.onRound = true;
        player2Behaviour.onRound = true;
    }

    void PlayerOneWon()
    {

    }

    void PlayerTwoWon()
    {

    }

    IEnumerator TimerBeforeRound()
    {
        float timer = Random.Range(minTimer, maxTimer);

        yield return new WaitForSeconds(timer);

        LaunchRound();
    }

    
    
}
