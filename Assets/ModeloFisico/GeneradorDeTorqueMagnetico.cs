using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeTorqueMagnetico : MonoBehaviour {

	public GameObject MRGO;
	Rigidbody ObjectToAttract;
	Microrobot MR;
	public BobinasHelmontz BH;

	void Awake(){
		ObjectToAttract = MRGO.GetComponent<Rigidbody> ();
		MR = MRGO.GetComponent<Microrobot> ();
	}

	void FixedUpdate () {
		ActualizarRotacion ();
		MR.actualizarVectorM ();
	}


	public void ActualizarVectorDirector (float theta, float phi) {
		transform.transform.eulerAngles = new Vector3 (0, -phi, -theta);
	}

	public void ActualizarRotacion(){

		Quaternion AngleDifference = Quaternion.FromToRotation(ObjectToAttract.transform.up, transform.up);

		float AngleToCorrect = Quaternion.Angle(transform.rotation, ObjectToAttract.transform.rotation);
		Vector3 Perpendicular = Vector3.Cross(transform.up, transform.forward);
		if (Vector3.Dot(ObjectToAttract.transform.forward, Perpendicular) < 0)
			AngleToCorrect *= -1;
		Quaternion Correction = Quaternion.AngleAxis(AngleToCorrect, transform.up);

		Vector3 MainRotation = RectifyAngleDifference((AngleDifference).eulerAngles);
		Vector3 CorrectiveRotation = RectifyAngleDifference((Correction).eulerAngles);

		Vector3 Axis = (MainRotation - CorrectiveRotation / 2) - ObjectToAttract.angularVelocity;

		BH.torque = MR.m * BH.Hh*Mathf.Sin(AngleToCorrect*Mathf.Deg2Rad);

		ObjectToAttract.AddTorque(Axis, ForceMode.Acceleration);
	}

	private Vector3 RectifyAngleDifference(Vector3 angdiff)
	{
		if (angdiff.x > 180) angdiff.x -= 360;
		if (angdiff.y > 180) angdiff.y -= 360;
		if (angdiff.z > 180) angdiff.z -= 360;
		return angdiff;
	}




}
