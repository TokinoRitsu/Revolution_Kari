using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SettingsPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameSettings gameSettings;
    private List<ISettingsPersistence> settingsPersistenceObjects;
    private FileDataHandler dataHandler;
    public static SettingsPersistenceManager instance { get; private set; }

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
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, "", fileName);
        this.settingsPersistenceObjects = FindAllSettingsPersistenceObjects();
        LoadSettings();
        SaveSettings();
    }

    public void NewSettings()
    {
        this.gameSettings = new GameSettings();
    }

    public void LoadSettings()
    {
        // Load any saved data from a file using the data handler
        this.gameSettings = dataHandler.LoadGameSettings();
        // If no data can be loaded, initialize to a new game
        if (this.gameSettings == null)
        {
            Debug.Log("No settings was found. Initializing settings to defaults.");
            NewSettings();
        }
        // Push the loaded data to all other scripts
        foreach (ISettingsPersistence settingsPersistenceObj in settingsPersistenceObjects)
        {
            settingsPersistenceObj.LoadSettings(gameSettings);
        }
    }
    public void SaveSettings()
    {
        // Pass the data to other scripts so they can update it
        foreach (ISettingsPersistence settingsPersistenceObj in settingsPersistenceObjects)
        {
            settingsPersistenceObj.SaveSettings(ref gameSettings);
        }
        // Save that data to a file using the data handler
        dataHandler.SaveGameSettings(gameSettings);
    }

    private List<ISettingsPersistence> FindAllSettingsPersistenceObjects()
    {
        IEnumerable<ISettingsPersistence> settingsPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISettingsPersistence>();

        return new List<ISettingsPersistence>(settingsPersistenceObjects);
    }
}
