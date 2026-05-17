using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager Instance;

    [Header("UI Elements")]
    public GameObject winText;

    [Header("Audio")]
    public AudioSource winAudio;

    void Awake()
    {
        Instance = this;
    }

    // Displays win feedback to the player
    public void ShowWin()
    {
        StartCoroutine(ShowWinRoutine());
    }

    // Handles temporary win text and sound
    IEnumerator ShowWinRoutine()
    {
        if (winText != null)
        {
            winText.SetActive(true);
        }

        if (winAudio != null)
        {
            winAudio.Play();
        }

        yield return new WaitForSeconds(2f);

        if (winText != null)
        {
            winText.SetActive(false);
        }
    }
}