using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public float tiempoLimite,tiempoActual;
    public int objetoLanzables,bombas;
    public GameObject player,enemigos, objetos;
    public Text tiempo,items,bombasText;
    public Vector3 respawn;
    // Start is called before the first frame update
    void Start()
    {
        tiempoActual = tiempoLimite;
        respawn = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual -= Time.deltaTime;
        if (tiempoActual <= 0) Respawnea();
        items.text = objetoLanzables.ToString();
        tiempo.text = tiempoActual.ToString();
        bombasText.text = bombas.ToString();
    }

    public void Respawnea()
    {
        tiempoActual = tiempoLimite;
        for(int i=0;i<enemigos.transform.childCount;i++)
        {
            enemigos.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < objetos.transform.childCount; i++)
        {
            objetos.transform.GetChild(i).gameObject.SetActive(true);

        }
        player.transform.position = respawn;

    }
}
