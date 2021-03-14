using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructori : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("duck") || other.transform.CompareTag("bomb") || other.transform.CompareTag("golduck"))
        {
            Destroy(other.gameObject);
        }
    }
}
