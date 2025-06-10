using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClicksScript : MonoBehaviour
{
    private TMP_Text text;
    public GameObject obj;
    private Stats script;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        script = obj.GetComponent<Stats>();
    }

    void Update()
    {
        text.text = "Нажатий - "+script.clicks;
    }
}
