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

    void Update()
    {
        if (lives >= 80 && lives <= 100){ Health.text = "A (" + lives + "%)"; }
        if (lives >= 60 && lives < 80){ Health.text = "B (" + lives + "%)"; }
        if (lives >= 40 && lives < 60){ Health.text = "C (" + lives + "%)"; }
        if (lives >= 20 && lives < 40){ Health.text = "D (" + lives + "%)"; }
        if (lives >= 0 && lives < 20){ Health.text = "F (" + lives + "%)"; }
    }
}
