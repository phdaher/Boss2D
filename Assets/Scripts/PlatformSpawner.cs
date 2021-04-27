using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    // Timer de spawn da plafaorma
    public float platform_Spawn_Timer = 0.5f;
    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;

    // X max e min para o bloco dar spawn
    public float min_X = -4f, max_X = 4f;

    // Start is called before the first frame update
    void Start() {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    // Update is called once per frame
    void Update() {
        SpawnPlatforms();
    }

    void SpawnPlatforms() {

        current_Platform_Spawn_Timer += Time.deltaTime;

        if(current_Platform_Spawn_Timer >= platform_Spawn_Timer) {

            platform_Spawn_Count++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;

            // Gera uma plataforma normal
            if(platform_Spawn_Count < 2) {

                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

            } else if(platform_Spawn_Count == 2) { 

                // Gera uma plataforma aleatória (moving/ normal)
                if(Random.Range(0, 2) > 0) {

                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                } else {

                    newPlatform = Instantiate(
                    movingPlatforms[Random.Range(0, movingPlatforms.Length)],
                        temp, Quaternion.identity);

                }

            } else if(platform_Spawn_Count == 3) {

                // Gera uma plataforma aleatória (spike/ normal)
                if (Random.Range(0, 2) > 0) {

                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                } else {

                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);

                }

            } else if (platform_Spawn_Count == 4) {

                // Gera uma plataforma aleatória (quebravel/ normal)
                if (Random.Range(0, 2) > 0) {

                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

                } else {

                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);

                }

                // Zera o contador
                platform_Spawn_Count = 0;

            }

            if(newPlatform)
                newPlatform.transform.parent = transform;

            // Restart no timer
            current_Platform_Spawn_Timer = 0f;

        } 

    }


}







































