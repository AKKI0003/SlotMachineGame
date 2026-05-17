using UnityEngine;
using System.Collections;
using TMPro;

public class SlotMachineController : MonoBehaviour
{
    [Header("Reel References")]
    public ReelController[] reels;

    [Header("UI")]
    public TextMeshProUGUI winText;

    [Header("Animations")]
    public Animator winAnimator;
    public Animator handleAnimator;

    [Header("Audio")]
    public AudioSource reelAudioSource;
    public AudioSource winAudioSource;

    // Prevents multiple spins
    private bool isSpinning = false;

    public void Spin()
    {
        // Prevent multiple spins
        if (isSpinning)
            return;

        // Check if player can afford spin
        if (!GameManager.Instance.CanSpin())
            return;

        // Deduct current bet
        GameManager.Instance.SpendCoins();

        // Play handle animation
        if (handleAnimator != null)
        {
            handleAnimator.SetTrigger("Spin");
        }

        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
    {
        isSpinning = true;

        // Clear previous win text
        if (winText != null)
        {
            winText.text = "";
        }

        // Play reel sound
        if (reelAudioSource != null)
        {
            reelAudioSource.Play();
        }

        // Start reels
        reels[0].StartSpin();

        yield return new WaitForSeconds(0.08f);

        reels[1].StartSpin();

        yield return new WaitForSeconds(0.08f);

        reels[2].StartSpin();

        // Wait for spinning
        yield return new WaitForSeconds(3.7f);

        // Stop reel sound
        if (reelAudioSource != null)
        {
            reelAudioSource.Stop();
        }

        // Check result
        CheckWin();

        isSpinning = false;
    }

    void CheckWin()
    {
        Sprite leftSymbol = reels[0].GetCenterSprite();
        Sprite middleSymbol = reels[1].GetCenterSprite();
        Sprite rightSymbol = reels[2].GetCenterSprite();

        // Safety check
        if (leftSymbol == null ||
            middleSymbol == null ||
            rightSymbol == null)
        {
            return;
        }

        // WIN CONDITION
        if (leftSymbol == middleSymbol &&
            middleSymbol == rightSymbol)
        {
            int reward =
                CalculateReward(leftSymbol.name);

            // Add winnings
            GameManager.Instance.AddCoins(reward);

            // Show win text
            if (winText != null)
            {
                winText.text =
                    "YOU WIN: " + reward;
            }

            // Play win animation
            if (winAnimator != null &&
                winAnimator.gameObject.activeInHierarchy)
            {
                winAnimator.Play("WinPop", 0, 0f);
            }

            // Play win sound
            if (winAudioSource != null)
            {
                winAudioSource.Stop();
                winAudioSource.Play();
            }

            // Show UI effects
            if (UIManager.Instance != null)
            {
                UIManager.Instance.ShowWin();
            }
        }
        else
        {
            // Show retry panel if player lost all coins
            if (GameManager.Instance.IsOutOfCoins())
            {
                UIManager.Instance.ShowRetryPanel();
            }
        }
    }

    // Reward calculation based on current bet
    int CalculateReward(string symbolName)
    {
        int bet = GameManager.Instance.currentBet;

        if (symbolName.Contains("7"))
            return bet * 50;

        if (symbolName.Contains("BAR"))
            return bet * 25;

        if (symbolName.Contains("Cherry"))
            return bet * 15;

        if (symbolName.Contains("Lemon"))
            return bet * 10;

        if (symbolName.Contains("WILD"))
            return bet * 75;

        return bet * 5;
    }
}