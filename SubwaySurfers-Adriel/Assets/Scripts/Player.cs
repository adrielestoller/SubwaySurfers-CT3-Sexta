using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public float velocidade, alturaPulo, velocidadePulo, gravidade;
    private float posicaoHorizontal = 0;
    private Vector3 Horizontal;
    public float velocidadeDeTrocaDeRota = 100f;

    private bool limite, direita, esquerda;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        direita = true;
        esquerda = true;
        limite = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direcao = Vector3.forward * velocidade;
        
        if(controller.isGrounded) 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                velocidadePulo = alturaPulo;
            }
        }
        else
        {
            velocidadePulo -= gravidade;
        }

        direcao.y = velocidadePulo;
        controller.Move(direcao * Time.deltaTime);
        Mover();
    }

    void Mover() 
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && esquerda)
        {
            if(posicaoHorizontal == 0)
            {
                posicaoHorizontal = -3.5f;
                limite = true;
                if(posicaoHorizontal == -3.5f && limite)
                {
                    esquerda = false;
                    direita = true;
                }
            }
            else if(posicaoHorizontal == 3.5f)
            {
                posicaoHorizontal = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && direita)
        {
            if(posicaoHorizontal == 0)
            {
                posicaoHorizontal = 3.5f;
                limite = true;
                if(posicaoHorizontal == 3.5f && limite)
                {
                    direita = false;
                    esquerda = true;
                }
            }
            else if(posicaoHorizontal == -3.5f)
            {
                posicaoHorizontal = 0;
            }
        }
        else
        {
            esquerda = true;
            direita = true;
            limite = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posicaoHorizontal, transform.position.y, transform.position.z), velocidadeDeTrocaDeRota * Time.deltaTime);
    }
}
