using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAW : MonoBehaviour
{
    [SerializeField] private int dano;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MuerteJugador>().TomarDano(dano);
            Destroy(gameObject);
        }
    }
}
