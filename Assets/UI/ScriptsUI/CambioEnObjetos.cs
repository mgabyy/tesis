using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioEnObjetos : MonoBehaviour {

    public BobinasHelmontz BH;
    public ParBobinasHelmontz BHX, BHY, BHZ;
    public BobinasMaxwell BM;
    public ParBobinasMaxwell BM_;
    public Microrobot MR;
    public Rigidbody RB;
    public ConstantesMagneticas CM;

    public Text textoIHelmontzX;
    public Text textoIHelmontzY;
    public Text textoIHelmontzZ;
    public Text textoIMaxwell;
    public Text textoV;

    //PanelDatos

    public void CambioTheta(float nf) {
        Debug.Log("Theta = " + nf);
        BH.theta = nf;
        BH.calcularTodo();
        ActualizarCorrientes();
    }

    public void CambioPhi(float nf) {
        Debug.Log("Phi = " + nf);
        BH.phi = nf;
        BH.calcularTodo();
        ActualizarCorrientes();
    }

    //PanelConfig - Magnitudes

    public void CambioFuerza(float nf) {
        Debug.Log("Fuerza = " + nf);
        BM.F = nf;
        BM.calcularTodo();
        ActualizarCorrientes();
    }

    public void CambioIntensidadDeCampoMagnetico(float nf) {
        Debug.Log("Intensidad De CampoMagnetico = " + nf);
        BH.Hh = nf;
        BH.calcularTodo();
        ActualizarCorrientes();
    }

    public void Desplazar(float v) {
        Debug.Log("Desplazando en " + v);
        BM.Desplazar(v);
        ActualizarV();
    }

    //PanelConfig - Bobinas

    public void CambioNBHX(float nf) {
        Debug.Log("Vueltas bobina Helmotz X = " + nf);
        BHX.n = nf;
        BH.calcularTodo();
        ActualizarCorrientes();
    }

    public void CambioRBHX(float nf) {
        Debug.Log("Radio bobina Helmotz X = " + nf);
        BHX.r = nf;
        BHX.dimensionar();
        BH.calcularTodo();

        ActualizarCorrientes();
    }

    public void CambioNBHY(float nf) {
        Debug.Log("Vueltas bobina Helmotz Y = " + nf);
        BHY.n = nf;
        BH.calcularTodo();
        ActualizarCorrientes();
    }

    public void CambioRBHY(float nf) {
        Debug.Log("Radio bobina Helmotz Y = " + nf);
        BHY.r = nf;
        BHY.dimensionar();
        BH.calcularTodo();
        ActualizarCorrientes();
    }

    public void CambioNBHZ(float nf) {
        Debug.Log("Vueltas bobina Helmotz Z = " + nf);
        BHZ.n = nf;
        BH.calcularTodo();
        ActualizarCorrientes();
    }

    public void CambioRBHZ(float nf) {
        Debug.Log("Radio bobina Helmotz Z = " + nf);
        BHZ.r = nf;
        BHZ.dimensionar();
        BH.calcularTodo();
        ActualizarCorrientes();
    }

    public void CambioNBM(float nf) {
        Debug.Log("Vueltas bobina Maxwell = " + nf);
        BM_.n = nf;
        BM.calcularTodo();
        ActualizarCorrientes();
    }

    public void CambioRBM(float nf) {
        Debug.Log("Radio bobina Maxwell = " + nf);
        BM_.r = nf;
        BM_.dimensionar();
        BM.calcularTodo();
        ActualizarCorrientes();
    }

    //PanelConfig - MicroRobot

    public void CambioM_MR(float nf) {
        Debug.Log("Magnetizacion Micro Robot  = " + nf);
        MR.M = nf;
    }

    public void CambioR_MR(float nf) {
        Debug.Log("Radio Micro Robot  = " + nf);
        MR.r = nf/100f;
    }

    public void CambioD_MR(float nf) {
        Debug.Log("Densidad Micro Robot = " + nf);
        MR.d = nf*1000f;
    }

    //PanelConfig - Medio
   
    
			
    public void CambioUr(float nf) {
        Debug.Log("Permeabilidad magnética = " + nf);
        CM.ur = nf;
        CM.u =CM.ur * CM.u0;
    }

    public void CambioFD(float nf) {
        Debug.Log("Fuerza de arrastre  = " + nf);
        RB.drag = nf;
    }

    public void CambioTD(float nf) {
        Debug.Log("Torque de arrastre = " + nf);
        RB.angularDrag = nf;
    }

    void ActualizarCorrientes() {
        textoIHelmontzX.text = "Ix = " + BHX.I.ToString("0.00") + "A";
        textoIHelmontzY.text = "Iy = " + BHY.I.ToString("0.00") + "A";
        textoIHelmontzZ.text = "Iz = " + BHZ.I.ToString("0.00") + "A";
        textoIMaxwell.text = "I = " + BM_.I.ToString("0.00") + "A";
    }

    //Velocidad del microrobot

    public void ActualizarV() {

        float V = RB.velocity.magnitude * 100f;
        textoV.text = "V = " + V.ToString("0.00") + " cm/s";

    }

    private void Update() {
        if (RB.velocity.magnitude>0f) {
            ActualizarV();
        }
    }
}
