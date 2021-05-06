//controla funções dos botões presentes nas telas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Screens : MonoBehaviour
{
    public Text movements;

    public GameObject VirusScreenUI;
    public GameObject GameEndedUI;
    public GameObject InstructionsUI;

    GameObject Gc; //Gc: GameController
    GameController Gcs;  


    public void EndGameScreen()
    {
        Gc = GameObject.Find("GameController");
        Gcs = Gc.GetComponent<GameController>();
        //quando o jogo chega ao fim, mostra a tela de finalização
        movements.text = Mathf.RoundToInt(Gcs.countGuesses).ToString();

        GameEndedUI.SetActive(true);
    }

    public void VirusScreen() //tela alertando de que o virus foi achado, então jogo vai reiniciar
    {
        VirusScreenUI.SetActive(true);
    }

    public void NextScene() //carrega próxima fase
    {
        SceneManager.LoadScene("Fase2");
    }

    public void ResetButton()//função que está no botão de reinicialização
    {
        SceneManager.LoadScene("Game");
    }

    public void DisableInstructions()//desativa tela de instruções
    {
        InstructionsUI.SetActive(false);
    }

}
