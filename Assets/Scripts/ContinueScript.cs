using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ContinueScript : MonoBehaviour
{
    string[] arr = {"Shortly after you finish your last final, you, a Trinity CS student decide to take a break",
    "You load up some games to play on your computer and sit down at your desk to play", 
    "Before you know it, you are fast asleep, launched into a feverish dreamscape",
    "You beg for your life, your grades, your sanity, as you run away from evil programming languages and bastardized versions of your favorite professors",
    "Will you survive? Or will you lose your spot on the Dean's List?",
    "GAME START", ""};
    public TextMeshProUGUI TMPtext;
    int place = 0;
    public void ContinueGame(){
        TMPtext.text = arr[place];
        place++;
        if(place >= arr.Length){
            SceneManager.LoadScene("JacobAndJeremyComb");
        }
    }
}
