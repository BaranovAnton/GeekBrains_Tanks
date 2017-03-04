using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

    public float damage;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.GetComponent<Tank>().GetHit(damage);
            Destroy(gameObject);
        }
    }
}
