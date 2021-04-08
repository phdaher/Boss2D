using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    // Velocidade em que o Backgorund rola
    public float scroll_Speed = 0.1f;

    private MeshRenderer mesh_Renderer;

    void Awake() {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update() {
        Scroll();
    }

    // Funcionalida da função que faz o Background rolar
    void Scroll() {

        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_Speed;
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
} 







































