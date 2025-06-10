using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonScript : MonoBehaviour
{
    public GameObject statsObj;
    public GameObject ClickSound;
    public GameObject clickVisualizer;
    private Animator animator;
    private Stats stats;
    public GameObject fireObj;
    private int prevfire = 0;
    private int fire = 0;
    private float firedelay=0;

    void Start()
    {

        animator = GetComponent<Animator>();

        stats = statsObj.GetComponent<Stats>();
        
    }
    void Update()
    {
        if (Time.time - firedelay >= 0.25)
        {
            firedelay = Time.time;
            if (fire > 0 && prevfire == fire)
            {
                fire -= 5;
                if (fire < 0)
                {
                    fire = 0;
                }
            }
            prevfire = fire;
        }
        fireObj.GetComponent<Image>().color = new Color(1, 1, 1, (float)(fire) / 100);
    }
    public void onClick()
    {
        GameObject ClickClone = GameObject.Instantiate(ClickSound);
        ClickClone.transform.SetParent(ClickSound.transform.parent);
        ClickClone.GetComponent<AudioSource>().Play();
        ClickClone.GetComponent<DestroyAfterPlayScript>().enabled = true;
        if (fire < 100)
        {
            prevfire = fire;
            fire += 1;
        }
        bool randomizerEnable = false;
        if (stats.randomizer > 0 && Random.Range(1, 11) == Random.Range(1, 11))
        {
            randomizerEnable = true;
            foreach (Transform comp in transform.parent.GetComponentsInChildren<Transform>())
            {
                if (comp.name == "Click")
                {
                    GameObject click1 = GameObject.Instantiate(comp.gameObject);
                    click1.GetComponent<TMP_Text>().text = "x" + stats.randomizer;
                    click1.GetComponent<TMP_Text>().color = new Color(0, 1, 0, 0.8313726f);
                    foreach (Transform comp1 in transform.parent.GetComponentsInChildren<Transform>())
                    {
                        if (comp1.name == "Panel")
                        {
                            click1.transform.SetParent(comp1);
                            click1.transform.position = comp1.position + new Vector3(Random.Range(-150, 150), Random.Range(-150, 150), 0);
                        }
                    }
                    if (click1.GetComponent<ClickMover>() != null)
                    {
                        click1.GetComponent<ClickMover>().active = true;
                    }
                }
            }
        }
        int clks = (int)((1 + stats.plusOne) * stats.multiplier * ((stats.randomizer > 0 && randomizerEnable == true) ? stats.randomizer : 1)*(fire<75 ? 1+(float)(fire)/75 : 2));
        clickVisualizer.GetComponent<PointVisualizer>().click(clks);
        stats.clicks += clks;
        animator.SetTrigger("Pressed");
    }
}
