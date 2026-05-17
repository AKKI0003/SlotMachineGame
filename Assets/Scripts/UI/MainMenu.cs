using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loads the main gameplay scene
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Closes the application
    public void QuitGame()
    {
        Application.Quit();

        // Allows quitting inside Unity Editor during testing
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}