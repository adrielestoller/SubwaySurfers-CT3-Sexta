using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gerenciador : MonoBehaviour
{
    int moedas = 0;
    TextMeshProUGUI textoMoedas;

    void Start()
    {
        textoMoedas = GameObject.FindGameObjectWithTag("Moedas").GetComponent<TextMeshProUGUI>();
    }

    public void Pontuar()
    {
        Debug.Log("PEGOU UMA MOEDA MEU CHAPA");
        moedas++;
        textoMoedas.text = moedas.ToString();
    }
}
