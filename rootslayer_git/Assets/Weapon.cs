using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int dano;

    // Start is called before the first frame update
    void Start()
    {
        dano = 20;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemigo = collider.gameObject.GetComponent<Enemy>();

        Debug.Log("Le pegamos al enemigo");

        if(enemigo != null)
        {
            enemigo.TomarDaño(dano);
        }   
    }
}
