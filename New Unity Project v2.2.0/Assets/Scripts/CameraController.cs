using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public new Camera camera;

    public float pitch = 2f;

    private float currentZoom = 10f;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            // I want the camera to rotate based on where the player if facing. Ask Kelvin for help with this.
    }

    private void LateUpdate()
    {
        Vector3 Direction = new Vector3(0, 0, - pitch);
        Quaternion rotation = Quaternion.Euler(target.eulerAngles.x, target.eulerAngles.y, 0);

        //Debug.Log(rotation);

        transform.position = target.position + rotation * Direction;

        transform.LookAt(target.position);


        //    transform.position = target.position;
        //    transform.rotation = target.rotation;
        //    camera.transform.position = transform.position + transform.forward - offset * currentZoom;
        //   //camera.transform.LookAt(transform.position + Vector3.up * pitch);
    }
}
