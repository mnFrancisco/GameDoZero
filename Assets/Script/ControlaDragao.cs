using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaDragao : MonoBehaviour
{
    public GameObject Player;
    //public GameObject Alvo;
    public float Velocidade = 5;
    public float areaAtaque = 5;
    public int dano = 1;
    public int vida = 3;
    public float areaPerseguicao = 10; 

    
    public void SofrerDano(int dano){

        vida -= dano;
        if (vida <= 0){

            Morrer();
        }
    }

    void FixedUpdate()
    {
        //Vai atras dos Player
        float distancia = Vector3.Distance(transform.position, Player.transform.position);

        if (distancia <= areaPerseguicao){

            Vector3 direcaoJogador = Player.transform.position - transform.position;
            Quaternion novaRotacao = Quaternion.LookRotation(direcaoJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
            GetComponent<Animator>().SetBool("Correndo", true);

            if (distancia > areaAtaque){

                Vector3 direcao = Player.transform.position - transform.position;
                GetComponent<Rigidbody>().MovePosition(
                    GetComponent<Rigidbody>().position +
                    (direcao.normalized * Velocidade * Time.deltaTime));
                GetComponent<Animator>().SetBool("Ataque", false);
            }
            else{
                
                GetComponent<Animator>().SetBool("Ataque", true);
            }
        }else{

            GetComponent<Animator>().SetBool("Correndo", false);
            GetComponent<Animator>().SetBool("Ataque", false); // Não ataca se o jogador estiver fora da área de perseguição
        }

        /*// Vai atras do Zumbi
        float distanciaAlvo = Vector3.Distance(transform.position, Alvo.transform.position);

        if (distanciaAlvo <= areaPerseguicao){

            Vector3 direcaoAlvo = Alvo.transform.position - transform.position;
            Quaternion novaRotacaoAlvo = Quaternion.LookRotation(direcaoAlvo);

            GetComponent<Rigidbody>().MoveRotation(novaRotacaoAlvo);
            GetComponent<Animator>().SetBool("Correndo", true);

            if (distanciaAlvo > areaAtaque){

                Vector3 direcao = Alvo.transform.position - transform.position;
                GetComponent<Rigidbody>().MovePosition(
                    GetComponent<Rigidbody>().position +
                    (direcao.normalized * Velocidade * Time.deltaTime));
                GetComponent<Animator>().SetBool("Ataque", false);
            }
            else{
                
                GetComponent<Animator>().SetBool("Ataque", true);
            }
        }else{

            GetComponent<Animator>().SetBool("Correndo", false);
            GetComponent<Animator>().SetBool("Ataque", false); // Não ataca se o jogador estiver fora da área de perseguição
        }*/
    }

    void AtacaJogador(){

        /*ControlaZombi jogador = Player.GetComponent<ControlaZombi>();

        if (jogador != null){

            jogador.SofrerDano(dano); // Substitua 'dano' pelo valor adequado
        }*/

        PlayerBehavior playerScript = Player.GetComponent<PlayerBehavior>();
        playerScript.TextoGameOver.SetActive(true);
        Time.timeScale = 0;
        playerScript.Vivo = false;

    }

    void Morrer(){

        Destroy(gameObject, 0.1f); // Destrua o objeto do inimigo após um tempo
    }
}
