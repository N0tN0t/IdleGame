using System;
using TMPro;
using UnityEngine;

public class DiscouintsScript : MonoBehaviour
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
        if (stats.clicks >= value && stats.discounts+1<=50)
        {
            stats.discounts += 1;
            stats.clicks -= value;
            setValue();
            CashSound.GetComponent<AudioSource>().Play();
        }
    }

    public int setValue()
    {
        value = 2000 * (int)Math.Round(Math.Pow(1.115, stats.discounts));
        foreach (Transform component in GetComponentsInChildren<Transform>())
        {
            if (component.parent.name == "Discounts" && component.name == "Value")
            {
                component.GetComponent<TMP_Text>().text = value.ToString();
            }
            if (component.parent.name == "Discounts" && component.name == "Amount")
            {
                component.GetComponent<TMP_Text>().text = stats.discounts.ToString() + "%";
            }
        }
        foreach (Transform component in transform.parent.GetComponentsInChildren<Transform>())
        {
            if (component.name == "Multiplier")
            {
                component.GetComponent<MultiplierScript>().setValue();
            }
            if (component.name == "PlusOne")
            {
                component.GetComponent<PlusOneScript>().setValue();
            }
        }
        return value;
    }
}
