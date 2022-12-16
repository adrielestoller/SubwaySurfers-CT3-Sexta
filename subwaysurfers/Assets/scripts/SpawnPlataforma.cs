using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] plataformas;
    public float gerador = 0f;
    private float tamanhoPlataforma = 30;
    private Transform Jogador;
    private int plataformasNaTela = 5;
    private List<GameObject> plataformasAtivas = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindGameObjectWithTag("player").transform;

        for (int i = 0; i <= plataformasNaTela; i++)
            gerarPlataformas(Random.Range(0, i));
    }

    // Update is called once per frame
    void Update()
    {
        if(Jogador.position.z - 35 > (gerador - plataformasNaTela * tamanhoPlataforma))
        {
            gerarPlataformas(Random.Range(0, plataformas.Length));
            Deletarplataformas();
        }
    }

    public void gerarPlataformas(int numeroDaPista)
    {
        GameObject Iniciar;
        Iniciar = Instantiate(plataformas[numeroDaPista]) as GameObject;
        Iniciar.transform.SetParent(transform);
        Iniciar.transform.position = Vector3.forward * gerador;
        gerador += tamanhoPlataforma;
        plataformasAtivas.Add(Iniciar);
    }

    public void Deletarplataformas()
    {
        Destroy(plataformasAtivas[0]);
        plataformasAtivas.RemoveAt(0);
    }
}
