using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float Velocidade = 20;
    public int dano = 1;

    void FixedUpdate(){
        GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position +
            transform.forward * Velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoDeColisao){
        if (objetoDeColisao.CompareTag("Inimigo")){
            ControlaZombi inimigo = objetoDeColisao.GetComponent<ControlaZombi>();
            if (inimigo != null){
                inimigo.SofrerDano(dano); // Chame o método para causar dano ao inimigo
            }
        }if (objetoDeColisao.CompareTag("Inimigo")){
            ControlaDragao inimigo = objetoDeColisao.GetComponent<ControlaDragao>();
            if (inimigo != null){
                inimigo.SofrerDano(dano); // Chame o método para causar dano ao inimigo
            }
        }
        Destroy(gameObject); // Destrua a bala independentemente da colisão
    }
}

