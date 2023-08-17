using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float Velocidade = 8;
    public LayerMask MascaraChao;
    
    private Vector3 direcao;

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
        
    }


    void FixedUpdate(){
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Time.fixedDeltaTime * Velocidade));
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;
        if(Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }


}
