using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour {

	public GameObject crear(Vector3 P, Vector3 Q, int Divs, float N, float R, Material material, Color color, string nombre = null){
		//Debug.Log ("Creando en: "+P +"  " + Q + " "  + ro + " "+ theta*180/Mathf.PI + " " + phi*180/Mathf.PI ) ;
		GameObject V;
		if (Calculos.calcularRo (Q) > 0) {
			V = crearGO ();
			Vector3[] vertices = calcularVertices (P, Q, Divs, N, R);
			int[] triangulos = calcularTriangulos (Divs); 
			asignarMesh (V, vertices, triangulos, material, color);
		} else {
			V = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			V.transform.position = Calculos.trans(P);
			V.transform.localScale = new Vector3(2*R,2*R,2*R);
			cambiarMaterial (V, material);
			cambiarColor (V, color);
		}
		V.transform.SetParent (this.gameObject.transform);
		if (nombre != null) {
			V.name = nombre;
		}
		return V;
	}

	private GameObject crearGO(){
		GameObject V = new GameObject ();
		V.AddComponent<MeshFilter> ();
		V.AddComponent<MeshRenderer> ();
		return V;
	}

	private Vector3[] calcularVertices(Vector3 P, Vector3 Q, int Divs, float N,float R){

		float theta = Calculos.calcularTheta(Q);
		float phi = Calculos.calcularPhi(Q);

		Vector3[] vertices = new Vector3[Divs + 2];
		vertices [0] =new Vector3 (0, 0, N);
		for (int i = 0; i < Divs; i++) {
			float x = R * Mathf.Cos (2 * Mathf.PI * i / Divs);
			float y = R * Mathf.Sin (2 * Mathf.PI * i / Divs);
			float z = 0;
			vertices [i + 1] = new Vector3 (x, y, z);
		}

		vertices [Divs + 1] = new Vector3 (0, 0, 0);

		for (int i = 0; i < vertices.Length; i++) {
			vertices [i] = Calculos.Rotacion(vertices[i],theta,phi);
			vertices [i] = Calculos.trans (vertices [i] + P);
		}

		return vertices;
	}

	private int[] calcularTriangulos(int Divs){
		int[] conos = new int[3 * Divs];
		int[] tapas = new int[3 * Divs];
		int[] triangulos = new int[conos.Length + tapas.Length];

		for (int i = 0; i < Divs - 1; i++) {
			conos [3 * i] = i + 2;
			conos [3 * i + 1] = 0;
			conos [3 * i + 2] = i + 1;

			tapas [3 * i] = i + 1;
			tapas [3 * i + 1] = Divs+1;
			tapas [3 * i + 2] = i + 2;
		}

		conos [3 * (Divs - 1)] = 1;
		conos [3 * (Divs - 1) + 1] = 0;
		conos [3 * (Divs - 1) + 2] = Divs;

		tapas [3 * (Divs - 1)] = Divs;
		tapas [3 * (Divs - 1) + 1] = Divs+1;
		tapas [3 * (Divs - 1) + 2] = 1;

		conos.CopyTo(triangulos, 0);
		tapas.CopyTo(triangulos, conos.Length);

		return triangulos;
	}

	private void asignarMesh (GameObject V, Vector3[] vertices, int[] triangulos, Material material,Color color){
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangulos;
		mesh.RecalculateNormals ();
		V.GetComponent<MeshFilter> ().mesh = mesh;
		material.color = color;
		cambiarMaterial (V, material);
	}

	public void cambiarMaterial(GameObject V,Material material){
		V.GetComponent<Renderer> ().material = material;
	}

	public void cambiarColor (GameObject V,Color color){
		V.GetComponent<Renderer> ().material.color = color;
	}

	public void ModificarVector(GameObject V, Vector3 P,Vector3 Q,int Divs, float N,float R,Material material, Color color){
		Vector3[] vertices = calcularVertices (P, Q, Divs, N, R);
		int[] triangulos = calcularTriangulos (Divs); 
		asignarMesh (V, vertices, triangulos, material, color);
	}

}
