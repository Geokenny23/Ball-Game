using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public void LoadLevel(int levelIndex)
    {
        string sceneName = "Level " + levelIndex;
        SceneManager.LoadScene(sceneName);
    }
}
    
