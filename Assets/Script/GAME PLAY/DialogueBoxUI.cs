using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxUI : MonoBehaviour
{
    [SerializeField] public string[] DialogueLine;
    [SerializeField] public Text DialogueText;
    [SerializeField] public GameObject [] DialogueBox;
    [SerializeField] public GameObject tutorialPasta;
    [SerializeField] public AudioSource[] Soto;

    QuestionManager qm;
    int currentLine = 0;
    int currentBox = 0;
    GameObject tmp;
    private void Start()
    {
        
        qm = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();

        foreach(var b in DialogueBox)
        {
            if(b.name == this.name)
            {
                Soto[0].Play();
                Debug.Log(currentBox);
                break;
            }
            currentBox++;
        }
       
        if (this.gameObject.name == "Explain Pasta Box")
        {
            tmp = GameObject.FindGameObjectWithTag("PastaCharacter");
            tmp.transform.SetSiblingIndex(12);
        }
        else if (this.gameObject.name == "Explain Pot Answer Box")
        {
            tmp = GameObject.Find("Pot answer");
            tmp.transform.SetSiblingIndex(12);
        }
        else if (this.gameObject.name == "Explain Life System Box")
        {
            tmp = GameObject.FindGameObjectWithTag("LifeSystem");
            tmp.transform.SetSiblingIndex(10);
        }
        else if (this.gameObject.name == "Replay Question Box")
        {
            tmp = GameObject.FindGameObjectWithTag("ReplayButton");
            tmp.transform.SetSiblingIndex(12);
        }
        else if (this.gameObject.name == "Try Again Box")
        {
            tutorialPasta.SetActive(true);
            AudioManager.Instance.shadow.SetActive(true);
        }
        
        DialogueText.text = DialogueLine[0];
        tutorialPasta.SetActive(true);
    }



    public void waitToPlayQuestion()
    {
        qm.PlayTutorialQuestion();
    }

    public void changeLine()
    {
        Soto[currentLine].Stop();
        currentLine++;        
        if (DialogueLine.Length > currentLine)
        {           
            DialogueText.text = DialogueLine[currentLine];          
            Soto[currentLine].Play();
        }          
        else
        {

            if(this.gameObject.name == "Explain Pasta Box")
            {
                tmp.transform.SetSiblingIndex(7);
            }
            
            if (this.gameObject.name == "Finish Tutorial Box")
            {
                var load = GameObject.Find("LoadSceneManager").GetComponent<LoadScene>();
                load.LoadMainMenu();
            }
            else if (this.gameObject.name == "Try Again Box")
            {
                qm.resetPot();
                qm.resetPlate();
                GameObject.FindGameObjectWithTag("TutorialCharacter").SetActive(false);
                AudioManager.Instance.shadow.SetActive(false);
                //var load = GameObject.Find("LoadSceneManager").GetComponent<LoadScene>();
                //load.LoadHowToPlay();
            }
            else if (this.gameObject.name == "Try Now Box")
            {
                GameObject.FindGameObjectWithTag("TutorialCharacter").SetActive(false);
                GameObject.Find("AudioManager").GetComponent<AudioManager>().warning.SetActive(true);
                    
                qm.PlayTutorialQuestion1();
                this.gameObject.SetActive(false);
                //GameObject.FindGameObjectWithTag("TutorialCharacter").SetActive(false);
            }
            else if (this.gameObject.name == "Dialogue")
            {
                GameObject.FindGameObjectWithTag("TutorialCharacter").SetActive(false);
                GameObject.Find("AudioManager").GetComponent<AudioManager>().warning.SetActive(true);
                Debug.Log("ss");
                QuestionManager.instance.playLevel4Invoke();
                this.gameObject.SetActive(false);
                //GameObject.FindGameObjectWithTag("TutorialCharacter").SetActive(false);
            }
            else if (DialogueBox.Length > 1)
                DialogueBox[currentBox + 1].SetActive(true);
            else
            {
                tutorialPasta.SetActive(false);
                AudioManager.Instance.shadow.SetActive(false);
            }
                    
            if (tmp != null)
                tmp.transform.SetSiblingIndex(4);
            this.gameObject.SetActive(false);
            
            currentLine=0;
        }
            
    }
}
