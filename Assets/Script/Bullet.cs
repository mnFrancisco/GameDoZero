using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dano = 1;

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
