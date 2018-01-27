using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {
    public GameObject pause;
    private bool isEnabled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Enable pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && !isEnabled)
        {
            pause.SetActive(true);
            isEnabled = true;
            Time.timeScale = 0;
            //quitBtn.SetActive(true);
            //adds.SetActive(false);
        }

        // disable pause menu
        else if (Input.GetKeyDown(KeyCode.Escape) && isEnabled)
        {
            pause.SetActive(false);
            isEnabled = false;
            Time.timeScale = 1;
        }
    }
    public void SaveButton()
    {
        //PersistentStorage.instance.Save();//saves 
        //gameloop.Save();
    }

    public void Resume(){
        pause.SetActive(false);
        isEnabled = false;
        Time.timeScale = 1;
    }

    public void Options(){
        
    }

    public void Quit()
    {
        SceneManager.LoadScene("startMenu", LoadSceneMode.Single);//loads start menu
    }
}
