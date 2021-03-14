using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GvrReticlePointer pointer;
    public Transform goal;
    public ParticleSystem effect;

    bool isTeleporting;
    void Start()
    {
        effect.Stop();
    }


    public void TeleportEnter()
    {
        pointer.GetComponent<MeshRenderer>().material.color = Color.blue;
        effect.Play();
    }

    public void TeleportClick()
    {
        if (!isTeleporting)
        {
            isTeleporting = true;
            StartCoroutine(IETeleport());
        }
    }

    public void TeleportExit()
    {
        pointer.GetComponent<MeshRenderer>().material.color = Color.white;
        effect.Stop();
    }

    IEnumerator IETeleport()
    {
        SCR_Fade.instance.Fading();
        yield return new WaitForSeconds(SCR_Fade.instance.fadeDuration);
        player.transform.position = goal.position;
        pointer.GetComponent<MeshRenderer>().material.color = Color.white;
        gameObject.SetActive(false);
        isTeleporting = false;
    }
}
