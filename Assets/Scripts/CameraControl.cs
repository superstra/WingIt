using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private Transform objectPosition;
    [SerializeField] private float distanceFromBird = 13F;
    private Vector3 camOffset;

    // Start is called before the first frame update
    void Start()
    {
        updateCamOffset();
    }

    void updateCamOffset() {
        Vector3 angles = cam.transform.rotation.eulerAngles;
        camOffset = new Vector3(Mathf.Sin(angles.y * Mathf.Deg2Rad)* Mathf.Cos(angles.x * Mathf.Deg2Rad),
                                -1F * Mathf.Sin(angles.x * Mathf.Deg2Rad), 
                                Mathf.Cos(angles.x * Mathf.Deg2Rad) * Mathf.Cos(angles.y*Mathf.Deg2Rad));
        camOffset.Normalize();
        camOffset *= -distanceFromBird;
    }

    // Update is called once per frame
    void Update()
    {
        //float objx = objectPosition.position.x, objy = objectPosition.position.y, objz = objectPosition.position.z;
        //cam.transform.SetPositionAndRotation(new Vector3(objx, objy + 13, objz-5), cam.transform.rotation);
        
        //updateCamOffset();
        cam.transform.SetPositionAndRotation(objectPosition.position + camOffset, cam.transform.rotation);
    }
}
