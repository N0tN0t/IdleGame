using UnityEngine;

public class Stats : MonoBehaviour
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

    public void SaveData()
    {
        SaveSystem.SaveStats(this);
    }

    public void LoadData()
    {
        DataForSaving data = SaveSystem.LoadStats();

        clicks = data.clicks;
        plusOne = data.plusOne;
        multiplier = data.multiplier;
        discounts = data.discounts;
        randomizer = data.randomizer;
        autoclicker = data.autoclicker;
        autospeed = data.autospeed;
        automultiplier = data.automultiplier;
        autoboost = data.autoboost;
    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    void Start()
    {
        LoadData();
    }
}
