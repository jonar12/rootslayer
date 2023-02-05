using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RondaTxt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI RondaText;
    [SerializeField] private Global global1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateRound(global1.getRondaActual());
    }
    
    public void updateRound(int rondaActual) {
        RondaText.text = string.Format("Ronda {0}", rondaActual);
    }
}
