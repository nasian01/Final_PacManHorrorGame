using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : ButtonCommand
{
    public override void OnSpacePressed()
    {
        Debug.Log("Back button clicked!");
        // switch scene to playScene
        SceneManager.LoadScene("MenuScreen");
        
    }
}

