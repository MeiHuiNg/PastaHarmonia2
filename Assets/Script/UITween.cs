using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour
{
    [SerializeField]
    GameObject backPanel, homeButton, NextLevelButton,

    Tomato1, Tomato2, Tomato3, Amazza, rabion, wheel;

    private void Start()
    {
        LeanTween.rotateAround(wheel, Vector3.forward, -360, 10f).setLoopClamp();
        LeanTween.scale(Amazza, new Vector3(1, 1, 1), 2).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
        ;
    }
}
