using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionPanelController : MonoBehaviour
{
    private Manager gameManager;
    private UIManager uiManager;

    public int lineindex = 0;
    public int currentLineindex = 0;
    public CaptionTextController captionText;
    public Text captionName;

    private void Awake()
    {
        gameManager = GameObject.Find("Manager").GetComponent<Manager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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
    private Queue<char> stringToCharQueue(string str)
    {
        char[] chars = str.ToCharArray();
        Queue<char> _charQueue = new Queue<char>();
        foreach (char c in chars) _charQueue.Enqueue(c);
        return _charQueue;
    }
    public void playLine(int index)
    {
        lineindex = index;
        if (Database.lines_names[index][currentLineindex] == null) captionName.gameObject.transform.parent.gameObject.SetActive(false);
        else captionName.gameObject.transform.parent.gameObject.SetActive(true);
        captionText.gameObject.GetComponent<Text>().text = "";
        captionText.charQueue = stringToCharQueue(Database.lines_text[index][currentLineindex]);
        captionName.text = Database.lines_names[index][currentLineindex];
        StartCoroutine(captionText.playText(uiManager.captionSpeed * -1));
    }
    public void showLine()
    {
        StopCoroutine(captionText.playText(uiManager.captionSpeed * -1));
        while (captionText.OutputChar()) ;
    }
    public void nextLine()
    {
        if (currentLineindex + 1 == Database.lines_text[lineindex].Count)
        {
            gameManager.mode = 0;
            Destroy(gameObject);
        }
        else
        {
            currentLineindex++;
            playLine(lineindex);
        }
    }
    
    // Play Caption End--------------------------------------------------------------------------------------
}
