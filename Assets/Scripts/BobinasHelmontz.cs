using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinasHelmontz : MonoBehaviour {

	public BobinaHelmontz bobinaX;
	public BobinaHelmontz bobinaY;
	public BobinaHelmontz bobinaZ;

	public Vector3 Hh;

	void Update () {
		Hh = bobinaX.H + bobinaY.H + bobinaZ.H;
	}
}
