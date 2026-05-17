using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReelController : MonoBehaviour
{
    [Header("Symbol References")]
    public Image[] symbols;

    [Header("Available Slot Symbols")]
    public Sprite[] symbolSprites;

    [Header("Spin Settings")]
    public float spinInterval = 0.05f;
    public float spinDuration = 4f;

    // Tracks whether the reel is currently spinning
    private bool isSpinning = false;

    // Fixed Y positions for symbols on the reel
    private readonly float[] symbolPositions =
    {
        300f,
        150f,
        0f,
        -150f,
        -300f
    };

    // Stores current symbol indexes
    private int[] currentIndexes;

   
    /// Initializes reel symbols and positions.
    
    void Start()
    {
        currentIndexes = new int[symbols.Length];

        for (int i = 0; i < symbols.Length; i++)
        {
            // Assign random symbol
            currentIndexes[i] =
                Random.Range(0, symbolSprites.Length);

            symbols[i].sprite =
                symbolSprites[currentIndexes[i]];

            // Set fixed reel position
            symbols[i].rectTransform.anchoredPosition =
                new Vector2(0, symbolPositions[i]);
        }
    }

    
    /// Starts reel spinning coroutine.
    
    public void StartSpin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinRoutine());
        }
    }

   
    /// Continuously rotates symbols for the duration of the spin.
    
    IEnumerator SpinRoutine()
    {
        isSpinning = true;

        float timer = 0f;

        while (timer < spinDuration)
        {
            timer += spinInterval;

            RotateSymbols();

            yield return new WaitForSeconds(spinInterval);
        }

        isSpinning = false;
    }

   
    /// Rotates reel symbols downward and randomizes the top symbol.
    
    void RotateSymbols()
    {
        // Shift indexes downward
        for (int i = currentIndexes.Length - 1; i > 0; i--)
        {
            currentIndexes[i] = currentIndexes[i - 1];
        }

        // Generate new random symbol at top
        currentIndexes[0] =
            Random.Range(0, symbolSprites.Length);

        // Apply updated symbols and positions
        for (int i = 0; i < symbols.Length; i++)
        {
            symbols[i].sprite =
                symbolSprites[currentIndexes[i]];

            symbols[i].rectTransform.anchoredPosition =
                new Vector2(0, symbolPositions[i]);
        }
    }

   
    /// Returns the symbol currently located on the center payline.
   
    public Sprite GetCenterSprite()
    {
        return symbols[2].sprite;
    }
}