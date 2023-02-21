using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onSelectEvent : MonoBehaviour
{
    [SerializeField] public bool isPress;
    public Sprite imagePress;

    [SerializeField] public Sprite OriImage;
    Vector3 scale;

    private void Start()
    {
        scale = this.gameObject.transform.localScale;
        OriImage = this.gameObject.GetComponent<Image>().sprite;
    }
    public void Selected()
    {
        if (!isPress)
        {
            var potlist = GameObject.FindGameObjectsWithTag("Pot");
            foreach (var p in potlist)
            {
                var isp = p.GetComponent<onSelectEvent>().isPress;
                if (isp)
                {
                    p.GetComponent<onSelectEvent>().isPress = false;
                    p.GetComponent<onSelectEvent>().deselected();
                }
                    
            }

            this.gameObject.GetComponent<Image>().sprite = imagePress;
            this.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            isPress = true;
        }
       
    }

    public void deselected()
    {
        StartCoroutine(wait());
        this.gameObject.transform.localScale = scale;
        if(this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite == null)
            this.gameObject.GetComponent<Image>().sprite = OriImage;
        
       
        isPress = false;

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
