using UnityEngine;
using System.Collections;
using TMPro;

public class SlotMachineController : MonoBehaviour
{
    [Header("Reel References")]
    public ReelController[] reels;

    [Header("UI Elements")]
    public TextMeshProUGUI winText;

    [Header("Animations")]
    public Animator winAnimator;

    [Header("Audio Sources")]
    public AudioSource reelAudioSource;
    public AudioSource winAudioSource;

    // Prevents multiple spins at the same time
    private bool isSpinning = false;


    /// Starts the slot machine spin sequence.

    public void Spin()
    {
        // Prevent player from spinning while reels are active
        if (isSpinning)
            return;

        // Check if player has enough coins
        if (!GameManager.Instance.CanSpin())
            return;

        // Deduct spin cost
        GameManager.Instance.SpendCoins();

        // Begin spinning reels
        StartCoroutine(SpinRoutine());
    }


    /// Handles reel spinning sequence and timing.

    IEnumerator SpinRoutine()
    {
        isSpinning = true;

        // Clear previous win message
        if (winText != null)
        {
            winText.text = "";
        }

        // Play reel spinning sound
        if (reelAudioSource != null)
        {
            reelAudioSource.Play();
        }

        // Start reels with slight delay for realistic effect
        reels[0].StartSpin();
        yield return new WaitForSeconds(0.08f);

        reels[1].StartSpin();
        yield return new WaitForSeconds(0.08f);

        reels[2].StartSpin();

        // Wait until spinning finishes
        yield return new WaitForSeconds(3.7f);

        // Stop reel audio
        if (reelAudioSource != null)
        {
            reelAudioSource.Stop();
        }

        // Evaluate winning combination
        CheckWin();

        isSpinning = false;
    }


    /// Checks the center payline for matching symbols.
    /// Rewards player if all three symbols match.

    void CheckWin()
    {
        Sprite leftSymbol = reels[0].GetCenterSprite();
        Sprite middleSymbol = reels[1].GetCenterSprite();
        Sprite rightSymbol = reels[2].GetCenterSprite();

        // Safety check
        if (leftSymbol == null || middleSymbol == null || rightSymbol == null)
            return;

        // Win condition: all three symbols match
        if (leftSymbol == middleSymbol && middleSymbol == rightSymbol)
        {
            int reward = CalculateReward(leftSymbol.name);

            // Add payout to player coins
            GameManager.Instance.AddCoins(reward);

            // Display win message
            if (winText != null)
            {
                winText.text = "YOU WIN: " + reward;
            }

            // Play win animation
            if (winAnimator != null)
            {
                winAnimator.Play("WinPop");
            }

            // Play win sound
            if (winAudioSource != null)
            {
                winAudioSource.Play();
            }
        }
    }


    /// Returns payout amount based on symbol type.

    int CalculateReward(string symbolName)
    {
        if (symbolName.Contains("7"))
            return 1000;

        if (symbolName.Contains("BAR"))
            return 500;

        if (symbolName.Contains("Cherry"))
            return 300;

        if (symbolName.Contains("Lemon"))
            return 200;

        if (symbolName.Contains("WILD"))
            return 1500;

        // Default reward
        return 100;
    }
}