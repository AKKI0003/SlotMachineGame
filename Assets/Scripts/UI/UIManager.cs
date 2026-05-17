using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Win UI")]
    public GameObject winText;

    public AudioSource winAudio;

    [Header("Retry Panel")]
    public GameObject retryPanel;

    private CanvasGroup retryCanvasGroup;

    void Awake()
    {
        Instance = this;

        // Get canvas group
        if (retryPanel != null)
        {
            retryCanvasGroup =
                retryPanel.GetComponent<CanvasGroup>();
        }
    }

    // Show win text temporarily
    public void ShowWin()
    {
        StartCoroutine(ShowWinRoutine());
    }

    IEnumerator ShowWinRoutine()
    {
        if (winText != null)
        {
            winText.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        if (winText != null)
        {
            winText.SetActive(false);
        }
    }

    // Smooth retry popup
    public void ShowRetryPanel()
    {
        if (retryPanel != null)
        {
            retryPanel.SetActive(true);

            StartCoroutine(AnimateRetryPanel());
        }
    }

    IEnumerator AnimateRetryPanel()
    {
        float duration = 0.3f;
        float timer = 0f;

        Vector3 startScale =
            Vector3.zero;

        Vector3 endScale =
            Vector3.one;

        retryPanel.transform.localScale =
            startScale;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float progress =
                timer / duration;

            // Scale animation
            retryPanel.transform.localScale =
                Vector3.Lerp(
                    startScale,
                    endScale,
                    progress
                );

            // Fade animation
            if (retryCanvasGroup != null)
            {
                retryCanvasGroup.alpha =
                    Mathf.Lerp(0f, 1f, progress);
            }

            yield return null;
        }

        retryPanel.transform.localScale =
            endScale;

        if (retryCanvasGroup != null)
        {
            retryCanvasGroup.alpha = 1f;
        }
    }
}