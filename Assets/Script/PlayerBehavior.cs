using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float Velocidade = 8;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private Vector3 direcao;

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Correndo", true);
            Vector3 direcaoJogador = new Vector3(eixoX, 0, eixoZ);
            Quaternion novaRotacao = Quaternion.LookRotation(direcaoJogador);
            transform.rotation = novaRotacao;
        }
        else
        {
            GetComponent<Animator>().SetBool("Correndo", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

            
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Time.fixedDeltaTime * Velocidade));
    }

    void Shoot()
    {
        if (bulletPrefab && bulletSpawnPoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody)
            {
                bulletRigidbody.velocity = transform.forward * 10f; // Movimento constante para a frente
            }
        }

        // Ativa a animação de tiro
        GetComponent<Animator>().SetBool("Atirar", true);

        // Reinicia o parâmetro de animação após um tempo para que a animação possa ser repetida
        Invoke("ResetAnimacaoTiro", 0.5f);
    }
    void ResetAnimacaoTiro()
    {
        GetComponent<Animator>().SetBool("Atirar", false);
    }

}
