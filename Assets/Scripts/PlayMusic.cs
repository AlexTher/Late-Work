using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource mainmusic;
    public AudioSource yippee;

    // Start is called before the first frame update
    public void playmain(){
        mainmusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}