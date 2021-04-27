using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Classe para gerenciar os modos do jogo
public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public int recordLevel;
    public int level;

   private GameManager()
   {
       level = 1;
       recordLevel = 1;
   }

    void Start()
    {
        level = 1;
        recordLevel = PlayerPrefs.GetInt("recordLevel", 1);
    }
    void Awake() {
        if (instance == null)
            instance = this;
    }
    public void RestartGame() {
        Invoke("RestarteAfterTime", 2f);
    }

    void RestarteAfterTime() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void NextLevel() {
        level += 1;
        recordLevel = Math.Max(level, recordLevel);
        PlayerPrefs.SetInt("recordLevel", recordLevel);
    }
    public void ResetLevel() {
        level = 1;
    }


} 



































