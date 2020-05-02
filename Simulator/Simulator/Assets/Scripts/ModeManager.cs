using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//This script handles all the modes in the game, such as "Edit", "Spawn".

public class ModeManager : MonoBehaviour
{
    public static ModeManager Instance { get; private set; }

    public const string MODE_EDIT = "EDIT";
    public const string MODE_SPAWN = "SPAWN";

    public string currentMode = MODE_SPAWN;
    public string currentModeChecker;
    public string currentLabel;

    public Text modeTxt;

    [Header("Labels")]
    public string editLabel = "Edit";
    public string spawnLabel = "Spawn";

    public InputMaster controls;

    public UnityAction onModeChange;

    private void Awake()
    {
        controls = new InputMaster();

        //Change mode action
        controls.Editor.changeMode.performed += ctx => currentMode = NextMode(currentMode);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else { Destroy(gameObject); }
    }

    private void Update()
    {
        
        switch (currentMode) //Set the currentLabel in relation to the currentMode.
        {
            case MODE_SPAWN:
                currentLabel = spawnLabel;
                modeTxt.text = currentLabel;

                if (currentModeChecker != currentMode)
                {
                    onModeChange();

                    currentModeChecker = currentMode;
                }
                
                break;

            case MODE_EDIT:
                currentLabel = editLabel;
                modeTxt.text = currentLabel;

                if (currentModeChecker != currentMode)
                {
                    onModeChange();

                    currentModeChecker = currentMode;
                }

                break;

        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private string NextMode(string mode) //When the user presses left shift, what mode is the next?
    {
        string result = mode;

        switch (mode)
        {
            case MODE_SPAWN:
                result = MODE_EDIT;
                break;

            case MODE_EDIT:
                result = MODE_SPAWN;
                break;
        }

        return result;
    }

    
}


