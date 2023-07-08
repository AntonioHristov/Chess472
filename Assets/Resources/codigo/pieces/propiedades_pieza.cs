using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class propiedades_pieza : MonoBehaviour, IPointerDownHandler
{
    public bool pieza_activa = false;

    private static int id_peon = 1;
    private static int id_torre = 2;
    private static int id_caballo = 3;
    private static int id_alfil = 4;
    private static int id_dama = 5;
    private static int id_rey = 6;


    public int id_casilla_numero;
    public int id_casilla_letra;


    public int id_tipo_pieza;


    public bool es_blanca = true;
    public bool fue_comida = false;
    public bool no_se_ha_movido = true;
    public bool victima_de_comida_al_paso = false;

    public GameObject posicion_pieza_comida;


    public piezas todas_las_piezas;


    public casillas todas_las_casillas;


    public partida la_partida;


    public void OnPointerDown(PointerEventData eventData)
    {
        if(!la_partida.partida_terminada)
        {
            if (es_blanca)
            {

                if (id_tipo_pieza == id_peon)
                {
                    es_peon_blanco();
                }
                else if (id_tipo_pieza == id_torre)
                {
                    es_torre_blanco();
                }
                else if (id_tipo_pieza == id_caballo)
                {
                    es_caballo_blanco();
                }
                else if (id_tipo_pieza == id_alfil)
                {
                    es_alfil_blanco();
                }
                else if (id_tipo_pieza == id_dama)
                {
                    es_dama_blanca();
                }
                else
                {
                    es_rey_blanco();
                }



            }
            else
            {
                if (id_tipo_pieza == id_peon)
                {
                    es_peon_negro();
                }
                else if (id_tipo_pieza == id_torre)
                {
                    es_torre_negro();
                }
                else if (id_tipo_pieza == id_caballo)
                {
                    es_caballo_negro();
                }
                else if (id_tipo_pieza == id_alfil)
                {
                    es_alfil_negro();
                }
                else if (id_tipo_pieza == id_dama)
                {
                    es_dama_negra();
                }
                else
                {
                    es_rey_negro();
                }

            }
        }
        












    }


    

    public void es_peon_blanco()
    {
        

        if
            (
            la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_piezas_peon_blanco();
            
        }
        else if (pieza_activa)
        {
            desactivar_piezas_peon_blanco();

        }
    }

    public void es_peon_negro()
    {
        if
            (
            !la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_piezas_peon_negro();
            
        }
        else if (pieza_activa)
        {
            desactivar_piezas_peon_negro();

        }
    }

    public void es_torre_blanco()
    {

        if
            (
            la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_pieza_pulsada();
            activar_piezas_vertical_blanco();
            activar_piezas_horizontal_blanco();
        }
        else if (pieza_activa)
        {
            desactivar_piezas_vertical_blanco();
            desactivar_piezas_horizontal_blanco();
            desactivar_pieza_pulsada();
        }
    }

    public void es_torre_negro()
    {

        if
            (
            !la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_pieza_pulsada();
            activar_piezas_vertical_negro();
            activar_piezas_horizontal_negro();
        }
        else if (pieza_activa)
        {
            desactivar_piezas_vertical_negro();
            desactivar_piezas_horizontal_negro();
            desactivar_pieza_pulsada();
        }
    }

    public void es_caballo_blanco()
    {

        if
            (
            la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_piezas_caballo_blanco();

        }
        else if (pieza_activa)
        {
            desactivar_piezas_caballos();
        }
    }

    public void es_caballo_negro()
    {

        if
            (
            !la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_piezas_caballo_negro();

        }
        else if (pieza_activa)
        {
            desactivar_piezas_caballos();
        }
    }

    public void es_alfil_blanco()
    {
        if
            (
            la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_pieza_pulsada();
            activar_piezas_diagonal_arriba_izquierda_blanco();
            activar_piezas_diagonal_arriba_derecha_blanco();
            activar_piezas_diagonal_abajo_izquierda_blanco();
            activar_piezas_diagonal_abajo_derecha_blanco();

        }
        else if (pieza_activa)
        {
            desactivar_piezas_diagonal_arriba_izquierda_blanco();
            desactivar_piezas_diagonal_arriba_derecha_blanco();
            desactivar_piezas_diagonal_abajo_izquierda_blanco();
            desactivar_piezas_diagonal_abajo_derecha_blanco();
            desactivar_pieza_pulsada();
        }
    }

    public void es_alfil_negro()
    {
        if
            (
            !la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_pieza_pulsada();
            activar_piezas_diagonal_arriba_izquierda_negro();
            activar_piezas_diagonal_arriba_derecha_negro();
            activar_piezas_diagonal_abajo_izquierda_negro();
            activar_piezas_diagonal_abajo_derecha_negro();

        }
        else if (pieza_activa)
        {
            desactivar_piezas_diagonal_arriba_izquierda_negro();
            desactivar_piezas_diagonal_arriba_derecha_negro();
            desactivar_piezas_diagonal_abajo_izquierda_negro();
            desactivar_piezas_diagonal_abajo_derecha_negro();
            desactivar_pieza_pulsada();
        }
    }

    public void es_dama_blanca()
    {
        if
            (
            la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_pieza_pulsada();
            activar_piezas_vertical_blanco();
            activar_piezas_horizontal_blanco();
            activar_piezas_diagonal_arriba_izquierda_blanco();
            activar_piezas_diagonal_arriba_derecha_blanco();
            activar_piezas_diagonal_abajo_izquierda_blanco();
            activar_piezas_diagonal_abajo_derecha_blanco();
        }
        else if (pieza_activa)
        {
            desactivar_piezas_vertical_blanco();
            desactivar_piezas_horizontal_blanco();
            desactivar_piezas_diagonal_arriba_izquierda_blanco();
            desactivar_piezas_diagonal_arriba_derecha_blanco();
            desactivar_piezas_diagonal_abajo_izquierda_blanco();
            desactivar_piezas_diagonal_abajo_derecha_blanco();
            desactivar_pieza_pulsada();
        }

       
    }

    public void es_dama_negra()
    {
        if
            (
            !la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_pieza_pulsada();
            activar_piezas_vertical_negro();
            activar_piezas_horizontal_negro();
            activar_piezas_diagonal_arriba_izquierda_negro();
            activar_piezas_diagonal_arriba_derecha_negro();
            activar_piezas_diagonal_abajo_izquierda_negro();
            activar_piezas_diagonal_abajo_derecha_negro();
        }
        else if (pieza_activa)
        {
            desactivar_piezas_vertical_negro();
            desactivar_piezas_horizontal_negro();
            desactivar_piezas_diagonal_arriba_izquierda_negro();
            desactivar_piezas_diagonal_arriba_derecha_negro();
            desactivar_piezas_diagonal_abajo_izquierda_negro();
            desactivar_piezas_diagonal_abajo_derecha_negro();
            desactivar_pieza_pulsada();
        }
    }

    public void es_rey_blanco()
    {
        if
            (
            la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_pieza_pulsada();
            comprobar_si_rey_blanco_puede_moverse();
            

        }
        else if (pieza_activa)
        {
            desactivar_casillas_rey();
            desactivar_pieza_pulsada();
            
        }


    }

    public void es_rey_negro()
    {
        if
            (
            !la_partida.turno_blancas
            &&
            !todas_las_piezas.hay_una_pieza_activa
            )
        {
            activar_pieza_pulsada();
            comprobar_si_rey_negro_puede_moverse();
            
        }
        else if (pieza_activa)
        {
            desactivar_casillas_rey();
            desactivar_pieza_pulsada();
        }
    }

    public void activar_piezas_peon_blanco()
    {
        int id_numero_una_casilla_arriba_de_la_que_esta_este_peon_blanco = id_casilla_numero + 1;
        int id_letra_una_casilla_arriba_de_la_que_esta_este_peon_blanco = id_casilla_letra;

        int id_numero_dos_casillas_arriba_de_la_que_esta_este_peon_blanco = id_casilla_numero + 2;
        int id_letra_dos_casillas_arriba_de_la_que_esta_este_peon_blanco = id_casilla_letra;


        int id_numero_casilla_diagonal_comer_izquierda = id_casilla_numero + 1;
        int id_letra_casilla_diagonal_comer_izquierda = id_casilla_letra - 1;

        int id_numero_casilla_diagonal_comer_derecha = id_casilla_numero + 1;
        int id_letra_casilla_diagonal_comer_derecha = id_casilla_letra + 1;

        int id_numero_casilla_izquierda_comida_al_paso = id_casilla_numero;
        int id_letra_casilla_izquierda_comida_al_paso = id_casilla_numero - 1;

        int id_numero_casilla_derecha_comida_al_paso = id_casilla_numero;
        int id_letra_casilla_derecha_comida_al_paso = id_casilla_numero + 1;


        activar_pieza_pulsada();



        peon_comprobar_si_se_puede_activar_casilla_y_activarla
            (
            id_numero_una_casilla_arriba_de_la_que_esta_este_peon_blanco
            ,
            id_letra_una_casilla_arriba_de_la_que_esta_este_peon_blanco
            ,
            todas_las_casillas.id_no_ocupado
            );


        peon_comprobar_si_se_puede_activar_casilla_y_activarla
            (
            id_numero_dos_casillas_arriba_de_la_que_esta_este_peon_blanco
            ,
            id_letra_dos_casillas_arriba_de_la_que_esta_este_peon_blanco
            ,
            no_se_ha_movido
            &&
            no_se_sale_del_array(id_numero_una_casilla_arriba_de_la_que_esta_este_peon_blanco)
            &&
            todas_las_casillas.id_casillas[id_numero_una_casilla_arriba_de_la_que_esta_este_peon_blanco, id_casilla_letra].ocupado
            ==
            todas_las_casillas.id_no_ocupado
            ,
            todas_las_casillas.id_no_ocupado
            );


        peon_comprobar_si_se_puede_activar_casilla_y_activarla
            (
            id_numero_casilla_diagonal_comer_izquierda
            ,
            id_letra_casilla_diagonal_comer_izquierda
            ,
            todas_las_casillas.id_ocupado_negras
            );


        peon_comprobar_si_se_puede_activar_casilla_y_activarla
           (
           id_numero_casilla_diagonal_comer_derecha
           ,
           id_letra_casilla_diagonal_comer_derecha
           ,
           todas_las_casillas.id_ocupado_negras
           );

        comprobar_si_se_puede_activar_casilla_y_activarla_comida_al_paso
            (
            this.id_casilla_numero
            ,
            this.id_casilla_letra - 1
            ,
            todas_las_casillas.id_ocupado_blancas
            ,
            todas_las_casillas.id_ocupado_negras
            );

        comprobar_si_se_puede_activar_casilla_y_activarla_comida_al_paso
            (
            this.id_casilla_numero
            ,
            this.id_casilla_letra + 1
            ,
            todas_las_casillas.id_ocupado_blancas
            ,
            todas_las_casillas.id_ocupado_negras
            );
    }

    public void desactivar_piezas_peon_blanco()
    {
        int id_numero_una_casilla_arriba_de_la_que_esta_este_peon_blanco = id_casilla_numero + 1;
        int id_letra_una_casilla_arriba_de_la_que_esta_este_peon_blanco = id_casilla_letra;

        int id_numero_dos_casillas_arriba_de_la_que_esta_este_peon_blanco = id_casilla_numero + 2;
        int id_letra_dos_casillas_arriba_de_la_que_esta_este_peon_blanco = id_casilla_letra;


        int id_numero_casilla_diagonal_comer_izquierda = id_casilla_numero + 1;
        int id_letra_casilla_diagonal_comer_izquierda = id_casilla_letra - 1;

        int id_numero_casilla_diagonal_comer_derecha = id_casilla_numero + 1;
        int id_letra_casilla_diagonal_comer_derecha = id_casilla_letra + 1;

        int id_numero_casilla_izquierda_comida_al_paso = id_casilla_numero;
        int id_letra_casilla_izquierda_comida_al_paso = id_casilla_numero - 1;

        int id_numero_casilla_derecha_comida_al_paso = id_casilla_numero;
        int id_letra_casilla_derecha_comida_al_paso = id_casilla_numero + 1;

        desactivar_casillas(
                id_numero_una_casilla_arriba_de_la_que_esta_este_peon_blanco
                ,
                id_letra_una_casilla_arriba_de_la_que_esta_este_peon_blanco
                );

        desactivar_casillas(
            id_numero_dos_casillas_arriba_de_la_que_esta_este_peon_blanco
            ,
            id_letra_dos_casillas_arriba_de_la_que_esta_este_peon_blanco
            );

        desactivar_casillas(
            id_numero_casilla_diagonal_comer_izquierda
            ,
            id_letra_casilla_diagonal_comer_izquierda
            );

        desactivar_casillas(
            id_numero_casilla_diagonal_comer_derecha
            ,
            id_letra_casilla_diagonal_comer_derecha
            );

        desactivar_pieza_pulsada();

    }

    public void activar_piezas_peon_negro()
    {
        int id_numero_una_casilla_arriba_de_la_que_esta_este_peon_negro = id_casilla_numero - 1;
        int id_letra_una_casilla_arriba_de_la_que_esta_este_peon_negro = id_casilla_letra;

        int id_numero_dos_casillas_arriba_de_la_que_esta_este_peon_negro = id_casilla_numero - 2;
        int id_letra_dos_casillas_arriba_de_la_que_esta_este_peon_negro = id_casilla_letra;


        int id_numero_casilla_diagonal_comer_izquierda = id_casilla_numero - 1;
        int id_letra_casilla_diagonal_comer_izquierda = id_casilla_letra + 1;

        int id_numero_casilla_diagonal_comer_derecha = id_casilla_numero - 1;
        int id_letra_casilla_diagonal_comer_derecha = id_casilla_letra - 1;

        activar_pieza_pulsada();


        peon_comprobar_si_se_puede_activar_casilla_y_activarla
            (
            id_numero_una_casilla_arriba_de_la_que_esta_este_peon_negro
            ,
            id_letra_una_casilla_arriba_de_la_que_esta_este_peon_negro
            ,
            todas_las_casillas.id_no_ocupado
            );


        peon_comprobar_si_se_puede_activar_casilla_y_activarla
            (
            id_numero_dos_casillas_arriba_de_la_que_esta_este_peon_negro
            ,
            id_letra_dos_casillas_arriba_de_la_que_esta_este_peon_negro
            ,
            no_se_ha_movido
            &&
            no_se_sale_del_array(id_numero_una_casilla_arriba_de_la_que_esta_este_peon_negro)
            &&
            todas_las_casillas.id_casillas[id_numero_una_casilla_arriba_de_la_que_esta_este_peon_negro, id_casilla_letra].ocupado
            ==
            todas_las_casillas.id_no_ocupado
            ,
            todas_las_casillas.id_no_ocupado
            );


        peon_comprobar_si_se_puede_activar_casilla_y_activarla
            (
            id_numero_casilla_diagonal_comer_izquierda
            ,
            id_letra_casilla_diagonal_comer_izquierda
            ,
            todas_las_casillas.id_ocupado_blancas
            );


        peon_comprobar_si_se_puede_activar_casilla_y_activarla
           (
           id_numero_casilla_diagonal_comer_derecha
           ,
           id_letra_casilla_diagonal_comer_derecha
           ,
           todas_las_casillas.id_ocupado_blancas
           );

        comprobar_si_se_puede_activar_casilla_y_activarla_comida_al_paso
            (
            this.id_casilla_numero
            ,
            this.id_casilla_letra - 1
            ,
            todas_las_casillas.id_ocupado_negras
            ,
            todas_las_casillas.id_ocupado_blancas
            );

        comprobar_si_se_puede_activar_casilla_y_activarla_comida_al_paso
            (
            this.id_casilla_numero
            ,
            this.id_casilla_letra + 1
            ,
            todas_las_casillas.id_ocupado_negras
            ,
            todas_las_casillas.id_ocupado_blancas
            );
    }

    public void desactivar_piezas_peon_negro()
    {
        int id_numero_una_casilla_arriba_de_la_que_esta_este_peon_negro = id_casilla_numero - 1;
        int id_letra_una_casilla_arriba_de_la_que_esta_este_peon_negro = id_casilla_letra;

        int id_numero_dos_casillas_arriba_de_la_que_esta_este_peon_negro = id_casilla_numero - 2;
        int id_letra_dos_casillas_arriba_de_la_que_esta_este_peon_negro = id_casilla_letra;


        int id_numero_casilla_diagonal_comer_izquierda = id_casilla_numero - 1;
        int id_letra_casilla_diagonal_comer_izquierda = id_casilla_letra + 1;

        int id_numero_casilla_diagonal_comer_derecha = id_casilla_numero - 1;
        int id_letra_casilla_diagonal_comer_derecha = id_casilla_letra - 1;

        desactivar_casillas(
                id_numero_una_casilla_arriba_de_la_que_esta_este_peon_negro
                ,
                id_letra_una_casilla_arriba_de_la_que_esta_este_peon_negro
                );

        desactivar_casillas(
            id_numero_dos_casillas_arriba_de_la_que_esta_este_peon_negro
            ,
            id_letra_dos_casillas_arriba_de_la_que_esta_este_peon_negro
            );

        desactivar_casillas(
            id_numero_casilla_diagonal_comer_izquierda
            ,
            id_letra_casilla_diagonal_comer_izquierda
            );

        desactivar_casillas(
            id_numero_casilla_diagonal_comer_derecha
            ,
            id_letra_casilla_diagonal_comer_derecha
            );

        desactivar_pieza_pulsada();
    }

    public void activar_piezas_vertical_blanco()
    {
        activar_piezas_arriba_blanco();
        activar_piezas_abajo_blanco();
    }

    public void activar_piezas_vertical_negro()
    {
        activar_piezas_arriba_negro();
        activar_piezas_abajo_negro();
    }

    public void desactivar_piezas_vertical_blanco()
    {
        desactivar_piezas_arriba_blanco();
        desactivar_piezas_abajo_blanco();
    }

    public void desactivar_piezas_vertical_negro()
    {
        desactivar_piezas_arriba_negro();
        desactivar_piezas_abajo_negro();
    }

    public void activar_piezas_horizontal_blanco()
    {
        activar_piezas_izquierda_blanco();
        activar_piezas_derecha_blanco();
    }

    public void activar_piezas_horizontal_negro()
    {
        activar_piezas_izquierda_negro();
        activar_piezas_derecha_negro();
    }

    public void desactivar_piezas_horizontal_blanco()
    {
        desactivar_piezas_izquierda_blanco();
        desactivar_piezas_derecha_blanco();
    }

    public void desactivar_piezas_horizontal_negro()
    {
        desactivar_piezas_izquierda_negro();
        desactivar_piezas_derecha_negro();
    }

    public void activar_piezas_arriba_blanco()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )              
                )
                {
                    limite_vertical_torre = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_arriba_negro()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    limite_vertical_torre = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_abajo_blanco()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {                
                    limite_vertical_torre = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_abajo_negro()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    limite_vertical_torre = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_izquierda_blanco()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero 
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero 
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero 
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    limite_vertical_torre = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_izquierda_negro()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    limite_vertical_torre = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_derecha_blanco()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    limite_vertical_torre = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_derecha_negro()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    limite_vertical_torre = true;
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_arriba_blanco()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                 (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                    (
                       todas_las_casillas.id_casillas
                       [
                       this.id_casilla_numero + id_contador
                       ,
                       this.id_casilla_letra
                       ]
                       ,
                       todas_las_casillas.id_ocupado_blancas
                    )
                  )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                   (
                   !no_se_sale_del_array(id_casilla_numero + id_contador)
                   ||
                   todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                          (
                              todas_las_casillas.id_casillas
                              [
                              this.id_casilla_numero + id_contador
                              ,
                              this.id_casilla_letra
                              ]
                              ,
                              todas_las_casillas.id_ocupado_negras
                          )
                    )
                {                    
                    if(no_se_sale_del_array(id_casilla_numero + id_contador))
                    {
                        desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra
                    );
                    }                    
                    limite_vertical_torre = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_arriba_negro()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                 (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                    (
                       todas_las_casillas.id_casillas
                       [
                       this.id_casilla_numero + id_contador
                       ,
                       this.id_casilla_letra
                       ]
                       ,
                       todas_las_casillas.id_ocupado_negras
                    )
                  )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                   (
                   !no_se_sale_del_array(id_casilla_numero + id_contador)
                   ||
                   todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                          (
                              todas_las_casillas.id_casillas
                              [
                              this.id_casilla_numero + id_contador
                              ,
                              this.id_casilla_letra
                              ]
                              ,
                              todas_las_casillas.id_ocupado_blancas
                          )
                    )
                {
                    if (no_se_sale_del_array(id_casilla_numero + id_contador))
                    {
                        desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra
                    );
                    }
                    limite_vertical_torre = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_abajo_blanco()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                 (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                    (
                       todas_las_casillas.id_casillas
                       [
                       this.id_casilla_numero - id_contador
                       ,
                       this.id_casilla_letra
                       ]
                       ,
                       todas_las_casillas.id_ocupado_blancas
                    )
                  )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                   (
                   !no_se_sale_del_array(id_casilla_numero - id_contador)
                   ||
                   todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                          (
                              todas_las_casillas.id_casillas
                              [
                              this.id_casilla_numero - id_contador
                              ,
                              this.id_casilla_letra
                              ]
                              ,
                              todas_las_casillas.id_ocupado_negras
                          )
                    )
                {
                    if (no_se_sale_del_array(id_casilla_numero - id_contador))
                    {
                        desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra
                    );
                    }
                    limite_vertical_torre = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_abajo_negro()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                 (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                    (
                       todas_las_casillas.id_casillas
                       [
                       this.id_casilla_numero - id_contador
                       ,
                       this.id_casilla_letra
                       ]
                       ,
                       todas_las_casillas.id_ocupado_negras
                    )
                  )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                   (
                   !no_se_sale_del_array(id_casilla_numero - id_contador)
                   ||
                   todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                          (
                              todas_las_casillas.id_casillas
                              [
                              this.id_casilla_numero - id_contador
                              ,
                              this.id_casilla_letra
                              ]
                              ,
                              todas_las_casillas.id_ocupado_blancas
                          )
                    )
                {
                    if (no_se_sale_del_array(id_casilla_numero - id_contador))
                    {
                        desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra
                    );
                    }
                    limite_vertical_torre = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_izquierda_blanco()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                 (
           this.id_casilla_numero 
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                    (
                       todas_las_casillas.id_casillas
                       [
                       this.id_casilla_numero 
                       ,
                       this.id_casilla_letra - id_contador
                       ]
                       ,
                       todas_las_casillas.id_ocupado_blancas
                    )
                  )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                   (
                   !no_se_sale_del_array(id_casilla_letra - id_contador)
                   ||
                   todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                          (
                              todas_las_casillas.id_casillas
                              [
                              this.id_casilla_numero 
                              ,
                              this.id_casilla_letra - id_contador
                              ]
                              ,
                              todas_las_casillas.id_ocupado_negras
                          )
                    )
                {
                    if (no_se_sale_del_array(id_casilla_letra - id_contador))
                    {
                        desactivar_casillas(
                    id_casilla_numero 
                    ,
                    id_casilla_letra - id_contador
                    );
                    }
                    limite_vertical_torre = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero 
                    ,
                    id_casilla_letra - id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_izquierda_negro()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                 (
           this.id_casilla_numero
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                    (
                       todas_las_casillas.id_casillas
                       [
                       this.id_casilla_numero
                       ,
                       this.id_casilla_letra - id_contador
                       ]
                       ,
                       todas_las_casillas.id_ocupado_negras
                    )
                  )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                   (
                   !no_se_sale_del_array(id_casilla_letra - id_contador)
                   ||
                   todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                          (
                              todas_las_casillas.id_casillas
                              [
                              this.id_casilla_numero
                              ,
                              this.id_casilla_letra - id_contador
                              ]
                              ,
                              todas_las_casillas.id_ocupado_blancas
                          )
                    )
                {
                    if (no_se_sale_del_array(id_casilla_letra - id_contador))
                    {
                        desactivar_casillas(
                    id_casilla_numero
                    ,
                    id_casilla_letra - id_contador
                    );
                    }
                    limite_vertical_torre = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero
                    ,
                    id_casilla_letra - id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_derecha_blanco()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                 (
           this.id_casilla_numero
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                    (
                       todas_las_casillas.id_casillas
                       [
                       this.id_casilla_numero
                       ,
                       this.id_casilla_letra + id_contador
                       ]
                       ,
                       todas_las_casillas.id_ocupado_blancas
                    )
                  )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                   (
                   !no_se_sale_del_array(id_casilla_letra + id_contador)
                   ||
                   todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                          (
                              todas_las_casillas.id_casillas
                              [
                              this.id_casilla_numero
                              ,
                              this.id_casilla_letra + id_contador
                              ]
                              ,
                              todas_las_casillas.id_ocupado_negras
                          )
                    )
                {
                    if (no_se_sale_del_array(id_casilla_letra + id_contador))
                    {
                        desactivar_casillas(
                    id_casilla_numero
                    ,
                    id_casilla_letra + id_contador
                    );
                    }
                    limite_vertical_torre = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero
                    ,
                    id_casilla_letra + id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_derecha_negro()
    {
        bool limite_vertical_torre = false;
        int id_contador = 1;
        while (!limite_vertical_torre)
        {
            if (
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                 (
           this.id_casilla_numero
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                    (
                       todas_las_casillas.id_casillas
                       [
                       this.id_casilla_numero
                       ,
                       this.id_casilla_letra + id_contador
                       ]
                       ,
                       todas_las_casillas.id_ocupado_negras
                    )
                  )
                )
            {
                limite_vertical_torre = true;
            }
            else
            {
                if
                   (
                   !no_se_sale_del_array(id_casilla_letra + id_contador)
                   ||
                   todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                          (
                              todas_las_casillas.id_casillas
                              [
                              this.id_casilla_numero
                              ,
                              this.id_casilla_letra + id_contador
                              ]
                              ,
                              todas_las_casillas.id_ocupado_blancas
                          )
                    )
                {
                    if (no_se_sale_del_array(id_casilla_letra + id_contador))
                    {
                        desactivar_casillas(
                    id_casilla_numero
                    ,
                    id_casilla_letra + id_contador
                    );
                    }
                    limite_vertical_torre = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero
                    ,
                    id_casilla_letra + id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_caballo_blanco()
    {
        activar_pieza_pulsada();

        int nueva_casilla_activada_numero = id_casilla_numero + 2;
        int nueva_casilla_activada_letra = id_casilla_letra - 1;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_blancas

            );


        nueva_casilla_activada_letra = id_casilla_letra + 1;

        comprobar_si_se_puede_activar_casilla_y_activarla
        (
        nueva_casilla_activada_numero
        ,
        nueva_casilla_activada_letra
        ,
        todas_las_casillas.id_ocupado_blancas

        );

        nueva_casilla_activada_numero = id_casilla_numero + 1;
        nueva_casilla_activada_letra = id_casilla_letra - 2;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_blancas

            );

        nueva_casilla_activada_numero = id_casilla_numero + 1;
        nueva_casilla_activada_letra = id_casilla_letra + 2;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_blancas

            );


        nueva_casilla_activada_numero = id_casilla_numero - 2;
        nueva_casilla_activada_letra = id_casilla_letra + 1;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_blancas

            );

        nueva_casilla_activada_letra = id_casilla_letra - 1;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_blancas

            );

        nueva_casilla_activada_numero = id_casilla_numero - 1;
        nueva_casilla_activada_letra = id_casilla_letra + 2;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_blancas

            );

        nueva_casilla_activada_numero = id_casilla_numero - 1;
        nueva_casilla_activada_letra = id_casilla_letra - 2;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_blancas

            );
    }

    public void activar_piezas_caballo_negro()
    {
        activar_pieza_pulsada();

        int nueva_casilla_activada_numero = id_casilla_numero + 2;
        int nueva_casilla_activada_letra = id_casilla_letra - 1;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_negras

            );


        nueva_casilla_activada_letra = id_casilla_letra + 1;

        comprobar_si_se_puede_activar_casilla_y_activarla
        (
        nueva_casilla_activada_numero
        ,
        nueva_casilla_activada_letra
        ,
        todas_las_casillas.id_ocupado_negras

        );

        nueva_casilla_activada_numero = id_casilla_numero + 1;
        nueva_casilla_activada_letra = id_casilla_letra - 2;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_negras

            );

        nueva_casilla_activada_numero = id_casilla_numero + 1;
        nueva_casilla_activada_letra = id_casilla_letra + 2;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_negras

            );


        nueva_casilla_activada_numero = id_casilla_numero - 2;
        nueva_casilla_activada_letra = id_casilla_letra + 1;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_negras

            );

        nueva_casilla_activada_letra = id_casilla_letra - 1;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_negras

            );

        nueva_casilla_activada_numero = id_casilla_numero - 1;
        nueva_casilla_activada_letra = id_casilla_letra + 2;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_negras

            );

        nueva_casilla_activada_numero = id_casilla_numero - 1;
        nueva_casilla_activada_letra = id_casilla_letra - 2;

        comprobar_si_se_puede_activar_casilla_y_activarla
            (
            nueva_casilla_activada_numero
            ,
            nueva_casilla_activada_letra
            ,
            todas_las_casillas.id_ocupado_negras

            );
    }

    public void desactivar_piezas_caballos()
    {
        int nueva_casilla_activada_numero = id_casilla_numero + 2;
        int nueva_casilla_activada_letra = id_casilla_letra - 1;


        desactivar_casillas(nueva_casilla_activada_numero, nueva_casilla_activada_letra);


        nueva_casilla_activada_letra = id_casilla_letra + 1;

        desactivar_casillas(nueva_casilla_activada_numero, nueva_casilla_activada_letra);

        nueva_casilla_activada_numero = id_casilla_numero + 1;
        nueva_casilla_activada_letra = id_casilla_letra - 2;

        desactivar_casillas(nueva_casilla_activada_numero, nueva_casilla_activada_letra);

        nueva_casilla_activada_numero = id_casilla_numero + 1;
        nueva_casilla_activada_letra = id_casilla_letra + 2;

        desactivar_casillas(nueva_casilla_activada_numero, nueva_casilla_activada_letra);


        nueva_casilla_activada_numero = id_casilla_numero - 2;
        nueva_casilla_activada_letra = id_casilla_letra + 1;

        desactivar_casillas(nueva_casilla_activada_numero, nueva_casilla_activada_letra);

        nueva_casilla_activada_letra = id_casilla_letra - 1;

        desactivar_casillas(nueva_casilla_activada_numero, nueva_casilla_activada_letra);

        nueva_casilla_activada_numero = id_casilla_numero - 1;
        nueva_casilla_activada_letra = id_casilla_letra + 2;

        desactivar_casillas(nueva_casilla_activada_numero, nueva_casilla_activada_letra);

        nueva_casilla_activada_numero = id_casilla_numero - 1;
        nueva_casilla_activada_letra = id_casilla_letra - 2;

        desactivar_casillas(nueva_casilla_activada_numero, nueva_casilla_activada_letra);

        desactivar_pieza_pulsada();
    }

    public void activar_piezas_diagonal_arriba_izquierda_blanco()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    limite_alfil = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_diagonal_arriba_izquierda_negro()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    limite_alfil = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_diagonal_arriba_derecha_blanco()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    limite_alfil = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_diagonal_arriba_derecha_negro()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    limite_alfil = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_diagonal_abajo_izquierda_blanco()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    limite_alfil = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_diagonal_abajo_izquierda_negro()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    limite_alfil = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_diagonal_abajo_derecha_blanco()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    limite_alfil = true;
                }
                id_contador++;
            }
        }
    }

    public void activar_piezas_diagonal_abajo_derecha_negro()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    limite_alfil = true;
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_diagonal_arriba_izquierda_blanco()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra - id_contador
                    );
                    limite_alfil = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra - id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_diagonal_arriba_izquierda_negro()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra - id_contador
                    );
                    limite_alfil = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra - id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_diagonal_arriba_derecha_blanco()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra + id_contador
                    );
                    limite_alfil = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra + id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_diagonal_arriba_derecha_negro()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero + id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero + id_contador
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero + id_contador
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero + id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero + id_contador
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra + id_contador
                    );
                    limite_alfil = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero + id_contador
                    ,
                    id_casilla_letra + id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_diagonal_abajo_izquierda_blanco()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra - id_contador
                    );
                    limite_alfil = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra - id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_diagonal_abajo_izquierda_negro()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra - id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra - id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra - id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra - id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra - id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra - id_contador
                    );
                    limite_alfil = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra - id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_diagonal_abajo_derecha_blanco()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_blancas
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_negras
                            )
                        )
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra + id_contador
                    );
                    limite_alfil = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra + id_contador
                    );
                }
                id_contador++;
            }
        }
    }

    public void desactivar_piezas_diagonal_abajo_derecha_negro()
    {
        bool limite_alfil = false;
        int id_contador = 1;
        while (!limite_alfil)
        {
            if (
                no_se_sale_del_array(id_casilla_numero - id_contador)
                &&
                no_se_sale_del_array(id_casilla_letra + id_contador)
                &&
                !
                comprobar_si_se_puede_activar_casilla_y_activarla
                    (
           this.id_casilla_numero - id_contador
           ,
           this.id_casilla_letra + id_contador
           ,
           !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                        (
                            todas_las_casillas.id_casillas
                            [
                            this.id_casilla_numero - id_contador
                            ,
                            this.id_casilla_letra + id_contador
                            ]
                            ,
                            todas_las_casillas.id_ocupado_negras
                        )
                    )
                )
            {
                limite_alfil = true;
            }
            else
            {
                if
                (
                !no_se_sale_del_array(id_casilla_numero - id_contador)
                    ||
                !no_se_sale_del_array(id_casilla_letra + id_contador)
                    ||
                        todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
                            (
                                todas_las_casillas.id_casillas
                                [
                                this.id_casilla_numero - id_contador
                                ,
                                this.id_casilla_letra + id_contador
                                ]
                                ,
                                todas_las_casillas.id_ocupado_blancas
                            )
                        )
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra + id_contador
                    );
                    limite_alfil = true;
                }
                else
                {
                    desactivar_casillas(
                    id_casilla_numero - id_contador
                    ,
                    id_casilla_letra + id_contador
                    );
                }
                id_contador++;
            }
        }
    }

  

    public bool comprobar_si_rey_blanco_puede_moverse()
    {
        bool resultado = false;

        if
                (
                    //comprobar_si_rey_blanco_puede_estar_en_la_casilla
                    //(
                    //id_casilla_numero + 1, id_casilla_letra - 1
                    //)
                    //&&
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero + 1, id_casilla_letra - 1, todas_las_casillas.id_ocupado_blancas)
                )
        {
            resultado = true;
                todas_las_casillas.activar_casilla(id_casilla_numero + 1, id_casilla_letra - 1);
            
        }

        if
                (
                    //comprobar_si_rey_blanco_puede_estar_en_la_casilla
                    //(
                    //id_casilla_numero + 1, id_casilla_letra
                    //)
                    //&&
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero + 1, id_casilla_letra, todas_las_casillas.id_ocupado_blancas)
                )
        {
            resultado = true;
                todas_las_casillas.activar_casilla(id_casilla_numero + 1, id_casilla_letra);
        }

        if
                (
                    //comprobar_si_rey_blanco_puede_estar_en_la_casilla
                    //(
                    //id_casilla_numero + 1, id_casilla_letra + 1
                    //)
                    //&&
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero + 1, id_casilla_letra+1, todas_las_casillas.id_ocupado_blancas)
                )
        {
            resultado = true;
                todas_las_casillas.activar_casilla(id_casilla_numero + 1, id_casilla_letra + 1);
        }

        if
                (
                    //comprobar_si_rey_blanco_puede_estar_en_la_casilla
                    //(
                    //id_casilla_numero, id_casilla_letra - 1
                    //)
                    //&&
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero, id_casilla_letra-1, todas_las_casillas.id_ocupado_blancas)
                )
        {
            resultado = true;
                todas_las_casillas.activar_casilla(id_casilla_numero, id_casilla_letra - 1);
        }

        if
                (
                    //comprobar_si_rey_blanco_puede_estar_en_la_casilla
                    //(
                    //id_casilla_numero, id_casilla_letra + 1
                    //)
                    //&&
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero, id_casilla_letra+1, todas_las_casillas.id_ocupado_blancas)
                )
        {
            resultado = true;
                todas_las_casillas.activar_casilla(id_casilla_numero, id_casilla_letra + 1);
        }

        if
                (
                    //comprobar_si_rey_blanco_puede_estar_en_la_casilla
                    //(
                    //id_casilla_numero - 1, id_casilla_letra - 1
                    //)
                    //&&
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero -1, id_casilla_letra -1, todas_las_casillas.id_ocupado_blancas)
                )
        {
            resultado = true;
                todas_las_casillas.activar_casilla(id_casilla_numero - 1, id_casilla_letra - 1);
        }

        if
                (
                    //comprobar_si_rey_blanco_puede_estar_en_la_casilla
                    //(
                    //id_casilla_numero -1, id_casilla_letra
                    //)
                    //&&
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero - 1, id_casilla_letra, todas_las_casillas.id_ocupado_blancas)
                )
        {
            resultado = true;
                todas_las_casillas.activar_casilla(id_casilla_numero - 1, id_casilla_letra);
        }

        if
                (
                    //comprobar_si_rey_blanco_puede_estar_en_la_casilla
                    //(
                    //id_casilla_numero - 1, id_casilla_letra + 1
                    //)
                    //&&
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero - 1, id_casilla_letra+1, todas_las_casillas.id_ocupado_blancas)
                )
        {
            resultado = true;
                todas_las_casillas.activar_casilla(id_casilla_numero - 1, id_casilla_letra + 1);
        }

        comprobar_y_activar_enroque_izquierda();
        comprobar_y_activar_enroque_derecha();

        return resultado;
    }

    public bool comprobar_si_rey_negro_puede_moverse()
    {
        bool resultado = false;

        if
                (
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero + 1, id_casilla_letra - 1, todas_las_casillas.id_ocupado_negras)
                )
        {
            resultado = true;
            todas_las_casillas.activar_casilla(id_casilla_numero + 1, id_casilla_letra - 1);

        }

        if
                (
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero + 1, id_casilla_letra, todas_las_casillas.id_ocupado_negras)
                )
        {
            resultado = true;
            todas_las_casillas.activar_casilla(id_casilla_numero + 1, id_casilla_letra);
        }

        if
                (
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero + 1, id_casilla_letra + 1, todas_las_casillas.id_ocupado_negras)
                )
        {
            resultado = true;
            todas_las_casillas.activar_casilla(id_casilla_numero + 1, id_casilla_letra + 1);
        }

        if
                (
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero, id_casilla_letra - 1, todas_las_casillas.id_ocupado_negras)
                )
        {
            resultado = true;
            todas_las_casillas.activar_casilla(id_casilla_numero, id_casilla_letra - 1);
        }

        if
                (
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero, id_casilla_letra + 1, todas_las_casillas.id_ocupado_negras)
                )
        {
            resultado = true;
            todas_las_casillas.activar_casilla(id_casilla_numero, id_casilla_letra + 1);
        }

        if
                (
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero - 1, id_casilla_letra - 1, todas_las_casillas.id_ocupado_negras)
                )
        {
            resultado = true;
            todas_las_casillas.activar_casilla(id_casilla_numero - 1, id_casilla_letra - 1);
        }

        if
                (
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero - 1, id_casilla_letra, todas_las_casillas.id_ocupado_negras)
                )
        {
            resultado = true;
            todas_las_casillas.activar_casilla(id_casilla_numero - 1, id_casilla_letra);
        }

        if
                (
                    comprobar_si_se_puede_activar_casilla_y_activarla(id_casilla_numero - 1, id_casilla_letra + 1, todas_las_casillas.id_ocupado_negras)
                )
        {
            resultado = true;
            todas_las_casillas.activar_casilla(id_casilla_numero - 1, id_casilla_letra + 1);
        }

        comprobar_y_activar_enroque_izquierda();
        comprobar_y_activar_enroque_derecha();

        return resultado;
    }

    public void desactivar_casillas_rey()
    {
        desactivar_casillas(id_casilla_numero + 1, id_casilla_letra - 1);
        desactivar_casillas(id_casilla_numero + 1, id_casilla_letra);
        desactivar_casillas(id_casilla_numero + 1, id_casilla_letra + 1);
        desactivar_casillas(id_casilla_numero, id_casilla_letra - 1);
        desactivar_casillas(id_casilla_numero, id_casilla_letra + 1);
        desactivar_casillas(id_casilla_numero, id_casilla_letra - 2);
        desactivar_casillas(id_casilla_numero, id_casilla_letra + 2);
        desactivar_casillas(id_casilla_numero - 1, id_casilla_letra - 1);
        desactivar_casillas(id_casilla_numero - 1, id_casilla_letra);
        desactivar_casillas(id_casilla_numero - 1, id_casilla_letra + 1);
    }

    public void comprobar_y_activar_enroque_izquierda()
    {
        if(this.id_tipo_pieza==todas_las_piezas.id_rey && no_se_ha_movido)
        {
            int contador_casilla_letra = id_casilla_letra-1;
            bool se_puede_enroque = true;
            
            while(se_puede_enroque && contador_casilla_letra > 0)
            {
                if
                    (
                        todas_las_casillas.id_casillas[id_casilla_numero, contador_casilla_letra].ocupado
                        ==
                        todas_las_casillas.id_no_ocupado                        
                    )
                {
                    contador_casilla_letra--;
                }
                else
                {
                    se_puede_enroque = false;
                }
            }

            if
                (
                    se_puede_enroque 
                    &&
                    todas_las_casillas.id_casillas[id_casilla_numero, 0].ocupado
                    !=
                    todas_las_casillas.id_no_ocupado
                    &&
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas[id_casilla_numero,0]
                        ).id_tipo_pieza==todas_las_piezas.id_torre
                    &&
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas[id_casilla_numero, 0]
                        ).no_se_ha_movido
                )
            {
                todas_las_casillas.activar_casilla(id_casilla_numero, id_casilla_letra - 2);
            }
                
        }
    }

    public void comprobar_y_activar_enroque_derecha()
    {
        if (this.id_tipo_pieza == todas_las_piezas.id_rey && no_se_ha_movido)
        {
            int contador_casilla_letra = id_casilla_letra + 1;
            bool se_puede_enroque = true;

            while (se_puede_enroque && contador_casilla_letra < 7)
            {
                if
                    (
                        todas_las_casillas.id_casillas[id_casilla_numero, contador_casilla_letra].ocupado
                        ==
                        todas_las_casillas.id_no_ocupado
                    )
                {
                    contador_casilla_letra++;
                }
                else
                {
                    se_puede_enroque = false;
                }
            }

            if
                (
                    se_puede_enroque
                    &&
                    todas_las_casillas.id_casillas[id_casilla_numero, 7].ocupado
                    !=
                    todas_las_casillas.id_no_ocupado
                    &&
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas[id_casilla_numero, 7]
                        ).id_tipo_pieza == todas_las_piezas.id_torre
                    &&
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                        (
                        todas_las_casillas.id_casillas[id_casilla_numero, 7]
                        ).no_se_ha_movido
                )
            {
                todas_las_casillas.activar_casilla(id_casilla_numero, id_casilla_letra + 2);
            }

        }
    }

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

    public void activar_pieza_pulsada()
    {
        pieza_activa = true;
        todas_las_piezas.hay_una_pieza_activa = true;
        todas_las_piezas.pieza_activada = this;
        todas_las_casillas.activar_casilla( todas_las_casillas.id_casillas[id_casilla_numero,id_casilla_letra]);
    }

    public void desactivar_pieza_pulsada()
    {
        pieza_activa = false;
        todas_las_piezas.hay_una_pieza_activa = false;
        todas_las_casillas.desactivar_casilla(todas_las_casillas.id_casillas[id_casilla_numero, id_casilla_letra]);
    }

    public void desactivar_casillas(int id_numero, int id_letra)
    {
        if (no_se_sale_del_array(id_numero)
                &&
                no_se_sale_del_array(id_letra)
                )
        {
            todas_las_casillas.desactivar_casilla(todas_las_casillas.id_casillas[id_numero, id_letra]);
        }
    }

    public bool comprobar_si_se_puede_activar_casilla_y_activarla(int id_numero, int id_letra, int id_ocupado_no_se_puede)
    {
        if
          (
              no_se_sale_del_array(id_numero)
                  &&
              no_se_sale_del_array(id_letra)
                  &&
(
          !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
              (


                  todas_las_casillas.id_casillas
                  [
                  id_numero
                  ,
                  id_letra
                  ]
              ,
                  id_ocupado_no_se_puede
              )
  
)
          )
        {

            todas_las_casillas.activar_casilla(
               todas_las_casillas.id_casillas
               [
               id_numero
               ,
               id_letra
               ]);

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool peon_comprobar_si_se_puede_activar_casilla_y_activarla(int id_numero, int id_letra, int id_ocupado_si_se_puede)
    {
        if
          (
              no_se_sale_del_array(id_numero)
                  &&
              no_se_sale_del_array(id_letra)
                  &&
          todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
              (


                  todas_las_casillas.id_casillas
                  [
                  id_numero
                  ,
                  id_letra
                  ]
              ,
                  id_ocupado_si_se_puede
              )
                  // Si no hay jaque o comprobar si esa casilla neutralizada evita el jaque
                  &&
              (     
                   ( 
                   !la_partida.jaque_a_blancas
                   &&
                   !la_partida.jaque_a_negras
                   )
                   ||
                   la_partida.comprobar_si_casilla_neutralizada_evita_el_jaque
                   (
                       todas_las_casillas.id_casillas
                        [
                        id_numero
                        ,
                        id_letra
                        ]
                   )
              )
              

          )
        {

            todas_las_casillas.activar_casilla(
               todas_las_casillas.id_casillas
               [
               id_numero
               ,
               id_letra
               ]);

            return true;
        }
        else
        {
            return false;
        }
    }


    public bool peon_comprobar_si_se_puede_activar_casilla_y_activarla(int id_numero, int id_letra, bool condicion_extra, int id_ocupado_si_se_puede)
    {
        if
          (
              no_se_sale_del_array(id_numero)
                  &&
              no_se_sale_del_array(id_letra)
                  &&
          todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
              (


                  todas_las_casillas.id_casillas
                  [
                  id_numero
                  ,
                  id_letra
                  ]
              ,
                  id_ocupado_si_se_puede
              )
              &&
              condicion_extra
                  // Si no hay jaque o comprobar si esa casilla neutralizada evita el jaque
                  &&
              (
                   (
                   !la_partida.jaque_a_blancas
                   &&
                   !la_partida.jaque_a_negras
                   )
                   ||
                   la_partida.comprobar_si_casilla_neutralizada_evita_el_jaque
                   (
                       todas_las_casillas.id_casillas
                        [
                        id_numero
                        ,
                        id_letra
                        ]
                   )
              )

          )
        {

            todas_las_casillas.activar_casilla(
               todas_las_casillas.id_casillas
               [
               id_numero
               ,
               id_letra
               ]);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool comprobar_si_se_puede_activar_casilla_y_activarla(int id_numero, int id_letra, bool condicion)
    {
        if
          (
              no_se_sale_del_array(id_numero)
                  &&
              no_se_sale_del_array(id_letra)
                  &&
              condicion
                  // Si no hay jaque o comprobar si esa casilla neutralizada evita el jaque
                  &&
              (
                   (
                   !la_partida.jaque_a_blancas
                   &&
                   !la_partida.jaque_a_negras
                   )
                   ||
                   la_partida.comprobar_si_casilla_neutralizada_evita_el_jaque
                   (
                       todas_las_casillas.id_casillas
                        [
                        id_numero
                        ,
                        id_letra
                        ]
                   )
              )

          )
        {

            todas_las_casillas.activar_casilla(
               todas_las_casillas.id_casillas
               [
               id_numero
               ,
               id_letra
               ]);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void comprobar_si_se_puede_activar_casilla_y_activarla_comida_al_paso(int id_numero_pieza_a_comer, int id_letra_pieza_a_comer, int id_ocupado_color_del_que_come, int id_ocupado_color_victima)
    {
        if(id_ocupado_color_del_que_come==todas_las_casillas.id_ocupado_blancas)
        {
            if
          (
              no_se_sale_del_array(id_numero_pieza_a_comer)
                  &&
              no_se_sale_del_array(id_letra_pieza_a_comer)
                  &&
               todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    todas_las_casillas.id_casillas[id_numero_pieza_a_comer, id_letra_pieza_a_comer]
                )
                  &&
                todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                ( 
                    todas_las_casillas.id_casillas[id_numero_pieza_a_comer,id_letra_pieza_a_comer]
                ).victima_de_comida_al_paso
                &&
          todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
              (


                  todas_las_casillas.id_casillas
                  [
                  id_numero_pieza_a_comer
                  ,
                  id_letra_pieza_a_comer
                  ]
              ,
                  id_ocupado_color_victima
              )
                  &&
          !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
              (


                  todas_las_casillas.id_casillas
                  [
                  id_numero_pieza_a_comer+1
                  ,
                  id_letra_pieza_a_comer
                  ]
              ,
                  id_ocupado_color_del_que_come
              )

        )

          
            {
               

                todas_las_casillas.activar_casilla(
                   todas_las_casillas.id_casillas
                   [
                   id_numero_pieza_a_comer + 1
                   ,
                   id_letra_pieza_a_comer
                   ]);
            }


        }
        else
        {
            if
         (
             no_se_sale_del_array(id_numero_pieza_a_comer)
                 &&
             no_se_sale_del_array(id_letra_pieza_a_comer)
                 &&                 
               todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    todas_las_casillas.id_casillas[id_numero_pieza_a_comer, id_letra_pieza_a_comer]
                )
                &&
               todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
               (
                   todas_las_casillas.id_casillas[id_numero_pieza_a_comer, id_letra_pieza_a_comer]
               ).victima_de_comida_al_paso
                 &&
                       todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
              (


                  todas_las_casillas.id_casillas
                  [
                  id_numero_pieza_a_comer
                  ,
                  id_letra_pieza_a_comer
                  ]
              ,
                  id_ocupado_color_victima
              )
                &&
         !todas_las_casillas.comprobar_si_casilla_ocupada_por_alguna_pieza
             (


                 todas_las_casillas.id_casillas
                 [
                 id_numero_pieza_a_comer - 1
                 ,
                 id_letra_pieza_a_comer
                 ]
             ,
                 id_ocupado_color_del_que_come
             )


         )
            {

                todas_las_casillas.activar_casilla(
                   todas_las_casillas.id_casillas
                   [
                   id_numero_pieza_a_comer - 1
                   ,
                   id_letra_pieza_a_comer
                   ]);
            }
        }
        
    }

    public void esta_pieza_es_comida()
    {
        /*
        if(!la_partida.partida_terminada && this.id_tipo_pieza==todas_las_piezas.id_rey)
        {
            if(this.es_blanca)
            {
                la_partida.blancas_perdieron();
            }
            else
            {
                la_partida.negras_perdieron();
            }
        }
        else
        {
        */
            if
           (
               la_partida.comprobar_si_casilla_neutralizada_evita_el_jaque
               (
                   todas_las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
                   (
                   this
                   )
               )
           )
            {
               
                la_partida.ya_no_hay_jaque();
            }
            this.fue_comida = true;
            this.transform.position = this.posicion_pieza_comida.transform.position;
        //}
        
    }

    public void Awake()
    {

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



