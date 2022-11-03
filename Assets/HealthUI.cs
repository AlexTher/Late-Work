using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public static int lives;
    public int healthCt = 100;
    public Text Health;

    void Start()
    {
        lives = healthCt;
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = lives + "%";
    }
}
