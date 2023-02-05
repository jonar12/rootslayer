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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Enemigo enemigo = collider.gameObject.GetComponent<Enemigo>();

        Debug.Log("Le pegamos al enemigo");

        if(enemigo != null)
        {
            enemigo.ApplyDamage(dano);
        }   
    }
}
