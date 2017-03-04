using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionShell : MonoBehaviour {

    public GameObject newShell;
    public float explosionTime;
    public int explosionCount;
    public int explosionAngle;

    private float force;
    private float startAngleY;
    private float angleStep;

	void Start () {
        force = newShell.GetComponent<Shell>().fireForce;

        // Shell angle calculation
        startAngleY = transform.rotation.eulerAngles.y - explosionAngle / 2;
        explosionCount = Mathf.Clamp(explosionCount, 2, explosionCount); // Explosion count has to be more than 1
        angleStep = explosionAngle / (explosionCount - 1);

        Invoke("Shoot", explosionTime);
	}
	
    private void Shoot()
    {
        for (int i=0; i<explosionCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, startAngleY + angleStep * i, 0f);
            GameObject shell = Instantiate(newShell, transform.position, rotation) as GameObject;
            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.velocity = force * shell.transform.forward;
        }

        Destroy(gameObject);
    }
}
