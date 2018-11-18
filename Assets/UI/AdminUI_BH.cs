using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminUI_BH : MonoBehaviour {

	public InputField[] texton;
	public InputField[] textor;
	public ParBobinasHelmontz[] BH;

	void Start(){
		for(int i = 0 ; i < 3 ; i++){
			poner_n (i);
			poner_r (i);
		}
	}

	public void poner_n(int N){

		texton[N].text = BH[N].n+"";
	}

	public void Actualizar_n(int N){

		if (texton[N].text == "") {
			texton[N].text = "0";
		}

		float n = float.Parse (texton[N].text);

		BH[N].n = n;

	}


	public void poner_r(int N){

		textor[N].text = (BH[N].r*100f)+"";
	}

	public void Actualizar_r(int N){

		if (textor[N].text == "") {
			textor[N].text = "0";
		}

		float r = float.Parse (textor[N].text);

		BH[N].r = r/100f;
		BH[N].dimensionar ();
	}

}
