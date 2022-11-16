using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornBoss : MonoBehaviour
{
    public AudioSource cold_one;
    public AudioSource evil_laugh;

    public Animator animator;
    public float countDownLength = 10f;
    private float countDown;

    public void PlayColdOne()
    {
        cold_one.Play();
    }

    public void PlayEvilLaugh()
    {
        evil_laugh.Play();
        MasterEnemy.globalSpeedMod = 2f;
    }

    public void StartHorn()
    {
        animator.Play("New State");
        animator.Play("CRACKING_A_COLD_ONE");
    }

    private void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0)
        {
            StartHorn();
            countDown = countDownLength;
        }
    }

    private void Start()
    {
        countDown = countDownLength;


    }
}
