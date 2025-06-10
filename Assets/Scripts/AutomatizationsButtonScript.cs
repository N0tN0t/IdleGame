using TMPro;
using UnityEngine;

public class AutomatizationsButtonScript : MonoBehaviour
{

    public GameObject ClickSound;

    public GameObject um;
    public GameObject statsObj;
    public GameObject ClickAuto;
    public GameObject SpeedAuto;
    public GameObject BoostAuto;
    public GameObject clickVisualizer;
    public GameObject UpSound;
    public GameObject DownSound;

    private float delay = 0;
    private float boostdelay = 0;
    private Stats stats;
    private bool boost = false;
    private int rotate=0;

    void Start()
    {
        delay = Time.time;
        stats = statsObj.GetComponent<Stats>();
    }

    void Update()
    {
        rotate = (int)(Time.time * 100)%400/4+1;
        if (stats.autoclicker > 0) ClickAuto.transform.parent.parent.parent.gameObject.GetComponent<Animator>().SetBool("Enable",true); else ClickAuto.transform.parent.parent.parent.gameObject.GetComponent<Animator>().SetBool("Enable",false);
        if (stats.autospeed > 0) SpeedAuto.transform.parent.parent.parent.gameObject.GetComponent<Animator>().SetBool("Enable",true); else SpeedAuto.transform.parent.parent.parent.gameObject.GetComponent<Animator>().SetBool("Enable",false);
        if (stats.autoboost > 0) BoostAuto.transform.parent.parent.parent.gameObject.GetComponent<Animator>().SetBool("Enable",true); else BoostAuto.transform.parent.parent.parent.gameObject.GetComponent<Animator>().SetBool("Enable",false);
        if (!boost)
        {
            BoostAuto.GetComponent<TMP_Text>().text = ((int)(Time.time - boostdelay)).ToString();
            BoostAuto.GetComponent<TMP_Text>().color = Color.white;
        }
        else
        {
            BoostAuto.GetComponent<TMP_Text>().text = ((int)((10+(int)(stats.autoboost*2))-(Time.time-boostdelay))).ToString();
            BoostAuto.GetComponent<TMP_Text>().color = Color.green;
        }
        SpeedAuto.transform.rotation = Quaternion.Euler(0, 0, -360 * (float)(rotate) / 100*stats.autospeed);
        if (Time.time - delay >= 1 - ((float)(stats.autospeed) / 45) && stats.autoclicker > 0)
        {
            delay = Time.time;
            generate();
            ClickAuto.GetComponent<Animator>().SetFloat("SpeedMultiplier", 1 + stats.autospeed / 5);
            ClickAuto.GetComponent<Animator>().SetTrigger("Click");
        }
        if (Time.time - boostdelay >= 60 && stats.autoboost > 0 && boost==false)
        {
            boostdelay = Time.time;
            boost = true;
        }
        if (Time.time - boostdelay >= 10+(int)(stats.autoboost*2) && boost == true)
        {
            boostdelay = Time.time;
            boost = false;
        }
    }

    public void clk()
    {

        if (!um.GetComponent<Animator>().GetBool("Open"))
        {
            UpSound.GetComponent<AudioSource>().Play();
        }
        else
        {
            DownSound.GetComponent<AudioSource>().Play();
        }

        um.GetComponent<Animator>().SetBool("Open", !um.GetComponent<Animator>().GetBool("Open"));

        foreach (Transform cmpnt in um.GetComponentsInChildren<Transform>())
        {
            if (cmpnt.parent.name == "AutoClicker" && cmpnt.name == "Value")
            {
                cmpnt.parent.GetComponent<AutoClickerScript>().setValue();
            }
            else if (cmpnt.parent.name == "AutoSpeed" && cmpnt.name == "Value")
            {
                cmpnt.parent.GetComponent<AutoSpeedScript>().setValue();
            }
            else if (cmpnt.parent.name == "AutoMultiplier" && cmpnt.name == "Value")
            {
                cmpnt.parent.GetComponent<AutoMultiplierScript>().setValue();
            }
            else if (cmpnt.parent.name == "AutoBoost" && cmpnt.name == "Value")
            {
                cmpnt.parent.GetComponent<AutoBoostScript>().setValue();
            }
        }
    }

    void generate()
    {

        GameObject ClickClone = GameObject.Instantiate(ClickSound);
        ClickClone.transform.SetParent(ClickSound.transform.parent);
        ClickClone.GetComponent<AudioSource>().Play();
        ClickClone.GetComponent<DestroyAfterPlayScript>().enabled = true;

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
        int clks = (int)(
            stats.autoclicker *
            (1 + stats.automultiplier * 0.25f) *
            (boost ? (1 + stats.autoboost * 0.2f) : 1) *
            ((stats.randomizer > 0 && randomizerEnable) ? (1 + stats.randomizer * 0.1f) : 1)
        );
        clickVisualizer.GetComponent<PointVisualizer>().click(clks);
        stats.clicks += clks;
    }
}
