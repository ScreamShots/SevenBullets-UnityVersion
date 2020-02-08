using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] int scorePlayer1;
    [SerializeField] int scorePlayer2;

    [SerializeField] Animator bellAnimator;
    [SerializeField] Text scorePlayer1TXT;
    [SerializeField] Text scorePlayer2TXT;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player1Behaviour = player1.GetComponent<PlayerBehaviour>();
        player2Behaviour = player2.GetComponent<PlayerBehaviour>();

        StartCoroutine(InitializingGame());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(TimerBeforeRound());
        }

        scorePlayer1TXT.text = scorePlayer1.ToString();
        scorePlayer2TXT.text = scorePlayer2.ToString();
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
        player1Behaviour.targetedButtonId = 0;
        player2Behaviour.targetedButtonId = 0;
    }

    public void WinRound(string player)
    {
        player1Behaviour.onRound = false;
        player2Behaviour.onRound = false;

        if (player == "Player1")
        {
            scorePlayer1 += 1;
        }
        else if (player == "Player2")
        {
            scorePlayer2 += 1;
        }

        StartCoroutine(TimerBeforeRound());
    }

    IEnumerator TimerBeforeRound()
    {
        float timer = Random.Range(minTimer, maxTimer);

        yield return new WaitForSeconds(timer);

        LaunchRound();
    }

    IEnumerator InitializingGame()
    {
        player1Behaviour.LaunchStartinAnim();
        player2Behaviour.LaunchStartinAnim();
        yield return new WaitForSeconds(6f);
        bellAnimator.SetTrigger("DownTheBell");
        yield return new WaitForSeconds(5f);
        LaunchRound();

    }

    
    
}
