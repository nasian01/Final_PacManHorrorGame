using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuNavigator : MonoBehaviour
{
    public ButtonCommand[] buttonCommands;
    private int currentButtonIndex = 0;
    private int previousButtonIndex = 0;
    void Start()
    {
        SceneManager.LoadScene("MenuScreen");
        currentButtonIndex = 0;
        previousButtonIndex = 0;
        for (int i = 0; i < buttonCommands.Length; i++)
        {
            buttonCommands[i].cursor.SetActive(false);
        }
        buttonCommands[currentButtonIndex].cursor.SetActive(true);
    }
    
    public void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            OnClickUp();
            buttonCommands[currentButtonIndex].cursor.SetActive(true);
            buttonCommands[previousButtonIndex].cursor.SetActive(false);
            previousButtonIndex = currentButtonIndex;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            OnClickDown();
            buttonCommands[currentButtonIndex].cursor.SetActive(true);
            buttonCommands[previousButtonIndex].cursor.SetActive(false);
            previousButtonIndex = currentButtonIndex;
        } else if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickSpace();
        }
    }

    public void OnClickUp()
    {
        if (currentButtonIndex == 2)
        {
            currentButtonIndex = 0;
        }
        else
        {
            currentButtonIndex++;
        }
    }

    public void OnClickDown()
    {
        if (currentButtonIndex == 0)
        {
            currentButtonIndex = 2;
        }
        else
        {
            currentButtonIndex--;
        }
    }

    public void OnClickSpace()
    {
        buttonCommands[currentButtonIndex].OnSpacePressed();
    }
}