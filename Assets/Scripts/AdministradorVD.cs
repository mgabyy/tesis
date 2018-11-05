using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorVD : MonoBehaviour {

	public int Divs;
	public float N;
	public float R;
	public Material material;
	public Color color;

	public BobinasHelmontz BH;
	private Vector3 H;
	private GameObject Flecha;
	private Vector vector;

	void Start () {
		vector = gameObject.AddComponent(typeof(Vector)) as Vector;
		Flecha = vector.crear (new Vector3(0,0,0),H, Divs, N, R, material, color,"Flecha");
	}

	void Update () {
		H = BH.Hh;
		vector.ModificarVector (Flecha, new Vector3 (0, 0, 0), H, Divs, N, R, material, color);
	}
}
