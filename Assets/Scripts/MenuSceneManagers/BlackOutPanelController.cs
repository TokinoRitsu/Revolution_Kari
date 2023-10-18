using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOutPanelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeBlackOut(bool fadeToBlack, float waitSeconds = 2f, int fadeSpeed = 5)
    {
        Color color = this.GetComponent<Image>().color;
        float fadeAmount;
        if (fadeToBlack)
        {
            GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0f);
            while (GetComponent<Image>().color.a < 1)
            {
                fadeAmount = color.a + fadeSpeed * Time.deltaTime;
                color = new Color(color.r, color.g, color.b, fadeAmount);
                this.GetComponent<Image>().color = color;
                yield return null;
            }
            yield return new WaitForSeconds(waitSeconds);
        }
        else
        {
            GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1f);
            while (GetComponent<Image>().color.a > 0)
            {
                fadeAmount = GetComponent<Image>().color.a - fadeSpeed * Time.deltaTime;
                color = new Color(color.r, color.g, color.b, fadeAmount);
                this.GetComponent<Image>().color = color;
                yield return null;
            }
        }
        Destroy(gameObject);
    }
}
