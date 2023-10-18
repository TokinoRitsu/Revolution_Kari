using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataPanelController : MonoBehaviour
{
    public GameObject YesNoPanel;
    private DataPersistenceManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SaveDataPanelAction()
    {

        yield return null;
    }
}
