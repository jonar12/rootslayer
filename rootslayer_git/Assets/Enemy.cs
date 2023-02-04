using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform jugador;
    public float velocidadMov = 0.1f;
    private Rigidbody2D rigidBody;
    private Vector2 movimiento;
    

    void Start(){
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 direccion = jugador.position - transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        rigidBody.rotation = angulo;
        direccion.Normalize();
        movimiento = direccion;

    }
    private void FixedUpdate() {
        moveCharacter(movimiento);
    }


    void moveCharacter(Vector2 direccion) {
        rigidBody.MovePosition((Vector2)transform.position + (direccion * velocidadMov * Time.deltaTime));
    }

}
