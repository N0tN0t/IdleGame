using UnityEngine;

[System.Serializable]
public class DataForSaving
{
    public int clicks;

    public int plusOne;
    public int multiplier;
    public int discounts;
    public int randomizer;
    public int autoclicker;
    public int autospeed;
    public int automultiplier;
    public int autoboost;

    public DataForSaving(Stats stats)
    {
        clicks = stats.clicks;
        plusOne = stats.plusOne;
        multiplier = stats.multiplier;
        discounts = stats.discounts;
        randomizer = stats.randomizer;
        autoclicker = stats.autoclicker;
        autospeed = stats.autospeed;
        automultiplier = stats.automultiplier;
        autoboost = stats.autoboost;
    }
}
