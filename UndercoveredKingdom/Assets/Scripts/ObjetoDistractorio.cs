using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDistractorio : MonoBehaviour
{
    public Collider triger;
    public Vector3 direccion;
    public float speed;
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
        if (Vector3.Distance(transform.position, direccion) < 1f)
        {
            triger.enabled = true;
            Invoke("destruir", 0.1f);

        }
        }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            MovimientoEnemigos script  = other.GetComponent<MovimientoEnemigos>();
            script.detectado = true;
            script.posicionDistraccion = direccion;

        }

    }
    public void destruir()
    {
        Destroy(this.gameObject);

    }

}
