using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float velocidade = 8;

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        if(direcao != Vector3.zero){

            GetComponent<Animator>().SetBool("Correndo", true);
        }else{
            GetComponent<Animator>().SetBool("Correndo", false);
        }

        transform.Translate(direcao * velocidade * Time.deltaTime);

    }
}
