using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public float move_Speed = 2f;
    public float bound_Y = 4f;

    public bool is_Spike, is_Platform;
    
    void Update() {
        Move();
    }

    // Movimento da plataforma 
    void Move() {

        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        // Detecta se saiu da tela e desativa
        if(temp.y >= bound_Y) {
            gameObject.SetActive(false);
        }

    }

    // Se o jogador bater nos espinhos
    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "Player") { 

            if(is_Spike) {

                target.transform.position = new Vector2(1000f, 1000f);
                GameManager.instance.RestartGame();

            }

        }

    } 

} 







































