using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe para gerenciar os modos do jogo
public class GameManager : MonoBehaviour {

    public static GameManager instance;

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

} 



































