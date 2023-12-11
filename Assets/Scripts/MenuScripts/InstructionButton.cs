using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionButton : ButtonCommand
{
    public override void OnSpacePressed()
    {
        Debug.Log("Instruction button pressed!");
        SceneManager.LoadScene("InstructionScreen");
    }
}