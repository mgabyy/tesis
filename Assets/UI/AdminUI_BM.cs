using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminUI_BM : MonoBehaviour {

	public InputField texton;
	public InputField textor;
	public ParBobinasMaxwell BM;

	void Start(){
		poner_n ();
		poner_r ();
	}

	public void poner_n(){

		texton.text = BM.n+"";
	}

	public void Actualizar_n(){

		if (texton.text == "") {
			texton.text = "0";
		}

		float n = float.Parse (texton.text);

		BM.n = n;

	}


	public void poner_r(){

		textor.text = (BM.r*100f)+"";
	}

	public void Actualizar_r(){

		if (textor.text == "") {
			textor.text = "0";
		}

		float r = float.Parse (textor.text);

		BM.r = r/100f;
		BM.dimensionar ();
	}

}
