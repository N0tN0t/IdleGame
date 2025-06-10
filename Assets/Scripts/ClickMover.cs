using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ClickMover : MonoBehaviour
{

    public bool active;

    private float time=-1;

    private int rand;
    private int rand1;
    private int rand2;

    void Start()
    {
        time = Time.time;
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            rand = -1;
        }
        rand1 = Random.Range(-3, 5);
        rand2 = Random.Range(1, 5);
        if (rand1 <= 0)
        {
            rand1 = 1/(rand1-1)*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {

            float tm = Time.time-time;
            transform.position += new Vector3(((1) / (-(tm + 1)) + 1)*rand1*rand,tm*rand2,0);
            GetComponent<TMP_Text>().color = new Color(GetComponent<TMP_Text>().color.r, GetComponent<TMP_Text>().color.g, GetComponent<TMP_Text>().color.b, 0.8313726f - tm);
            if (tm > 3)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
