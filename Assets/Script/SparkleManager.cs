using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleManager : MonoBehaviour
{
    public GameObject Sparkle;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Sparkle.SetActive(true);
    }
}
