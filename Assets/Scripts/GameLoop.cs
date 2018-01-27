using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour {
    //Player
    public int Level = 1;
    public int pLevel = 0;
    public int nextLevel = 5;
    public int Souls = 0;
    public int Speed = 1;
    public int Health = 10;
    public int mHealth = 10;
    public int minAttack = 5;
    public int maxAttack = 10;
    public int minDefence = 5;
    public int maxDefence = 10;
    public int Magic = 15;
    public int maxMagic = 15;
    //Player Spawner and Exit
    public bool playerIsDead = true;
    public GameObject player;
    public GameObject pSpawner;
    public GameObject pExit;
    //Enemy
    public GameObject Enemy;
    public int numOfEnemies;
    //Array of Enemy Spawners
    public GameObject[] eSpawners;
    //Inventory
    public Text curLevelText;
    public Text PlayerLevelText;
    public Text soulText;
    public Text speedText;
    public Text healthText;
    public Text attackText;
    public Text defenceText;
    public Text magicText;
    //Upgrade button
    public Button upgradeBtn;
    //Max out button
    public Button maxOutBtn;
    //health bar
    public GameObject bar;
    //magic bar
    public Image magicBar;
    //Opening SaveFile
    private const string FILE_NAME = "Save.dat";
    void Start () {
        //Find All Spawners in level
		Load();
        //Save();
        AutoFindSpawns();
        SpawnEnemy();
        spawnPlayer();
        //spawnPlayer();
    }
    private void FixedUpdate(){
        
        if (Souls >= nextLevel)
        {
            //Run Levelup and raise next Level
            pLevel++;
            nextLevel += nextLevel;
        }

        if(numOfEnemies <= 0)
        {
            //SpawnEnemy();
        }

        bar.transform.localScale = new Vector3(Mathf.Clamp(((float)Health / (float)mHealth), 0f, 1f),
                                                     bar.transform.localScale.y,
                                                     bar.transform.localScale.z);
        magicBar.fillAmount = (float)Magic / (float)maxMagic;

    }
    // Update is called once per frame
    public void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Save();
            print("Game was saved");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Load();
            print("Game was loaded");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SpawnEnemy();
            print("SpawnEnemy");
        }
        curLevelText.text=("Level: " + Level);
        PlayerLevelText.text = ("Player Level: " + pLevel);
        soulText.text = ("Souls: " + Souls);
        speedText.text = ("Speed: " + Speed);
        healthText.text = ("Health: " + Health+"/"+mHealth);
        attackText.text = ("Attack: " + minAttack + "/" + maxAttack);
        defenceText.text = ("Defence: " + minDefence + "/" + maxDefence);
        magicText.text = ("Magic: " + Magic + "/" + maxMagic);

        if(Souls>=10){//make upgrade button visible 
            upgradeBtn.gameObject.SetActive(true);
        }
        else{
            upgradeBtn.gameObject.SetActive(false);
        }

        if(Souls>=50){//make max out button visible
            maxOutBtn.gameObject.SetActive(true);
        }
        else{
            maxOutBtn.gameObject.SetActive(false);
        }

        bar = GameObject.FindGameObjectWithTag("healthBar");
        magicBar = GameObject.FindGameObjectWithTag("magicBar").GetComponent<Image>();

    }

    //Find All Spawners in level
    void AutoFindSpawns()
    {
        eSpawners = GameObject.FindGameObjectsWithTag("Spawners");
        pSpawner = GameObject.FindGameObjectWithTag("playerSpawner");
        pExit = GameObject.FindGameObjectWithTag("playerExit");
    }

    //spawnEnemys it takes the level and give the enemies random stats based on the level number
    void SpawnEnemy()
    {  
        foreach (GameObject respawn in eSpawners)
        {
            Instantiate(Enemy, respawn.transform.position, respawn.transform.rotation);
            numOfEnemies++;
        }
    }
    //Spawning in Player;
    void spawnPlayer()
    {
        Instantiate(player, pSpawner.transform.position, pSpawner.transform.rotation);
        Health=mHealth;
        playerIsDead=false;
    }

    public void MagicPlus()
    {
        Magic++;
    }
    
    public void Save()
    {
        StreamWriter sw = File.CreateText(FILE_NAME);

        //Player
        sw.WriteLine(Level);
        sw.WriteLine(pLevel);
        sw.WriteLine(nextLevel);
        sw.WriteLine(Souls);
        sw.WriteLine(Speed);
        sw.WriteLine(Health);
        sw.WriteLine(mHealth);
        sw.WriteLine(minAttack);
        sw.WriteLine(maxAttack);
        sw.WriteLine(minDefence);
        sw.WriteLine(maxDefence);
        sw.WriteLine(Magic);
        sw.WriteLine(maxMagic);

        sw.Close();
    }

    public void Load()
    {
        StreamReader sr = File.OpenText(FILE_NAME);
        //Player
        Level = Int32.Parse(sr.ReadLine());
        pLevel = Int32.Parse(sr.ReadLine());
        nextLevel = Int32.Parse(sr.ReadLine());
        Souls = Int32.Parse(sr.ReadLine());
        Speed = Int32.Parse(sr.ReadLine());
        Health = Int32.Parse(sr.ReadLine());
        mHealth = Int32.Parse(sr.ReadLine());
        minAttack = Int32.Parse(sr.ReadLine());
        maxAttack = Int32.Parse(sr.ReadLine());
        minDefence = Int32.Parse(sr.ReadLine());
        maxDefence = Int32.Parse(sr.ReadLine());
        Magic = Int32.Parse(sr.ReadLine());
        maxMagic = Int32.Parse(sr.ReadLine());


        sr.Close();
    }

}