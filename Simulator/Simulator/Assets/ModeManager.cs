using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script handles all the modes in the game, such as "Edit", "Spawn" and "Destroy".

public class ModeManager : MonoBehaviour
{
    public const string MODE_EDIT = "EDIT";
    public const string MODE_SPAWN = "SPAWN";
    public const string MODE_DESTROY = "DESTROY";

    public string currentMode = MODE_SPAWN;
    public string currentLabel;

    public Text modeTxt;

    [Header("Labels")]
    public string editLabel = "Edit";
    public string spawnLabel = "Spawn";
    public string destroyLabel = "Destroy";


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentMode = nextMode(currentMode);
        }

        switch (currentMode) //Set the currentLabel in relation to the currentMode.
        {
            case MODE_SPAWN:
                currentLabel = spawnLabel;
                modeTxt.text = currentLabel;
                break;

            case MODE_EDIT:
                currentLabel = editLabel;
                modeTxt.text = currentLabel;
                break;

            case MODE_DESTROY:
                currentLabel = destroyLabel;
                modeTxt.text = currentLabel;
                break;
      
        }
    }

    private string nextMode(string mode) //When the user presses left shift, what mode is the next?
    {
        string result = mode;

        switch (mode)
        {
            case MODE_SPAWN:
                result = MODE_EDIT;
                break;

            case MODE_EDIT:
                result = MODE_DESTROY;
                break;

            case MODE_DESTROY:
                result = MODE_SPAWN;
                break;
        }

        return result;
    }
}


