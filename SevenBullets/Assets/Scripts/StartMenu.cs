using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Animator startPanelAnimator;
    [SerializeField] GameObject startClipingInfo;
    bool onMenu;

    
    void Update()
    {
        if (Input.anyKeyDown && onMenu == false 
            && startPanelAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= startPanelAnimator.GetCurrentAnimatorStateInfo(0).length)
        {
            StartPanelUp();
        }
        else if (Input.GetButtonDown("Cancel") && onMenu == true
            && startPanelAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= startPanelAnimator.GetCurrentAnimatorStateInfo(0).length)
        {
            StartCoroutine(LeaveMenu());
        }
    }

    void StartPanelUp()
    {
        startClipingInfo.SetActive(false);
        startPanelAnimator.SetTrigger("anyButtonPressed");
        onMenu = true;
    }
    IEnumerator LeaveMenu()
    {        
        startPanelAnimator.SetTrigger("return");
        yield return new WaitForSeconds(startPanelAnimator.GetCurrentAnimatorStateInfo(0).length + 0.05f);
        startClipingInfo.SetActive(true);
        onMenu = false;        
    }

   
}
