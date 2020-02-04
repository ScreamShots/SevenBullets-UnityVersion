using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] Animator enterBlackMelt;
    [SerializeField] Animator leaveBlackMelt;
    [SerializeField] GameObject returnButton;
    bool creditsSet;
    void Start()
    {
        StartCoroutine(ReturnButtonAppear());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && creditsSet == true)
        {
            StartCoroutine(BackToMenu());
        }
    }

    IEnumerator ReturnButtonAppear()
    {
        yield return new WaitForSeconds(enterBlackMelt.GetCurrentAnimatorStateInfo(0).length);
        returnButton.SetActive(true);
        creditsSet = true;
    }

    IEnumerator BackToMenu()
    {
        leaveBlackMelt.gameObject.SetActive(true);
        yield return new WaitForSeconds(leaveBlackMelt.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(0);
    }

}
