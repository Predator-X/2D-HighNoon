using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class PeristentManager : MonoBehaviour{
    public int currentLevelID;
    public int highestLevelCompleted;
    public int gemsCollected;
    public static PeristentManager dataStore;
    
    void Awake()
    {
        if (dataStore == null)
        {
            DontDestroyOnLoad(gameObject);
            dataStore = this;
            Load();
        }
        else if(dataStore != this) { Destroy(gameObject); }
    }
    [Serializable] class GameData { public int gemsCollectedTotal, highestLevel; }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GmaeData.dat");
        GameData data = new GameData();
        data.gemsCollectedTotal = gemsCollected;
        data.highestLevel = highestLevelCompleted;
        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/GameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + 
                "/GameData.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();
            gemsCollected = data.gemsCollectedTotal;
            highestLevelCompleted = data.highestLevel;
        }
    }
    public int getGemsCollected() { return gemsCollected; }
    public void endGameWithWin()
    {
        if (currentLevelID > highestLevelCompleted) { highestLevelCompleted = currentLevelID; }
        Save();
        Debug.Log("Game Over - Win");
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenu");
    }

    public void endGameWithLoss()
    {
        Debug.Log("Game Over - Loss");
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenu");
    }
}
 /* Let's understand the concepts:
Save:
1. Create the file and a "binary formatter" which will allow us to output data to the file.
2. Populate our serializable object with the data we want to store.
3. Write the binary data to the file (and close when we're finished).
Load:
Basically, we have the reverse operations here:
1. Open the file (which Save() has created) and a "binary formatter" to retrieve the data.
2. Read the data into a Serializable object.
3. Populate our actual variables with the data retrieved via the Serializable object.
 
 */
