using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    [SerializeField] private int rondasMax;
    private int rondaActual;
    GameObject[] allEnemies;
    public GameObject jugador;
    [SerializeField] private ControladorEnemigos controladorEnemigos1;
    private GameObject[] spawners;
    private bool roundHasChanged;
    [SerializeField] private float timeBetweenRoundsMax;
    [SerializeField] private float timeBetweenRounds;
    [SerializeField] private GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenRounds = 0;
        rondaActual = 1;
        jugador = GameObject.FindGameObjectWithTag("Player");
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        initializeRound();
    }

    // Update is called once per frame
    void Update()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(!roundHasChanged) {
            checkRound();
        } else {
            initializeRound();
        }
        
    }

    public int getRondaActual() {
        return rondaActual;
    }

    private void checkRound() {
        // Revisar si continuamos a la siguiente ronda
        if(allEnemies.Length == 0 && jugador != null && timer.GetComponent<TimerScript>().TimeLeft <= 0) {
            rondaActual++;
            roundHasChanged = true;
            while(timeBetweenRounds <= timeBetweenRoundsMax) {
                timeBetweenRounds += Time.deltaTime;
            } 
        }
    }

    private void initializeRound() {
        roundHasChanged = false;
        // Resetear el tiempo
        timer.GetComponent<TimerScript>().TimeLeft = rondaActual * 15;
        timer.GetComponent<TimerScript>().TimerOn = true;
    }
}
