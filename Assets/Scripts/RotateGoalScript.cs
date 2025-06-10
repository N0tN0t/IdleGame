using System;
using UnityEngine;

public class RotateGoalScript : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, (float)Math.Sin(Time.time)*5);
    }
}
