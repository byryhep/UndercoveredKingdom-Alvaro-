using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{

    public GameObject punto1, punto2;
    public float speed;
    public bool movimiento = true;
    public bool linea = false;
    public Vector3 direccion,rotacion, posicionConstante;
    public bool detectado,golpeado;
    public Transform[] puntos;
    public int nextPoint;
    public Transform posicionDistraccion;

    // Start is called before the first frame update
    void Start()
    {
        
        //punto1.transform.position = gameObject.transform.position;

        if (puntos.Length > 0)
                nextPoint = 0;
        golpeado = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (detectado==false) 
        { 
     
        if (nextPoint <= puntos.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntos[nextPoint].position, speed * Time.deltaTime);
        }

        Debug.DrawLine(transform.position, puntos[nextPoint].position, Color.yellow);

        if (Vector3.Distance(transform.position, puntos[nextPoint].position) < 0.3f)
        {
            GetNextPoint();

            LookToPoint(puntos[nextPoint]);
        }

        }
        else
        {
            if (posicionConstante != null)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, posicionConstante, speed * Time.deltaTime);
                    

                
            }
            else detectado = false;
            
        }
        if (golpeado) Invoke("desactivar", 2);
    }
   
    public void guardarTransform()
    {
       posicionConstante= posicionDistraccion.position;
       LookToPoint(posicionDistraccion);
        Invoke("stopFollowing", 2f);

    }

    public void LookToPoint(Transform point)
    {
        Vector3 miPosicion = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 nextPointPosition = new Vector3(point.position.x, point.position.y, 0);
        Vector3 direccion = point.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direccion, Vector3.forward);
        transform.rotation = rotation;
        
    }

    public void GetNextPoint()
    {
        nextPoint++;

        if (nextPoint >= puntos.Length)
        {
            nextPoint = 0;
        }
    }
    public void stopFollowing()
    {
        detectado = false;
        LookToPoint(puntos[nextPoint]);
    }
    public void desactivar()
    {
        gameObject.SetActive(false);
    }


}
