using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public int lifeint = 5;
    string lifeLevel = "A";
    // Start is called before the first frame update
    void Start()
    {
        lifeint = 5;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("LifeText").GetComponent<Text>().text = lifeLevel;
        if (lifeint == 5)
        {
            GameObject.Find("LifeText").GetComponent<Text>().color = Color.green;
            lifeLevel = "A";
        }
        else if (lifeint == 4)
        {
            lifeLevel = "B";
        }
        else if (lifeint == 3)
        {
            GameObject.Find("LifeText").GetComponent<Text>().color = Color.yellow;
            lifeLevel = "C";
        }
        else if (lifeint == 2)
        {
            GameObject.Find("LifeText").GetComponent<Text>().color = Color.red;
            lifeLevel = "D";
        }
        else if (lifeint == 1)
        {
            lifeLevel = "F";
            SceneManager.LoadScene("EndScene");
        }
    }

    public void Lifecounter()
    {
        lifeint -= 1;
    }
}
