using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class casillas : MonoBehaviour
{
  

    public GameObject obj_a1_casilla;
    public GameObject obj_b1_casilla;
    public GameObject obj_c1_casilla;
    public GameObject obj_d1_casilla;
    public GameObject obj_e1_casilla;
    public GameObject obj_f1_casilla;
    public GameObject obj_g1_casilla;
    public GameObject obj_h1_casilla;
                      
    public GameObject obj_a2_casilla;
    public GameObject obj_b2_casilla;
    public GameObject obj_c2_casilla;
    public GameObject obj_d2_casilla;
    public GameObject obj_e2_casilla;
    public GameObject obj_f2_casilla;
    public GameObject obj_g2_casilla;
    public GameObject obj_h2_casilla;
                      
    public GameObject obj_a3_casilla;
    public GameObject obj_b3_casilla;
    public GameObject obj_c3_casilla;
    public GameObject obj_d3_casilla;
    public GameObject obj_e3_casilla;
    public GameObject obj_f3_casilla;
    public GameObject obj_g3_casilla;
    public GameObject obj_h3_casilla;
                      
    public GameObject obj_a4_casilla;
    public GameObject obj_b4_casilla;
    public GameObject obj_c4_casilla;
    public GameObject obj_d4_casilla;
    public GameObject obj_e4_casilla;
    public GameObject obj_f4_casilla;
    public GameObject obj_g4_casilla;
    public GameObject obj_h4_casilla;
                      
    public GameObject obj_a5_casilla;
    public GameObject obj_b5_casilla;
    public GameObject obj_c5_casilla;
    public GameObject obj_d5_casilla;
    public GameObject obj_e5_casilla;
    public GameObject obj_f5_casilla;
    public GameObject obj_g5_casilla;
    public GameObject obj_h5_casilla;
                      
    public GameObject obj_a6_casilla;
    public GameObject obj_b6_casilla;
    public GameObject obj_c6_casilla;
    public GameObject obj_d6_casilla;
    public GameObject obj_e6_casilla;
    public GameObject obj_f6_casilla;
    public GameObject obj_g6_casilla;
    public GameObject obj_h6_casilla;
                      
    public GameObject obj_a7_casilla;
    public GameObject obj_b7_casilla;
    public GameObject obj_c7_casilla;
    public GameObject obj_d7_casilla;
    public GameObject obj_e7_casilla;
    public GameObject obj_f7_casilla;
    public GameObject obj_g7_casilla;
    public GameObject obj_h7_casilla;
                      
    public GameObject obj_a8_casilla;
    public GameObject obj_b8_casilla;
    public GameObject obj_c8_casilla;
    public GameObject obj_d8_casilla;
    public GameObject obj_e8_casilla;
    public GameObject obj_f8_casilla;
    public GameObject obj_g8_casilla;
    public GameObject obj_h8_casilla;


    public piezas las_piezas;
    public partida la_partida;

    public propiedades_casilla[,] id_casillas = new propiedades_casilla[8,8];


    public int id_casilla_a = 0;
    public int id_casilla_b = 1;
    public int id_casilla_c = 2;
    public int id_casilla_d = 3;
    public int id_casilla_e = 4;
    public int id_casilla_f = 5;
    public int id_casilla_g = 6;
    public int id_casilla_h = 7;

    public int id_casilla_1 = 0;
    public int id_casilla_2 = 1;
    public int id_casilla_3 = 2;
    public int id_casilla_4 = 3;
    public int id_casilla_5 = 4;
    public int id_casilla_6 = 5;
    public int id_casilla_7 = 6;
    public int id_casilla_8 = 7;

    public int id_no_ocupado = 0;
    public int id_ocupado_blancas = 1;
    public int id_ocupado_negras = 2;

    //public propiedades_casilla casilla_jaque_a_blancas;
    //public propiedades_casilla casilla_jaque_a_negras;



    private void Awake()
    {
        id_casillas[id_casilla_1 , id_casilla_a] = obj_a1_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_1 , id_casilla_b] = obj_b1_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_1 , id_casilla_c] = obj_c1_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_1 , id_casilla_d] = obj_d1_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_1 , id_casilla_e] = obj_e1_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_1 , id_casilla_f] = obj_f1_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_1 , id_casilla_g] = obj_g1_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_1 , id_casilla_h] = obj_h1_casilla.GetComponent<propiedades_casilla>();
                                 
        id_casillas[id_casilla_2 , id_casilla_a] = obj_a2_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_2 , id_casilla_b] = obj_b2_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_2 , id_casilla_c] = obj_c2_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_2 , id_casilla_d] = obj_d2_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_2 , id_casilla_e] = obj_e2_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_2 , id_casilla_f] = obj_f2_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_2 , id_casilla_g] = obj_g2_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_2 , id_casilla_h] = obj_h2_casilla.GetComponent<propiedades_casilla>();
                                  
        id_casillas[id_casilla_3 , id_casilla_a] = obj_a3_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_3 , id_casilla_b] = obj_b3_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_3 , id_casilla_c] = obj_c3_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_3 , id_casilla_d] = obj_d3_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_3 , id_casilla_e] = obj_e3_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_3 , id_casilla_f] = obj_f3_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_3 , id_casilla_g] = obj_g3_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_3 , id_casilla_h] = obj_h3_casilla.GetComponent<propiedades_casilla>();
                                 
        id_casillas[id_casilla_4 , id_casilla_a] = obj_a4_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_4 , id_casilla_b] = obj_b4_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_4 , id_casilla_c] = obj_c4_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_4 , id_casilla_d] = obj_d4_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_4 , id_casilla_e] = obj_e4_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_4 , id_casilla_f] = obj_f4_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_4 , id_casilla_g] = obj_g4_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_4 , id_casilla_h] = obj_h4_casilla.GetComponent<propiedades_casilla>();
                                 
        id_casillas[id_casilla_5 , id_casilla_a] = obj_a5_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_5 , id_casilla_b] = obj_b5_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_5 , id_casilla_c] = obj_c5_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_5 , id_casilla_d] = obj_d5_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_5 , id_casilla_e] = obj_e5_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_5 , id_casilla_f] = obj_f5_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_5 , id_casilla_g] = obj_g5_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_5 , id_casilla_h] = obj_h5_casilla.GetComponent<propiedades_casilla>();
                                 
        id_casillas[id_casilla_6 , id_casilla_a] = obj_a6_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_6 , id_casilla_b] = obj_b6_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_6 , id_casilla_c] = obj_c6_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_6 , id_casilla_d] = obj_d6_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_6 , id_casilla_e] = obj_e6_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_6 , id_casilla_f] = obj_f6_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_6 , id_casilla_g] = obj_g6_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_6 , id_casilla_h] = obj_h6_casilla.GetComponent<propiedades_casilla>();
                                  
        id_casillas[id_casilla_7 , id_casilla_a] = obj_a7_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_7 , id_casilla_b] = obj_b7_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_7 , id_casilla_c] = obj_c7_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_7 , id_casilla_d] = obj_d7_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_7 , id_casilla_e] = obj_e7_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_7 , id_casilla_f] = obj_f7_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_7 , id_casilla_g] = obj_g7_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_7 , id_casilla_h] = obj_h7_casilla.GetComponent<propiedades_casilla>();
                                 
        id_casillas[id_casilla_8 , id_casilla_a] = obj_a8_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_8 , id_casilla_b] = obj_b8_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_8 , id_casilla_c] = obj_c8_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_8 , id_casilla_d] = obj_d8_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_8 , id_casilla_e] = obj_e8_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_8 , id_casilla_f] = obj_f8_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_8 , id_casilla_g] = obj_g8_casilla.GetComponent<propiedades_casilla>();
        id_casillas[id_casilla_8 , id_casilla_h] = obj_h8_casilla.GetComponent<propiedades_casilla>();

        id_casillas[id_casilla_1, id_casilla_a].id_casilla_numero = id_casilla_1;
        id_casillas[id_casilla_1, id_casilla_a].id_casilla_letra = id_casilla_a;

        id_casillas[id_casilla_1, id_casilla_b].id_casilla_numero = id_casilla_1;
        id_casillas[id_casilla_1, id_casilla_b].id_casilla_letra = id_casilla_b;

        id_casillas[id_casilla_1, id_casilla_c].id_casilla_numero = id_casilla_1;
        id_casillas[id_casilla_1, id_casilla_c].id_casilla_letra = id_casilla_c;

        id_casillas[id_casilla_1, id_casilla_d].id_casilla_numero = id_casilla_1;
        id_casillas[id_casilla_1, id_casilla_d].id_casilla_letra = id_casilla_d;

        id_casillas[id_casilla_1, id_casilla_e].id_casilla_numero = id_casilla_1;
        id_casillas[id_casilla_1, id_casilla_e].id_casilla_letra = id_casilla_e;

        id_casillas[id_casilla_1, id_casilla_f].id_casilla_numero = id_casilla_1;
        id_casillas[id_casilla_1, id_casilla_f].id_casilla_letra = id_casilla_f;

        id_casillas[id_casilla_1, id_casilla_g].id_casilla_numero = id_casilla_1;
        id_casillas[id_casilla_1, id_casilla_g].id_casilla_letra = id_casilla_g;

        id_casillas[id_casilla_1, id_casilla_h].id_casilla_numero = id_casilla_1;
        id_casillas[id_casilla_1, id_casilla_h].id_casilla_letra = id_casilla_h;



        id_casillas[id_casilla_2, id_casilla_a].id_casilla_numero = id_casilla_2;
        id_casillas[id_casilla_2, id_casilla_a].id_casilla_letra = id_casilla_a;

        id_casillas[id_casilla_2, id_casilla_b].id_casilla_numero = id_casilla_2;
        id_casillas[id_casilla_2, id_casilla_b].id_casilla_letra = id_casilla_b;

        id_casillas[id_casilla_2, id_casilla_c].id_casilla_numero = id_casilla_2;
        id_casillas[id_casilla_2, id_casilla_c].id_casilla_letra = id_casilla_c;

        id_casillas[id_casilla_2, id_casilla_d].id_casilla_numero = id_casilla_2;
        id_casillas[id_casilla_2, id_casilla_d].id_casilla_letra = id_casilla_d;

        id_casillas[id_casilla_2, id_casilla_e].id_casilla_numero = id_casilla_2;
        id_casillas[id_casilla_2, id_casilla_e].id_casilla_letra = id_casilla_e;

        id_casillas[id_casilla_2, id_casilla_f].id_casilla_numero = id_casilla_2;
        id_casillas[id_casilla_2, id_casilla_f].id_casilla_letra = id_casilla_f;

        id_casillas[id_casilla_2, id_casilla_g].id_casilla_numero = id_casilla_2;
        id_casillas[id_casilla_2, id_casilla_g].id_casilla_letra = id_casilla_g;

        id_casillas[id_casilla_2, id_casilla_h].id_casilla_numero = id_casilla_2;
        id_casillas[id_casilla_2, id_casilla_h].id_casilla_letra = id_casilla_h;



        id_casillas[id_casilla_3, id_casilla_a].id_casilla_numero = id_casilla_3;
        id_casillas[id_casilla_3, id_casilla_a].id_casilla_letra = id_casilla_a;

        id_casillas[id_casilla_3, id_casilla_b].id_casilla_numero = id_casilla_3;
        id_casillas[id_casilla_3, id_casilla_b].id_casilla_letra = id_casilla_b;

        id_casillas[id_casilla_3, id_casilla_c].id_casilla_numero = id_casilla_3;
        id_casillas[id_casilla_3, id_casilla_c].id_casilla_letra = id_casilla_c;

        id_casillas[id_casilla_3, id_casilla_d].id_casilla_numero = id_casilla_3;
        id_casillas[id_casilla_3, id_casilla_d].id_casilla_letra = id_casilla_d;

        id_casillas[id_casilla_3, id_casilla_e].id_casilla_numero = id_casilla_3;
        id_casillas[id_casilla_3, id_casilla_e].id_casilla_letra = id_casilla_e;

        id_casillas[id_casilla_3, id_casilla_f].id_casilla_numero = id_casilla_3;
        id_casillas[id_casilla_3, id_casilla_f].id_casilla_letra = id_casilla_f;

        id_casillas[id_casilla_3, id_casilla_g].id_casilla_numero = id_casilla_3;
        id_casillas[id_casilla_3, id_casilla_g].id_casilla_letra = id_casilla_g;

        id_casillas[id_casilla_3, id_casilla_h].id_casilla_numero = id_casilla_3;
        id_casillas[id_casilla_3, id_casilla_h].id_casilla_letra = id_casilla_h;



        id_casillas[id_casilla_4, id_casilla_a].id_casilla_numero = id_casilla_4;
        id_casillas[id_casilla_4, id_casilla_a].id_casilla_letra = id_casilla_a;

        id_casillas[id_casilla_4, id_casilla_b].id_casilla_numero = id_casilla_4;
        id_casillas[id_casilla_4, id_casilla_b].id_casilla_letra = id_casilla_b;

        id_casillas[id_casilla_4, id_casilla_c].id_casilla_numero = id_casilla_4;
        id_casillas[id_casilla_4, id_casilla_c].id_casilla_letra = id_casilla_c;

        id_casillas[id_casilla_4, id_casilla_d].id_casilla_numero = id_casilla_4;
        id_casillas[id_casilla_4, id_casilla_d].id_casilla_letra = id_casilla_d;

        id_casillas[id_casilla_4, id_casilla_e].id_casilla_numero = id_casilla_4;
        id_casillas[id_casilla_4, id_casilla_e].id_casilla_letra = id_casilla_e;

        id_casillas[id_casilla_4, id_casilla_f].id_casilla_numero = id_casilla_4;
        id_casillas[id_casilla_4, id_casilla_f].id_casilla_letra = id_casilla_f;

        id_casillas[id_casilla_4, id_casilla_g].id_casilla_numero = id_casilla_4;
        id_casillas[id_casilla_4, id_casilla_g].id_casilla_letra = id_casilla_g;

        id_casillas[id_casilla_4, id_casilla_h].id_casilla_numero = id_casilla_4;
        id_casillas[id_casilla_4, id_casilla_h].id_casilla_letra = id_casilla_h;



        id_casillas[id_casilla_5, id_casilla_a].id_casilla_numero = id_casilla_5;
        id_casillas[id_casilla_5, id_casilla_a].id_casilla_letra = id_casilla_a;

        id_casillas[id_casilla_5, id_casilla_b].id_casilla_numero = id_casilla_5;
        id_casillas[id_casilla_5, id_casilla_b].id_casilla_letra = id_casilla_b;

        id_casillas[id_casilla_5, id_casilla_c].id_casilla_numero = id_casilla_5;
        id_casillas[id_casilla_5, id_casilla_c].id_casilla_letra = id_casilla_c;

        id_casillas[id_casilla_5, id_casilla_d].id_casilla_numero = id_casilla_5;
        id_casillas[id_casilla_5, id_casilla_d].id_casilla_letra = id_casilla_d;

        id_casillas[id_casilla_5, id_casilla_e].id_casilla_numero = id_casilla_5;
        id_casillas[id_casilla_5, id_casilla_e].id_casilla_letra = id_casilla_e;

        id_casillas[id_casilla_5, id_casilla_f].id_casilla_numero = id_casilla_5;
        id_casillas[id_casilla_5, id_casilla_f].id_casilla_letra = id_casilla_f;

        id_casillas[id_casilla_5, id_casilla_g].id_casilla_numero = id_casilla_5;
        id_casillas[id_casilla_5, id_casilla_g].id_casilla_letra = id_casilla_g;

        id_casillas[id_casilla_5, id_casilla_h].id_casilla_numero = id_casilla_5;
        id_casillas[id_casilla_5, id_casilla_h].id_casilla_letra = id_casilla_h;



        id_casillas[id_casilla_6, id_casilla_a].id_casilla_numero = id_casilla_6;
        id_casillas[id_casilla_6, id_casilla_a].id_casilla_letra = id_casilla_a;

        id_casillas[id_casilla_6, id_casilla_b].id_casilla_numero = id_casilla_6;
        id_casillas[id_casilla_6, id_casilla_b].id_casilla_letra = id_casilla_b;

        id_casillas[id_casilla_6, id_casilla_c].id_casilla_numero = id_casilla_6;
        id_casillas[id_casilla_6, id_casilla_c].id_casilla_letra = id_casilla_c;

        id_casillas[id_casilla_6, id_casilla_d].id_casilla_numero = id_casilla_6;
        id_casillas[id_casilla_6, id_casilla_d].id_casilla_letra = id_casilla_d;

        id_casillas[id_casilla_6, id_casilla_e].id_casilla_numero = id_casilla_6;
        id_casillas[id_casilla_6, id_casilla_e].id_casilla_letra = id_casilla_e;

        id_casillas[id_casilla_6, id_casilla_f].id_casilla_numero = id_casilla_6;
        id_casillas[id_casilla_6, id_casilla_f].id_casilla_letra = id_casilla_f;

        id_casillas[id_casilla_6, id_casilla_g].id_casilla_numero = id_casilla_6;
        id_casillas[id_casilla_6, id_casilla_g].id_casilla_letra = id_casilla_g;

        id_casillas[id_casilla_6, id_casilla_h].id_casilla_numero = id_casilla_6;
        id_casillas[id_casilla_6, id_casilla_h].id_casilla_letra = id_casilla_h;



        id_casillas[id_casilla_7, id_casilla_a].id_casilla_numero = id_casilla_7;
        id_casillas[id_casilla_7, id_casilla_a].id_casilla_letra = id_casilla_a;

        id_casillas[id_casilla_7, id_casilla_b].id_casilla_numero = id_casilla_7;
        id_casillas[id_casilla_7, id_casilla_b].id_casilla_letra = id_casilla_b;

        id_casillas[id_casilla_7, id_casilla_c].id_casilla_numero = id_casilla_7;
        id_casillas[id_casilla_7, id_casilla_c].id_casilla_letra = id_casilla_c;

        id_casillas[id_casilla_7, id_casilla_d].id_casilla_numero = id_casilla_7;
        id_casillas[id_casilla_7, id_casilla_d].id_casilla_letra = id_casilla_d;

        id_casillas[id_casilla_7, id_casilla_e].id_casilla_numero = id_casilla_7;
        id_casillas[id_casilla_7, id_casilla_e].id_casilla_letra = id_casilla_e;

        id_casillas[id_casilla_7, id_casilla_f].id_casilla_numero = id_casilla_7;
        id_casillas[id_casilla_7, id_casilla_f].id_casilla_letra = id_casilla_f;

        id_casillas[id_casilla_7, id_casilla_g].id_casilla_numero = id_casilla_7;
        id_casillas[id_casilla_7, id_casilla_g].id_casilla_letra = id_casilla_g;

        id_casillas[id_casilla_7, id_casilla_h].id_casilla_numero = id_casilla_7;
        id_casillas[id_casilla_7, id_casilla_h].id_casilla_letra = id_casilla_h;



        id_casillas[id_casilla_8, id_casilla_a].id_casilla_numero = id_casilla_8;
        id_casillas[id_casilla_8, id_casilla_a].id_casilla_letra = id_casilla_a;

        id_casillas[id_casilla_8, id_casilla_b].id_casilla_numero = id_casilla_8;
        id_casillas[id_casilla_8, id_casilla_b].id_casilla_letra = id_casilla_b;

        id_casillas[id_casilla_8, id_casilla_c].id_casilla_numero = id_casilla_8;
        id_casillas[id_casilla_8, id_casilla_c].id_casilla_letra = id_casilla_c;

        id_casillas[id_casilla_8, id_casilla_d].id_casilla_numero = id_casilla_8;
        id_casillas[id_casilla_8, id_casilla_d].id_casilla_letra = id_casilla_d;

        id_casillas[id_casilla_8, id_casilla_e].id_casilla_numero = id_casilla_8;
        id_casillas[id_casilla_8, id_casilla_e].id_casilla_letra = id_casilla_e;

        id_casillas[id_casilla_8, id_casilla_f].id_casilla_numero = id_casilla_8;
        id_casillas[id_casilla_8, id_casilla_f].id_casilla_letra = id_casilla_f;

        id_casillas[id_casilla_8, id_casilla_g].id_casilla_numero = id_casilla_8;
        id_casillas[id_casilla_8, id_casilla_g].id_casilla_letra = id_casilla_g;

        id_casillas[id_casilla_8, id_casilla_h].id_casilla_numero = id_casilla_8;
        id_casillas[id_casilla_8, id_casilla_h].id_casilla_letra = id_casilla_h;



    }


    public void activar_casilla(propiedades_casilla casilla)
    {
        if(
            casilla.no_se_sale_del_array(casilla.id_casilla_numero)
            &&
            casilla.no_se_sale_del_array(casilla.id_casilla_letra)
          )
        {
            casilla.GetComponent<Image>().sprite = casilla.fondo_activado;
            casilla.casilla_activada = true;
        }
       
    }

    public void activar_casilla(int numero, int letra)
    {
         
        if  (
            no_se_sale_del_array(numero)
            &&
            no_se_sale_del_array(letra)
            )
        {
            propiedades_casilla casilla = id_casillas[numero, letra];

      
            casilla.GetComponent<Image>().sprite = casilla.fondo_activado;
            casilla.casilla_activada = true;
        }
    }

    public void desactivar_casilla(propiedades_casilla casilla)
    {
        if (
            casilla.no_se_sale_del_array(casilla.id_casilla_numero)
            &&
            casilla.no_se_sale_del_array(casilla.id_casilla_letra)
          )
        {
            casilla.GetComponent<Image>().sprite = casilla.fondo_principal;
            casilla.casilla_activada = false;
        }
    }

    public void desactivar_casilla(int numero, int letra)
    {
        if (
            no_se_sale_del_array(numero)
            &&
            no_se_sale_del_array(letra)
            )
        {

            propiedades_casilla casilla = id_casillas[numero, letra];

            casilla.GetComponent<Image>().sprite = casilla.fondo_principal;
            casilla.casilla_activada = false;
        }
    }

    public bool comprobar_si_casilla_ocupada_por_alguna_pieza(propiedades_casilla casilla, int id_casilla_ocupada)
    {

        if(casilla.ocupado==id_casilla_ocupada)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool comprobar_si_casilla_ocupada_por_alguna_pieza(propiedades_casilla casilla)
    {

        if (casilla.ocupado != id_no_ocupado)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public propiedades_pieza dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa(propiedades_casilla casilla)
    {
        return id_casillas[casilla.id_casilla_numero, casilla.id_casilla_letra].pieza_que_la_ocupa;
    }

    //public void casilla_hace_jaque_a_blancas(int numero, int letra)
    //{
        
    //        casilla_jaque_a_blancas
    //        =
    //        id_casillas[numero, letra];

    //}
   

    public bool no_se_sale_del_array(int numero)
    {
        if (numero > 7 || numero < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void actualizar_casillas_atacadas()
    {
        ninguna_casilla_atacada();

        actualizar_casillas_atacadas_por_peones(las_piezas.peon_blanco_1);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_blanco_2);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_blanco_3);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_blanco_4);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_blanco_5);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_blanco_6);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_blanco_7);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_blanco_8);

        actualizar_casillas_atacadas_por_peones(las_piezas.peon_negro_1);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_negro_2);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_negro_3);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_negro_4);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_negro_5);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_negro_6);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_negro_7);
        actualizar_casillas_atacadas_por_peones(las_piezas.peon_negro_8);


        actualizar_casillas_atacadas_por_torres(las_piezas.torre_blanca_1);
        actualizar_casillas_atacadas_por_torres(las_piezas.torre_blanca_2);
        actualizar_casillas_atacadas_por_torres(las_piezas.torre_negra_1);
        actualizar_casillas_atacadas_por_torres(las_piezas.torre_negra_2);


        actualizar_casillas_atacadas_por_caballos(las_piezas.caballo_blanco_1);
        actualizar_casillas_atacadas_por_caballos(las_piezas.caballo_blanco_2);
        actualizar_casillas_atacadas_por_caballos(las_piezas.caballo_negro_1);
        actualizar_casillas_atacadas_por_caballos(las_piezas.caballo_negro_2);


        actualizar_casillas_atacadas_por_alfiles(las_piezas.alfil_blanco_1);
        actualizar_casillas_atacadas_por_alfiles(las_piezas.alfil_blanco_2);
        actualizar_casillas_atacadas_por_alfiles(las_piezas.alfil_negro_1);
        actualizar_casillas_atacadas_por_alfiles(las_piezas.alfil_negro_2);


        actualizar_casillas_atacadas_por_damas(las_piezas.dama_blanca_1);
        actualizar_casillas_atacadas_por_damas(las_piezas.dama_negra_1);


        actualizar_casillas_atacadas_por_reyes(las_piezas.rey_blanco_1);
        actualizar_casillas_atacadas_por_reyes(las_piezas.rey_negro_1);




    }

    public void actualizar_casillas_atacadas_por_peones(propiedades_pieza peon)
    {

        /* 
           PRIMERO COMPRUEBA SI EL PEÓN FUE CORONADO Y DE SERLO
           LAS CASILLAS QUE ATACA VAN ACORDE A LA PIEZA QUE FUE
           CORONADO
        */

        if (peon.id_tipo_pieza==las_piezas.id_torre)
        {
            actualizar_casillas_atacadas_por_torres(peon);
        }
        else
        if (peon.id_tipo_pieza == las_piezas.id_caballo)
        {
            actualizar_casillas_atacadas_por_caballos(peon);
        }
        else
        if (peon.id_tipo_pieza == las_piezas.id_alfil)
        {
            actualizar_casillas_atacadas_por_alfiles(peon);
        }
        else
        if (peon.id_tipo_pieza == las_piezas.id_dama)
        {
            actualizar_casillas_atacadas_por_damas(peon);
        }
        /*
               SI LLEGA AQUI ES PORQUE ES UN PEÓN SIN CORONAR 
               DE MODO QUE ATACA LAS CASILLAS QUE UN PEÓN ATACA
        */
        else
        if
            (
            peon.es_blanca
            )
        {
            if
            (
                !peon.fue_comida
                &&
                no_se_sale_del_array
                (
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero + 1
                )
            )
            {
                // CASILLA ARRIBA IZQUIERDA DEL PEÓN
                if
                (
                    no_se_sale_del_array
                    (
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra - 1
                    )
                )
                {
                    id_casillas
                    [

                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero + 1
                    ,
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_letra - 1

                    ].atacado_por_blancas += 1;

                    // Comprueba si hay jaque y si lo hay se activa el jaque

                    if
                        (
                            hay_jaque_si_atacamos_en_la_casilla
                            (
                                 id_casillas
                                    [
                                        peon.id_casilla_numero + 1
                                        ,
                                        peon.id_casilla_letra - 1
                                    ]
                                ,
                                peon
                            )
                        )
                    {
                        la_partida.hay_jaque_con_parametros
                            (
                            peon
                            ,
                            id_casillas
                                [
                                    peon.id_casilla_numero + 1
                                    ,
                                    peon.id_casilla_letra - 1
                                ]
                            );
                            
                    }


                }


                // CASILLA ARRIBA DERECHA DEL PEÓN

                if
                (
                    no_se_sale_del_array
                    (
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra + 1
                    )
                )
                {
                    id_casillas
                    [

                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero + 1
                    ,
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_letra + 1

                    ].atacado_por_blancas += 1;

                    // Comprueba si hay jaque y si lo hay se activa el jaque


                    if
                        (
                            hay_jaque_si_atacamos_en_la_casilla
                            (
                                 id_casillas
                                    [
                                        peon.id_casilla_numero + 1
                                        ,
                                        peon.id_casilla_letra + 1
                                    ]
                                ,
                                peon
                            )
                        )
                    {
                        la_partida.hay_jaque_con_parametros
                            (
                            peon
                            ,
                            id_casillas
                                [
                                    peon.id_casilla_numero + 1
                                    ,
                                    peon.id_casilla_letra + 1
                                ]
                            );

                        

                    }
                }


                // CASILLA IZQUIERDA DEL PEÓN SOLO SI ES COMIDA AL PASO

                if
                (
                    no_se_sale_del_array
                    (
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra - 1
                    )

                    &&

                     id_casillas
                        [

                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_numero
                        ,
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra - 1

                        ].ocupado != id_no_ocupado

                    &&

                    dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                    (
                        id_casillas
                        [

                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_numero
                        ,
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra - 1

                        ]
                    ).victima_de_comida_al_paso

                )
                {
                    id_casillas
                    [

                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero
                    ,
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_letra - 1

                    ].atacado_por_blancas += 1;
                }


                // CASILLA DERECHA DEL PEÓN SOLO SI ES COMIDA AL PASO

                if
                (
                    no_se_sale_del_array
                    (
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra + 1
                    )


                    &&

                     id_casillas
                        [

                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_numero
                        ,
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra + 1

                        ].ocupado != id_no_ocupado

                    &&

                    dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                    (
                        id_casillas
                        [

                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_numero
                        ,
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra + 1

                        ]
                    ).victima_de_comida_al_paso

                )
                {
                    id_casillas
                    [

                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero
                    ,
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_letra + 1

                    ].atacado_por_blancas += 1;
                }


            }
        }
        else
        {
            if
            (
                !peon.fue_comida
                &&
                no_se_sale_del_array
                (
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero - 1
                )
            )
            {
                // CASILLA ABAJO IZQUIERDA DEL PEÓN
                if
                (
                    no_se_sale_del_array
                    (
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra - 1
                    )
                )
                {
                    id_casillas
                    [

                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero - 1
                    ,
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_letra - 1

                    ].atacado_por_negras += 1;

                    // Comprueba si hay jaque y si lo hay se activa el jaque

                    if
                        (
                            hay_jaque_si_atacamos_en_la_casilla
                            (
                                 id_casillas
                                    [
                                        peon.id_casilla_numero - 1
                                        ,
                                        peon.id_casilla_letra - 1
                                    ]
                                ,
                                peon
                            )
                        )
                    {
                        la_partida.hay_jaque_con_parametros
                            (
                            peon
                            ,
                            id_casillas
                                [
                                    peon.id_casilla_numero - 1
                                    ,
                                    peon.id_casilla_letra - 1
                                ]
                            );

                    }
                }


                // CASILLA ABAJO DERECHA DEL PEÓN

                if
                (
                    no_se_sale_del_array
                    (
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra + 1
                    )
                )
                {
                    id_casillas
                    [

                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero - 1
                    ,
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_letra + 1

                    ].atacado_por_negras += 1;

                    // Comprueba si hay jaque y si lo hay se activa el jaque

                    if
                        (
                            hay_jaque_si_atacamos_en_la_casilla
                            (
                                 id_casillas
                                    [
                                        peon.id_casilla_numero - 1
                                        ,
                                        peon.id_casilla_letra + 1
                                    ]
                                ,
                                peon
                            )
                        )
                    {
                        la_partida.hay_jaque_con_parametros
                            (
                            peon
                            ,
                            id_casillas
                                [
                                    peon.id_casilla_numero - 1
                                    ,
                                    peon.id_casilla_letra + 1
                                ]
                            );

                    }
                }

                // CASILLA IZQUIERDA DEL PEÓN SOLO SI ES COMIDA AL PASO

                if
                (
                    no_se_sale_del_array
                    (
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra - 1
                    )

                    &&

                     id_casillas
                        [

                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_numero
                        ,
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra - 1

                        ].ocupado != id_no_ocupado

                    &&

                    dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                    (
                        id_casillas
                        [

                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_numero
                        ,
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra - 1

                        ]
                    ).victima_de_comida_al_paso

                )
                {
                    id_casillas
                    [

                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero
                    ,
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_letra - 1

                    ].atacado_por_negras += 1;
                }


                // CASILLA DERECHA DEL PEÓN SOLO SI ES COMIDA AL PASO

                if
                (
                    no_se_sale_del_array
                    (
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra + 1
                    )


                    &&

                     id_casillas
                        [

                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_numero
                        ,
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra + 1

                        ].ocupado != id_no_ocupado

                    &&

                    dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                    (
                        id_casillas
                        [

                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_numero
                        ,
                        las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                        (
                        peon
                        ).id_casilla_letra + 1

                        ]
                    ).victima_de_comida_al_paso

                )
                {
                    id_casillas
                    [

                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_numero
                    ,
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                    peon
                    ).id_casilla_letra + 1

                    ].atacado_por_negras += 1;
                }



            }
        }
    }

   

    public void actualizar_casillas_atacadas_por_torres(propiedades_pieza la_torre)
    {
        actualizar_casillas_atacadas_por_torres_vertical(la_torre);
        actualizar_casillas_atacadas_por_torres_horizontal(la_torre);
    }

    public void actualizar_casillas_atacadas_por_torres_vertical(propiedades_pieza la_torre)
    {
        actualizar_casillas_atacadas_por_torres_arriba(la_torre);
        actualizar_casillas_atacadas_por_torres_abajo(la_torre);
    }

    public void actualizar_casillas_atacadas_por_torres_horizontal(propiedades_pieza la_torre)
    {
        actualizar_casillas_atacadas_por_torres_izquierda(la_torre);
        actualizar_casillas_atacadas_por_torres_derecha(la_torre);
    }

    public void actualizar_casillas_atacadas_por_torres_arriba(propiedades_pieza la_torre)
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                !no_se_sale_del_array(la_torre.id_casilla_numero + id_contador)

                )
            {
                limite_vertical_torre = true;
            }
            else if
                (
                 comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            id_casillas
                            [
                            la_torre.id_casilla_numero + id_contador
                            ,
                            la_torre.id_casilla_letra
                            ]

                        )
                )
            {
                limite_vertical_torre = true;
                if(la_torre.es_blanca)
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero + id_contador
                           ,
                           la_torre.id_casilla_letra
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero + id_contador
                           ,
                           la_torre.id_casilla_letra
                           ].atacado_por_negras += 1;
                }              
            }
            else
            {
                if (la_torre.es_blanca)
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero + id_contador
                           ,
                           la_torre.id_casilla_letra
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero + id_contador
                           ,
                           la_torre.id_casilla_letra
                           ].atacado_por_negras += 1;
                }
                id_contador++;
            }
        }
    }

    public void actualizar_casillas_atacadas_por_torres_abajo(propiedades_pieza la_torre)
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                !no_se_sale_del_array(la_torre.id_casilla_numero - id_contador)

                )
            {
                limite_vertical_torre = true;
            }
            else if
                (
                 comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            id_casillas
                            [
                            la_torre.id_casilla_numero - id_contador
                            ,
                            la_torre.id_casilla_letra
                            ]

                        )
                )
            {
                limite_vertical_torre = true;
                if (la_torre.es_blanca)
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero - id_contador
                           ,
                           la_torre.id_casilla_letra
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero - id_contador
                           ,
                           la_torre.id_casilla_letra
                           ].atacado_por_negras += 1;
                }
            }
            else
            {
                if (la_torre.es_blanca)
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero - id_contador
                           ,
                           la_torre.id_casilla_letra
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero - id_contador
                           ,
                           la_torre.id_casilla_letra
                           ].atacado_por_negras += 1;
                }
                id_contador++;
            }
        }

    }

    public void actualizar_casillas_atacadas_por_torres_izquierda(propiedades_pieza la_torre)
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                !no_se_sale_del_array(la_torre.id_casilla_letra - id_contador)

                )
            {
                limite_vertical_torre = true;
            }
            else if
                (
                 comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            id_casillas
                            [
                            la_torre.id_casilla_numero 
                            ,
                            la_torre.id_casilla_letra - id_contador
                            ]

                        )
                )
            {
                limite_vertical_torre = true;
                if (la_torre.es_blanca)
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero 
                           ,
                           la_torre.id_casilla_letra - id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero 
                           ,
                           la_torre.id_casilla_letra - id_contador
                           ].atacado_por_negras += 1;
                }
            }
            else
            {
                if (la_torre.es_blanca)
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero 
                           ,
                           la_torre.id_casilla_letra - id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero 
                           ,
                           la_torre.id_casilla_letra - id_contador
                           ].atacado_por_negras += 1;
                }
                id_contador++;
            }
        }
    }

    public void actualizar_casillas_atacadas_por_torres_derecha(propiedades_pieza la_torre)
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                !no_se_sale_del_array(la_torre.id_casilla_letra + id_contador)

                )
            {
                limite_vertical_torre = true;
            }
            else if
                (
                 comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            id_casillas
                            [
                            la_torre.id_casilla_numero
                            ,
                            la_torre.id_casilla_letra + id_contador
                            ]

                        )
                )
            {
                limite_vertical_torre = true;
                if (la_torre.es_blanca)
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero
                           ,
                           la_torre.id_casilla_letra + id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero
                           ,
                           la_torre.id_casilla_letra + id_contador
                           ].atacado_por_negras += 1;
                }
            }
            else
            {
                if (la_torre.es_blanca)
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero
                           ,
                           la_torre.id_casilla_letra + id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           la_torre.id_casilla_numero
                           ,
                           la_torre.id_casilla_letra + id_contador
                           ].atacado_por_negras += 1;
                }
                id_contador++;
            }
        }
    }

    public void actualizar_casillas_atacadas_por_caballos(propiedades_pieza el_caballo)
    {
        actualizar_casillas_atacadas_por_caballos_arriba(el_caballo);
        actualizar_casillas_atacadas_por_caballos_abajo(el_caballo);
    }

    public void actualizar_casillas_atacadas_por_caballos_arriba(propiedades_pieza el_caballo)
    {
        if (
            no_se_sale_del_array(el_caballo.id_casilla_numero + 1)
            &&
            no_se_sale_del_array(el_caballo.id_casilla_letra - 2)
            )
            {
                if (el_caballo.es_blanca)
                {
                    id_casillas
                           [
                           el_caballo.id_casilla_numero +1
                           ,
                           el_caballo.id_casilla_letra - 2
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_caballo.id_casilla_numero + 1
                           ,
                           el_caballo.id_casilla_letra - 2
                           ].atacado_por_negras += 1;
                }
            }


        if (
            no_se_sale_del_array(el_caballo.id_casilla_numero + 1)
            &&
            no_se_sale_del_array(el_caballo.id_casilla_letra + 2)
            )
        {
            if (el_caballo.es_blanca)
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero + 1
                       ,
                       el_caballo.id_casilla_letra + 2
                       ].atacado_por_blancas += 1;
            }
            else
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero + 1
                       ,
                       el_caballo.id_casilla_letra + 2
                       ].atacado_por_negras += 1;
            }
        }


        if (
           no_se_sale_del_array(el_caballo.id_casilla_numero + 2)
           &&
           no_se_sale_del_array(el_caballo.id_casilla_letra - 1)
           )
        {
            if (el_caballo.es_blanca)
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero + 2
                       ,
                       el_caballo.id_casilla_letra - 1
                       ].atacado_por_blancas += 1;
            }
            else
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero + 2
                       ,
                       el_caballo.id_casilla_letra - 1
                       ].atacado_por_negras += 1;
            }
        }



        if (
          no_se_sale_del_array(el_caballo.id_casilla_numero + 2)
          &&
          no_se_sale_del_array(el_caballo.id_casilla_letra + 1)
          )
        {
            if (el_caballo.es_blanca)
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero + 2
                       ,
                       el_caballo.id_casilla_letra + 1
                       ].atacado_por_blancas += 1;
            }
            else
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero + 2
                       ,
                       el_caballo.id_casilla_letra + 1
                       ].atacado_por_negras += 1;
            }
        }
    }


    public void actualizar_casillas_atacadas_por_caballos_abajo(propiedades_pieza el_caballo)
    {
        if (
            no_se_sale_del_array(el_caballo.id_casilla_numero - 1)
            &&
            no_se_sale_del_array(el_caballo.id_casilla_letra - 2)
            )
        {
            if (el_caballo.es_blanca)
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero - 1
                       ,
                       el_caballo.id_casilla_letra - 2
                       ].atacado_por_blancas += 1;
            }
            else
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero - 1
                       ,
                       el_caballo.id_casilla_letra - 2
                       ].atacado_por_negras += 1;
            }
        }


        if (
            no_se_sale_del_array(el_caballo.id_casilla_numero - 1)
            &&
            no_se_sale_del_array(el_caballo.id_casilla_letra + 2)
            )
        {
            if (el_caballo.es_blanca)
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero - 1
                       ,
                       el_caballo.id_casilla_letra + 2
                       ].atacado_por_blancas += 1;
            }
            else
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero - 1
                       ,
                       el_caballo.id_casilla_letra + 2
                       ].atacado_por_negras += 1;
            }
        }


        if (
           no_se_sale_del_array(el_caballo.id_casilla_numero - 2)
           &&
           no_se_sale_del_array(el_caballo.id_casilla_letra - 1)
           )
        {
            if (el_caballo.es_blanca)
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero - 2
                       ,
                       el_caballo.id_casilla_letra - 1
                       ].atacado_por_blancas += 1;
            }
            else
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero - 2
                       ,
                       el_caballo.id_casilla_letra - 1
                       ].atacado_por_negras += 1;
            }
        }



        if (
          no_se_sale_del_array(el_caballo.id_casilla_numero - 2)
          &&
          no_se_sale_del_array(el_caballo.id_casilla_letra + 1)
          )
        {
            if (el_caballo.es_blanca)
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero - 2
                       ,
                       el_caballo.id_casilla_letra + 1
                       ].atacado_por_blancas += 1;
            }
            else
            {
                id_casillas
                       [
                       el_caballo.id_casilla_numero - 2
                       ,
                       el_caballo.id_casilla_letra + 1
                       ].atacado_por_negras += 1;
            }
        }
    }


    public void actualizar_casillas_atacadas_por_alfiles(propiedades_pieza el_alfil)
    {
        actualizar_casillas_atacadas_por_alfiles_arriba(el_alfil);
        actualizar_casillas_atacadas_por_alfiles_abajo(el_alfil);
    }


    public void actualizar_casillas_atacadas_por_alfiles_arriba(propiedades_pieza el_alfil)
    {

        // DIAGONAL ARRIBA IZQUIERDA

        bool limite_diagonal_alfil = false;
        int id_contador = 1;
        while (!limite_diagonal_alfil)
        {
            if (
                !no_se_sale_del_array(el_alfil.id_casilla_numero + id_contador)
                ||
                !no_se_sale_del_array(el_alfil.id_casilla_letra - id_contador)

                )
            {
                limite_diagonal_alfil = true;
            }
            else if
                (
                 comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            id_casillas
                            [
                            el_alfil.id_casilla_numero + id_contador
                            ,
                            el_alfil.id_casilla_letra - id_contador
                            ]

                        )
                )
            {
                limite_diagonal_alfil = true;
                if (el_alfil.es_blanca)
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero + id_contador
                           ,
                           el_alfil.id_casilla_letra - id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero + id_contador
                           ,
                           el_alfil.id_casilla_letra - id_contador
                           ].atacado_por_negras += 1;
                }
            }
            else
            {
                if (el_alfil.es_blanca)
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero + id_contador
                           ,
                           el_alfil.id_casilla_letra - id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero + id_contador
                           ,
                           el_alfil.id_casilla_letra - id_contador
                           ].atacado_por_negras += 1;
                }
                id_contador++;
            }
        }




        // DIAGONAL ARRIBA DERECHA

        limite_diagonal_alfil = false;
        id_contador = 1;
        while (!limite_diagonal_alfil)
        {
            if (
                !no_se_sale_del_array(el_alfil.id_casilla_numero + id_contador)
                ||
                !no_se_sale_del_array(el_alfil.id_casilla_letra + id_contador)

                )
            {
                limite_diagonal_alfil = true;
            }
            else if
                (
                 comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            id_casillas
                            [
                            el_alfil.id_casilla_numero + id_contador
                            ,
                            el_alfil.id_casilla_letra + id_contador
                            ]

                        )
                )
            {
                limite_diagonal_alfil = true;
                if (el_alfil.es_blanca)
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero + id_contador
                           ,
                           el_alfil.id_casilla_letra + id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero + id_contador
                           ,
                           el_alfil.id_casilla_letra + id_contador
                           ].atacado_por_negras += 1;
                }
            }
            else
            {
                if (el_alfil.es_blanca)
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero + id_contador
                           ,
                           el_alfil.id_casilla_letra + id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero + id_contador
                           ,
                           el_alfil.id_casilla_letra + id_contador
                           ].atacado_por_negras += 1;
                }
                id_contador++;
            }
        }
    }


    public void actualizar_casillas_atacadas_por_alfiles_abajo(propiedades_pieza el_alfil)
    {

        // DIAGONAL ABAJO IZQUIERDA

        bool limite_diagonal_alfil = false;
        int id_contador = 1;
        while (!limite_diagonal_alfil)
        {
            if (
                !no_se_sale_del_array(el_alfil.id_casilla_numero - id_contador)
                ||
                !no_se_sale_del_array(el_alfil.id_casilla_letra - id_contador)

                )
            {
                limite_diagonal_alfil = true;
            }
            else if
                (
                 comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            id_casillas
                            [
                            el_alfil.id_casilla_numero - id_contador
                            ,
                            el_alfil.id_casilla_letra - id_contador
                            ]

                        )
                )
            {
                limite_diagonal_alfil = true;
                if (el_alfil.es_blanca)
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero - id_contador
                           ,
                           el_alfil.id_casilla_letra - id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero - id_contador
                           ,
                           el_alfil.id_casilla_letra - id_contador
                           ].atacado_por_negras += 1;
                }
            }
            else
            {
                if (el_alfil.es_blanca)
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero - id_contador
                           ,
                           el_alfil.id_casilla_letra - id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero - id_contador
                           ,
                           el_alfil.id_casilla_letra - id_contador
                           ].atacado_por_negras += 1;
                }
                id_contador++;
            }
        }




        // DIAGONAL ABAJO DERECHA

        limite_diagonal_alfil = false;
        id_contador = 1;
        while (!limite_diagonal_alfil)
        {
            if (
                !no_se_sale_del_array(el_alfil.id_casilla_numero - id_contador)
                ||
                !no_se_sale_del_array(el_alfil.id_casilla_letra + id_contador)

                )
            {
                limite_diagonal_alfil = true;
            }
            else if
                (
                 comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            id_casillas
                            [
                            el_alfil.id_casilla_numero - id_contador
                            ,
                            el_alfil.id_casilla_letra + id_contador
                            ]

                        )
                )
            {
                limite_diagonal_alfil = true;
                if (el_alfil.es_blanca)
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero - id_contador
                           ,
                           el_alfil.id_casilla_letra + id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero - id_contador
                           ,
                           el_alfil.id_casilla_letra + id_contador
                           ].atacado_por_negras += 1;
                }
            }
            else
            {
                if (el_alfil.es_blanca)
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero - id_contador
                           ,
                           el_alfil.id_casilla_letra + id_contador
                           ].atacado_por_blancas += 1;
                }
                else
                {
                    id_casillas
                           [
                           el_alfil.id_casilla_numero - id_contador
                           ,
                           el_alfil.id_casilla_letra + id_contador
                           ].atacado_por_negras += 1;
                }
                id_contador++;
            }
        }
    }


    public void actualizar_casillas_atacadas_por_damas(propiedades_pieza la_dama)
    {
        actualizar_casillas_atacadas_por_torres(la_dama);
        actualizar_casillas_atacadas_por_alfiles(la_dama);
    }


    public void actualizar_casillas_atacadas_por_reyes(propiedades_pieza el_rey)
    {
        if(el_rey.es_blanca)
        {
            // CASILLA ARRIBA IZQUIERDA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero + 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra - 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero + 1
                          ,
                          el_rey.id_casilla_letra - 1
                          ].atacado_por_blancas += 1;
            }

            // CASILLA ARRIBA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero + 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero + 1
                          ,
                          el_rey.id_casilla_letra
                          ].atacado_por_blancas += 1;
            }

            // CASILLA ARRIBA DERECHA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero + 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra + 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero + 1
                          ,
                          el_rey.id_casilla_letra + 1
                          ].atacado_por_blancas += 1;
            }

            // CASILLA IZQUIERDA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra - 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero
                          ,
                          el_rey.id_casilla_letra - 1
                          ].atacado_por_blancas += 1;
            }

            // CASILLA DERECHA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra + 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero
                          ,
                          el_rey.id_casilla_letra + 1
                          ].atacado_por_blancas += 1;
            }

            // CASILLA ABAJO IZQUIERDA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero - 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra - 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero - 1
                          ,
                          el_rey.id_casilla_letra - 1
                          ].atacado_por_blancas += 1;
            }

            // CASILLA ABAJO DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero - 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero - 1
                          ,
                          el_rey.id_casilla_letra
                          ].atacado_por_blancas += 1;
            }

            // CASILLA ABAJO DERECHA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero - 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra + 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero - 1
                          ,
                          el_rey.id_casilla_letra + 1
                          ].atacado_por_blancas += 1;
            }


        }
        else
        {
            // CASILLA ARRIBA IZQUIERDA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero + 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra - 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero + 1
                          ,
                          el_rey.id_casilla_letra - 1
                          ].atacado_por_negras += 1;
            }

            // CASILLA ARRIBA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero + 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero + 1
                          ,
                          el_rey.id_casilla_letra
                          ].atacado_por_negras += 1;
            }

            // CASILLA ARRIBA DERECHA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero + 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra + 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero + 1
                          ,
                          el_rey.id_casilla_letra + 1
                          ].atacado_por_negras += 1;
            }

            // CASILLA IZQUIERDA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra - 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero
                          ,
                          el_rey.id_casilla_letra - 1
                          ].atacado_por_negras += 1;
            }

            // CASILLA DERECHA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra + 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero
                          ,
                          el_rey.id_casilla_letra + 1
                          ].atacado_por_negras += 1;
            }

            // CASILLA ABAJO IZQUIERDA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero - 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra - 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero - 1
                          ,
                          el_rey.id_casilla_letra - 1
                          ].atacado_por_negras += 1;
            }

            // CASILLA ABAJO DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero - 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero - 1
                          ,
                          el_rey.id_casilla_letra
                          ].atacado_por_negras += 1;
            }

            // CASILLA ABAJO DERECHA DEL REY
            // PERO PRIMERO NOS ASEGURAMOS QUE ESA CASILLA NO QUEDE
            // FUERA DEL TABLERO
            if
                (
                   no_se_sale_del_array(el_rey.id_casilla_numero - 1)
                   &&
                   no_se_sale_del_array(el_rey.id_casilla_letra + 1)
                )
            {
                id_casillas
                          [
                          el_rey.id_casilla_numero - 1
                          ,
                          el_rey.id_casilla_letra + 1
                          ].atacado_por_negras += 1;
            }
        }
    }

    public bool hay_jaque_si_atacamos_en_la_casilla(propiedades_casilla casilla_atacada, propiedades_pieza pieza_que_ataca)
    {
        // Comprueba si hay jaque y si lo hay se activa el jaque

        if
            (
                id_casillas
                    [
                        casilla_atacada.id_casilla_numero
                        ,
                        casilla_atacada.id_casilla_letra
                    ].ocupado!=id_no_ocupado

                &&

                dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    id_casillas
                    [
                        casilla_atacada.id_casilla_numero
                        ,
                        casilla_atacada.id_casilla_letra
                    ]
                ).id_tipo_pieza == las_piezas.id_rey

                &&

                  dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    id_casillas
                    [
                        casilla_atacada.id_casilla_numero
                        ,
                        casilla_atacada.id_casilla_letra
                    ]
                ).es_blanca
                !=
                pieza_que_ataca.es_blanca
            )
        {
            if(!la_partida.pieza_que_hace_jaque)
            {
                la_partida.pieza_que_hace_jaque = pieza_que_ataca;
                la_partida.pasar_casilla_a_en_medio_del_jaque
               (
                    las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                    (
                        la_partida.pieza_que_hace_jaque
                    )
               );
            }
            /*
            else if(la_partida.pieza_que_hace_jaque!=pieza_que_ataca)
            {
                la_partida.pieza_que_hace_jaque_2 = pieza_que_ataca;
            }
            */
           

            return true;
        }
        else
        {
            return false;
        }
    }

    public void ninguna_casilla_atacada()
    {
        // RECORRE TODAS LAS CASILLAS Y LE DA FALSO A SUS ATRIBUTOS DE ATACADAS

        for(int casilla_numero=id_casilla_1;casilla_numero<=id_casilla_8;casilla_numero++)
        {
            for (int casilla_letra = id_casilla_a; casilla_letra <= id_casilla_h; casilla_letra++)
            {
                id_casillas[casilla_numero, casilla_letra].atacado_por_blancas = 0;
                id_casillas[casilla_numero, casilla_letra].atacado_por_negras = 0;
            }
        }

    }

    public bool esta_casilla_es_atacada_por_color(propiedades_casilla la_casilla ,bool atacado_por_blancas)
    {
        if(atacado_por_blancas)
        {
            if
                (
                la_casilla.atacado_por_blancas>0
                )
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        else
        {
            if
               (
               la_casilla.atacado_por_negras > 0
               )
            {
                return true;
            }
            else
            {
                return false;
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
