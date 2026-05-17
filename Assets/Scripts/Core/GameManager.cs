using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    [Header("Coin Settings")]
    public int startingCoins = 1000;
    public int spinCost = 50;

    // Current player coin balance
    private int currentCoins;

    [Header("UI References")]
    public TextMeshProUGUI coinsText;

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
        // Initialize player coins
        currentCoins = startingCoins;

        UpdateCoinsUI();
    }

    // Checks if player has enough coins to spin
    public bool CanSpin()
    {
        return currentCoins >= spinCost;
    }

    // Deducts spin cost from player coins
    public void SpendCoins()
    {
        currentCoins -= spinCost;

        UpdateCoinsUI();
    }

    // Adds reward coins to player balance
    public void AddCoins(int amount)
    {
        currentCoins += amount;

        UpdateCoinsUI();
    }

    // Updates coin display text
    void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            coinsText.text = currentCoins.ToString();
        }
    }
}