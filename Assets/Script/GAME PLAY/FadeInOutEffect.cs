using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutEffect : MonoBehaviour
{
    public float fadeOutTime = 1f;
    bool fo;

    private void Start()
    {
       // fadeOutTime = 0.5f;
        fo = true;  
    }
    private void Update()
    {
        if (!fo)
        {
            coroutineFadeIn();
        }
        else
        {
            coroutineFadeOut();
        }
    }

    public void coroutineFadeOut()
    {
        StartCoroutine(doFadeOut(GetComponent<Image>()));
    }

    public void coroutineFadeIn()
    {
        StartCoroutine(doFadeIn(GetComponent<Image>()));
    }

    IEnumerator doFadeIn(Image _sprite)
    {
        float tmpColor = _sprite.color.a;

        while(tmpColor < 1f)
        {
            tmpColor += Time.deltaTime * fadeOutTime;
            _sprite.color= new Color (_sprite.color.r, _sprite.color.g, _sprite.color.b, tmpColor);

            if (tmpColor >= 1f)
                tmpColor = 1.0f;

            yield return null;
        }

        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, tmpColor);

        fo = true;
    }

    IEnumerator doFadeOut(Image _sprite)
    {
        float tmpColor = _sprite.color.a;

        while (tmpColor > 0.4f)
        {
            tmpColor -= Time.deltaTime * fadeOutTime;
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, tmpColor);

            if (tmpColor <= 0f)
                tmpColor = 0f;

            yield return null;
        }

        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, tmpColor);

        fo = false;
    }
}
