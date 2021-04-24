using System.Collections;
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

        if (nameInfo == "pix")
        {
            Pause();
            typeCard.text = "Você achou o Pix !";
            typeInfo.text = "O Pix é um novo meio de pagamento instantâneo criado pelo Banco Central, as transferências podem ser feitas " +
                            "a qualquer momento e são realizadas através do aplicativo de Internet Banking de sua Instituição. ";
        }
        if (nameInfo == "qr")
        {
            Pause();
            typeCard.text = "Você achou o Código QR!";
            typeInfo.text = "O Código QR, assim como o código de barras um meio de armazenar informações e pode ser lido pela câmera do celular," +
                            " muito utilizado para armazenar endereços eletrônicos e para realizaÇão de pagamentos instantâneos.";
        }
        if (nameInfo == "codigoDeBarras")
        {
            Pause();
            typeCard.text = "Você achou o Código de Barras!";
            typeInfo.text = "O Código de Barras é utilizado para representar uma sequência de números, que pode ser lido por meio de scanners " +
                            "ou até pelo celular, o que pode vir a ser útil, para pagamento de boletos sem a necessidade de ir a um banco ou lotérica.";
        }
        if (nameInfo == "cadeado")
        {
            Pause();
            typeCard.text = "Você achou o Cadeado!";
            typeInfo.text = "O cadeado pode ser visto no seu navegador ao lado do endereço eletrônico acessado, caso ele esteja fechado significa" +
                            " que o site que está sendo acessado possui um protocolo de segurânÇa extra e serão criptografados em uma conexão que será verificada pelo servidor.";
        }
    }
}
