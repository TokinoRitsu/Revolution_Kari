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
        if (gameManager.mode == Manager.gameMode.Normal)
        {
            Move_Normal();
        }

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

    private void Move_Normal()
    {
        Vector2 moveInput = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) moveInput += Vector2.up;
        if (Input.GetKey(KeyCode.S)) moveInput += Vector2.down;
        if (Input.GetKey(KeyCode.A)) moveInput += Vector2.left;
        if (Input.GetKey(KeyCode.D)) moveInput += Vector2.right;
        transform.Translate(new Vector3(moveInput.x, moveInput.y) * 0.05f);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Warp")
        {
            StartCoroutine(gameManager.WarpToMap(collision.gameObject.GetComponent<WarpController>()));
        }
    }


}
