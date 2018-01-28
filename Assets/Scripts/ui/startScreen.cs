using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class startScreen : MonoBehaviour {

    public GameObject credits;
    public GameObject controls;

    public void Update()
    {

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
        FindObjectOfType<SoundManager>().Play("MenuButtonSelectSound");
        credits.SetActive(true);
    }

}
