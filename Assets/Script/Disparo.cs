using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float Velocidade = 20;
    
    public int dano = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + 
            transform.forward * Velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        ControlaZombi inimigo = other.GetComponent<ControlaZombi>();
        if (inimigo != null)
        {
            inimigo.SofrerDano(dano);
            Destroy(gameObject); // Destrua a bala após acertar um inimigo
        }
    }
}

