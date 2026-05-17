using UnityEngine;

public class GameUIController : MonoBehaviour
{
    void Update()
    {
        // Close the game when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    // Handles quitting the application
    public void QuitGame()
    {
        Application.Quit();

        // Allows quitting while testing inside Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}