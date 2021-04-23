using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons2 : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;

    void Awake()
    {
        for (int i = 0; i < 10; i++) //gera 10 botões na tela
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
        }
    }
}
