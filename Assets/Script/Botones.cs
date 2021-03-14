using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    public GameObject Inicio;
   
    public void iniciar()
    {
        GameManager.startGame();
        Inicio.SetActive(false);
    }

}
