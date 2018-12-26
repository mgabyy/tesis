using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametrosMR : MonoBehaviour {

    public InputField IF_r;
    public InputField IF_D;
    public Text IF_V;
    public Text IF_m;
    public Microrobot MR;


    public void Awake() {
        IF_r.text = 1f + "";
        IF_D.text = 1f + "";
    }

    public void ActualizarDatos() {
        string rs = IF_r.text;
        string ds = IF_D.text;
        float r = float.Parse(rs);
        float D = float.Parse(ds);
        float v = (4f / 3f) * Mathf.PI * Mathf.Pow(r, 3);
        float m = D * v;

        IF_V.text = v + "";
        IF_m.text = m + "";

        MR.V = v / 1000000f;
        MR.m = m / 1000f;

    }

}
