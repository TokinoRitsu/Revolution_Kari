using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButtonController : MonoBehaviour
{
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        this.GetComponent<Button>().onClick.AddListener(() => CreditsButtonAction());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreditsButtonAction()
    {
        StartCoroutine(isClickedControl());
    }

    private IEnumerator isClickedControl()
    {
        if (!uiManager.isClicked)
        {
            uiManager.isClicked = true;
            uiManager.InstantiatePanel(uiManager.creditsPanel);
            uiManager.startMinusX1920();
        }
        yield return new WaitForSeconds(0.5f);
        uiManager.isClicked = false;
    }
}
