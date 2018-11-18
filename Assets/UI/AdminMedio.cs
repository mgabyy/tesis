using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminMedio : MonoBehaviour {

	public InputField textoUr;

	public InputField textoFD;
	public InputField textoTD;

	public ConstantesMagneticas CM;
	public Rigidbody rb;

	void Start(){
		poner_ur ();
		poner_FD ();
		poner_TD ();
	}

	public void poner_ur(){
		textoUr.text = CM.ur+"";
	}

	public void Actualizar_ur(){

		if (textoUr.text == "") {
			textoUr.text = "0";
		}

		float ur = float.Parse (textoUr.text);

		CM.ur = ur;
		CM.u = ur*CM.u0;
	}



	//-------------------------------------
		
	public void poner_FD(){
		textoFD.text = rb.drag+"";
	}

	public void Actualizar_FD(){

		if (textoFD.text == "") {
			textoFD.text = "0";
		}

		float drag = float.Parse (textoFD.text);

		rb.drag = drag;
	}

	//-------------------------------------

	public void poner_TD(){
		textoTD.text = rb.angularDrag+"";
	}

	public void Actualizar_TD(){

		if (textoTD.text == "") {
			textoTD.text = "0";
		}

		float Adrag = float.Parse (textoTD.text);

		rb.angularDrag = Adrag;
	}

}
