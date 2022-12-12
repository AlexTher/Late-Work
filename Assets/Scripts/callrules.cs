using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class callrules : MonoBehaviour
{
    // Start is called before the first frame update
    public void callrule()
    {
        SceneManager.LoadScene("RulesScene");
    }
}
