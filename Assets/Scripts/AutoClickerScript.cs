using System;
using TMPro;
using UnityEngine;

public class AutoClickerScript : MonoBehaviour
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
            if (stats.autoclicker <= 0)
            {
                stats.autoclicker = 1;
            }
            else
            {
                stats.autoclicker *= 2;
            }
            stats.clicks -= value;
            setValue();
            CashSound.GetComponent<AudioSource>().Play();
        }
    }

    public int setValue()
    {
        value = (int)(800*(1-((float)stats.discounts/100))) * (int)Math.Round(Math.Pow(1.15, stats.autoclicker));
        foreach (Transform component in GetComponentsInChildren<Transform>())
        {
            if (component.name == "Value")
            {
                component.GetComponent<TMP_Text>().text = value.ToString();
            }
            if (component.name == "Amount")
            {
                component.GetComponent<TMP_Text>().text = stats.autoclicker.ToString();
            }
        }
        return value;
    }
}
