using UnityEngine;

using System.Collections;

public class RotationHandler : MonoBehaviour
{
    public float sensitivity = 2f;
    void Start()
    {
    }


    void Update()
    {
        float yRot = Input.GetAxis("Mouse X") * sensitivity;
        float xRot = Input.GetAxis("Mouse Y") * sensitivity;


        transform.Rotate(new Vector3(0, yRot, 0f));
        Camera.main.gameObject.transform.Rotate(-xRot, 0, 0);
    }




}