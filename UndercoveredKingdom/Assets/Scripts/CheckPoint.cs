using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Manager scriptManager;
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        scriptManager = manager.GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        scriptManager.respawn = transform.position;
    }
}
