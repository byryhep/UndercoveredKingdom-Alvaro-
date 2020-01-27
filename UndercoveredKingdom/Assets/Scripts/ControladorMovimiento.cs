using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMovimiento : MonoBehaviour
{
    Rigidbody rb;
    public float speed,fuerza,starDashTime, dashTime,Cooldown, CooldownMax;
    float direccionSalto;
    bool impulsado,agachado;
    public GameObject imagenCooldown;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cooldown = 0;
    }

    private void Update()
    {
        if (agachado == false)
        {
            float direccionVertical = Input.GetAxis("Vertical");
            float direccionHorizontal = Input.GetAxis("Horizontal");

            if (direccionHorizontal > 0) transform.Translate(transform.right * Time.deltaTime * speed);
            if (direccionHorizontal < 0) transform.Translate(transform.right * -1 * Time.deltaTime * speed);
            if (direccionVertical > 0) transform.Translate(transform.up * Time.deltaTime * speed);
            if (direccionVertical < 0) transform.Translate(transform.up * -1 * Time.deltaTime * speed);


            if (Input.GetButtonDown("Run"))
            {
                speed *= 1.5f;
            }

            if (Input.GetButtonUp("Run"))
            {
                speed /= 1.5f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direccionSalto = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direccionSalto = 2;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                direccionSalto = 3;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direccionSalto = 4;
            }
            if (dashTime <= 0)
            {
                direccionSalto = 0;
                dashTime = starDashTime;
                rb.velocity = Vector3.zero;

                impulsado = false;
            }
            if (impulsado == true)
            {
                dashTime -= Time.deltaTime;
            }
            if (Cooldown <= 0)
            {


                if (Input.GetButtonDown("Jump"))
                {

                    if (direccionSalto == 1)
                    {
                        rb.velocity = transform.right * -1 * fuerza;
                    }
                    else if (direccionSalto == 2)
                    {
                        rb.velocity = transform.right * fuerza;
                    }
                    else if (direccionSalto == 3)
                    {
                        rb.velocity = transform.up * fuerza;
                    }
                    else if (direccionSalto == 4)
                    {
                        rb.velocity = transform.up * -1 * fuerza;
                    }
                    impulsado = true;
                    Cooldown = CooldownMax;
                }

            }
        }

        if (Cooldown >= 0)

        {
            imagenCooldown.SetActive(true);
            Cooldown -= Time.deltaTime;

        }
       


        if (Input.GetButtonDown("Crouch")) agachado = true;
        if (Input.GetButtonUp("Crouch")) agachado = false;

        if (agachado) transform.localScale =new Vector3 (0.75f,0.75f,0.75f);
        else transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "EspaldaEnemigo")
        {

            if (Input.GetButtonDown("Attack"))
            {
                other.transform.parent.transform.parent.transform.parent.gameObject.SetActive(false);
            }
        }
    }
    
}
