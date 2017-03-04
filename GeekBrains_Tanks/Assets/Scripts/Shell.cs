using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public int damage;
    public float fireForce;
    public float rechargeTime;
    public float lifeTime;

    void Start () {
        Destroy(gameObject, lifeTime);
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            coll.transform.parent.GetComponent<TurretController>().GetHit(damage);
            Destroy(gameObject);
        }   
    }
}
