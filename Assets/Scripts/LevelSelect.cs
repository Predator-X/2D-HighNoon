using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {
    public string levelPrefix = "Level0";
    public void loadLevel(int levelID) { SceneManager.LoadScene(levelPrefix + levelID); }

}
