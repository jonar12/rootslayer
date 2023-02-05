using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int dano;
    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        dano = 20;
        hitSound = GameObject.FindGameObjectWithTag("HitSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Enemy enemigo = collider.gameObject.GetComponent<Enemy>();

        hitSound.Play();

        if(enemigo != null)
        {
            enemigo.TomarDaño(dano);
        }   
    }
}
