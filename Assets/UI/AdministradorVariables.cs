using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdministradorVariables : MonoBehaviour {

	public InputField textoTheta;
	public InputField textoPhi;

	public Text textoIHelmontzX;
	public Text textoIHelmontzY;
	public Text textoIHelmontzZ;
	public Text textoIMaxwell;

	public InputField textoF;
	public InputField textoHh;

	public Text textoV;

	public BobinasHelmontz BH;
	public BobinasMaxwell BM;

	public double IHelmontzX;
	public double IHelmontzY;
	public double IHelmontzZ;
	public double IMaxwell;

	public float theta;
	public float phi;

	public Dropdown HhD;

	public Rigidbody rb;

	float AM2T = 0.0000012566370614f;
	float AM2G = 0.012566370614f;
	float T2AM = 795774.7154822216f;
	float G2AM = 79.57747154822215f;

	void Start(){
		ponerFuerza ();
		ponerIntensidadDeCampo ();
	}

	void Update () {
		IHelmontzX = BH.Ix;
		IHelmontzY = BH.Iy;
		IHelmontzZ = BH.Iz;
		IMaxwell = BM.I;
		theta = BH.theta;
		phi = BH.phi;

		actualizarAngulos ();
		actualizarTau ();
		actualizarCorrientes ();
	}

	void actualizarAngulos(){
		textoTheta.text = theta.ToString("0.0");
		textoPhi.text = phi.ToString("0.0");
	}

	void actualizarTau(){

		float V = rb.velocity.magnitude * 100f;
		textoV.text = "V = "+ V.ToString("0.00")+" cm/s";

	}

	void actualizarCorrientes(){
		textoIHelmontzX.text = "Ix = " + IHelmontzX.ToString("0.00") + "A";
		textoIHelmontzY.text = "Iy = " + IHelmontzY.ToString("0.00") + "A";
		textoIHelmontzZ.text = "Iz = " + IHelmontzZ.ToString("0.00") + "A";
		textoIMaxwell.text = "I = " + IMaxwell.ToString("0.00") + "A";
	}

	public void ponerFuerza(){
		textoF.text = BM.F+"";
	}

	public void ActualizarFuerza(){

		if (textoF.text == "") {
			textoF.text = "0";
		}

		BM.F = float.Parse (textoF.text);
	}



	public void ponerIntensidadDeCampo(){
		float HhC = 0f;
		switch (HhD.value) {
		case 0:
			HhC = BH.Hh*1f;
			break;
		case 1:
			HhC = BH.Hh * AM2T;
			break;
		case 2:
			HhC = BH.Hh * AM2G;
			break;
		}
		textoHh.text = HhC+"";
	}

	public void ActualizarIntensidadDeCampo(){

		if (textoHh.text == "") {
			textoHh.text = "0";
		}

		float Hh = float.Parse (textoHh.text);

		switch (HhD.value) {
		case 0:
			Hh = Hh*1f;
			break;
		case 1:
			Hh = Hh * T2AM;
			break;
		case 2:
			Hh = Hh * G2AM;
			break;
		}

		BH.Hh = Hh;

	}

	public void cambioTheta(){
		BH.theta = float.Parse (textoTheta.text);
		BH.calcularTodo ();
	}

	public void cambioPhi(){
		BH.phi = float.Parse (textoPhi.text);
		BH.calcularTodo ();
	}

}
