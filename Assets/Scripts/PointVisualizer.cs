using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PointVisualizer : MonoBehaviour
{


    public GameObject Click;

    public void click(int clicks)
    {
        GameObject click1 = GameObject.Instantiate(Click);
        click1.GetComponent<TMP_Text>().text = "+" + clicks;
        click1.transform.SetParent(transform);
        click1.transform.position = gameObject.transform.position + new Vector3(Random.Range(-150, 150), Random.Range(-150, 150), 0);
        if (click1.GetComponent<ClickMover>() != null)
        {
            click1.GetComponent<ClickMover>().active = true;
        }
    }

}
