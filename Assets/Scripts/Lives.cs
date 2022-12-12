using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Lives : MonoBehaviour
{
    public int lifeint = 5;
    string lifeLevel = "A";
    public AudioSource tookdamage;
    // Start is called before the first frame update
    void Start()
    {
        lifeint = 5;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("LifeText").GetComponent<TMPro.TextMeshProUGUI>().text = lifeLevel;
        if (lifeint == 5)
        {
            GameObject.Find("LifeText").GetComponent<TMPro.TextMeshProUGUI>().color = Color.green;
            lifeLevel = "Grade: A";
        }
        else if (lifeint == 4)
        {
            lifeLevel = "Grade: B";
        }
        else if (lifeint == 3)
        {
            GameObject.Find("LifeText").GetComponent<TMPro.TextMeshProUGUI>().color = Color.yellow;
            lifeLevel = "Grade: C";
        }
        else if (lifeint == 2)
        {
            GameObject.Find("LifeText").GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
            lifeLevel = "Grade: D";
        }
        else if (lifeint == 1)
        {
            lifeLevel = "Grade: F";
            SceneManager.LoadScene("EndScene");
        }
    }

    public void Lifecounter()
    {
        lifeint -= 1;
        tookdamage.Play();
    }
}
