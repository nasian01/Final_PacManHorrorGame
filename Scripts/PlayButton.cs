using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : ButtonCommand
{
    public override void OnSpacePressed()
    {
        Debug.Log("Play button clicked!");
        // switch scene to playScene
        SceneManager.LoadScene("PlayScreen");
    }
}
