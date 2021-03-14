using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pato;
    public GameObject bomba;
    public GameObject patoDorado;
    public string id;
    public bool direccion;
    float tiempo;
    int selector;

    // Start is called before the first frame update
    void Start()
    {
        tiempo = 3;
        if(id == "U")
        {
            GameManager.RegistarSpawnerU(this);
        }
        else if(id == "D")
        {
            GameManager.RegistarSpawnerD(this);
        }
        else if (id == "T")
        {
            GameManager.RegistarSpawnerT(this);
        }
        else
        {
            Debug.Log("Falta o fallo de ID");
        }
    }

    public void startSpawner()
    {
        StartCoroutine("spawn");
    }

    public void stopSpawner()
    {
        StopCoroutine("spawn");
    }

    IEnumerator spawn()
    {
        if(GameManager.gameover)
        {
            StopCoroutine("spawn");
        }
        selector = Random.Range(1, 10);

        if(GameManager.tiempoTranscurrido < 10.0f)
        {
            if (selector <= 1)
            {
                if (direccion)
                    Instantiate(patoDorado, transform.position, Quaternion.Euler(0, -180, 0));
                else
                    Instantiate(patoDorado, transform.position, Quaternion.identity);
            }
            else if(selector >= 9)
                Instantiate(bomba, transform.position, Quaternion.Euler(-90, 0, 0));
            else
            {
                if (direccion)
                    Instantiate(pato, transform.position, Quaternion.Euler(0, -180, 0));
                else
                    Instantiate(pato, transform.position, Quaternion.identity);
            }
            tiempo = 2;
        }
        else if(GameManager.tiempoTranscurrido >= 10.0f && GameManager.tiempoTranscurrido <= 20.0f)
        {
            if (selector <= 2)
            {
                if(direccion)
                    Instantiate(patoDorado, transform.position, Quaternion.Euler(0, -180, 0));
                else
                    Instantiate(patoDorado, transform.position, Quaternion.identity);
            }
            else if (selector >= 8)
                Instantiate(bomba, transform.position, Quaternion.Euler(-90, 0, 0));
            else
            {
                if (direccion)
                    Instantiate(pato, transform.position, Quaternion.Euler(0, -180, 0));
                else
                    Instantiate(pato, transform.position, Quaternion.identity);
            }
            tiempo = 2;
        }
        else if (GameManager.tiempoTranscurrido >= 20.0f && GameManager.tiempoTranscurrido <= 30.0f)
        {
            if (selector <= 2)
            {
                if (direccion)
                    Instantiate(patoDorado, transform.position, Quaternion.Euler(0, -180, 0));
                else
                    Instantiate(patoDorado, transform.position, Quaternion.identity);
            }
            else if (selector >= 8)
                Instantiate(bomba, transform.position, Quaternion.Euler(-90, 0, 0));
            else
            {
                if (direccion)
                    Instantiate(pato, transform.position, Quaternion.Euler(0, -180, 0));
                else
                    Instantiate(pato, transform.position, Quaternion.identity);
            }
            tiempo = 1;
        }


        yield return new WaitForSeconds(tiempo);

        StartCoroutine("spawn");
    }
}
