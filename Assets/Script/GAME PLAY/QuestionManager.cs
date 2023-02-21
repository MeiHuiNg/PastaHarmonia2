using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;
    [SerializeField] AudioClip[] PianoKeys;
    [SerializeField] Image[] lifeSystem;
    [SerializeField] Sprite lifeBreak;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject replayCanvas;

    [SerializeField] Image[] tomatoSystem;
    [SerializeField] Sprite tomatoGrey;


    [HideInInspector] public int Level=0;

    [Header("Sound Effect")]
    public AudioSource Breakingplate;
    public AudioSource Win;
    public AudioSource Lose;
    public AudioSource Serious;

    List<AudioClip> question = new List<AudioClip>();
    AudioClip []disturb = new AudioClip [4];

    public GameObject [] pots;
    int answerNum = 0;
    int lifecount = 3;
    int checkAnsNum = 0;
    bool checkAns;
    bool isTutorial;
    bool replay;
    Sprite oriPlateSprite;
    

    List<onSelectEvent> PotList = new List<onSelectEvent>();
    private void Start()
    {
        answerNum = 0;
        if (GameObject.FindGameObjectWithTag("TutorialCharacter"))
        {
            Level = 0;
            isTutorial = true;
        }
        else
        {
            Serious.Play();
            if (SceneManager.GetActiveScene().buildIndex == 2)
                Level = 1;    //For testing use, can remove this line once finish testing
            else if (SceneManager.GetActiveScene().buildIndex == 3)
                Level = 2;
            else if (SceneManager.GetActiveScene().buildIndex == 4)
                Level = 3;
            else if (SceneManager.GetActiveScene().buildIndex == 5)
                Level = 4;
        }
            
        Invoke("MusicQuestion",2f);    // play question on start, will modify and have a countdown function after this
       // pots = GameObject.FindGameObjectsWithTag("Pot");
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
            if (lifecount < 1)  //loseeeeeeeee
                gameOverCanvas.SetActive(true);
            else if (answerNum == pots.Length)
                winCanvas.SetActive(true);  //win  
        }
        else
        {
            if (lifecount < 1)
            {
                GameObject.Find("Main Canvas").GetComponent<DialogueBoxUI>().tutorialPasta.SetActive(true);
                GameObject.Find("Main Canvas").GetComponent<DialogueBoxUI>().DialogueBox[6].SetActive(true);
                GameObject.Find("Try Again Box").GetComponent<DialogueBoxUI>().Soto[0].Play();
                
                answerNum = 0;
                lifecount = 3;
                resetPot();
                resetPlate();
            }
                
            else if (answerNum == 3)
            {
                //GameObject.FindGameObjectWithTag("Shadow").SetActive(true);
                GameObject.Find("Main Canvas").GetComponent<DialogueBoxUI>().DialogueBox[7].SetActive(true);
            }
        }
        
    }

    public void MusicQuestion()
    {
        
        switch(Level)
        {
            case 1: //CreateRandomQuestion(3);
                    question.Clear();
                    question.Add(PianoKeys[0]);
                    question.Add(PianoKeys[1]);
                    question.Add(PianoKeys[1]);
                    AudioManager.Instance.RandomSoundEffect(question);
                    
                    break;
            case 2:
                    question.Clear();
                    question.Add(PianoKeys[2]);
                    question.Add(PianoKeys[1]);
                    question.Add(PianoKeys[0]);
                    AudioManager.Instance.RandomSoundEffect(question);
                    break;
            case 3:
                    question.Clear();
                    question.Add(PianoKeys[Random.Range(0,3)]);
                    question.Add(PianoKeys[Random.Range(0, 3)]);
                    question.Add(PianoKeys[Random.Range(0, 3)]);
                    question.Add(PianoKeys[Random.Range(0, 3)]);
                    AudioManager.Instance.RandomSoundEffect(question);
                    break;
            case 4:
                    question.Clear();
                    question.Add(PianoKeys[Random.Range(0, 3)]);
                    question.Add(PianoKeys[Random.Range(0, 3)]);
                    question.Add(PianoKeys[Random.Range(0, 3)]);
                    question.Add(PianoKeys[Random.Range(0, 3)]);
                    disturb[Random.Range(0, 2)] = PianoKeys[Random.Range(0, 3)];
                    AudioManager.Instance.RandomSoundEffect_Disturb(question, disturb);
                    break;
            case 0:
                    question.Clear();
                    question.Add(PianoKeys[0]);
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
           // question.Add(PianoKeys[Random.Range(0, 2)]); //
        }
    }

    public void ReplayQuestion()    // For replay button
    {
        if (!replay )
        {
            if(Level == 4)
                AudioManager.Instance.Replay_Disturb(question, disturb);
            else
                AudioManager.Instance.Replay(question);
            replay = true;
            replayCanvas.SetActive(false);
        }
        
    }

    public void resetPot()
    {
        
        foreach (var p in pots)
        {
            var childpot = p.transform.GetChild(0).gameObject.GetComponent<Image>();
            p.GetComponent<Image>().sprite = p.GetComponent<onSelectEvent>().OriImage;
            childpot.sprite = null;
            childpot.color = new Color32(255, 255, 255, 0);
           // lifeSystem[lifecount - 1].GetComponent<Image>().sprite = oriPlateSprite;
        }
        checkAnsNum = 0;
        checkAns = false;
    }

    public void resetPlate()
    {
        foreach (var p in lifeSystem)
        {
            lifecount = 3;
            p.GetComponent<Image>().sprite = oriPlateSprite;
        }
    }

    public void checkFinalAnswer()
    {
        
        foreach(var p in pots)
        {
            p.GetComponent<onSelectEvent>().deselected();
            var ans = p.transform.GetChild(0).gameObject.GetComponent<AudioSource>().clip;
            if (ans != question[answerNum])
            {
                answerNum = 0;
                lifecount -= 1;
                lifeSystem[lifecount].GetComponent<Image>().sprite = lifeBreak;

                if (lifecount < 1)
                    Lose.Play();
                else
                    Breakingplate.Play();

                if (lifecount == 2)
                {
                    tomatoSystem[2].GetComponent<Image>().sprite = tomatoGrey;
                }else if(lifecount == 1)
                {
                    tomatoSystem[1].GetComponent<Image>().sprite = tomatoGrey;
                    tomatoSystem[2].GetComponent<Image>().sprite = tomatoGrey;
                }
                else
                {

                }

                resetPot();
                break;
            }
            else
            {
                answerNum++;               
                if (answerNum==pots.Length)
                    Win.Play();
            }
        }      
    }

    public void PlayTutorialQuestion1()
    {
        Serious.Play();
        Invoke("PlayTutorialQuestion",2f);
    }
    public void PlayTutorialQuestion()
    {
        //Serious.Play();
        AudioManager.Instance.RandomSoundEffect(question);
        StartCoroutine(wait(4.65f));
    }

    IEnumerator wait(float s)
    {
        yield return new WaitForSeconds(s);
        GameObject.Find("Main Canvas").GetComponent<DialogueBoxUI>().DialogueBox[2].SetActive(true);
        AudioManager.Instance.shadow.SetActive(true);

    }
}
