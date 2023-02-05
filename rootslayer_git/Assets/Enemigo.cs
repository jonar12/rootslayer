using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
            Destroy (gameObject);
    }


    public void ApplyDamage(int dano)
    {
        vida = vida - dano;
        Debug.Log("Hicimos daño");

    }
    
}
