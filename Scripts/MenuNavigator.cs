using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
    // create an array of ButtonCommands
    public ButtonCommand[] buttonCommands;
    // fill with button commands in the inspector
    // create a variable to hold the current button index
    private int currentButtonIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // set the current button index to 0
        currentButtonIndex = 0;

        public void Update() {
            // if the index is equal to the button, show that button's cursor object
        }
        
    }
}
