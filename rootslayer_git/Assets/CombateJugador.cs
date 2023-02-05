using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;
    [SerializeField] private float maximoVida;
    private BarraDeVida barraDeVida;
    private AudioSource hurtSound;

    // Start is called before the first frame update
    private void Start()
    {
        vida = maximoVida;
        hurtSound = GameObject.FindGameObjectWithTag("HurtSound").GetComponent<AudioSource>();
        barraDeVida = GameObject.FindGameObjectWithTag("BarraDeVida").GetComponent<BarraDeVida>();
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño) {
        vida -= daño;
        hurtSound.Play();
        barraDeVida.CambiarVidaActual(vida);
        if(vida <= 0) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
