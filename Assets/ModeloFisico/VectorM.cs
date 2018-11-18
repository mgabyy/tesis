using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorM : MonoBehaviour {

	public int Divs;
	public float N;
	public float R;
	public Material material;
	public Color color;
	public Microrobot MR;
	Vector vector;

	GameObject V;

	void Start () {
		vector = gameObject.AddComponent(typeof(Vector)) as Vector;
		V = vector.crear(MR.gameObject.transform.position, MR.MV, Divs, N, R, material,color,"Flecha");
	}
	

	void Update () {
		vector.ModificarVector(V,Calculos.trans(MR.gameObject.transform.position), MR.MV, Divs, N, R, material,color);
	}
}
