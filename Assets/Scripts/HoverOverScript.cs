using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.SetActive(false);
    }
}
