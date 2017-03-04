using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour {  

    public GameObject[] shellsGO;
    public Transform spawnPoint;
    public GameObject shotEffect;
    public Image[] rechargeImages;
    public RectTransform activePos;

    private Shell[] shells;
    private int currentShell;
    private GameObject shellPrefab;
    private float fireForce;
    private float rechargeTime;
    private float[] rechargeTimers;

    private const float activeOffset = 2.5f;

    private ParticleSystem particle;
    private AudioSource shootSound;

    void Start () {
        currentShell = 0;   

        rechargeTimers = new float[shellsGO.Length];
        shells = new Shell[shellsGO.Length];
        for (int i = 0; i < shells.Length; i++)
        {
            rechargeTimers[i] = 0f;
            shells[i] = shellsGO[i].GetComponent<Shell>();
        }

        SetCurrentShell(currentShell);

        particle = shotEffect.GetComponent<ParticleSystem>();
        shootSound = GetComponent<AudioSource>();
	}

	void Update () {
        // Recharge each shell type if it's available
        for (int i=0; i<rechargeTimers.Length; i++)
        {
            if (shells[i].available)
            {
                rechargeTimers[i] += Time.deltaTime;
                rechargeImages[i].fillAmount -= (Time.deltaTime / shells[i].rechargeTime);
            }
        }       

        // Shoot, if current shell is recharged
        if (Input.GetButtonDown("Fire1") && rechargeTimers[currentShell] >= rechargeTime)
        {
            GameObject shell = Instantiate(shellPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.velocity = fireForce * spawnPoint.forward;
            //shellRigidbody.AddForce(fireForce * spawnPoint.forward);

            particle.Play();
            shootSound.Play();

            rechargeTimers[currentShell] = 0f;
            rechargeImages[currentShell].fillAmount = 1f;
        }

        // Change shell type if it's available and it's not the same type
        if (Input.GetKeyDown(KeyCode.Alpha1) && shells[0].available && currentShell != 0)
        {
            SetCurrentShell(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && shells[1].available && currentShell != 1)
        {
            SetCurrentShell(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && shells[2].available && currentShell != 2)
        {
            SetCurrentShell(2);
        }
    }

    private void SetCurrentShell(int _currentShell)
    {
        currentShell = _currentShell;
        shellPrefab = shellsGO[currentShell];
        fireForce = shells[currentShell].fireForce;
        rechargeTime = shells[currentShell].rechargeTime;

        activePos.localPosition = new Vector3(rechargeImages[currentShell].transform.parent.localPosition.x + activeOffset, activePos.localPosition.y, activePos.localPosition.z);
    }

    public void OpenShell(int _shellIndex)
    {
        shells[_shellIndex].available = true;
    }
}
