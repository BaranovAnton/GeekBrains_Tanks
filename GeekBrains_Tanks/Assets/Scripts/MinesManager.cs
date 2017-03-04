using UnityEngine;
using System.Collections;

public class MinesManager : MonoBehaviour {

    public GameObject minePrefab;
    public float radius;
    public Transform[] spawnPoints;

    public static int count;

    private int spawnIndex;
    private Vector3 spawnPosition;

    void Start () {
        InvokeRepeating("SpawnMine", 0, 5);
	}

    private void SpawnMine()
    {
        if (count < 3)
        {
            spawnIndex = Random.Range(0, spawnPoints.Length);
            spawnPosition = spawnPoints[spawnIndex].position;
            float randomDelta = Random.Range(-radius, radius);
            spawnPosition = new Vector3(spawnPosition.x + randomDelta, spawnPosition.y, spawnPosition.z + randomDelta);
            GameObject bonus = Instantiate(minePrefab, spawnPosition, Quaternion.identity) as GameObject;

            count++;
        }
    }
}
