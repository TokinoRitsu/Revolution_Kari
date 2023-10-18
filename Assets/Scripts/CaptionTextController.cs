using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionTextController : MonoBehaviour
{
    private UIManager uiManager;

    private Text currentLineText;
    public Queue<char> charQueue = new Queue<char>();
    public int length;

    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        currentLineText = gameObject.GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // Play Caption--------------------------------------------------------------------------------------
    public bool OutputChar()
    {
        if (charQueue.Count <= 0) return false;
        currentLineText.text += charQueue.Dequeue();
        return true;
    }
    public IEnumerator playText(float sec)
    {
        while (OutputChar())
            yield return new WaitForSeconds(sec);
        yield break;
    }
    public void showLine()
    {
        StopCoroutine(playText(uiManager.captionSpeed));
        while (OutputChar()) ;
    }

    // Play Caption End--------------------------------------------------------------------------------------
}
