using System;
using TMPro;
using UnityEngine;

public class MultiplierScript : MonoBehaviour
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
            stats.multiplier += 1;
            stats.clicks -= value;
            setValue();
            CashSound.GetComponent<AudioSource>().Play();
        }
    }

    public int setValue()
    {
        value = (int)(300*(1-((float)stats.discounts/100))) * (int)Math.Round(Math.Pow(1.6, stats.multiplier-1));
        foreach (Transform component in GetComponentsInChildren<Transform>())
        {
            if (component.parent.name == "Multiplier" && component.name == "Value")
            {
                component.GetComponent<TMP_Text>().text = value.ToString();
            }
            if (component.parent.name == "Multiplier" && component.name == "Amount")
            {
                component.GetComponent<TMP_Text>().text = "x" + stats.multiplier.ToString();
            }
        }
        return value;
    }
}
