using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public GameObject jugador;
    public CombateJugador combateJugador;
    public int daño = 30;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null) {
        combateJugador = jugador.GetComponent<CombateJugador>();   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D colision) {
        if(colision.gameObject.tag == "Player" && jugador != null) {
            combateJugador.TomarDaño(daño);
        }
    }
}
