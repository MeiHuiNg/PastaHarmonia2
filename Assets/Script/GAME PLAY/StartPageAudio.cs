using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPageAudio : MonoBehaviour
{
    public AudioSource clairPop;
    // Start is called before the first frame update
    
    public void PlayClairPop()
    {
        clairPop.Play();
    }
}
