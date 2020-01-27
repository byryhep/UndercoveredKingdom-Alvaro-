using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownHUDController : MonoBehaviour
{
    Image imagen;
    ControladorMovimiento script;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        imagen = GetComponent<Image>();
        script = player.GetComponent<ControladorMovimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.Cooldown > 0)
        {
            imagen.fillAmount = (script.Cooldown ) / script.CooldownMax;
        }
        else
            gameObject.SetActive(false);
    }
}
