using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float Velocidade = 8;
    public int Vida = 10;

    public bool Vivo = true;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    private Vector3 direcao;

    void Start(){
        Time.timeScale = 1;
        TextoGameOver.SetActive(false);
    }

    void Update(){

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if (direcao != Vector3.zero){
            GetComponent<Animator>().SetBool("Correndo", true);
            /*Vector3 direcaoJogador = new Vector3(eixoX, 0, eixoZ);
            Quaternion novaRotacao = Quaternion.LookRotation(direcaoJogador);
            transform.rotation = novaRotacao;*/
        }
        else{
            GetComponent<Animator>().SetBool("Correndo", false);
        }

        if(Vivo == false){
            if(Input.GetButtonDown("Fire1")){
                SceneManager.LoadScene("SampleScene");
            }
        }
        
    }

    void FixedUpdate()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);
        direcao.Normalize(); // Normaliza a direção para evitar movimento mais rápido na diagonal

        // Define a velocidade atual do jogador com a direção e velocidade configuradas
        Vector3 velocidade = direcao * Velocidade;
        GetComponent<Rigidbody>().velocity = velocidade;

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }



}
