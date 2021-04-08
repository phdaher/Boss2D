using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

    public float min_X = -7.6f, max_X = 7.6f, min_Y = 6.2f;
    private bool out_Of_Bounds;

    void Update() {
        CheckBounds();
    }

    // Checa as bordas da tela do jogo
    void CheckBounds() {

        Vector2 temp = transform.position;

        if (temp.x > max_X)
            temp.x = max_X;

        if (temp.x < min_X)
            temp.x = min_X;

        transform.position = temp;

        if(temp.y <= min_Y) { 

            if(!out_Of_Bounds) {

                out_Of_Bounds = true;
                GameManager.instance.RestartGame();
            }

        }

    } 

    // Se o jogador encostar no fogo
    void OnTriggerEnter2D(Collider2D target) {

        if(target.tag == "TopFire") {

            transform.position = new Vector2(1000f, 1000f);
            GameManager.instance.RestartGame();

        }

    }

} 



































