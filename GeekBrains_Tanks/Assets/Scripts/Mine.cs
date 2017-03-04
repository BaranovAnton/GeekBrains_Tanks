using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

    public int damage;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.GetComponent<TankHealth>().GetHit(damage);
            MinesManager.count--;
            Destroy(gameObject);
        }
    }
}
