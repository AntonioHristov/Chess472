using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_promote : MonoBehaviour
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
        //this.Hide();
    }

        // Update is called once per frame
        void Update()
    {
        /*
        if (!mostrando_caja_de_texto)
        {
            Hide();
        }
        */
    }

    public void Show(APiece piece)
    {
        todas_las_piezas_activas();
        if (piece.is_white)
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
        this.mostrando_caja_de_texto = true;
        Time.timeScale = 0;
        this.gameObject.SetActive(true);


    }

    public void Hide()
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
