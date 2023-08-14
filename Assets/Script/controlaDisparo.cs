using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaDisparo : MonoBehaviour
{
    public GameObject Disparo;
    public GameObject Bala;
    // Start is called before the first frame update
    
    void Update()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            Instantiate(Bala, Disparo.transform.position, Disparo.transform.rotation);
        }
    }
}


