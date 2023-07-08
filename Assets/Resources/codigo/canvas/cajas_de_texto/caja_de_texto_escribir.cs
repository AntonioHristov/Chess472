using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class caja_de_texto_escribir : MonoBehaviour
{
    public GameObject obj_caja_escribir;
    public Text txt_titulo;
    public Text txt_contenido;
    public Text txt_btn_ok;
    public GameObject btn_ok;
    public bool mostrando_caja_de_texto = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!mostrando_caja_de_texto)
        {
            ocultar_caja_de_texto_escribir();
        }
    }

    public void mostrar_caja_de_texto_escribir(string titulo, string contenido, string txt_ok)
    {
        txt_titulo.text = titulo;
        txt_contenido.text = contenido;
        txt_btn_ok.text = txt_ok;
        mostrando_caja_de_texto = true;
        Time.timeScale = 0;
        obj_caja_escribir.SetActive(true);
    }

    public void ocultar_caja_de_texto_escribir()
    {
        mostrando_caja_de_texto = false;
        Time.timeScale = 1;
        obj_caja_escribir.SetActive(false);
    }

}
