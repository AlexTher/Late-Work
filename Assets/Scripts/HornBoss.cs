using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornBoss : MonoBehaviour
{
    public AudioSource cold_one;
    public AudioSource evil_laugh;

    public Animator animator;
    public float activationTime = 10f;
    [SerializeField]private float activationCountDown;
    public float buffTime = 10f;
    private float buffCountUp = 0;
    private bool hornActivated = false;

    public void PlayColdOne()
    {
        cold_one.Play();
    }

    public void PlayEvilLaugh()
    {
        evil_laugh.Play();
        MasterEnemy.globalSpeedMod = 2f;
        hornActivated = true;
    }

    public void StartHorn()
    {
        animator.Play("New State");
        animator.Play("CRACKING_A_COLD_ONE");
    }

    private void Update()
    {
        activationCountDown -= Time.deltaTime;
        if (hornActivated) 
            buffCountUp += Time.deltaTime;

        if (activationCountDown < 0)
        {
            StartHorn();
            activationCountDown = activationTime;
        }
        if (buffCountUp > buffTime)
        {
            buffCountUp = 0;
            MasterEnemy.globalSpeedMod = 1f;
            hornActivated = false;
        }
    }

    private void Start()
    {
        activationCountDown = activationTime;


    }
}
