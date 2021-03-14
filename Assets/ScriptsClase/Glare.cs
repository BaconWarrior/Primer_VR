using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glare : MonoBehaviour
{
    public GvrReticlePointer pointer;
    public float timeToWait;
    float timer;
    bool canInteract;

    void Update()
    {
        TimerUpdate();
    }

    public void TimerEnter()
    {
        canInteract = true;
        pointer.GetComponent<MeshRenderer>().material.color = Color.red;
    }    

    public void TimerUpdate()
    {
        if(canInteract)
        {
            //Debug.Log(pointer.CurrentRaycastResult.worldPosition);

            timer += Time.deltaTime;
            pointer.progress = Mathf.Lerp(0, pointer.reticleSegments, timer / timeToWait);
            pointer.CreateReticleVertices();
            if(timer >= timeToWait)
            {
                TimerExit(); 
                // Aqui se puede poner una interaccion deseada
                gameObject.SetActive(false);
            }
        }
    }

   

    public void TimerExit()
    {
        canInteract = false;
        timer = 0;

        pointer.progress = 0;
        pointer.CreateReticleVertices();
        pointer.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    
}
