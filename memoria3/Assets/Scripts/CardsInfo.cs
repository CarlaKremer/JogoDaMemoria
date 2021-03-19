﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 //informações das cartas encontradas
public class CardsInfo : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject infoMenuUI;

    GameObject gc;  //gc: GameController
    GameController gcs;

    public Text typeCard;  
    public Text typeInfo;

    public static string nameInfo;

    public void Resume() //No botão da tela, para fechar a tela de informação e continuar o jogo
    {
        infoMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()  //Pausa para mostrar as infomações das cartas
    {
        infoMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

   public void OpenInfo()
    {
        //exibe a informação da respectiva carta encontrada
        gc = GameObject.Find("GameController");
        gcs = gc.GetComponent<GameController>();

        nameInfo = gcs.infoName;  //pega o nome da carta para saber qual informação exibir
        
        if (nameInfo == "bear icon")
        {
            Pause();
            typeCard.text = "Você achou o Pix !";
            typeInfo.text = "O Pix é................................";
        }
        if (nameInfo == "parrot icon")
        {
            Pause();
            typeCard.text = "Você achou o Código QR!";
            typeInfo.text = "O Código QR é.............";
        }
        if (nameInfo == "koala icon")
        {
            Pause();
            typeCard.text = "Você achou o Código de Barras!";
            typeInfo.text = "O Código de Barras é ...................";
        }
        if (nameInfo == "eagle icon")
        {
            Pause();
            typeCard.text = "Você achou o Cadeado!";
            typeInfo.text = "O cadeado é ...................";
        }
   }
}