using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private  Camera camera;
    [SerializeField] private Transform objectPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float objx = objectPosition.position.x, objy = objectPosition.position.y, objz = objectPosition.position.z;
        camera.transform.SetPositionAndRotation(new Vector3(objx, objy + 13, objz-5), camera.transform.rotation);
    }
}
