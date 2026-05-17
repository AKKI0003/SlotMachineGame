using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    [Header("Coin Settings")]
    public int startingCoins = 1000;

    [Header("Bet Settings")]
    public int currentBet = 50;
    public int minBet = 50;
    public int maxBet = 500;
    public int betStep = 50;

    // Current player balance
    private int currentCoins;

    [Header("UI References")]
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI betText;

    void Awake()
    {
        // Ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize coins
        currentCoins = startingCoins;

        UpdateCoinsUI();
        UpdateBetUI();
    }

    // Check if player has enough coins
    public bool CanSpin()
    {
        return currentCoins >= currentBet;
    }

    // Check if player is completely out of coins
    public bool IsOutOfCoins()
    {
        return currentCoins <= 0;
    }

    // Deduct current bet
    public void SpendCoins()
    {
        currentCoins -= currentBet;

        UpdateCoinsUI();
    }

    // Add reward coins
    public void AddCoins(int amount)
    {
        currentCoins += amount;

        UpdateCoinsUI();
    }

    // Increase bet amount
    public void IncreaseBet()
    {
        currentBet += betStep;

        if (currentBet > maxBet)
        {
            currentBet = maxBet;
        }

        UpdateBetUI();
    }

    // Decrease bet amount
    public void DecreaseBet()
    {
        currentBet -= betStep;

        if (currentBet < minBet)
        {
            currentBet = minBet;
        }

        UpdateBetUI();
    }

    // Update coin display
    void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            coinsText.text = currentCoins.ToString();
        }
    }

    // Update bet display
    void UpdateBetUI()
    {
        if (betText != null)
        {
            betText.text = "BET: " + currentBet;
        }
    }
}