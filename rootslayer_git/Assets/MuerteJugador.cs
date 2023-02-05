using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteJugador : MonoBehaviour
{
    [SerializeField] private int life;

    public void TomarDano(int cantidadDano)
    {
        life -= cantidadDano;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
