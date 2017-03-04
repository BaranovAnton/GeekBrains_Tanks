using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public float smooth = 1;

    private Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
        print("offset "+offset);
    }

    void LateUpdate()
    {
        float cameraAngle = transform.eulerAngles.y;
        float towelAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(cameraAngle, towelAngle, Time.deltaTime * smooth);

        Quaternion rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, angle, 0);
        transform.rotation = rotation;
        //transform.position = target.transform.position - (rotation * offset);
        //transform.position = target.transform.position - offset;
    }
}
