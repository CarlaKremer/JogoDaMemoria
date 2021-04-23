using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//informações das cartas encontradas
public class CardsInfo2 : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject infoMenuUI;

    GameObject gc;  //gc: GameController
    GameController2 gcs;

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
        gc = GameObject.Find("GameController2");
        gcs = gc.GetComponent<GameController2>();

        nameInfo = gcs.infoName;  //pega o nome da carta para saber qual informação exibir

        
        
        if (nameInfo == "alerta")
        {
            Debug.Log("Alerta");
            Pause();
            typeCard.text = "Você achou o alerta!";
            typeInfo.text = "O alerta é...........";
        }
        if (nameInfo == "bluetooth")
        {
            Pause();
            typeCard.text = "Você achou o Bluetooth!";
            typeInfo.text = "o Bluetooth é.......";
        }
        if (nameInfo == "lixo")
        {
            Pause();
            typeCard.text = "Você achou a Lixeira!";
            typeInfo.text = "A lixeira é ...................";
        }
        if (nameInfo == "wifi")
        {
            Pause();
            typeCard.text = "Você achou o Wi-fi!";
            typeInfo.text = "O Wi-fi é ...................";
        }
    }
}
