﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class startScreen : MonoBehaviour {

    public GameObject credits;
    public GameObject controls;
    public GameObject us;
    public GameObject splashGGJ;
    public GameObject splashD;
    public GameObject backg;
    public float time=80f;
    bool timeron;


    public void Start()
    {
       
        FindObjectOfType<SoundManager>().Play("LWMenuTrack");
    }

    public void Update()
    {
        if (timeron)
        {
            time= time-Time.deltaTime;
            Debug.Log(+time);
        }

    }

    public void StartButton()
    {
        SceneManager.LoadScene("level1", LoadSceneMode.Single);//load scene level
        FindObjectOfType<SoundManager>().Play("MenuButtonSelectSound");
    }

    public void LoadButton()
    {
        FindObjectOfType<SoundManager>().Play("MenuButtonSelectSound");
    }
    public void Controls(){
        FindObjectOfType<SoundManager>().Play("MenuButtonSelectSound");
        controls.SetActive(true);
    }
    public void CreditsButton()
    {
        timeron = true;
       
        FindObjectOfType<SoundManager>().Play("MenuButtonSelectSound");
        credits.SetActive(true);
        backg.SetActive(true);
        if(time<=60f){
            credits.SetActive(false);
            us.SetActive(true);
        }
        else if(time<40f){
            backg.SetActive(false);
            us.SetActive(false);
            splashD.SetActive(true);
        }
        else if(time<20f){
            splashD.SetActive(false);
            splashGGJ.SetActive(true);
        }
        else if(time<0f){
            splashGGJ.SetActive(false);
        }

    }

}
