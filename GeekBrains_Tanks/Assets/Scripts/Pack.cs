using UnityEngine;
using System.Collections;

public class Pack : MonoBehaviour {

    public enum PackType { Health, Armor }
    public PackType packType;
    public float addValue;
	
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.GetComponent<Tank>().AddHealth(addValue);
            Destroy(gameObject);
        }
    }
}
