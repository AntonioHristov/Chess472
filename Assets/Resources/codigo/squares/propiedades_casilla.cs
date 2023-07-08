using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class propiedades_casilla : MonoBehaviour, IPointerDownHandler
{


    public casillas todas_las_casillas;
    public piezas todas_las_piezas;
    public partida la_partida;

    private static int id_no_ocupado = 0;
    private static int id_ocupado_blancas = 1;
    private static int id_ocupado_negras = 2;

    public int ocupado=0;
   

    public int id_casilla_numero;
    public int id_casilla_letra;

    public propiedades_pieza pieza_que_la_ocupa;

    public bool casilla_activada = false;
    public int atacado_por_blancas = 0;
    public int atacado_por_negras = 0;

    public Sprite fondo_principal;
    public Sprite fondo_activado;
    


    public void OnPointerDown(PointerEventData eventData)
    {
        if(casilla_activada)
        {
            propiedades_casilla casilla_de_la_pieza_activa = todas_las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta(todas_las_piezas.pieza_activada);



            // SI ENTRA ES PORQUE EL USUARIO PULSÓ EN UNA CASILLA POSIBLE EN LA QUE MOVER LA PIEZA ELEGIDA PREVIAMENTE POR EL USUARIO
            if (
                casilla_de_la_pieza_activa != this
              )
            {


                


                if(todas_las_piezas.pieza_activada.es_blanca)
                {
                    // SI ENTRA ES PORQUE LA PIEZA QUE EL USUARIO HABÍA DECIDIDO MOVER ES UN PEÓN BLANCO
                    if (todas_las_piezas.pieza_activada.id_tipo_pieza == todas_las_piezas.id_peon)
                    {
                        es_peon_blanco();
                    }
                    else 
                    {
                        desactivar_casillas_y_mover();
                    }
                }
                else
                {
                    if (todas_las_piezas.pieza_activada.id_tipo_pieza == todas_las_piezas.id_peon)
                    {
                        es_peon_negro();
                    }
                    else 
                    {
                        desactivar_casillas_y_mover();
                    }
                }

                la_partida.nuevo_turno();

            }
        }
        

    }

    public void es_peon_blanco()
    {
        comprobar_si_peon_blanco_es_victima_de_comida_al_paso_o_si_comio_a_una_victima();
        desactivar_casillas_y_mover();
        comprobar_si_corona_peon_blanco();        
    }

    public void es_peon_negro()
    {
        comprobar_si_peon_negro_es_victima_de_comida_al_paso_o_si_comio_a_una_victima();
        desactivar_casillas_y_mover();
        comprobar_si_corona_peon_negro();
    }

    public void desactivar_casillas_y_mover()
    {
        hacer_enroque_si_es();
        todas_las_piezas.desactivar_pieza_activa_y_movimientos_posibles();
        todas_las_piezas.pieza_activada.no_se_ha_movido = false;
        todas_las_piezas.pieza_activada.pieza_activa = false;      
        todas_las_piezas.asignar_pieza_a_casilla(todas_las_piezas.pieza_activada, this);
        todas_las_piezas.hay_una_pieza_activa = false;
    }

    public void hacer_enroque_si_es()
    {

        if (
            todas_las_piezas.pieza_activada.id_tipo_pieza==todas_las_piezas.id_rey
            &&
            this.id_casilla_letra+2==todas_las_piezas.pieza_activada.id_casilla_letra
          )
        {
            todas_las_piezas.asignar_pieza_a_casilla
                (
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                    (
                    todas_las_casillas.id_casillas[id_casilla_numero, 0]
                    )
                    ,
                    todas_las_casillas.id_casillas[id_casilla_numero, id_casilla_letra + 1]

                );
        }

        if (
           todas_las_piezas.pieza_activada.id_tipo_pieza == todas_las_piezas.id_rey
           &&
           this.id_casilla_letra - 2 == todas_las_piezas.pieza_activada.id_casilla_letra
         )
        {
            todas_las_piezas.asignar_pieza_a_casilla
                (
                    todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                    (
                    todas_las_casillas.id_casillas[id_casilla_numero, 7]
                    )
                    ,
                    todas_las_casillas.id_casillas[id_casilla_numero, id_casilla_letra - 1]

                );
        }
    }

    public bool comprobar_si_corona_peon_blanco()
    {
        propiedades_pieza peon_a_comprobar = todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa(this);
        if (peon_a_comprobar.id_casilla_numero==7)
        {
            todas_las_piezas.peon_que_corona = peon_a_comprobar;
            todas_las_piezas.coronado_es_blanca = true;
            la_partida.mostrar_caja_corona();


            return true;
        }
        else
        {
            return false;
        }
        
    }

    public bool comprobar_si_corona_peon_negro()
    {
        propiedades_pieza peon_a_comprobar = todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa(this);
        if (peon_a_comprobar.id_casilla_numero == 0)
        {
            todas_las_piezas.peon_que_corona = peon_a_comprobar;
            todas_las_piezas.coronado_es_blanca = false;
            la_partida.mostrar_caja_corona();
          

            return true;
        }
        else
        {
            return false;
        }

    }


    public void comprobar_si_peon_blanco_es_victima_de_comida_al_paso_o_si_comio_a_una_victima()
    {
        if(
            this.id_casilla_numero-todas_las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta
            (todas_las_piezas.pieza_activada).id_casilla_numero==2
            )
        {
            todas_las_piezas.pieza_activada.victima_de_comida_al_paso = true;
        }
        else
        {
            todas_las_piezas.pieza_activada.victima_de_comida_al_paso = false;

            if(
                todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    todas_las_casillas.id_casillas
                    [
                    this.id_casilla_numero - 1
                    ,
                    this.id_casilla_letra
                    ]
                )
                &&
                todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    todas_las_casillas.id_casillas
                    [
                    this.id_casilla_numero - 1
                    ,
                    this.id_casilla_letra
                    ]
                ).victima_de_comida_al_paso
                &&
                !todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    todas_las_casillas.id_casillas
                    [
                    this.id_casilla_numero - 1
                    ,
                    this.id_casilla_letra
                    ]
                ).es_blanca

            )

            {

                todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
            (
                todas_las_casillas.id_casillas
                [
                this.id_casilla_numero - 1
                ,
                this.id_casilla_letra
                ]
            ).esta_pieza_es_comida();


                todas_las_casillas.id_casillas
                     [
                    this.id_casilla_numero - 1
                    ,
                    this.id_casilla_letra
                    ].ocupado = todas_las_casillas.id_no_ocupado;
            }

                
        }
    }

    public void comprobar_si_peon_negro_es_victima_de_comida_al_paso_o_si_comio_a_una_victima()
    {
        if (todas_las_piezas.dime_pieza_y_te_digo_en_que_casilla_esta(todas_las_piezas.pieza_activada).id_casilla_numero - this.id_casilla_numero == 2)
        {
            todas_las_piezas.pieza_activada.victima_de_comida_al_paso = true;
        }
        else
        {
            todas_las_piezas.pieza_activada.victima_de_comida_al_paso = false;

            if (
                todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    todas_las_casillas.id_casillas
                    [
                    this.id_casilla_numero + 1
                    ,
                    this.id_casilla_letra
                    ]
                )
                &&
                todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    todas_las_casillas.id_casillas
                    [
                    this.id_casilla_numero + 1
                    ,
                    this.id_casilla_letra
                    ]
                ).victima_de_comida_al_paso
                &&
                todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
                (
                    todas_las_casillas.id_casillas
                    [
                    this.id_casilla_numero + 1
                    ,
                    this.id_casilla_letra
                    ]
                ).es_blanca

            )

            {

                todas_las_casillas.dime_casilla_y_te_devuelvo_la_pieza_que_lo_ocupa
            (
                todas_las_casillas.id_casillas
                [
                this.id_casilla_numero + 1
                ,
                this.id_casilla_letra
                ]
            ).esta_pieza_es_comida();

                todas_las_casillas.id_casillas
                     [
                    this.id_casilla_numero + 1
                    ,
                    this.id_casilla_letra
                    ].ocupado = todas_las_casillas.id_no_ocupado;
            }
        }
    }

 
    public int numeros_no_salgan_del_array(int numero)
    {
        if (numero > 7)
        {
            return 7;
        }
        else if (numero < 0)
        {
            return 0;
        }
        else
        {
            return numero;
        }
    }

    public void Awake()
    {


        ocupado = id_no_ocupado;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
