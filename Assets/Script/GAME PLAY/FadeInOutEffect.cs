using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutEffect : MonoBehaviour
{
    public float fadeOutTime = 1f;
    bool fo;
    bool complete;
    bool completeText;
    private void Start()
    {
        // fadeOutTime = 0.5f;
        if (!this.gameObject.CompareTag("Unlock"))
            fo = true;
    }
    private void Update()
    {
        if (!fo && !this.gameObject.CompareTag("Unlock") && !this.gameObject.CompareTag("UnlockText"))
        {
            coroutineFadeIn();
        }
        else if (fo && !this.gameObject.CompareTag("Unlock") && !this.gameObject.CompareTag("UnlockText"))
        {
            coroutineFadeOut();
        }
        else if (completeText)
        {
            coroutineTextCompleteFadeOut();
        }
        else if (complete && this.gameObject.CompareTag("Unlock"))
        {
            coroutineCompleteFadeOut();
        }
        



    }

    public void setComplete()
    {
        complete = true;
    }
    public void setCompleteText()
    {
        completeText = true;
    }
    public void coroutineTextCompleteFadeOut()
    {
        StartCoroutine(doTextCompleteFadeOut(GetComponent<Text>()));
    }
    public void coroutineCompleteFadeOut()
    {
        StartCoroutine(doCompleteFadeOut(GetComponent<Image>()));
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

    IEnumerator doCompleteFadeOut(Image _sprite)
    {
        float tmpColor = _sprite.color.a;

        while (tmpColor > 0.1f)
        {
            tmpColor -= Time.deltaTime * fadeOutTime;
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, tmpColor);

            if (tmpColor <= 0f)
                tmpColor = 0f;

            yield return null;
        }

        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, tmpColor);
        this.gameObject.SetActive(false);
        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 0.4f);
        complete = false;
    }

    IEnumerator doTextCompleteFadeOut(Text _sprite)
    {
        float tmpColor = _sprite.color.a;

        while (tmpColor > 0.1f)
        {
            tmpColor -= Time.deltaTime * fadeOutTime;
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, tmpColor);

            if (tmpColor <= 0f)
                tmpColor = 0f;

            yield return null;
        }

        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, tmpColor);
       // this.gameObject.SetActive(false);
        _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 1);
        completeText = false;
    }

}
