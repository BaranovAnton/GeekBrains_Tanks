using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public float moveSpeed, rotateSpeed, rotateSpeedTower;
    public GameObject tower;

    private float move, rotate;
    private float rotateTower;

    private Rigidbody rigidbody;

    // Управление танком на счет Rigidbody (аналог проекта Tanks! Tutorial)
	void Awake () {
        rigidbody = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        Move();
        Turn();
        TurnTower();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * move * moveSpeed * Time.deltaTime;
        rigidbody.MovePosition(rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = rotate * rotateSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
    }

    private void TurnTower()
    {
        tower.transform.Rotate(Vector3.up, rotateTower * rotateSpeedTower * Time.deltaTime);
    }

	void Update () {
        move = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");

        rotateTower = Input.GetAxis("HorizontalTower");
    }
    // -----

    // Управление танком за счет перемещения объекта
    /*void Update()
    {
        // Управление танком
        move = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");

        if (move != 0)
        {
            transform.Translate(Vector3.forward * move * moveSpeed * Time.deltaTime);
        }

        if (rotate != 0)
        {
            transform.Rotate(Vector3.up, rotate * rotateSpeed * Time.deltaTime);
        }

        // Управление башней танка
        rotateTower = Input.GetAxis("HorizontalTower");
        if (rotateTower != 0)
        {
            tower.transform.Rotate(Vector3.up, rotateTower * rotateSpeedTower * Time.deltaTime);
        }
    }*/
    // -----
}