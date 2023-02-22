using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour
{
    [SerializeField]
    GameObject backPanel, homeButton, NextLevelButton, retryButton,

    Tomato1, Tomato2, Tomato3, Amazza, rabion, wheel;


    [SerializeField] AudioSource tomato;
    [SerializeField] AudioSource stamp;
    private void Start()
    {
        LeanTween.rotateAround(wheel, Vector3.forward, -360, 10f).setLoopClamp();
        LeanTween.scale(wheel, new Vector3(1, 1, 1), 2).setDelay(0f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(backPanel, new Vector3(1, 1, 1), 2).setDelay(0f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Tomato1, new Vector3(1, 1, 1), 2).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        StartCoroutine(playTomato(1));
        LeanTween.scale(Tomato2, new Vector3(1, 1, 1), 2).setDelay(1.5f).setEase(LeanTweenType.easeOutElastic);
        StartCoroutine(playTomato(1.5f));
        LeanTween.scale(Tomato3, new Vector3(1, 1, 1), 2).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
        StartCoroutine(playTomato(2f));
        LeanTween.rotateAround(Amazza, Vector3.forward, -720, 1f).setDelay(2.5f);
        LeanTween.scale(Amazza, new Vector3(1, 1, 1), 2f).setDelay(2.3f).setEase(LeanTweenType.easeInOutElastic);
        stamp.PlayDelayed(3f);
        LeanTween.scale(rabion, new Vector3(1, 1, 1), 2).setDelay(3f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(NextLevelButton, new Vector3(1, 1, 1), 2).setDelay(4f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.scale(homeButton, new Vector3(1, 1, 1), 2).setDelay(4f).setEase(LeanTweenType.easeOutCubic);
        LeanTween.scale(retryButton, new Vector3(1, 1, 1), 2).setDelay(4f).setEase(LeanTweenType.easeOutCubic);
    }

    IEnumerator playTomato(float w)
    {
        yield return new WaitForSeconds(w); 
        tomato.Play();
    }
}
