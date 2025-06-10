using System;
using TMPro;
using UnityEngine;

public class AutoBoostScript : MonoBehaviour
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
        if (stats.clicks >= value && stats.autoboost+1<=10)
        {
            stats.autoboost += 1;
            stats.clicks -= value;
            setValue();
            CashSound.GetComponent<AudioSource>().Play();
        }
    }

    public int setValue()
    {
        value = (int)(2500*(1-((float)stats.discounts/100))) * (int)Math.Round(Math.Pow(1.5, stats.autoboost));
        foreach (Transform component in GetComponentsInChildren<Transform>())
        {
            if (component.name == "Value")
            {
                component.GetComponent<TMP_Text>().text = value.ToString();
            }
            if (component.name == "Amount")
            {
                component.GetComponent<TMP_Text>().text = stats.autoboost.ToString();
            }
        }
        return value;
    }
}
