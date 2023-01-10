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

    QuestionManager qm;
    int currentLine = 0;
    int currentBox = 0;
    GameObject tmp;
    private void Start()
    {
        //DialogueLine[0] = "BENVENUTO A PASTA HARMONIA!";
        qm = GameObject.Find("QuestionManager").GetComponent<QuestionManager>();

        foreach(var b in DialogueBox)
        {
            if(b.name == this.name)
            {
                Debug.Log(currentBox);
                break;
            }
            currentBox++;
        }

        if(this.gameObject.name == "Explain Pasta Box")
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
        DialogueText.text = DialogueLine[0];
        tutorialPasta.SetActive(true);
    }

    public void waitToPlayQuestion()
    {
        qm.PlayTutorialQuestion();
    }

    public void changeLine()
    {
        currentLine++;
        if (DialogueLine.Length > currentLine)
            DialogueText.text = DialogueLine[currentLine];
        else
        {
            if(this.gameObject.name == "Explain Pasta Box")
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().warning.SetActive(true);
                tmp.transform.SetSiblingIndex(7);
                Invoke("waitToPlayQuestion", 2f);
                this.gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("TutorialCharacter").SetActive(false);
            }
            else
            {
                if (this.gameObject.name == "Try Now Box" || this.gameObject.name == "Try Again Box" || this.gameObject.name == "Finish Tutorial Box")
                {
                    GameObject.FindGameObjectWithTag("TutorialCharacter").SetActive(false);
                    GameObject.FindGameObjectWithTag("Shadow").SetActive(false);
                }
                else
                    DialogueBox[currentBox + 1].SetActive(true);
                if(tmp != null)
                    tmp.transform.SetSiblingIndex(7);
                this.gameObject.SetActive(false);
                


            }
        }
            
    }
}
