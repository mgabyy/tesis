using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoHelmontz : MonoBehaviour {

	public Vector3Int Dim;
	public Vector2[] Lim;
	public int Divs;
	public float N;
	public float R;
	public Material material;
	public Color color;

	public Vector3 Hh;
	 Vector vector;
	 GameObject[,,] Vectores;
	 VolumenDeTrabajo VDT;

	void Awake(){
		VDT = transform.Find ("../VolumenDeTrabajo").gameObject.GetComponent<VolumenDeTrabajo> ();
	}

	void Start () {
		
		vector = gameObject.AddComponent(typeof(Vector)) as Vector;
		Vectores = new GameObject[Dim.x, Dim.y, Dim.z];
		actualizarVolumen ();
		for (int x = 0; x < Dim.x; x++) {
			for (int y = 0; y < Dim.y; y++) {
				for (int z = 0; z < Dim.z; z++) {
					float DimX = Mathf.Max (1f, Dim.x - 1);
					float DimY = Mathf.Max (1f, Dim.y - 1);
					float DimZ = Mathf.Max (1f, Dim.z - 1);

					float Px = Calculos.map (x, 0, DimX, Lim[0].x, Lim[0].y);
					float Py = Calculos.map (y, 0, DimY, Lim[1].x, Lim[1].y);
					float Pz = Calculos.map (z, 0, DimZ, Lim[2].x, Lim[2].y);
					Vector3 P = new Vector3 (Px, Py, -Pz);
					Vector3 Q = Hh;
					string titulo = "[" + x + " " + y + " " + z + "]";
					Vectores [x, y, z] = vector.crear(P, Q, Divs, N, R, material,color,titulo);
				}
			}
		}


	}

	public void actualizarVector () {
		for (int x = 0; x < Dim.x; x++) {
			for (int y = 0; y < Dim.y; y++) {
				for (int z = 0; z < Dim.z; z++) {
					float DimX = Mathf.Max (1f, Dim.x - 1);
					float DimY = Mathf.Max (1f, Dim.y - 1);
					float DimZ = Mathf.Max (1f, Dim.z - 1);
					float Px = Calculos.map (x, 0, DimX, Lim[0].x, Lim[0].y);
					float Py = Calculos.map (y, 0, DimY, Lim[1].x, Lim[1].y);
					float Pz = Calculos.map (z, 0, DimZ, Lim[2].x, Lim[2].y);
					Vector3 P = new Vector3 (Px, Py, -Pz);
					Vector3 Q = Hh;
					vector.ModificarVector(Vectores [x, y, z] ,P, Q, Divs, N, R, material,color);
				}
			}
		}
	}

	public void actualizarVolumen(){
		Lim [0].x = -VDT.transform.localScale.x / 2f;
		Lim [0].y = VDT.transform.localScale.x / 2f;
		Lim [1].x = -VDT.transform.localScale.z / 2f;
		Lim [1].y = VDT.transform.localScale.z / 2f;
		Lim [2].x = -VDT.transform.localScale.y / 2f;
		Lim [2].y = VDT.transform.localScale.y / 2f;
	}
}
