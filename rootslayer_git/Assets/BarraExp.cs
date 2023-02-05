using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraExp : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetExpMaxima(float expMaxima) {
        slider.maxValue = expMaxima;
    }

    public void SetExpActual(float cantidadExp) {
        slider.value = cantidadExp;
    }

    public void InicializarBarraExp(float cantidadExp) {
        slider = GetComponent<Slider>();   
        SetExpMaxima(cantidadExp);
        SetExpActual(cantidadExp);
    }
}
