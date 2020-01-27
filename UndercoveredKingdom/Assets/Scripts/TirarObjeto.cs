using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarObjeto : MonoBehaviour
{
    public GameObject prefabObjetoDistraccion,prefabBomba,manager;
    Manager scriptManager;

    private void Start()
    {
        scriptManager = manager.GetComponent<Manager>();
    }
    private void Update()
    {
        if ((Input.GetButtonDown("Fire2"))&&(scriptManager.objetoLanzables>0)) tirarObjeto();
        if ((Input.GetButtonDown("Fire1")) && (scriptManager.bombas > 0)) tirarBomba();
    }
    public void tirarObjeto()
    {
        scriptManager.objetoLanzables--;

        Instantiate(prefabObjetoDistraccion, transform.position,transform.rotation);

    }

    public void tirarBomba()
    {
        scriptManager.bombas--;

        Instantiate(prefabBomba, transform.position, transform.rotation);

    }
}
