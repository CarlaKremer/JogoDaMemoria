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

        
        
        if (nameInfo == "web")
        {
            Debug.Log("Web");
            Pause();
            typeCard.text = "Você achou a Web!";
            typeInfo.text = "Esta ícone simboliza páginas da web, sites, que você pode acessar através de computadores, celulares, entre outros.";
        }
        if (nameInfo == "bluetooth")
        {
            Pause();
            typeCard.text = "Você achou o Bluetooth!";
            typeInfo.text = "O Bluetooth é um meio de"+
                           " transferir dados sem fios, em pequenas distâncias, esse dados podem ser arquivos; sons, como músicas e chamadas de voz;"+
                           " controlar dispositivos, entre outros.";
        }
        if (nameInfo == "share")
        {
            Pause();
            typeCard.text = "Você achou o Compartilhar!";
            typeInfo.text = "O botão Compartilhar, muitas vezes visto em redes sociais, é uma maneira fácil de compartilhar conteúdo com outras"+
                            " pessoas, pois todas os meios de compartilhamento estarão agrupados naquele botão.";
        }
        if (nameInfo == "wifi")
        {
            Pause();
            typeCard.text = "Você achou o Wi-fi!";
            typeInfo.text = "O Wi-fi é um meio de se acessar a internet sem a necessidade de cabos, é necessário apenas estar na área de abrangência de seu sinal.";
        }
    }
}
