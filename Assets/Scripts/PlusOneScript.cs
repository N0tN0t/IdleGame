using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlusOneScript : MonoBehaviour
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
            stats.plusOne += 1;
            stats.clicks -= value;
            setValue();
            CashSound.GetComponent<AudioSource>().Play();
        }
    }

    public int setValue()
    {
        value = (int)(150*(1-((float)stats.discounts/100))) * (int)Math.Round(Math.Pow(1.3, stats.plusOne));
        foreach (Transform component in GetComponentsInChildren<Transform>())
        {
            if (component.parent.name == "PlusOne" && component.name == "Value")
            {
                component.GetComponent<TMP_Text>().text = value.ToString();
            }
            if (component.parent.name == "PlusOne" && component.name == "Amount")
            {
                component.GetComponent<TMP_Text>().text = stats.plusOne.ToString();
            }
        }
        return value;
    }
}
