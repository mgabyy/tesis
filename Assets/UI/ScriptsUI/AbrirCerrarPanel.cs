using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrarPanel : MonoBehaviour {
	
	public void Abrir () {
        gameObject.SetActive(true);
	}

    public void Cerrar(){
        gameObject.SetActive(false);
    }

    public void AbrirOCerrar(){

        gameObject.SetActive(!gameObject.activeSelf);
    }

}
