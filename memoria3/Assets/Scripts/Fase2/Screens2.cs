﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//telas de fim e de vírus
public class Screens2 : MonoBehaviour
{
    public Text movements;

    public GameObject VirusScreenUI;
    public GameObject GameEndedUI;

    GameObject Gc; //Gc: GameController
    GameController2 Gcs;


    public void EndGameScreen()
    {
        Gc = GameObject.Find("GameController2");
        Gcs = Gc.GetComponent<GameController2>();
        //quando o jogo chega ao fim, mostra a tela de finalização
        movements.text = Mathf.RoundToInt(Gcs.countGuesses).ToString();

        GameEndedUI.SetActive(true);
    }

    public void VirusScreen() //tela alertando de que o virus foi achado, então jogo vai reiniciar
    {
        VirusScreenUI.SetActive(true);
    }

    public void ResetButton()//função que está no botão de reinicialização
    {
        SceneManager.LoadScene("Fase2");
    }
}