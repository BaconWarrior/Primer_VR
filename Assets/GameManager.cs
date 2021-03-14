using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager controlador;

    public static float tiempoRestante;
    public static string cuentAtras;
    public static float tiempoTranscurrido;
    public static float puntos;
    public static bool gameover;
    static GameObject ZonaTiro;
    static Spawner spawnerU;
    static Spawner spawnerD;
    static Spawner spawnerT;

    private void Awake()
    {
        if(controlador != null && controlador != this)
        {
            Destroy(gameObject);
            return;
        }
        controlador = this;
        DontDestroyOnLoad(gameObject);

        gameover = true;
        cuentAtras = "00:00";
    }
    

    void Update()
    {
        if(tiempoRestante > 0 && !gameover)
        {
            tiempoRestante -= Time.deltaTime;
            string minutos = ((int)tiempoRestante / 60).ToString();
            string segundos = ((int)tiempoRestante % 60).ToString();

            cuentAtras = minutos + ":" + segundos;
        }
        if(tiempoRestante <= 0 && !gameover)
        {
            cuentAtras = "00:00";
            gameover = true;
            endGame();
        }
    }

    public static void startGame()
    {
        tiempoRestante = 20;
        gameover = false;
        puntos = 0;
        ZonaTiro.SetActive(true);
        spawnerU.startSpawner();
        spawnerD.startSpawner();
        spawnerT.startSpawner();
    }

    public void endGame()
    {
        ZonaTiro.SetActive(false);
        spawnerU.stopSpawner();
        spawnerD.stopSpawner();
        spawnerT.stopSpawner();
    }

    public static GameObject registraObjetos(GameObject aRegistrar)
    {
        return aRegistrar;
    }

    public static void RegistarZona(GameObject Zona)
    {
        if (controlador == null)
            return;

        ZonaTiro = Zona;
    }
    public static void RegistarSpawnerU(Spawner Spawn)
    {
        if (controlador == null)
            return;

        spawnerU = Spawn;
    }
    public static void RegistarSpawnerD(Spawner Spawn)
    {
        if (controlador == null)
            return;

        spawnerD = Spawn;
    }
    public static void RegistarSpawnerT(Spawner Spawn)
    {
        if (controlador == null)
            return;

        spawnerT = Spawn;
    }
}
