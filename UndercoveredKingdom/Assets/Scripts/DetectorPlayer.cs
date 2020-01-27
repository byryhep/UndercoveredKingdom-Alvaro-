using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorPlayer : MonoBehaviour
{
    public GameObject manager;
    Manager scriptRespawn;
    public LayerMask diferenteEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        scriptRespawn = manager.GetComponent < Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Enemy")
        {


            RaycastHit hit;
            Vector3 direccion = other.transform.position - transform.parent.transform.position;
            Debug.DrawRay(transform.parent.transform.position, direccion);
            if(Physics.Raycast(transform.parent.transform.position, direccion, out hit, diferenteEnemigo))
            {
                
                if (hit.collider.gameObject.tag == "Player")
                {
                    scriptRespawn.Respawnea();
                }
            }
           
            
        }

    }
}
