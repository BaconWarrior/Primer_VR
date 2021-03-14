using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cronometro : MonoBehaviour
{
    public TextMesh countdown;
    // Update is called once per frame
    void Update()
    {
      countdown.text = GameManager.cuentAtras;
    }
}
