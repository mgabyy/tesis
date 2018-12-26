using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminTeclado : MonoBehaviour {

    public GameObject panelSAlir;
    public GameObject imOn, imOff;
    public float vr,vt;

    public float theta;
    public float phi;
    public ParametrosIniciales parametrosIniciales;
    public CambioVariables cambioVariables;
    bool cambio = false;

    private void Start() {
        theta = parametrosIniciales.theta;
        phi = parametrosIniciales.phi;
    }

    void FixedUpdate() {

        if (Input.GetKey("escape")) {
            panelSAlir.SetActive(true);
        }



        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                float vertical = Input.GetAxis("Vertical");
                cambioVariables.Desplazar(vertical * vt);
                imOn.SetActive(true);
                imOff.SetActive(false);
                cambio = true;
            } else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) {

                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
                    float vertical = Input.GetAxis("Vertical");
                    theta -= vertical * vr;
                    theta = Mathf.Max(theta, 0f);
                    theta = Mathf.Min(theta, 180f);
                    cambioVariables.CambioTheta(theta + "");
                }else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
                    float Horizontal = Input.GetAxis("Horizontal");
                    phi += Horizontal * vr;

                    if (phi > 360f) {
                        phi = phi - 360f;
                    }

                    if (phi < 0f) {
                        phi = phi + 360f;
                    }

                    cambioVariables.CambioPhi(phi + "");
                }
            }
        } else {

            if (cambio) {
                imOn.SetActive(false);
                imOff.SetActive(true);
                cambio = false;
            }
        }
    }

    public void cerrarPrograma() {
        Application.Quit();
    }
    
    public void cancelarSalir() {
        panelSAlir.SetActive(false);
    }
}
