using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCaptionController : MonoBehaviour
{
    private UIManager uiManager;
    public CaptionTextController captionText;
    public bool isNextLine;
    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        isNextLine = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Queue<char> stringToCharQueue(string str)
    {
        char[] chars = str.ToCharArray();
        Queue<char> _charQueue = new Queue<char>();
        foreach (char c in chars) _charQueue.Enqueue(c);
        return _charQueue;
    }

    public void playLine(string line)
    {
        isNextLine = false;
        captionText.gameObject.GetComponent<Text>().text = "";
        captionText.charQueue = stringToCharQueue(line);
        captionText.length = line.Length;
        StartCoroutine(captionText.playText(uiManager.captionSpeed * -1f));
    }

    public void showLine()
    {
        StopCoroutine(captionText.playText(uiManager.captionSpeed * -1));
        while (captionText.OutputChar()) ;
    }
    public void nextLine()
    {
        isNextLine = true;
    }

}
