using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_yes_no : MonoBehaviour
{
    public GameObject obj_box_yes_no;
    public Text txt_titulo;
    public Text txt_contenido;
    public Text txt_btn_si;
    public Text txt_btn_no;
    public bool mostrando_caja_de_texto = false;
    public int modo = 0;
    private string titulo;
    private string contenido;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!mostrando_caja_de_texto)
        {
            ocultar_caja_de_texto_confirmar();
        }
    }

    public void mostrar_caja_de_texto_confirmar(string titulo, string contenido, string btn_si, string btn_no)
    {
        txt_titulo.text = titulo;
        txt_contenido.text = contenido;
        txt_btn_si.text = btn_si;
        txt_btn_no.text = btn_no;
        mostrando_caja_de_texto = true;
        Time.timeScale = 0;
        obj_box_yes_no.SetActive(true);

      
    }

    public void ocultar_caja_de_texto_confirmar()
    {
        mostrando_caja_de_texto = false;
        Time.timeScale = 1;
        obj_box_yes_no.SetActive(false);
    }

}
