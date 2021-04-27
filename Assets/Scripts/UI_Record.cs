using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Record : MonoBehaviour
{
    Text textComp;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
       textComp = GetComponent<Text>();   
       gm = GameManager.instance;     
    }

    // Update is called once per frame
    void Update()
    {
       textComp.text = $"Record: Level {gm.recordLevel}";        
    }
}
