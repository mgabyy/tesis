using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tube : MonoBehaviour {

	public float h = 0.2f;
	public float r = 0.4f;
	public float th = 0.5f;
	public int Divs = 36;

	public GameObject innerCylinderGO,outerCylinderGO,topDiskGO,bottomDiskGO;
	Vector3[] vertInsideTop,vertOutsideTop,vertInsideBottom,vertOutsideBottom;

	void Awake () {

		innerCylinderGO = transform.Find ("innerCylinder").gameObject;
		outerCylinderGO = transform.Find ("outerCylinder").gameObject;
		topDiskGO = transform.Find ("topDisk").gameObject;
		bottomDiskGO = transform.Find ("bottomDisk").gameObject;
		draw();
	}

	void Start(){
		draw();
	}
		
	void Update(){
		if (!Application.isPlaying) {
			draw ();
		}
	}

	public void draw(){
		vertInsideTop = circularVerts (r, h);
		vertOutsideTop = circularVerts (r + th, h);
		vertInsideBottom = circularVerts (r, 0);
		vertOutsideBottom = circularVerts (r + th, 0);

		TopDisk ();
		BottomDisk ();
		InnerCylinder ();
		OuterCylinder ();
	}

	private void TopDisk(){

		Vector3[] topDiskVerts = new Vector3[vertInsideTop.Length + vertOutsideTop.Length];
		vertInsideTop.CopyTo(topDiskVerts,0);
		vertOutsideTop.CopyTo(topDiskVerts,Divs+1);
	
		int[] topDiskTrigs = new int[6 * Divs];

		for (int i = 0; i < Divs; i++) {

			int ir = i + Divs+1;

			topDiskTrigs [6 * i + 0] = ir;
			topDiskTrigs [6 * i + 1] = ir+1;
			topDiskTrigs [6 * i + 2] = i;
			topDiskTrigs [6 * i + 3] = ir+1;
			topDiskTrigs [6 * i + 4] = i+1;
			topDiskTrigs [6 * i + 5] = i;

		}

		asignMesh (topDiskGO, topDiskVerts, topDiskTrigs);
	}

	private void BottomDisk(){
		Vector3[] bottomDiskVerts = new Vector3[vertInsideBottom.Length + vertOutsideBottom.Length];
		vertInsideBottom.CopyTo(bottomDiskVerts,0);
		vertOutsideBottom.CopyTo(bottomDiskVerts,Divs+1);

		int[] bottomDiskTrigs = new int[6 * Divs];

		for (int i = 0; i < Divs; i++) {

			int ir = i + Divs+1;

			bottomDiskTrigs [6 * i + 0] = i;
			bottomDiskTrigs [6 * i + 1] = ir+1;
			bottomDiskTrigs [6 * i + 2] = ir;
			bottomDiskTrigs [6 * i + 3] = i;
			bottomDiskTrigs [6 * i + 4] = i+1;
			bottomDiskTrigs [6 * i + 5] = ir+1;
		}

		asignMesh (bottomDiskGO, bottomDiskVerts, bottomDiskTrigs);
	}

	private void InnerCylinder(){
		Vector3[] innerDiskVerts = new Vector3[vertInsideBottom.Length + vertOutsideBottom.Length];
		vertInsideTop.CopyTo(innerDiskVerts,0);
		vertInsideBottom.CopyTo(innerDiskVerts,Divs+1);

		int[] innerDiskTrigs = new int[6 * Divs];

		for (int i = 0; i < Divs; i++) {

			int ir = i + Divs+1;

			innerDiskTrigs [6 * i + 0] = i;
			innerDiskTrigs [6 * i + 1] = ir+1;
			innerDiskTrigs [6 * i + 2] = ir;
			innerDiskTrigs [6 * i + 3] = i;
			innerDiskTrigs [6 * i + 4] = i+1;
			innerDiskTrigs [6 * i + 5] = ir+1;
		}

		asignMesh (innerCylinderGO, innerDiskVerts, innerDiskTrigs);
	}

	private void OuterCylinder(){
		Vector3[] outerDiskVerts = new Vector3[vertInsideBottom.Length + vertOutsideBottom.Length];
		vertOutsideTop.CopyTo(outerDiskVerts,0);
		vertOutsideBottom.CopyTo(outerDiskVerts,Divs+1);

		int[] outerDiskTrigs = new int[6 * Divs];

		for (int i = 0; i < Divs; i++) {

			int ir = i + Divs+1;

			outerDiskTrigs [6 * i + 0] = ir;
			outerDiskTrigs [6 * i + 1] = ir+1;
			outerDiskTrigs [6 * i + 2] = i;
			outerDiskTrigs [6 * i + 3] = ir+1;
			outerDiskTrigs [6 * i + 4] = i+1;
			outerDiskTrigs [6 * i + 5] = i;
		}

		asignMesh (outerCylinderGO, outerDiskVerts, outerDiskTrigs);
	}

	private void asignMesh (GameObject V, Vector3[] vertices, int[] triangulos){
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangulos;
		mesh.RecalculateNormals ();
		V.GetComponent<MeshFilter> ().mesh = mesh;
	}

	private Vector3[] circularVerts(float r, float z){
		Vector3[] vertices = new Vector3[Divs+1];
		for (int i = 0; i <= Divs; i++) {
			float x = r * Mathf.Sin (2 * Mathf.PI * i / Divs);
			float y = r * Mathf.Cos (2 * Mathf.PI * i / Divs);
			vertices [i] = new Vector3 (x, z, y);
		}
		return vertices;
	}
}

