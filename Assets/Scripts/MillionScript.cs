using TMPro;
using UnityEngine;

public class MillionScript : MonoBehaviour
{

    public GameObject statsObj;
    public GameObject BossFight;
    public GameObject goalText;
    public GameObject bossFightPanel;
    public GameObject bossFigthTimer;
    public GameObject finishGame;

    private Stats stats;
    private bool end = false;

    private int endAmo = 150;

    float tm = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = statsObj.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.clicks >= 1000000 && end == false)
        {
            end = true;
            goalText.GetComponent<TMP_Text>().text = "Цель - не дать дойти до 0 нажатий";
            tm = Time.time;
            bossFigthTimer.SetActive(true);
        }
        if (stats.clicks <= 0)
        {
            end = false;
            goalText.GetComponent<TMP_Text>().text = "Цель - 1 миллион нажатий!";
            bossFigthTimer.SetActive(false);
        }

        if (end)
        {
            bossFigthTimer.GetComponent<TMP_Text>().text = ((int)(120 - (Time.time - tm))).ToString();
            if (stats.clicks - endAmo * 100 * 3 * bossFightPanel.GetComponentInChildren<Transform>().childCount > 0 && Random.Range(1,100) == Random.Range(1,100))
            {
                GameObject bossFightClone = GameObject.Instantiate(BossFight);
                bossFightClone.transform.SetParent(bossFightPanel.transform);
                bossFightClone.GetComponent<BossFightMinusScript>().amount = endAmo * 100;
                bossFightClone.GetComponent<BossFightMinusScript>().enabled = true;
                bossFightClone.transform.position = bossFightPanel.transform.position + new Vector3(Random.Range(-200,200),Random.Range(-150,150));
            }
            if (stats.clicks - endAmo > 0)
            {
                stats.clicks -= endAmo;
            }
            else
            {
                stats.clicks = 0;
                foreach( Transform tr in bossFightPanel.GetComponentInChildren<Transform>() ) {
                    Destroy(tr.gameObject);
                }
            }
            if (Time.time - tm > 20)
            {
                foreach( Transform tr in bossFightPanel.GetComponentInChildren<Transform>() ) {
                    Destroy(tr.gameObject);
                }
                end = false;
                goalText.GetComponent<TMP_Text>().text = "Вы победили!";
                stats.clicks = 1;
                bossFigthTimer.SetActive(false);
                finishGame.GetComponent<AudioSource>().Play();
            }
        }
    }
}
