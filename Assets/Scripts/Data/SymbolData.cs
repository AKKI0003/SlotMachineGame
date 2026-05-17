using UnityEngine;

// Stores data for each slot machine symbol
[System.Serializable]
public class SymbolData
{
    // Name of the symbol
    public string symbolName;

    // Visual sprite used for the symbol
    public Sprite sprite;

    // Reward amount given when matched
    public int payout;
}