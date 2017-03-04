using UnityEngine;
using System.Collections;

public class MinesManager : MonoBehaviour {

    public GameObject minePrefab;
    public float radius;
    public Transform[] spawnPoints;

    private Vector3 spawnPosition;

    void Start () {
        SpawnMines();
	}

    private void SpawnMines()
    {
        for (int i=0; i<spawnPoints.Length; i++)
        {
            spawnPosition = spawnPoints[i].position;
            float randomDelta = Random.Range(-radius, radius);
            spawnPosition = new Vector3(spawnPosition.x + randomDelta, spawnPosition.y, spawnPosition.z + randomDelta);
            GameObject bonus = Instantiate(minePrefab, spawnPosition, Quaternion.identity) as GameObject;
        }
    }
}
