using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour
{
    public int health;
    public GameObject shellPrefab;
    public Transform[] spawnPoint;
    public int rotationSpeed;
    public float rechargeTime;
    public int fireForce;

    private Transform player;
    private Coroutine shootCoroutine;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            shootCoroutine = StartCoroutine(Shoot());
        }
    }

    public void GetHit(int _damage)
    {
        health -= _damage;
        if (health <= 0)
            Destroy(gameObject);
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            StopCoroutine(shootCoroutine);
        }
    }

    void Update()
    {
        if (player != null)
        {
            Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            for (int i=0; i<spawnPoint.Length; i++)
            {
                GameObject shell = Instantiate(shellPrefab, spawnPoint[i].position, spawnPoint[i].rotation) as GameObject;
                Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
                shellRigidbody.velocity = fireForce * spawnPoint[i].forward;
            }  

            yield return new WaitForSeconds(rechargeTime);
        }
    }
}