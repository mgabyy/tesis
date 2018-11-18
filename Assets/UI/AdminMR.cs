using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminMR : MonoBehaviour {

	public InputField textoM;
	public InputField textoR;
	public Text textoV;
	public InputField textoRo;

	public Text textomasa;

	public Dropdown MD;

	public Microrobot MR;

	float AM2T = 0.0000012566370614f;
	float AM2G = 0.012566370614f;
	float T2AM = 795774.7154822216f;
	float G2AM = 79.57747154822215f;

	bool PVA = true;
	bool PVB = true;

	int contador = 0;

	void Start(){
		ponerM ();
		poner_r ();
		poner_ro ();
		ponerV ();
		ponermasa ();
	}

	public void ponerM(){
		float MC = 0f;
		switch (MD.value) {
		case 0:
			MC = MR.M*1f;
			break;
		case 1:
			MC = MR.M * AM2T;
			break;
		case 2:
			MC = MR.M * AM2G;
			break;
		}
		textoM.text = MC+"";
	}

	public void ActualizarM(){

		if (textoM.text == "") {
			textoM.text = "0";
		}

		float M = float.Parse (textoM.text);

		switch (MD.value) {
		case 0:
			M = M*1f;
			break;
		case 1:
			M = M * T2AM;
			break;
		case 2:
			M = M * G2AM;
			break;
		}
		MR.M = M;
	}

	//------------------------------------------------------------------------------

	public void poner_r(){
		textoR.text = (MR.r*100f)+"";
	}

	public void Actualizar_R(){

			if (textoR.text == "") {
				textoR.text = "0";
			}

			float r = float.Parse (textoR.text);

			MR.r = r / 100f;
			MR.actualizarValores ();

	}

	//-----------------------------------------------------------------------

	public void poner_ro(){
		textoRo.text = (MR.d/1000f)+"";
	}

	public void Actualizar_ro(){
		
		if (textoRo.text == "") {
			textoRo.text = "0";
		}

		float ro = float.Parse (textoRo.text);

		MR.d = ro*1000f;
		MR.actualizarValores ();
		textomasa.text = (MR.m*1000)+"";
	}
		
	public void ponerV(){
		textoV.text = (MR.V * 1000000f) + "";
	}

	public void ponermasa(){
		textomasa.text = (MR.m*1000)+"";
	}

}
