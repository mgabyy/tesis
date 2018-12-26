using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamaraClick : MonoBehaviour {

    public GameObject O;
    public Camera c;

    public float vZoom;
    public float velOrbit;

    public float rMin;
    public float rMax;

    public float thetaMin;
    public float thetaMax;

    public float r;
    public float theta;
    public float phi;

     Vector2 DeltaD = Vector2.zero;
    float DeltaS = 0f;


    void Update() {

        if (!Application.isPlaying) {
            c.transform.LookAt(xyz2xzy(O.transform.position));
            theta = 90f * Mathf.Deg2Rad - c.transform.localEulerAngles.x * Mathf.Deg2Rad;
            phi = -90f * Mathf.Deg2Rad - c.transform.localEulerAngles.y * Mathf.Deg2Rad;
            r = Vector3.Distance(O.transform.position, c.transform.position);
        } else {
            if (Input.GetMouseButton(0)) {
                DeltaD = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * 40f;
                orbit(DeltaD);
            }
            DeltaS = Input.GetAxis("Mouse ScrollWheel");
            if (DeltaS != 0) {
                zoom(-DeltaS);
            }
            applyToCameraGO();
        }
    }

    public void zoom(float dT) {

        float velZoom = Mathf.Pow(r / 2, 0.75f) * vZoom; //función para que la velocidad no sea constante.
        r = r + dT * velZoom;
        r = Mathf.Min(r, rMax);
        r = Mathf.Max(r, rMin);
    }

    public void orbit(Vector2 dP) {
        phi -= dP.x * velOrbit * Mathf.Deg2Rad;
        theta += dP.y * velOrbit * Mathf.Deg2Rad;

        if (phi > 2 * Mathf.PI) {
            phi -= 2 * Mathf.PI;
        }

        if (phi < 0) {
            phi += 2 * Mathf.PI;
        }

        theta = Mathf.Max(theta, thetaMin);
        theta = Mathf.Min(theta, thetaMax);
    }

    public void applyToCameraGO() {

        Vector3 ar = new Vector3(Mathf.Cos(phi) * Mathf.Sin(theta), Mathf.Sin(phi) * Mathf.Sin(theta), Mathf.Cos(theta));
        Vector3 aph = new Vector3(-Mathf.Sin(phi), Mathf.Cos(phi), 0);
        Vector3 ath = new Vector3(-Mathf.Cos(phi) * Mathf.Cos(theta), -Mathf.Cos(theta) * Mathf.Sin(phi), Mathf.Sin(theta));

        Vector3 Pos = r * ar + O.transform.position;
        c.transform.localPosition = xyz2xzy(Pos);
        c.transform.LookAt(xyz2xzy(O.transform.position));


    }
    public Vector3 xyz2xzy(Vector3 V) {
        return new Vector3(V.x, V.z, V.y);
    }
}
