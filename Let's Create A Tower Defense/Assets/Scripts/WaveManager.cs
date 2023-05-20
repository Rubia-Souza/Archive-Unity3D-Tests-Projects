using UnityEngine;

/*
 * Essa classe irá gerênciar as ondas do jogo
 * e suas propriedades.
*/

public class WaveManager : MonoBehaviour {

    public float timeCountDown = 5f;
    public float countDown = 0f;
    public int maxWaves = 1;

    // Public apenas para Debug
    public int actualWave = 0;
    public WaveStates actualState = WaveStates.COUNTING;

    // Contador usado para aprimorar a preformance e não ficar checando toda hieraquia a cada frame
    private float winConditionCheckCount = 1f;
    private Spawner[] spawners;

    private void Start() {

        // Preenchee o vetor de spawners com o componente desses objetos
        GameObject[] spawnersObjetcs = GameObject.FindGameObjectsWithTag("Spawner");
        spawners = new Spawner[spawnersObjetcs.Length];

        for (int i = 0; i < spawnersObjetcs.Length; i++) {
            spawners[i] = spawnersObjetcs[i].GetComponent<Spawner>();
        }

        countDown = timeCountDown;

    }

    private void Update() {

        // Se a onda estiver ocorrendo
        // Devemos checar pelas condições de fim de turno
        if (actualState == WaveStates.RUNNING) {

            // Se não hover nenhum inimigo, devemos iniciar próximo turno
            if (!StillHaveEnemys()) 
                CompleteWave();

            // se aida houverem inimigos, devemos esperar eles morrerem
            return;

        }

        // Checa se já está na hora de iniciar a onda
        // Checa se ela já não está no estado de spawn
        if (countDown <= 0 && !actualState.Equals(WaveStates.RUNNING)) {
            StartWave();
        } 
        else {
            actualState = WaveStates.COUNTING;
            countDown -= Time.deltaTime;
        }

    }

    private void StartWave() {

        actualState = WaveStates.RUNNING;
        actualWave++;

        foreach (Spawner spawnPoint in spawners) {

            // reseta o spawner para o estado que pode spawnar
            spawnPoint.countSpawnedEnemys = 0;
            spawnPoint.actualState = SpawnerStates.SPAWNING;

            // Iniciar o ciclo de ciração dos spawners
            StartCoroutine(spawnPoint.SpawnCicle());

        }

        Debug.Log("Turno iniciado");

    }

    private void CompleteWave() {

        Debug.Log("Iniciando próximo turno");

        if (actualWave >= maxWaves) {
            Debug.Log("Nível Completo. Restart ... ");
        }

        countDown = timeCountDown;
        actualState = WaveStates.COUNTING;

    }

    private bool StillHaveEnemys() {

        winConditionCheckCount -= Time.deltaTime;

        if (winConditionCheckCount >= 0) {
            return true;
        }

        winConditionCheckCount = 1f;
        bool hasEnemys = (GameObject.FindGameObjectWithTag("Enemy") != null);

        Debug.Log("Inimigos vivos? " + hasEnemys);

        return hasEnemys;

    }
}
