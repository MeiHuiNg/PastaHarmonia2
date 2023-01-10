using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoKeyButton : MonoBehaviour
{
    AudioClip pianoKeyButton;
    QuestionManager qManager;
    onSelectEvent potObject;
    // Start is called before the first frame update
    bool isSelect;
    void Start()
    {
        pianoKeyButton = GetComponent<AudioSource>().clip;
        qManager = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();
    }

    private void Update()
    {
        var potlist = GameObject.FindGameObjectsWithTag("Pot");
        foreach (var p in potlist)
        {
            var potSelect = p.GetComponent<onSelectEvent>();
            if (potSelect.isPress)
            {
                isSelect = true;
                potObject = potSelect;
                break;
            }
            else
            {
                isSelect = false;
            }
        }
    }

    public void buttonOnPress()
    {
        
        if (!isSelect)
        {
            AudioManager.Instance.PlayMusic(pianoKeyButton);
        }
        else
        {
            var childpot = potObject.transform.GetChild(0).gameObject.GetComponent<Image>();
            //var parentpot = potObject.GetComponent<Image>();
            childpot.sprite = this.gameObject.GetComponent<Image>().sprite;
            potObject.GetComponent<Image>().sprite = potObject.imagePress;
            childpot.color = new Color32(255, 255, 255, 255);

            var PotAudioClip = potObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>() ;
            PotAudioClip.clip = this.gameObject.GetComponent<AudioSource>().clip;
            
        }
        //qManager.OnPressAnswer(pianoKeyButton);
    }
}
