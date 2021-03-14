using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaDisparo : MonoBehaviour
{
    public Transform jugador;
    public GvrReticlePointer pointer;
    bool charging;
    float power;
    public float maxPower;
    public GameObject bola;
    Rigidbody rb;
    private void Start()
    {
        Debug.Log(gameObject);
        rb = bola.GetComponent<Rigidbody>();
        GameManager.RegistarZona(this.gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameover)
        {
            powerCharge();
        }
    }

    public void powerEnter()
    {
        charging = true;
        pointer.GetComponent<MeshRenderer>().material.color = Color.red;
    }


    public void powerCharge()
    {
        if (charging)
        {
            //Debug.Log(pointer.CurrentRaycastResult.worldPosition);

            power += (Time.deltaTime * 1000.0f);
            pointer.progress = Mathf.Lerp(0, pointer.reticleSegments, power / maxPower);
            pointer.CreateReticleVertices();
            if (power >= maxPower)
            {
                powerExit();
                // Aqui se puede poner una interaccion deseada
                gameObject.SetActive(false);
            }
        }
    }

    public void powerExit()
    {
        charging = false;
        disparo();
        power = 0;

        pointer.progress = 0;
        pointer.CreateReticleVertices();
        pointer.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public void disparo()
    {
        rb.AddForce(jugador.transform.forward * power);
    }
}
