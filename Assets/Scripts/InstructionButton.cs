using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class InstructionButton : MonoBehaviour
{
    string[] arr = {"The shop is labeled, click items and click on the background to place towers",
    "Different enemies with different health spawn, you are going to kill them", 
    "Bosses affect gameplay, making enemies faster and stronger",
    "Towers decay over time, so be sure to replace them appropriately",
    "Some towers have diffent strengths, firing speeds, and longevities",
    "RETURNING", ""};
    public TextMeshProUGUI TMPtext;
    int place = 0;
    public void CallInstruction(){
        SceneManager.LoadScene("HelpScene");   
    }
    public void SendBack(){
        TMPtext.text = arr[place];
        place++;
        if(place >= arr.Length){
            SceneManager.LoadScene("TitleScene");
        }
    }
}
