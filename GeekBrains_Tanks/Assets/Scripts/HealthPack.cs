using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

    public int addHealth;
	
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.GetComponent<TankHealth>().AddHealth(addHealth);
            Destroy(gameObject);
        }
    }
}
