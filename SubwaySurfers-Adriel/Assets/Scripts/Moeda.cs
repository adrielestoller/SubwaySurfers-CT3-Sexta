using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    Gerenciador gerenciador;

    void Start()
    {
        gerenciador = GameObject.FindGameObjectWithTag("Gerenciador").GetComponent<Gerenciador>();
    }
    
    private void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Player") {
            gerenciador.Pontuar();
            Destroy(this.gameObject);
        }
    }
}
