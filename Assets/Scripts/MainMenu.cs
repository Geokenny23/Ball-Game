using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject levelSelectCanvas;

    public static bool GoToLevelSelect;

    void Start()
    {
        if (GoToLevelSelect)
        {
            mainMenuCanvas.SetActive(false);
            levelSelectCanvas.SetActive(true);

            GoToLevelSelect = false;
        }
        else
        {
            mainMenuCanvas.SetActive(true);
            levelSelectCanvas.SetActive(false);
        }
    }

    public void ShowLevelSelect()
    {
        mainMenuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        levelSelectCanvas.SetActive(false);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
