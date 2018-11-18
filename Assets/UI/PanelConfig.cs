using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelConfig : MonoBehaviour {


	public Button botonMagnitudes,botonBobinas,botonMicrorobot,botonMedio;
	public GameObject panelConfig;
	public GameObject PanelMagnitudes;
	public GameObject PanelBobinas;
	public GameObject PanelMicroRobot;
	public GameObject PanelMedio;

	ColorBlock CB1,CB0;

	void Start(){
		CB0 = botonMagnitudes.colors;
		CB1 = botonMagnitudes.colors;

		CB0.normalColor = botonMagnitudes.colors.normalColor;
		CB1.normalColor = botonMagnitudes.colors.highlightedColor;

		cerrarPanel ();
		abrirPanelMagnitudes ();
	}

	public void cerrarPanel(){
		panelConfig.SetActive (false);
	}


	public void AbrirPanel(){
		panelConfig.SetActive (true);
	}

	public void abrirPanelMagnitudes(){

		botonMagnitudes.colors = CB1;
		botonBobinas.colors = CB0;
		botonMicrorobot.colors = CB0;
		botonMedio.colors = CB0;

		PanelMagnitudes.SetActive (true);
		PanelBobinas.SetActive (false);
		PanelMicroRobot.SetActive (false);
		PanelMedio.SetActive (false);
	}

	public void abrirPanelBobinas(){

		botonMagnitudes.colors = CB0;
		botonBobinas.colors = CB1;
		botonMicrorobot.colors = CB0;
		botonMedio.colors = CB0;

		PanelMagnitudes.SetActive (false);
		PanelBobinas.SetActive (true);
		PanelMicroRobot.SetActive (false);
		PanelMedio.SetActive (false);
	}

	public void abrirPanelMicroRobot(){

		botonMagnitudes.colors = CB0;
		botonBobinas.colors = CB0;
		botonMicrorobot.colors = CB1;
		botonMedio.colors = CB0;

		PanelMagnitudes.SetActive (false);
		PanelBobinas.SetActive (false);
		PanelMicroRobot.SetActive (true);
		PanelMedio.SetActive (false);
	}

	public void abrirPanelMedio(){

		botonMagnitudes.colors = CB0;
		botonBobinas.colors = CB0;
		botonMicrorobot.colors = CB0;
		botonMedio.colors = CB1;

		PanelMagnitudes.SetActive (false);
		PanelBobinas.SetActive (false);
		PanelMicroRobot.SetActive (false);
		PanelMedio.SetActive (true);
	}

}
