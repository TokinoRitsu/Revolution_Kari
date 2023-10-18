using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => CloseButtonAction(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            CloseButtonAction(gameObject);
        }
    }

    static public void CloseButtonAction(GameObject _object)
    {
        Destroy(_object.transform.parent.gameObject);
    }
}
