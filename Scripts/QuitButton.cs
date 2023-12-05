using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : ButtonCommand
{
    public override void OnSpacePressed()
    {
        Debug.Log("Quit button clicked!");
        // switch scene to playScene
        Application.Quit();
    }
}

