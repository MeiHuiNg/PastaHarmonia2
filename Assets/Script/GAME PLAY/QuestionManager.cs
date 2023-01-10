using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] AudioClip[] PianoKeys;
    [SerializeField] Image[] lifeSystem;
    [SerializeField] Sprite lifeBreak;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject gameOverCanvas;

    [HideInInspector] int Level=0;

    List<AudioClip> question = new List<AudioClip>();
    

    GameObject [] pots;
    int answerNum = 0;
    int lifecount = 3;
    int checkAnsNum = 0;
    bool checkAns;
    bool isTutorial;
    Sprite oriPlateSprite;
    

    List<onSelectEvent> PotList = new List<onSelectEvent>();
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("TutorialCharacter"))
        {
            Level = 0;
            isTutorial = true;
        }
        else
            Level = 1;    //For testing use, can remove this line once finish testing

        Invoke("MusicQuestion",2f);    // play question on start, will modify and have a countdown function after this
        pots = GameObject.FindGameObjectsWithTag("Pot");
        oriPlateSprite = lifeSystem[0].GetComponent<Image>().sprite;

    }

    private void Update()
    {
        if (!checkAns)
        {
            foreach (var p in pots)
            {
                if (p.transform.GetChild(0).gameObject.GetComponent<Image>().sprite != null)
                {
                    checkAnsNum++;
                }
            }
            if (checkAnsNum == pots.Length)
            {
                Debug.Log(checkAnsNum + " " + pots.Length);
                checkAns = true;
                checkFinalAnswer();

            }
            else
                checkAnsNum = 0;
        }

        if (!isTutorial)
        {
            if (lifecount < 1)
                gameOverCanvas.SetActive(true);
            else if (answerNum == 3)
                winCanvas.SetActive(true);
        }
        else
        {
            if (lifecount < 1)
            {
                foreach (var p in pots)
                {
                    GameObject.Find("Main Canvas").GetComponent<DialogueBoxUI>().DialogueBox[6].SetActive(true);
                    answerNum = 0;
                    lifecount = 3;
                    lifeSystem[lifecount].GetComponent<Image>().sprite = oriPlateSprite;
                    resetPot();
                }
            }
                
            else if (answerNum == 3)
                GameObject.Find("Main Canvas").GetComponent<DialogueBoxUI>().DialogueBox[7].SetActive(true);
        }
        
    }

    public void MusicQuestion()
    {
        
        switch(Level)
        {
            case 1: CreateRandomQuestion(3);
                    AudioManager.Instance.RandomSoundEffect(question);
                    
                    break;
            case 2:
                    break;
            case 3:
                    break;
            case 4:
                    break;
            case 0: question.Add(PianoKeys[0]);
                    question.Add(PianoKeys[1]);
                    question.Add(PianoKeys[2]);
                    break;
            default: break;
        }
    }


    public void CreateRandomQuestion(int num)
    {
        for(int i = 0; i < num; i++)
        {
            question.Add(PianoKeys[Random.Range(0, 2)]); //
        }
    }

    public void ReplayQuestion()    // For replay button
    {
        AudioManager.Instance.RandomSoundEffect(question);
    }

    public void resetPot()
    {
        foreach(var p in pots)
        {
            var childpot = p.transform.GetChild(0).gameObject.GetComponent<Image>();
            p.GetComponent<Image>().sprite = p.GetComponent<onSelectEvent>().OriImage;
            childpot.sprite = null;
            childpot.color = new Color32(255, 255, 255, 0);
        }
        checkAnsNum = 0;
        checkAns = false;
    }

    public void checkFinalAnswer()
    {
        foreach(var p in pots)
        {
            p.GetComponent<onSelectEvent>().deselected();
            var ans = p.transform.GetChild(0).gameObject.GetComponent<AudioSource>().clip;
            if (ans != question[answerNum])
            {
                Debug.Log("wrong answer reset the answer");
                answerNum = 0;
                lifecount -= 1;
                lifeSystem[lifecount].GetComponent<Image>().sprite = lifeBreak;
                resetPot();
                break;
            }
            else
            {
                answerNum++;
                Debug.Log("correct answer");
            }
        }
        /*if(answerNum < question.Count)
        {
            if(AnsClip == question[answerNum])
            {
                answerNum++;
                Debug.Log("correct answer");
                // light the bulb etc.....
            }
            else
            {
                Debug.Log("wrong answer reset the answer");
                answerNum = 0;
                lifecount -= 1;
                lifeSystem[lifecount].GetComponent<Image>().sprite = lifeBreak;
                //loss 1 life
            }
        }
        else   //all correct
        {
            answerNum = 0; // reset
            // result canvas pop out
        }*/
    }

    public void PlayTutorialQuestion()
    {
        AudioManager.Instance.RandomSoundEffect(question);
        StartCoroutine(wait(6.2f));
    }

    IEnumerator wait(float s)
    {
        yield return new WaitForSeconds(s);
        GameObject.Find("Main Canvas").GetComponent<DialogueBoxUI>().DialogueBox[2].SetActive(true);
        AudioManager.Instance.shadow.SetActive(true);

    }
}
