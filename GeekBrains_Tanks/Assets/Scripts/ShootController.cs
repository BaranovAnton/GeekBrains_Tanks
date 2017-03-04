using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {  

    public GameObject[] shells;
    public Transform spawnPoint;
    public GameObject shotEffect;

    private int currentShell;
    private GameObject shellPrefab;
    private float fireForce;
    private float rechargeTime;
    private float rechargeTimer;

    private ParticleSystem particle;
    private AudioSource shootSound;

    void Start () {
        // По умолчанию нулевой тип снаряда
        currentShell = 0;
        SetShell();

        particle = shotEffect.GetComponent<ParticleSystem>();
        shootSound = GetComponent<AudioSource>();
	}

	void Update () {
        // Выстрел
        rechargeTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && rechargeTimer > rechargeTime)
        {
            GameObject shell = Instantiate(shellPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.velocity = fireForce * spawnPoint.forward;
            //shellRigidbody.AddForce(fireForce * spawnPoint.forward);

            particle.Play(); // Эффект выстрела
            shootSound.Play(); // Звук выстрела

            rechargeTimer = 0;
        }

        // Переключение типов снарядов
        if (Input.GetButtonDown("Fire2"))
        {
            currentShell++;
            if (currentShell >= shells.Length)
                currentShell = 0;

            SetShell();
        }
    }

    private void SetShell()
    {
        shellPrefab = shells[currentShell];
        Shell shell = shellPrefab.GetComponent<Shell>();
        fireForce = shell.fireForce;
        rechargeTime = shell.rechargeTime;
    }
}
