using System;
using TMPro;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    public GameObject statsObj;
    private Stats stats;
    public GameObject CashSound;

    protected int value;

    void Start()
    {
        stats = statsObj.GetComponent<Stats>();
    }

    public void Click()
    {
        if (stats.clicks >= value)
        {
            stats.randomizer += 2;
            stats.clicks -= value;
            setValue();
            CashSound.GetComponent<AudioSource>().Play();
        }
    }

    public int setValue()
    {
        value = (int)(5000*(1-((float)stats.discounts/100))) * (int)Math.Round(Math.Pow(3, stats.randomizer));
        foreach (Transform component in GetComponentsInChildren<Transform>())
        {
            if (component.parent.name == "Randomizer" && component.name == "Value")
            {
                component.GetComponent<TMP_Text>().text = value.ToString();
            }
            if (component.parent.name == "Randomizer" && component.name == "Amount")
            {
                component.GetComponent<TMP_Text>().text = "x" + stats.randomizer.ToString();
            }
        }
        return value;
    }
}
