using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Manager gameManager;
    private UIManager uiManager;
    private Canvas canvas;

    public GameObject GameMenuPanel;
    private void Awake()
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach(unit _unit in gameManager.allies)
            {
                unit.statusCalculation(_unit);
            }
        }
    }


    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (gameManager.mode == Manager.gameMode.Normal)
            {
                
            }
            else if (gameManager.mode == Manager.gameMode.Talking)
            {
                Interact_Talking();
            }
            else if (gameManager.mode == Manager.gameMode.Battling)
            {
                Interact_Battling();
            }
        }
    }

    public void OnCancel(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (gameManager.mode == Manager.gameMode.Normal)
            {
                
            }
            else if (gameManager.mode == Manager.gameMode.Battling)
            {
                
            }
            else if (gameManager.mode == Manager.gameMode.OnMenu)
            {
                Cancel_OnMenu();
            }
        }
    }

    public void OnMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (gameManager.mode == Manager.gameMode.Normal)
            {
                Menu_Normal();
            }

        }
    }

    public void Interact_Talking()
    {
        CaptionPanelController captionControl = GameObject.FindGameObjectWithTag("CaptionPanel").GetComponent<CaptionPanelController>();
        if (captionControl.GetComponentInChildren<CaptionTextController>().charQueue.Count > 0) captionControl.showLine();
        else captionControl.nextLine();
    }

    public void Interact_Battling()
    {
        BattleCaptionController captionControl = GameObject.FindGameObjectWithTag("BattleCaptionPanel").GetComponent<BattleCaptionController>();
        if (captionControl.GetComponentInChildren<CaptionTextController>().charQueue.Count > 0) captionControl.showLine();
        else if (captionControl.GetComponentInChildren<CaptionTextController>().charQueue.Count != captionControl.GetComponentInChildren<CaptionTextController>().length) captionControl.nextLine();
    }
    public void Cancel_OnMenu()
    {

    }
    public void Menu_Normal()
    {
        uiManager.openMenu();
    }
}
