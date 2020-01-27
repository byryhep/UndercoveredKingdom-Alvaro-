using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowing : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 6f;
    Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        posicion =new Vector3 (target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, posicion, Time.deltaTime * smoothTime);
    }
}
