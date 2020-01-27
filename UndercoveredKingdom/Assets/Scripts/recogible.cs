using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recogible : MonoBehaviour
{
    public Manager script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
       if(other.tag=="Player")
        {
            if (Input.GetButtonDown("Recoger"))
            {


                script.objetoLanzables++;
                gameObject.SetActive(false);
            }
        }
    }
}
