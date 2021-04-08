using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D myBody;

    // Velocidade do jogador
    public float moveSpeed = 8f;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        Move();
    }

    // Controla o jogador com o teclado
    void Move() {
     
        if(Input.GetAxisRaw("Horizontal") > 0f) {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f) {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
    } 

} 






































