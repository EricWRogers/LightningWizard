using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class startScreen : MonoBehaviour {

    public void Update()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene("level1", LoadSceneMode.Single);//load scene level
    }

    public void LoadButton()
    {

    }
    public void CreditsButton()
    {
        //credits.SetActive(true);
    }

}
