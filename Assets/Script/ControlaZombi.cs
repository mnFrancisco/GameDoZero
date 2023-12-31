using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ControlaZombi : MonoBehaviour
{
    public GameObject Player;
    public float Velocidade = 5;
    public float areaAtake = 5;

    public int dano1 = 5;
    public int dano2 = 5;

    public AudioClip SomDeMorte;
    public AudioClip SomDoZumbi;

    public int vida = 3;

    public void SofrerDano(int dano){
        vida -= dano;
        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Start(){
        Player = GameObject.FindWithTag("Player");
        ControlaAldio.instance.PlayOneShot(SomDoZumbi);
    }

    void FixedUpdate(){
        
        float distancia = Vector3.Distance(transform.position, Player.transform.position);
 
        Vector3 direcaoJogador = Player.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcaoJogador);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);
 
        if(distancia > areaAtake){

             Vector3 direcao = Player.transform.position - transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao.normalized * Velocidade * Time.deltaTime));
            GetComponent<Animator>().SetBool("Ataque", false); 
        }
        else{

            GetComponent<Animator>().SetBool("Ataque", true);
        }
       
    }

    void AtacaJogador(){

        int dano = Random.Range(dano1, dano2);
        PlayerBehavior playerScript = Player.GetComponent<PlayerBehavior>();
        playerScript.TomarDano(dano);
    }

    void Morrer(){
        ControlaAldio.instance.PlayOneShot(SomDeMorte);
        Destroy(gameObject, 0.1f); // Destrua o objeto do inimigo após um tempo
    }
}