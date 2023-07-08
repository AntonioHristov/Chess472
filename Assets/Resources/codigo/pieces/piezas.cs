using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class piezas : MonoBehaviour
{
    

    public propiedades_pieza peon_blanco_1;
    public propiedades_pieza peon_blanco_2;
    public propiedades_pieza peon_blanco_3;
    public propiedades_pieza peon_blanco_4;
    public propiedades_pieza peon_blanco_5;
    public propiedades_pieza peon_blanco_6;
    public propiedades_pieza peon_blanco_7;
    public propiedades_pieza peon_blanco_8;


    public propiedades_pieza torre_blanca_1;
    public propiedades_pieza torre_blanca_2;
  

    public propiedades_pieza caballo_blanco_1;
    public propiedades_pieza caballo_blanco_2;
  

    public propiedades_pieza alfil_blanco_1;
    public propiedades_pieza alfil_blanco_2;


    public propiedades_pieza dama_blanca_1;
    public propiedades_pieza rey_blanco_1;


    public propiedades_pieza peon_negro_1;
    public propiedades_pieza peon_negro_2;
    public propiedades_pieza peon_negro_3;
    public propiedades_pieza peon_negro_4;
    public propiedades_pieza peon_negro_5;
    public propiedades_pieza peon_negro_6;
    public propiedades_pieza peon_negro_7;
    public propiedades_pieza peon_negro_8;
   

    public propiedades_pieza torre_negra_1;
    public propiedades_pieza torre_negra_2;
   

    public propiedades_pieza caballo_negro_1;
    public propiedades_pieza caballo_negro_2;
  

    public propiedades_pieza alfil_negro_1;
    public propiedades_pieza alfil_negro_2;
            

    public propiedades_pieza dama_negra_1;
    public propiedades_pieza rey_negro_1;

    public int id_vacio = 0;
    public int id_peon = 1;
    public int id_torre = 2;
    public int id_caballo = 3;
    public int id_alfil = 4;
    public int id_dama = 5;
    public int id_rey = 6;

    public bool coronado_es_blanca = true;
    public int coronado_tipo_pieza = 1;
    public propiedades_pieza peon_que_corona;


    public bool hay_una_pieza_activa = false;
    public propiedades_pieza pieza_activada;


 
    public casillas todas_las_casillas;
    public partida la_partida;

    public Sprite peon_blanco_defecto;
    public Sprite peon_negro_defecto;

    public Sprite dama_blanca_coronar;
    public Sprite dama_negra_coronar;
    public Sprite torre_blanca_coronar;
    public Sprite torre_negra_coronar;
    public Sprite caballo_blanca_coronar;
    public Sprite caballo_negra_coronar;
    public Sprite alfil_blanca_coronar;
    public Sprite alfil_negra_coronar;


    public void Awake()
    {


        

        peon_blanco_1.id_casilla_numero = todas_las_casillas.id_casilla_2;
        peon_blanco_1.id_casilla_letra = todas_las_casillas.id_casilla_a;

        peon_blanco_2.id_casilla_numero = todas_las_casillas.id_casilla_2;
        peon_blanco_2.id_casilla_letra = todas_las_casillas.id_casilla_b;

        peon_blanco_3.id_casilla_numero = todas_las_casillas.id_casilla_2;
        peon_blanco_3.id_casilla_letra = todas_las_casillas.id_casilla_c;

        peon_blanco_4.id_casilla_numero = todas_las_casillas.id_casilla_2;
        peon_blanco_4.id_casilla_letra = todas_las_casillas.id_casilla_d;

        peon_blanco_5.id_casilla_numero = todas_las_casillas.id_casilla_2;
        peon_blanco_5.id_casilla_letra = todas_las_casillas.id_casilla_e;

        peon_blanco_6.id_casilla_numero = todas_las_casillas.id_casilla_2;
        peon_blanco_6.id_casilla_letra = todas_las_casillas.id_casilla_f;

        peon_blanco_7.id_casilla_numero = todas_las_casillas.id_casilla_2;
        peon_blanco_7.id_casilla_letra = todas_las_casillas.id_casilla_g;

        peon_blanco_8.id_casilla_numero = todas_las_casillas.id_casilla_2;
        peon_blanco_8.id_casilla_letra = todas_las_casillas.id_casilla_h;

        torre_blanca_1.id_casilla_numero = todas_las_casillas.id_casilla_1;
        torre_blanca_1.id_casilla_letra = todas_las_casillas.id_casilla_a;

        torre_blanca_2.id_casilla_numero = todas_las_casillas.id_casilla_1;
        torre_blanca_2.id_casilla_letra = todas_las_casillas.id_casilla_h;

        caballo_blanco_1.id_casilla_numero = todas_las_casillas.id_casilla_1;
        caballo_blanco_1.id_casilla_letra = todas_las_casillas.id_casilla_b;

        caballo_blanco_2.id_casilla_numero = todas_las_casillas.id_casilla_1;
        caballo_blanco_2.id_casilla_letra = todas_las_casillas.id_casilla_g;

        alfil_blanco_1.id_casilla_numero = todas_las_casillas.id_casilla_1;
        alfil_blanco_1.id_casilla_letra = todas_las_casillas.id_casilla_c;

        alfil_blanco_2.id_casilla_numero = todas_las_casillas.id_casilla_1;
        alfil_blanco_2.id_casilla_letra = todas_las_casillas.id_casilla_f;

        dama_blanca_1.id_casilla_numero = todas_las_casillas.id_casilla_1;
        dama_blanca_1.id_casilla_letra = todas_las_casillas.id_casilla_d;

        rey_blanco_1.id_casilla_numero = todas_las_casillas.id_casilla_1;
        rey_blanco_1.id_casilla_letra = todas_las_casillas.id_casilla_e;




        peon_negro_1.id_casilla_numero = todas_las_casillas.id_casilla_7;
        peon_negro_1.id_casilla_letra = todas_las_casillas.id_casilla_a;
             
        peon_negro_2.id_casilla_numero = todas_las_casillas.id_casilla_7;
        peon_negro_2.id_casilla_letra = todas_las_casillas.id_casilla_b;
             
        peon_negro_3.id_casilla_numero = todas_las_casillas.id_casilla_7;
        peon_negro_3.id_casilla_letra = todas_las_casillas.id_casilla_c;
             
        peon_negro_4.id_casilla_numero = todas_las_casillas.id_casilla_7;
        peon_negro_4.id_casilla_letra = todas_las_casillas.id_casilla_d;
             
        peon_negro_5.id_casilla_numero = todas_las_casillas.id_casilla_7;
        peon_negro_5.id_casilla_letra = todas_las_casillas.id_casilla_e;
             
        peon_negro_6.id_casilla_numero = todas_las_casillas.id_casilla_7;
        peon_negro_6.id_casilla_letra = todas_las_casillas.id_casilla_f;
             
        peon_negro_7.id_casilla_numero = todas_las_casillas.id_casilla_7;
        peon_negro_7.id_casilla_letra = todas_las_casillas.id_casilla_g;
             
        peon_negro_8.id_casilla_numero = todas_las_casillas.id_casilla_7;
        peon_negro_8.id_casilla_letra = todas_las_casillas.id_casilla_h;

        torre_negra_1.id_casilla_numero = todas_las_casillas.id_casilla_8;
        torre_negra_1.id_casilla_letra = todas_las_casillas.id_casilla_a;

        torre_negra_2.id_casilla_numero = todas_las_casillas.id_casilla_8;
        torre_negra_2.id_casilla_letra = todas_las_casillas.id_casilla_h;

        caballo_negro_1.id_casilla_numero = todas_las_casillas.id_casilla_8;
        caballo_negro_1.id_casilla_letra = todas_las_casillas.id_casilla_b;

        caballo_negro_2.id_casilla_numero = todas_las_casillas.id_casilla_8;
        caballo_negro_2.id_casilla_letra = todas_las_casillas.id_casilla_g;

        alfil_negro_1.id_casilla_numero = todas_las_casillas.id_casilla_8;
        alfil_negro_1.id_casilla_letra = todas_las_casillas.id_casilla_c;

        alfil_negro_2.id_casilla_numero = todas_las_casillas.id_casilla_8;
        alfil_negro_2.id_casilla_letra = todas_las_casillas.id_casilla_f;

        dama_negra_1.id_casilla_numero = todas_las_casillas.id_casilla_8;
        dama_negra_1.id_casilla_letra = todas_las_casillas.id_casilla_d;

        rey_negro_1.id_casilla_numero = todas_las_casillas.id_casilla_8;
        rey_negro_1.id_casilla_letra = todas_las_casillas.id_casilla_e;


    }

    public void asignando_piezas_a_las_casillas_iniciales()
    {

        asignar_pieza_a_casilla(peon_blanco_1, todas_las_casillas.id_casillas
            [ todas_las_casillas.id_casilla_2 , todas_las_casillas.id_casilla_a ]);

        asignar_pieza_a_casilla(peon_blanco_2, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_2 , todas_las_casillas.id_casilla_b]);

        asignar_pieza_a_casilla(peon_blanco_3, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_2 , todas_las_casillas.id_casilla_c]);

        asignar_pieza_a_casilla(peon_blanco_4, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_2 , todas_las_casillas.id_casilla_d]);

        asignar_pieza_a_casilla(peon_blanco_5, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_2 , todas_las_casillas.id_casilla_e]);

        asignar_pieza_a_casilla(peon_blanco_6, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_2 , todas_las_casillas.id_casilla_f]);

        asignar_pieza_a_casilla(peon_blanco_7, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_2 , todas_las_casillas.id_casilla_g]);

        asignar_pieza_a_casilla(peon_blanco_8, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_2 , todas_las_casillas.id_casilla_h]);

        asignar_pieza_a_casilla(torre_blanca_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_1 , todas_las_casillas.id_casilla_a]);

        asignar_pieza_a_casilla(torre_blanca_2, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_1 , todas_las_casillas.id_casilla_h]);

        asignar_pieza_a_casilla(caballo_blanco_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_1 , todas_las_casillas.id_casilla_b]);

        asignar_pieza_a_casilla(caballo_blanco_2, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_1 , todas_las_casillas.id_casilla_g]);

        asignar_pieza_a_casilla(alfil_blanco_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_1 , todas_las_casillas.id_casilla_c]);

        asignar_pieza_a_casilla(alfil_blanco_2, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_1 , todas_las_casillas.id_casilla_f]);

        asignar_pieza_a_casilla(dama_blanca_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_1 , todas_las_casillas.id_casilla_d]);

        asignar_pieza_a_casilla(rey_blanco_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_1 , todas_las_casillas.id_casilla_e]);



        asignar_pieza_a_casilla(peon_negro_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_7 , todas_las_casillas.id_casilla_a]);

        asignar_pieza_a_casilla(peon_negro_2, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_7 , todas_las_casillas.id_casilla_b]);

        asignar_pieza_a_casilla(peon_negro_3, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_7 , todas_las_casillas.id_casilla_c]);

        asignar_pieza_a_casilla(peon_negro_4, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_7 , todas_las_casillas.id_casilla_d]);

        asignar_pieza_a_casilla(peon_negro_5, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_7 , todas_las_casillas.id_casilla_e]);

        asignar_pieza_a_casilla(peon_negro_6, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_7 , todas_las_casillas.id_casilla_f]);

        asignar_pieza_a_casilla(peon_negro_7, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_7 , todas_las_casillas.id_casilla_g]);

        asignar_pieza_a_casilla(peon_negro_8, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_7 , todas_las_casillas.id_casilla_h]);

        asignar_pieza_a_casilla(torre_negra_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_8 , todas_las_casillas.id_casilla_a]);

        asignar_pieza_a_casilla(torre_negra_2, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_8 , todas_las_casillas.id_casilla_h]);

        asignar_pieza_a_casilla(caballo_negro_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_8 , todas_las_casillas.id_casilla_b]);

        asignar_pieza_a_casilla(caballo_negro_2, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_8 , todas_las_casillas.id_casilla_g]);

        asignar_pieza_a_casilla(alfil_negro_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_8 , todas_las_casillas.id_casilla_c]);

        asignar_pieza_a_casilla(alfil_negro_2, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_8 , todas_las_casillas.id_casilla_f]);

        asignar_pieza_a_casilla(dama_negra_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_8 , todas_las_casillas.id_casilla_d]);

        asignar_pieza_a_casilla(rey_negro_1, todas_las_casillas.id_casillas
            [todas_las_casillas.id_casilla_8 , todas_las_casillas.id_casilla_e]);




    }

    public void dar_valores_por_defecto_a_las_piezas()
    {
        propiedades_por_defecto(peon_blanco_1, id_peon);
        propiedades_por_defecto(peon_blanco_2, id_peon);
        propiedades_por_defecto(peon_blanco_3, id_peon);
        propiedades_por_defecto(peon_blanco_4, id_peon);
        propiedades_por_defecto(peon_blanco_5, id_peon);
        propiedades_por_defecto(peon_blanco_6, id_peon);
        propiedades_por_defecto(peon_blanco_7, id_peon);
        propiedades_por_defecto(peon_blanco_8, id_peon);
        propiedades_por_defecto(torre_blanca_1, id_torre);
        propiedades_por_defecto(torre_blanca_2, id_torre);
        propiedades_por_defecto(caballo_blanco_1, id_caballo);
        propiedades_por_defecto(caballo_blanco_2, id_caballo);
        propiedades_por_defecto(alfil_blanco_1, id_alfil);
        propiedades_por_defecto(alfil_blanco_2, id_alfil);
        propiedades_por_defecto(dama_blanca_1, id_dama);
        propiedades_por_defecto(rey_blanco_1, id_rey);

        propiedades_por_defecto(peon_negro_1, id_peon);
        propiedades_por_defecto(peon_negro_2, id_peon);
        propiedades_por_defecto(peon_negro_3, id_peon);
        propiedades_por_defecto(peon_negro_4, id_peon);
        propiedades_por_defecto(peon_negro_5, id_peon);
        propiedades_por_defecto(peon_negro_6, id_peon);
        propiedades_por_defecto(peon_negro_7, id_peon);
        propiedades_por_defecto(peon_negro_8, id_peon);
        propiedades_por_defecto(torre_negra_1, id_torre);
        propiedades_por_defecto(torre_negra_2, id_torre);
        propiedades_por_defecto(caballo_negro_1, id_caballo);
        propiedades_por_defecto(caballo_negro_2, id_caballo);
        propiedades_por_defecto(alfil_negro_1, id_alfil);
        propiedades_por_defecto(alfil_negro_2, id_alfil);
        propiedades_por_defecto(dama_negra_1, id_dama);
        propiedades_por_defecto(rey_negro_1, id_rey);
    }


    public void asignar_pieza_a_casilla(propiedades_pieza pieza, propiedades_casilla casilla)
    {
       
        dime_pieza_y_te_digo_en_que_casilla_esta(pieza).ocupado = todas_las_casillas.id_no_ocupado;

        pieza.id_casilla_numero = casilla.id_casilla_numero;
        pieza.id_casilla_letra = casilla.id_casilla_letra;

        

        //todas_las_casillas.id_casillas[pieza.id_casilla_numero, pieza.id_casilla_letra].pieza_que_la_ocupa=null;

        if(casilla.ocupado!= todas_las_casillas.id_no_ocupado)
        {
            //Destroy(casilla.pieza_que_la_ocupa.gameObject);
            casilla.pieza_que_la_ocupa.esta_pieza_es_comida();

        }
        


        casilla.pieza_que_la_ocupa = pieza;
        

        if (pieza.es_blanca)
        {
            casilla.ocupado = todas_las_casillas.id_ocupado_blancas;
        }
        else
        {
            casilla.ocupado = todas_las_casillas.id_ocupado_negras;
        }

        


        pieza.transform.position = casilla.transform.position;

        //if (casilla.id_casilla_numero == 0 && casilla.id_casilla_letra == 0)
        //{
        //    Debug.Log(todas_las_casillas.id_casillas[0, 0].ocupado);
        //}

       
    }

    public void propiedades_por_defecto(propiedades_pieza pieza, int id_tipo_pieza)
    {
        pieza.no_se_ha_movido = true;
        pieza.victima_de_comida_al_paso = false;
        pieza.id_tipo_pieza = id_tipo_pieza;
        pieza.fue_comida = false;
        if(id_tipo_pieza==id_peon)
        {
            if(pieza.es_blanca)
            {
                pieza.GetComponent<Image>().sprite = peon_blanco_defecto;
            }
            else
            {
                pieza.GetComponent<Image>().sprite = peon_negro_defecto;
            }
            
        }
    }

    public propiedades_casilla dime_pieza_y_te_digo_en_que_casilla_esta(propiedades_pieza pieza)
    {
        return todas_las_casillas.id_casillas[pieza.id_casilla_numero, pieza.id_casilla_letra];
    }

    public void actualizar_valor_cliqueable_y_girar_piezas()
    {
        if(la_partida.turno_blancas)
        {
            
                peon_blanco_1.GetComponent<Image>().raycastTarget = true;
                peon_blanco_1.transform.eulerAngles = new Vector3(0,0,0);
           
                peon_blanco_2.GetComponent<Image>().raycastTarget = true;
                peon_blanco_2.transform.eulerAngles = new Vector3(0, 0, 0);
         
                peon_blanco_3.GetComponent<Image>().raycastTarget = true;
                peon_blanco_3.transform.eulerAngles = new Vector3(0, 0, 0);

                peon_blanco_4.GetComponent<Image>().raycastTarget = true;
                peon_blanco_4.transform.eulerAngles = new Vector3(0, 0, 0);
            
                peon_blanco_5.GetComponent<Image>().raycastTarget = true;
                peon_blanco_5.transform.eulerAngles = new Vector3(0, 0, 0);
            
                peon_blanco_6.GetComponent<Image>().raycastTarget = true;
                peon_blanco_6.transform.eulerAngles = new Vector3(0, 0, 0);
            
                peon_blanco_7.GetComponent<Image>().raycastTarget = true;
                peon_blanco_7.transform.eulerAngles = new Vector3(0, 0, 0);

                peon_blanco_8.GetComponent<Image>().raycastTarget = true;
                peon_blanco_8.transform.eulerAngles = new Vector3(0, 0, 0);

                torre_blanca_1.GetComponent<Image>().raycastTarget = true;
                torre_blanca_1.transform.eulerAngles = new Vector3(0, 0, 0);
           
                torre_blanca_2.GetComponent<Image>().raycastTarget = true;
                torre_blanca_2.transform.eulerAngles = new Vector3(0, 0, 0);

                caballo_blanco_1.GetComponent<Image>().raycastTarget = true;
                caballo_blanco_1.transform.eulerAngles = new Vector3(0, 0, 0);
            
                caballo_blanco_2.GetComponent<Image>().raycastTarget = true;
                caballo_blanco_2.transform.eulerAngles = new Vector3(0, 0, 0);
            
                alfil_blanco_1.GetComponent<Image>().raycastTarget = true;
                alfil_blanco_1.transform.eulerAngles = new Vector3(0, 0, 0);
            
                alfil_blanco_2.GetComponent<Image>().raycastTarget = true;
                alfil_blanco_2.transform.eulerAngles = new Vector3(0, 0, 0);
           
                dama_blanca_1.GetComponent<Image>().raycastTarget = true;
                dama_blanca_1.transform.eulerAngles = new Vector3(0, 0, 0);
          
                rey_blanco_1.GetComponent<Image>().raycastTarget = true;
                rey_blanco_1.transform.eulerAngles = new Vector3(0, 0, 0);
        
                peon_negro_1.GetComponent<Image>().raycastTarget = false;
                peon_negro_1.transform.eulerAngles = new Vector3(0, 0, 0);
            
                peon_negro_2.GetComponent<Image>().raycastTarget = false;
                peon_negro_2.transform.eulerAngles = new Vector3(0, 0, 0);
            
                peon_negro_3.GetComponent<Image>().raycastTarget = false;
                peon_negro_3.transform.eulerAngles = new Vector3(0, 0, 0);
           
                peon_negro_4.GetComponent<Image>().raycastTarget = false;
                peon_negro_4.transform.eulerAngles = new Vector3(0, 0, 0);
            
                peon_negro_5.GetComponent<Image>().raycastTarget = false;
                peon_negro_5.transform.eulerAngles = new Vector3(0, 0, 0);
            
                peon_negro_6.GetComponent<Image>().raycastTarget = false;
                peon_negro_6.transform.eulerAngles = new Vector3(0, 0, 0);
           
                peon_negro_7.GetComponent<Image>().raycastTarget = false;
                peon_negro_7.transform.eulerAngles = new Vector3(0, 0, 0);

                peon_negro_8.GetComponent<Image>().raycastTarget = false;
                peon_negro_8.transform.eulerAngles = new Vector3(0, 0, 0);
           
                torre_negra_1.GetComponent<Image>().raycastTarget = false;
                torre_negra_1.transform.eulerAngles = new Vector3(0, 0, 0);
           
                torre_negra_2.GetComponent<Image>().raycastTarget = false;
                torre_negra_2.transform.eulerAngles = new Vector3(0, 0, 0);
            
                caballo_negro_1.GetComponent<Image>().raycastTarget = false;
                caballo_negro_1.transform.eulerAngles = new Vector3(0, 0, 0);
            
                caballo_negro_2.GetComponent<Image>().raycastTarget = false;
                caballo_negro_2.transform.eulerAngles = new Vector3(0, 0, 0);
            
                alfil_negro_1.GetComponent<Image>().raycastTarget = false;
                alfil_negro_1.transform.eulerAngles = new Vector3(0, 0, 0);
            
                alfil_negro_2.GetComponent<Image>().raycastTarget = false;
                alfil_negro_2.transform.eulerAngles = new Vector3(0, 0, 0);

                dama_negra_1.GetComponent<Image>().raycastTarget = false;
                dama_negra_1.transform.eulerAngles = new Vector3(0, 0, 0);
            
                rey_negro_1.GetComponent<Image>().raycastTarget = false;
                rey_negro_1.transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        else
        {
            
                peon_blanco_1.GetComponent<Image>().raycastTarget = false;
                peon_blanco_1.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_blanco_2.GetComponent<Image>().raycastTarget = false;
                peon_blanco_2.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_blanco_3.GetComponent<Image>().raycastTarget = false;
                peon_blanco_3.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_blanco_4.GetComponent<Image>().raycastTarget = false;
                peon_blanco_4.transform.eulerAngles = new Vector3(180, 180, 180);
           
                peon_blanco_5.GetComponent<Image>().raycastTarget = false;
                peon_blanco_5.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_blanco_6.GetComponent<Image>().raycastTarget = false;
                peon_blanco_6.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_blanco_7.GetComponent<Image>().raycastTarget = false;
                peon_blanco_7.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_blanco_8.GetComponent<Image>().raycastTarget = false;
                peon_blanco_8.transform.eulerAngles = new Vector3(180, 180, 180);
            
                torre_blanca_1.GetComponent<Image>().raycastTarget = false;
                torre_blanca_1.transform.eulerAngles = new Vector3(180, 180, 180);
                           
                torre_blanca_2.GetComponent<Image>().raycastTarget = false;
                torre_blanca_2.transform.eulerAngles = new Vector3(180, 180, 180);
           
                caballo_blanco_1.GetComponent<Image>().raycastTarget = false;
                caballo_blanco_1.transform.eulerAngles = new Vector3(180, 180, 180);
            
                caballo_blanco_2.GetComponent<Image>().raycastTarget = false;
                caballo_blanco_2.transform.eulerAngles = new Vector3(180, 180, 180);
            
                alfil_blanco_1.GetComponent<Image>().raycastTarget = false;
                alfil_blanco_1.transform.eulerAngles = new Vector3(180, 180, 180);
           
                alfil_blanco_2.GetComponent<Image>().raycastTarget = false;
                alfil_blanco_2.transform.eulerAngles = new Vector3(180, 180, 180);
           
                dama_blanca_1.GetComponent<Image>().raycastTarget = false;
                dama_blanca_1.transform.eulerAngles = new Vector3(180, 180, 180);
            
                rey_blanco_1.GetComponent<Image>().raycastTarget = false;
                rey_blanco_1.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_negro_1.GetComponent<Image>().raycastTarget = true;
                peon_negro_1.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_negro_2.GetComponent<Image>().raycastTarget = true;
                peon_negro_2.transform.eulerAngles = new Vector3(180, 180, 180);
           
                peon_negro_3.GetComponent<Image>().raycastTarget = true;
                peon_negro_3.transform.eulerAngles = new Vector3(180, 180, 180);
           
                peon_negro_4.GetComponent<Image>().raycastTarget = true;
                peon_negro_4.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_negro_5.GetComponent<Image>().raycastTarget = true;
                peon_negro_5.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_negro_6.GetComponent<Image>().raycastTarget = true;
                peon_negro_6.transform.eulerAngles = new Vector3(180, 180, 180);
          
                peon_negro_7.GetComponent<Image>().raycastTarget = true;
                peon_negro_7.transform.eulerAngles = new Vector3(180, 180, 180);
            
                peon_negro_8.GetComponent<Image>().raycastTarget = true;
                peon_negro_8.transform.eulerAngles = new Vector3(180, 180, 180);
            
                torre_negra_1.GetComponent<Image>().raycastTarget = true;
                torre_negra_1.transform.eulerAngles = new Vector3(180, 180, 180);
                          
                torre_negra_2.GetComponent<Image>().raycastTarget = true;
                torre_negra_2.transform.eulerAngles = new Vector3(180, 180, 180);
            
                caballo_negro_1.GetComponent<Image>().raycastTarget = true;
                caballo_negro_1.transform.eulerAngles = new Vector3(180, 180, 180);
            
                caballo_negro_2.GetComponent<Image>().raycastTarget = true;
                caballo_negro_2.transform.eulerAngles = new Vector3(180, 180, 180);
            
                alfil_negro_1.GetComponent<Image>().raycastTarget = true;
                alfil_negro_1.transform.eulerAngles = new Vector3(180, 180, 180);
            
                alfil_negro_2.GetComponent<Image>().raycastTarget = true;
                alfil_negro_2.transform.eulerAngles = new Vector3(180, 180, 180);
          
                dama_negra_1.GetComponent<Image>().raycastTarget = true;
                dama_negra_1.transform.eulerAngles = new Vector3(180, 180, 180);
           
                rey_negro_1.GetComponent<Image>().raycastTarget = true;
                rey_negro_1.transform.eulerAngles = new Vector3(180, 180, 180);
            
        }
    }

    public void desactivar_pieza_activa_y_movimientos_posibles()
    {
        if(hay_una_pieza_activa)
        {
            if (pieza_activada.es_blanca)
            {
                // SI ENTRA ES PORQUE LA PIEZA QUE EL USUARIO HABÍA DECIDIDO MOVER ES UN PEÓN BLANCO
                if (pieza_activada.id_tipo_pieza == id_peon)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_peon_blanco();

                }
                else if (pieza_activada.id_tipo_pieza == id_torre)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_torre_blanco();
                }
                else if (pieza_activada.id_tipo_pieza == id_caballo)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_caballo_blanco();
                }
                else if (pieza_activada.id_tipo_pieza == id_alfil)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_alfil_blanco();
                }
                else if (pieza_activada.id_tipo_pieza == id_dama)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_dama_blanca();
                }
                else
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                                            (
                                            todas_las_casillas.id_casillas
                                            [
                                                pieza_activada.id_casilla_numero
                                                ,
                                                pieza_activada.id_casilla_letra
                                            ]
                                            ).es_rey_blanco();
                }
            }
            else
            {
                if (pieza_activada.id_tipo_pieza == id_peon)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_peon_negro();
                }
                else if (pieza_activada.id_tipo_pieza == id_torre)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_torre_negro();
                }
                else if (pieza_activada.id_tipo_pieza == id_caballo)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_caballo_negro();
                }
                else if (pieza_activada.id_tipo_pieza == id_alfil)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_alfil_negro();
                }
                else if (pieza_activada.id_tipo_pieza == id_dama)
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas
                        [
                            pieza_activada.id_casilla_numero
                            ,
                            pieza_activada.id_casilla_letra
                        ]
                        ).es_dama_negra();
                }
                else
                {
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                                            (
                                            todas_las_casillas.id_casillas
                                            [
                                                pieza_activada.id_casilla_numero
                                                ,
                                                pieza_activada.id_casilla_letra
                                            ]
                                            ).es_rey_negro();
                }
            }
        }
       
    }

    public void desactivar_comida_al_paso_todos_los_peones_del_color_especificado(bool turno_blancas)
    {
        if(turno_blancas)
        {
            peon_blanco_1.victima_de_comida_al_paso = false;
            peon_blanco_2.victima_de_comida_al_paso = false;
            peon_blanco_3.victima_de_comida_al_paso = false;
            peon_blanco_4.victima_de_comida_al_paso = false;
            peon_blanco_5.victima_de_comida_al_paso = false;
            peon_blanco_6.victima_de_comida_al_paso = false;
            peon_blanco_7.victima_de_comida_al_paso = false;
            peon_blanco_8.victima_de_comida_al_paso = false;
        }
        else
        {
            peon_negro_1.victima_de_comida_al_paso = false;
            peon_negro_2.victima_de_comida_al_paso = false;
            peon_negro_3.victima_de_comida_al_paso = false;
            peon_negro_4.victima_de_comida_al_paso = false;
            peon_negro_5.victima_de_comida_al_paso = false;
            peon_negro_6.victima_de_comida_al_paso = false;
            peon_negro_7.victima_de_comida_al_paso = false;
            peon_negro_8.victima_de_comida_al_paso = false;
        }
    }


    public void coronar_peon()
    {
        if(coronado_es_blanca)
        {
            if (coronado_tipo_pieza == id_dama)
            {
                peon_que_corona.GetComponent<Image>().sprite = dama_blanca_coronar;
                peon_que_corona.id_tipo_pieza = id_dama;
            }
            else
            if (coronado_tipo_pieza==id_torre)
            {
                peon_que_corona.GetComponent<Image>().sprite = torre_blanca_coronar;
                peon_que_corona.id_tipo_pieza = id_torre;
            }
            else
            if (coronado_tipo_pieza == id_caballo)
            {
                peon_que_corona.GetComponent<Image>().sprite = caballo_blanca_coronar;
                peon_que_corona.id_tipo_pieza = id_caballo;
            }
            else
            {
                peon_que_corona.GetComponent<Image>().sprite = alfil_blanca_coronar;
                peon_que_corona.id_tipo_pieza = id_alfil;
            }
 
        }
        else
        {
            if (coronado_tipo_pieza == id_dama)
            {
                peon_que_corona.GetComponent<Image>().sprite = dama_negra_coronar;
                peon_que_corona.id_tipo_pieza = id_dama;
            }
            else
            if (coronado_tipo_pieza == id_torre)
            {
                peon_que_corona.GetComponent<Image>().sprite = torre_negra_coronar;
                peon_que_corona.id_tipo_pieza = id_torre;
            }
            else
            if (coronado_tipo_pieza == id_caballo)
            {
                peon_que_corona.GetComponent<Image>().sprite = caballo_negra_coronar;
                peon_que_corona.id_tipo_pieza = id_caballo;
            }
            else
            {
                peon_que_corona.GetComponent<Image>().sprite = alfil_negra_coronar;
                peon_que_corona.id_tipo_pieza = id_alfil;
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
