using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAldio : MonoBehaviour
{
    private AudioSource audioSource; // Componente de áudio
    public static ControlaAldio instance; // Singleton

    // Awake é chamado antes do Start
    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Pega o componente de áudio
        instance =  this; // Singleton
    }
    public void PlayOneShot(AudioClip som)
    {
        audioSource.PlayOneShot(som); // Toca o som
    }
    
    
}
