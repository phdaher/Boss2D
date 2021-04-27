using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_Countdown : MonoBehaviour
{
   Text textComp;
    GameManager gm;


   public float timeRemaining = 5;
   void Start()
   {
       textComp = GetComponent<Text>();
       gm = GameManager.instance;     
   }
   
   void Update()
   {
       if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else 
        {
            timeRemaining = 5;
            gm.NextLevel();
        }
       textComp.text = $"Desativa em: {Math.Truncate(timeRemaining)} s";
   }
}