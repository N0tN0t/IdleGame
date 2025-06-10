using System;
using UnityEngine;

public class MainScreenBGScript : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, (float)Math.Sin(Time.time) * 7);
    }
}
