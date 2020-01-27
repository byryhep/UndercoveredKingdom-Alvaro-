using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public Collider triger;
    public Vector3 direccion;
    public float speed;

    public float radius = 20F;
    public float power = 100000.0F;
    // Start is called before the first frame update
    void Start()
    {
        //triger= GetComponent<Collider>();
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            direccion = hit.point;
            direccion = new Vector3(direccion.x, direccion.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, direccion, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, direccion) < 0.5f)
        {
            explotar();
            Invoke("destruir", 0.1f);

        }
    }
    public void explotar()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag == "Enemy")
            { 


                Rigidbody rb = hit.GetComponent<Rigidbody>();
                MovimientoEnemigos script = hit.GetComponent<MovimientoEnemigos>();
                if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                script.golpeado=true;
                hit.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
   
    
    public void destruir()
    {
        Destroy(this.gameObject);

    }
}
