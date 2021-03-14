using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcador : MonoBehaviour
{
    public TextMesh puntaje;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntaje.text = GameManager.puntos.ToString();
    }
}
