using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    public GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        // Change the path to the save data here
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, "");
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        this.gameData.allies.Add(new unit(1, 100, new int[] { 31, 31, 31, 31, 31, 31, 31 }));
        SaveGame();
    }

    public void LoadGame()
    {
        // Load any saved data from a file using the data handler
        this.gameData = dataHandler.LoadGameData();

        // Push the loaded data to all other scripts

        if (gameDataExist())
        {
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(gameData);
            }
            Debug.Log("Loaded GameData with player name " + gameData.playerName);
        }
        
    }

    public void SaveGame()
    {
        // Pass the data to other scripts so they can update it
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved GameData with player name " + gameData.playerName);

        // Save that data to a file using the data handler
        dataHandler.SaveGameData(gameData);
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool gameDataExist()
    {
        bool result = false;
        if (this.gameData != null) result = true;
        return result;
    }
}
