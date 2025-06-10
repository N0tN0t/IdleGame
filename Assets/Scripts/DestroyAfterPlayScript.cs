using UnityEngine;

public class DestroyAfterPlayScript : MonoBehaviour
{

    float time;

    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time > gameObject.GetComponent<AudioSource>().clip.length)
        {
            Destroy(gameObject);
        }
    }
}
