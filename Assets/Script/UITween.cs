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
        LeanTween.scale(wheel, new Vector3(1, 1, 1), 2).setDelay(0f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(backPanel, new Vector3(1, 1, 1), 2).setDelay(0f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Tomato1, new Vector3(1, 1, 1), 2).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Tomato2, new Vector3(1, 1, 1), 2).setDelay(1.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Tomato3, new Vector3(1, 1, 1), 2).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Amazza, new Vector3(1, 1, 1), 2).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(rabion, new Vector3(1, 1, 1), 2).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(NextLevelButton, new Vector3(1, 1, 1), 2).setDelay(4f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.scale(homeButton, new Vector3(1, 1, 1), 2).setDelay(4f).setEase(LeanTweenType.easeOutCubic);
        
    }
}
