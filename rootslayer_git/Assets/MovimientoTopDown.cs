using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector2 direccion;
    [SerializeField] private float velocidadRotacion;

    private Rigidbody2D rigidBody;

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (direccion != Vector2.zero) {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direccion);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, velocidadRotacion * Time.deltaTime);
        }
    }

    private void FixedUpdate() {
        rigidBody.MovePosition(rigidBody.position + direccion * velocidad * Time.fixedDeltaTime);
    }
}
