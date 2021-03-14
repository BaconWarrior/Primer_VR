using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrusel : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public List<GameObject> onBelt;

    void Update()
    {
        for (int i = 0; i <= onBelt.Count - 1; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
        }
    }

    // Detecta objetos que entran a la cinta
    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject);
    }

    // Detecta objetos que salen de la cinta
    private void OnCollisionExit(Collision collision)
    {
        remover(collision.gameObject);
    }

    public void remover(GameObject aRemover)
    {
        onBelt.Remove(aRemover);
    }
}
