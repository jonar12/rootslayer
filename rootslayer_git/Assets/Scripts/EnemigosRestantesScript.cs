using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemigosRestantesScript : MonoBehaviour
{
    GameObject[] allEnemies;
    int numEnemiesRemaining;
    [SerializeField] private TextMeshProUGUI EnemigosRestantesTxt;

    // Start is called before the first frame update
    void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemiesRemaining = allEnemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemiesRemaining = allEnemies.Length;
        EnemigosRestantesTxt.text = string.Format("Remaining Enemies\n{0}", numEnemiesRemaining);
    }
}
