using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Vector3 posInicial;
    Rigidbody rb;
    public GameObject particulasPato;
    public GameObject particulasPatoDorado;
    public GameObject particulasBomba;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("reset"))
        {
            StartCoroutine("reposicion");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("duck"))
        {
            GameManager.puntos++;
            Instantiate(particulasPato, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("bomb"))
        {
            GameManager.tiempoRestante -= 3;
            Instantiate(particulasPato, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("golduck"))
        {
            GameManager.puntos += 3;
            GameManager.tiempoRestante += 5;
            Instantiate(particulasPatoDorado, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("reset"))
        {
            StartCoroutine("reposicion");
        }
    }
    IEnumerator reposicion()
    {
        yield return new WaitForSeconds(2);
        transform.position = posInicial;
        rb.isKinematic = true;
        rb.isKinematic = false;
    }
}
