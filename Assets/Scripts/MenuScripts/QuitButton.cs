using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;

public class QuitButton : ButtonCommand
{
    public override void OnSpacePressed()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}