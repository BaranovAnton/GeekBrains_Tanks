using UnityEngine;
using System.Collections;

public class BonusManager : MonoBehaviour {

    public GameObject bonusPrefab;
    public Transform[] spawnPoints;
    public float lifeTime;

    private int spawnIndex;

	void Start () {
        InvokeRepeating("SpawnBonus", 0, 5);
	}

    private void SpawnBonus()
    {
        spawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject bonus = Instantiate(bonusPrefab, spawnPoints[spawnIndex].position, Quaternion.identity) as GameObject;
        Destroy(bonus, lifeTime);
    }
}
