using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarObjeto : MonoBehaviour
{
    public GameObject prefabObjeto,manager;
    Manager scriptManager;

    private void Start()
    {
        scriptManager = manager.GetComponent<Manager>();
    }
    private void Update()
    {
        if ((Input.GetButtonDown("Fire2"))&&(scriptManager.objetoLanzables>0)) tirarObjeto();
    }
    public void tirarObjeto()
    {
        scriptManager.objetoLanzables--;

        Instantiate(prefabObjeto, transform.position,transform.rotation);

    }
}
