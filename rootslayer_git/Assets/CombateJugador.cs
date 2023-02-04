using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private float daño = 2;

    private float tiempoEntreAtaques;
    [SerializeField] private float startTiempoEntreAtaques;
    [SerializeField] public Transform attackPos;
    [SerializeField] public float attackRange;
    [SerializeField] public LayerMask queEsEnemigo;

    // Start is called before the first frame update
    private void Start()
    {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño) {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if(vida <= 0) {
            Destroy(gameObject);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoEntreAtaques <= 0) {
            // attack
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                Collider2D[] enemigosADañar = Physics2D.OverlapCircleAll(attackPos.position, attackRange, queEsEnemigo);
                for (int i = 0; i < enemigosADañar.Length; i++) {
                    enemigosADañar[i].GetComponent<Enemy>().TomarDaño(daño);
                }
            }

            tiempoEntreAtaques = startTiempoEntreAtaques;
        } else {
            tiempoEntreAtaques -= Time.deltaTime;
        }

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
