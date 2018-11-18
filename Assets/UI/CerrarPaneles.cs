using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPaneles : MonoBehaviour {

	public GameObject[] Paneles;


	public void cerrarPaneles(){
		for (int i = 0; i < Paneles.Length; i++) {
			if (i != 2) {
				Paneles [i].SetActive (false);
			}
		}
	}

	public void cerrarPanelesMenos(int x){
		for (int i = 0; i < Paneles.Length; i++) {
			if (i != x) {
				Paneles [i].SetActive (false);
			}
		}
	}

}
