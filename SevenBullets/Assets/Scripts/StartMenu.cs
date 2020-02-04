using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Animator startPanelAnimator;
    [SerializeField] Animator titleAnimator;
    [SerializeField] Animator allButtonAnimator;
    [SerializeField] GameObject startClipingInfo;
    [SerializeField] GameObject menuEventSystem;
    [SerializeField] GameObject blackScreenMelt;
    bool onMenu;
    bool onLoadAnimation;

    private void Start()
    {
        menuEventSystem.SetActive(false);
        startClipingInfo.SetActive(false);
        StartCoroutine(EnterStartScreen());
    }
    void Update()
    {
        if (Input.anyKeyDown && onMenu == false && onLoadAnimation == false
            && startPanelAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= startPanelAnimator.GetCurrentAnimatorStateInfo(0).length)
        {
            StartPanelUp();
        }
        else if (Input.GetButtonDown("Cancel") && onMenu == true && onLoadAnimation == false
            && startPanelAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= startPanelAnimator.GetCurrentAnimatorStateInfo(0).length)
        {
            StartCoroutine(LeaveMenu());
        }
    }

    IEnumerator EnterStartScreen()
    {        
        yield return new WaitForSeconds(startPanelAnimator.GetCurrentAnimatorStateInfo(0).length);
        startClipingInfo.SetActive(true);
    }

    void StartPanelUp()
    {
        startClipingInfo.SetActive(false);
        menuEventSystem.SetActive(true);
        startPanelAnimator.SetTrigger("anyButtonPressed");
        onMenu = true;
    }
    IEnumerator LeaveMenu()
    {        
        startPanelAnimator.SetTrigger("return");
        menuEventSystem.SetActive(false);
        yield return new WaitForSeconds(startPanelAnimator.GetCurrentAnimatorStateInfo(0).length + 0.05f);
        startClipingInfo.SetActive(true);        
        onMenu = false;        
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameTransition());
    }
   

    IEnumerator QuitGameTransition()
    {
        onLoadAnimation = true;
        Animator blackMeltAnimator = blackScreenMelt.GetComponent<Animator>();
        blackScreenMelt.SetActive(true);
        yield return new WaitForSeconds(blackMeltAnimator.GetCurrentAnimatorStateInfo(0).length);
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(StartGameTransition());
    }
    IEnumerator StartGameTransition()
    {
        titleAnimator.SetTrigger("GameLaunched");
        allButtonAnimator.SetTrigger("GameLaunched");
        yield return new WaitForSeconds(startPanelAnimator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        StartCoroutine(CreditsTransition());
    }

    IEnumerator CreditsTransition()
    {
        onLoadAnimation = true;
        Animator blackMeltAnimator = blackScreenMelt.GetComponent<Animator>();
        blackScreenMelt.SetActive(true);
        yield return new WaitForSeconds(blackMeltAnimator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(2);
    }
  
}
