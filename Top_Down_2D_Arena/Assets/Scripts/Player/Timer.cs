using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;

    private void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
    }
}
