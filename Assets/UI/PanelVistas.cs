using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelVistas : MonoBehaviour {

	public GameObject panelVistas;

	public GameObject LDC, VM, BHX,BHY,BHZ,BM,MR,EDT;
	public Toggle T_LDC, T_VM, T_BHX,T_BHY,T_BHZ,T_BM,T_MR,T_EDT;

	void Start(){

		cerrarPanel ();

		T_LDC.isOn = LDC.activeSelf;
		T_VM.isOn = VM.activeSelf;
		T_BHX.isOn = BHX.activeSelf;
		T_BHY.isOn = BHY.activeSelf;
		T_BHZ.isOn = BHZ.activeSelf;
		T_BM.isOn = BM.activeSelf;
		T_MR.isOn = MR.activeSelf;
		T_EDT.isOn = EDT.activeSelf;

		LDC.SetActive(T_LDC);
		VM.SetActive(T_VM);
		BHX.SetActive(T_BHX);
		BHY.SetActive(T_BHY);
		BHZ.SetActive(T_BHZ);
		BM.SetActive(T_BM);
		MR.SetActive(T_MR);
		EDT.SetActive(T_EDT);

	}


	public void cerrarPanel(){
		panelVistas.SetActive (false);
	}


	public void AbrirPanel(){
		panelVistas.SetActive (true);
	}

	public void toogle(int opcion){
		switch (opcion) {
		case 0:
			LDC.SetActive(T_LDC.isOn);
			break;
		case 1:
			VM.SetActive(T_VM.isOn);
			break;
		case 2:
			BHX.SetActive(T_BHX.isOn);
			break;
		case 3:
			BHY.SetActive(T_BHY.isOn);
			break;
		case 4:
			BHZ.SetActive(T_BHZ.isOn);
			break;
		case 5:
			BM.SetActive(T_BM.isOn);
			break;
		case 6:
			MR.SetActive(T_MR.isOn);
			break;
		case 7:
			EDT.SetActive(T_EDT.isOn);
			break;

		}

	}


}
