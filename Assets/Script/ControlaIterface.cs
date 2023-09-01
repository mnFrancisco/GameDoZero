using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaIterface : MonoBehaviour
{
    private PlayerBehavior scriptControlaJogador;
    public Slider SliderVidaJogador;
    // Start is called before the first frame update
    void Start()
    {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>();
        SliderVidaJogador.maxValue = scriptControlaJogador.Vida;
        AtualizaSlideVidaJogador();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizaSlideVidaJogador ()
    {
        SliderVidaJogador.value = scriptControlaJogador.Vida;
    }
}