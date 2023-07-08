﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coronar_caja : MonoBehaviour
{

    public piezas las_piezas;
    public Button dama_blanco;
    public Button torre_blanco;
    public Button alfil_blanco;
    public Button caballo_blanco;
    public Button dama_negro;
    public Button torre_negro;
    public Button alfil_negro;
    public Button caballo_negro;

    public bool mostrando_caja_de_texto = false;


   

    private void Awake()
    {

    }

        // Update is called once per frame
        void Update()
    {
        if (!mostrando_caja_de_texto)
        {
            ocultar_caja_de_texto_coronar();
        }
    }

    public void mostrar_caja_de_texto_coronar()
    {
        todas_las_piezas_activas();
        if (las_piezas.coronado_es_blanca)
        {
            dama_negro.gameObject.SetActive(false);
            torre_negro.gameObject.SetActive(false);
            alfil_negro.gameObject.SetActive(false);
            caballo_negro.gameObject.SetActive(false);
        }
        else
        {
            dama_blanco.gameObject.SetActive(false);
            torre_blanco.gameObject.SetActive(false);
            alfil_blanco.gameObject.SetActive(false);
            caballo_blanco.gameObject.SetActive(false);
        }
        mostrando_caja_de_texto = true;
        Time.timeScale = 0;
        this.gameObject.SetActive(true);


    }

    public void ocultar_caja_de_texto_coronar()
    {
        mostrando_caja_de_texto = false;
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void todas_las_piezas_activas()
    {
        //para evitar errores de desactivar pieza desactivada y tener todas las piezas desactivadas
        dama_negro.gameObject.SetActive(true);
        torre_negro.gameObject.SetActive(true);
        alfil_negro.gameObject.SetActive(true);
        caballo_negro.gameObject.SetActive(true);
        dama_blanco.gameObject.SetActive(true);
        torre_blanco.gameObject.SetActive(true);
        alfil_blanco.gameObject.SetActive(true);
        caballo_blanco.gameObject.SetActive(true);
    }
    

}
