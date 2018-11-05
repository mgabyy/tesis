using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinaHelmontz : MonoBehaviour {


	public float i;
	public float r;
	public float n;
	public Vector3 DIR;
	public Vector3 H;

	void Update () {
		recalcularH ();
	}

	public void recalcularH(){
		H = DIR * (0.716f * i * n / r);
	}

}
