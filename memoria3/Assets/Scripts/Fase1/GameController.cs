using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{   // Sprites e botões:
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    //variáveis para controlar o jogo:
    private bool firstGuess, secondGuess;

    public int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    public string firstGuessPuzzle, secondGuessPuzzle;
    public string secondButtonName;

    Button currentButton;

    private int firstGuessIndex, secondGuessIndex;

    //para saber qual carta foi achada e qual informação exibir:
    public string infoName;

    private void Awake() //carrega sprites
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Fase1");
    }

    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2; //total de tentativas corretas necessária é igual a metade do total de peças
    }

    void GetButtons()  //coloca a imagem padrão nos botões
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles() //colocando cartas do jogo
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)//adiciona uma mesma peça duas vezes
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);

            index++;
        }
    }

    void AddListeners() //para identificar quando o jogador selecionar uma peça
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }

    }

    public void PickAPuzzle() //para quando o jogador seleciona uma peça
    {

        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;



        if (!firstGuess)
        {

            firstGuess = true;

            //pega o nome da carta para comparar:
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

            currentButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            currentButton.interactable = false; //desativa esse botão para evitar o clique duplo
            //currentButton.Color

        }
        else if (!secondGuess)
        {

            currentButton.interactable = true;  //reativa o primeiro botão

            secondGuess = true;

            //pega o nome da carta para comparar
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];


            countGuesses++;

            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }
    IEnumerator CheckIfThePuzzlesMatch()
    {

        yield return new WaitForSeconds(1f);
        if (firstGuessPuzzle == secondGuessPuzzle)//caso as cartas sejam iguais:
        {
            infoName = secondGuessPuzzle; //para saber qual info  exbir no script "CardsInfo"

            if (secondGuessPuzzle == "virus")  // caso sejam as cartas do vírus
            {
                print("Ah não! Você achou o vírus!");

                countCorrectGuesses--; //evita de mostrar a tela de fim caso seja a penúltima combinação

                yield return new WaitForSeconds(.5f);

                FindObjectOfType<Screens>().VirusScreen();//mostra a tela de aviso do vírus e o jogo reinicia

            }
            if (secondGuessPuzzle == "pix")
            {
                print("Você achou o Pix! o pix é....");
                FindObjectOfType<CardsInfo>().OpenInfo();  //exibe informações desta carta

            }
            if (secondGuessPuzzle == "cadeado")
            {
                print("Você achou o cadeado!");
                FindObjectOfType<CardsInfo>().OpenInfo();
            }

            if (secondGuessPuzzle == "qr")
            {
                print("Você achou o código QR!");
                FindObjectOfType<CardsInfo>().OpenInfo();
            }

            if (secondGuessPuzzle == "barra")
            {
                print("Você achou o código de barras!");
                FindObjectOfType<CardsInfo>().OpenInfo();
            }

            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {//se as cartas não forem iguais volta para a sprite padrão
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false; //reseta as variáveis

    }
    public void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if ((countCorrectGuesses + 1) == gameGuesses) //o +1 finaliza sem a carta de vírus ter sido combinada
        {
            Debug.Log("Game Finished");
            Debug.Log("It took you" + countGuesses + "many guess(es) to finish the game.");

            FindObjectOfType<Screens>().EndGameScreen();
        }
    }

    void Shuffle(List<Sprite> list) //ramdomiza as sprites
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
