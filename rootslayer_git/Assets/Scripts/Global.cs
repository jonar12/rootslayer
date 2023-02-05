using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Global : MonoBehaviour
{
    [SerializeField] private int rondasMax;
    private int rondaActual;
    GameObject[] allEnemies;

    // prefab
    [SerializeField] public GameObject jugador;
    [SerializeField] private ControladorEnemigos controladorEnemigos1;
    private GameObject[] spawners;
    private bool roundHasChanged;
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private float timeBetweenRoundsMax;
    [SerializeField] private float timeBetweenRounds;
    [SerializeField] private GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        startGame();
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

    private void startGame() {
        // spawnear al jugador con vida reseteada
        Vector2 posicionSpawnJugador = new Vector2(playerSpawn.position.x, playerSpawn.position.y);
        jugador = Instantiate(jugador, posicionSpawnJugador, Quaternion.identity);
        setFollowTarget();
        rondaActual = 1;
        timeBetweenRounds = 0;
        initializeRound();
    }

    private void setFollowTarget() {
        CinemachineVirtualCamera virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();
        if(jugador == null) {
            jugador = GameObject.FindGameObjectWithTag("Player");
        }
        Transform tFollowTarget = jugador.transform;
        virtualCamera.LookAt = tFollowTarget;
        virtualCamera.Follow = tFollowTarget;
    }
}
