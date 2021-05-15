using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
//informações das cartas encontradas
[RequireComponent(typeof(AudioSource))]
public class CardsInfo2 : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject infoMenuUI;

    GameObject gc;  //gc: GameController
    GameController2 gcs;

    //som
    public AudioClip succeed;
    AudioSource audioSource;

    public Text typeCard;
    public Text typeInfo;
    Sprite typeImage;
    public Image imageT;

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

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(succeed, 0.7F);
        
        if (nameInfo == "download")
        {
            Debug.Log("download");
            Pause();
            typeCard.text = "Você achou o Download!";
            typeInfo.text = "O ícone de download aparecerá quando for possível salvar um arquivo em seu dispositivo para que possa ser acessado no momento"+
                            " em que desejar sem a necessidade de internet, este arquivo pode ser uma foto, vídeo, documento, entre outros.";
            typeImage = Resources.Load<Sprite>("Sprites/Icons/download");
            imageT.sprite = typeImage;
        }
        if (nameInfo == "bluetooth")
        {
            Pause();
            typeCard.text = "Você achou o Bluetooth!";
            typeInfo.text = "O Bluetooth é um meio de"+
                           " transferir dados sem fios, em pequenas distâncias, esse dados podem ser arquivos; sons, como músicas e chamadas de voz;"+
                           " controlar dispositivos, entre outros.";
            typeImage = Resources.Load<Sprite>("Sprites/Icons/bluetooth");
            imageT.sprite = typeImage;
        }
        if (nameInfo == "share")
        {
            Pause();
            typeCard.text = "Você achou o Compartilhar!";
            typeInfo.text = "O botão Compartilhar, muitas vezes visto em redes sociais, é uma maneira fácil de compartilhar conteúdo com outras"+
                            " pessoas, pois todas os meios de compartilhamento estarão agrupados naquele botão.";
            typeImage = Resources.Load<Sprite>("Sprites/Icons/share");
            imageT.sprite = typeImage;
        }
        if (nameInfo == "wifi")
        {
            Pause();
            typeCard.text = "Você achou o Wi-fi!";
            typeInfo.text = "O Wi-fi é um meio de se acessar a internet sem a necessidade de cabos, é necessário apenas estar na área de abrangência de seu sinal.";
            typeImage = Resources.Load<Sprite>("Sprites/Icons/wifi");
            imageT.sprite = typeImage;
        }
    }
}
