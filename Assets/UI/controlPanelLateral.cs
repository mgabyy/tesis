using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPanelLateral : MonoBehaviour {

	public GameObject panelLateral;

	public void cerrarPanel(){
	
		panelLateral.SetActive (false);

	}


	public void AbrirPanel(){

		panelLateral.SetActive (true);
	}


}
