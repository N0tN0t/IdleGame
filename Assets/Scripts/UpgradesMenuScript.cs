using TMPro;
using UnityEngine;

public class UpgradesMenuScript : MonoBehaviour
{

    public GameObject um;
    public GameObject UpSound;
    public GameObject DownSound;

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
            if (cmpnt.parent.name == "PlusOne" && cmpnt.name == "Value")
            {
                cmpnt.parent.GetComponent<PlusOneScript>().setValue();
            }
            else if (cmpnt.parent.name == "Multiplier" && cmpnt.name == "Value")
            {
                cmpnt.parent.GetComponent<MultiplierScript>().setValue();
            }
            else if (cmpnt.parent.name == "Discounts" && cmpnt.name == "Value")
            {
                cmpnt.parent.GetComponent<DiscouintsScript>().setValue();
            }
            else if (cmpnt.parent.name == "Randomizer" && cmpnt.name == "Value")
            {
                cmpnt.parent.GetComponent<RandomizerScript>().setValue();
            }
        }
    }
}
