using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossFightMinusScript : MonoBehaviour
{
    public GameObject statsObj;
    public GameObject poofSound;
    public int amount;

    private Stats stats;
    float tm = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tm = Time.time;
        stats = statsObj.GetComponent<Stats>();
        gameObject.GetComponentInChildren<TMP_Text>().text = "-" + amount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 0, 0, (float)Math.Clamp(Math.Sin(Math.Abs(Time.time-tm)),0.4,1));
        if (Time.time - tm > 5)
        {
            stats.clicks -= amount;
            dstr();
        }
    }

    public void dstr()
    {
        poofSound.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
