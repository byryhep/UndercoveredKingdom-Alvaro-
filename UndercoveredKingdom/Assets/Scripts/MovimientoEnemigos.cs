using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{

    public GameObject punto1, punto2;
    public float speed;
    public bool movimiento = true;
    public bool linea = false;
    public Vector3 direccion,rotacion;
    public bool detectado;
    public Transform[] puntos;
    public int nextPoint;
    public Vector3 posicionDistraccion;

    // Start is called before the first frame update
    void Start()
    {
        
        //punto1.transform.position = gameObject.transform.position;

        if (puntos.Length > 0)
                nextPoint = 0;
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
            if (posicionDistraccion != null)
            {
                posicionDistraccion = new Vector3(posicionDistraccion.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, posicionDistraccion, speed * Time.deltaTime);
                
                    Vector3 miPosicion = new Vector3(transform.position.x, transform.position.y, 0);
                    Vector3 nextPointPosition = new Vector3(posicionDistraccion.x, posicionDistraccion.y, 0);
                    Vector3 direccion = posicionDistraccion - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(direccion, Vector3.forward);                  
                    transform.rotation = rotation;
                    Invoke("stopFollowing", 3);
                    if(rotacion==Vector3.zero) LookToPoint(puntos[nextPoint]);

                
            }
            else detectado = false;
            
        }

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
}
