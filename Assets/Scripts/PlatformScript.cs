using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public float move_Speed = 2f;
    public float bound_Y = 4f;
    GameManager gm;

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;

    void Start()
    {
       gm = GameManager.instance;     
    }

    // Se for um objeto quebravel ele faz a animação
    void Awake() {
        if (is_Breakable)
            anim = GetComponent<Animator>();
    }

    void Update() {
        Move();
    }

    // Movimento da plataforma 
    void Move() {

        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime * gm.level / 2;
        transform.position = temp;

        // Detecta se saiu da tela e desativa
        if(temp.y >= bound_Y) {
            gameObject.SetActive(false);
        }

    }

    void BreakableDeactivate() {
        Invoke("DeactivateGameObject", 0.35f);
    }

    void DeactivateGameObject() {
         SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target) {
        
        // Se o jogador triscar na plataforma com espinhos
        if(target.tag == "Player") { 

            if(is_Spike) {

                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();

            }

        }

    } 

    void OnCollisionEnter2D(Collision2D target) {

        // Se o jogador cair na plataforma quebrável
        if(target.gameObject.tag == "Player") { 

            if(is_Breakable) {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            if(is_Platform) {
                SoundManager.instance.LandSound();
            }


        }

    } 

    void OnCollisionStay2D(Collision2D target) {

        // Se o jogador cair em cima das plataormas que se movimentam
        if(target.gameObject.tag == "Player") { 
       
            if(moving_Platform_Left) {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }

            if (moving_Platform_Right) {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }

        }

    } 

} 








































