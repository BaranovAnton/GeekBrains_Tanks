using UnityEngine;
using System.Collections;

public class TurretShot : MonoBehaviour {

    public int damage;
    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")) { 
            coll.GetComponent<Tank>().GetHit(damage);
            Destroy(gameObject);
        }
    }
}
