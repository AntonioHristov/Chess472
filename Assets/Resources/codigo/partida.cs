using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partida : MonoBehaviour
{

    /*
     INVESTIGAR EL BUG AL DAR BOTON REINICIAR EVITAR QUE SALGA EL MENSAJE JAQUE
    */


    public piezas las_piezas;
    public casillas las_casillas;
    public Box_promote la_caja_corona;
    public Box_confirm_promotion la_caja_confirmar_corona;
    public Box_read leeme;
    public propiedades_pieza rey_blanco;
    public propiedades_pieza rey_negro;
    public bool turno_blancas = true;
    public bool partida_terminada = false;


    public bool jaque_a_blancas = false;
    public bool jaque_a_negras = false;
    public bool mate_a_blancas = false;
    public bool mate_a_negras = false;


    public propiedades_casilla[] casillas_en_medio_del_jaque = new propiedades_casilla[8];
    public int cantidad_casillas_en_medio_del_jaque_por_ahora = 0;
    public propiedades_pieza pieza_que_hace_jaque;
    public propiedades_pieza pieza_que_hace_jaque_2;
    public propiedades_casilla casilla_del_rey_en_jaque;

    private bool id_turno_blancas = true;
    private bool id_turno_negras = false;


    public void nueva_partida()
    {
        for(int i=0;i<2;i++)
        {
            valores_por_defecto_de_la_partida();
            valores_por_defecto_de_las_casillas();
            valores_por_defecto_de_las_piezas();
        }
        
        

    }

    public void elegir_turno(bool id_turno)
    {
        if(!turno_blancas==id_turno)
        {
            turno_blancas = id_turno;
            girar_tablero();
        }
        
        las_piezas.actualizar_valor_cliqueable_y_girar_piezas();
    }

    public void nuevo_turno()
    {
        turno_blancas = !turno_blancas;
        girar_tablero();
        las_casillas.actualizar_casillas_atacadas();
        las_piezas.desactivar_comida_al_paso_todos_los_peones_del_color_especificado(turno_blancas);
        las_piezas.actualizar_valor_cliqueable_y_girar_piezas();
        //comprobar_si_es_jaque_o_jaque_mate();


    }

    public void girar_tablero()
    {
        if(turno_blancas)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+64, this.transform.position.z);
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y -64, this.transform.position.z);
            this.transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

    public void salir_del_juego()
    {
        Application.Quit();
    }

    public void valores_por_defecto_de_la_partida()
    {
        
        jaque_a_blancas = false;
        jaque_a_negras = false;
        mate_a_blancas = false;
        mate_a_negras = false;       
        partida_terminada = false;
        ya_no_hay_jaque();
        elegir_turno(id_turno_blancas);
    }

    public void valores_por_defecto_de_las_casillas()
    {
        las_casillas.actualizar_casillas_atacadas();
    }

    public void valores_por_defecto_de_las_piezas()
    {
        las_piezas.desactivar_pieza_activa_y_movimientos_posibles();
        las_piezas.dar_valores_por_defecto_a_las_piezas();       
        las_piezas.asignando_piezas_a_las_casillas_iniciales();
    }

    public void blancas_perdieron()
    {
        partida_terminada = true;
        leeme.mostrar_caja_de_texto_leer("JAQUE MATE", "Ganaron las negras", "Ok");
    }

    public void negras_perdieron()
    {
        partida_terminada = true;
        leeme.mostrar_caja_de_texto_leer("JAQUE MATE", "Ganaron las blancas", "Ok");
    }

    public void empate()
    {
        partida_terminada = true;
        leeme.mostrar_caja_de_texto_leer("EMPATE", "Nadie ganó", "Ok");
    }

    public void jaque()
    {
        leeme.mostrar_caja_de_texto_leer("JAQUE", "Jaque al rey", "Ok");
    }

    public void vaciar_tabla_casillas_en_medio_del_jaque()
    {
        for(int contador=0; contador<casillas_en_medio_del_jaque.Length; contador++)
        {
            casillas_en_medio_del_jaque[contador] = null;
            casillas_en_medio_del_jaque[contador] = null;
        }

      
    }

    public void pasar_casilla_a_en_medio_del_jaque(propiedades_casilla casilla)
    {

        casillas_en_medio_del_jaque[cantidad_casillas_en_medio_del_jaque_por_ahora] = casilla;
        cantidad_casillas_en_medio_del_jaque_por_ahora += 1;
    }

    public void ninguna_pieza_hace_jaque()
    {
        pieza_que_hace_jaque = null;
        pieza_que_hace_jaque_2 = null;
    }

    
    public bool hay_jaque_doble()
    {

        if(pieza_que_hace_jaque_2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    

    public void hay_jaque_con_parametros
        (
        propiedades_pieza pieza_que_da_jaque
        , 
        propiedades_casilla casilla_rey_jaqueado)
    {
        jaque();
        pieza_que_hace_jaque = pieza_que_da_jaque;
        casilla_del_rey_en_jaque = casilla_rey_jaqueado;
        if(pieza_que_hace_jaque.es_blanca)
        {
            jaque_a_negras = true;
        }
        else
        {
            jaque_a_blancas = true;
        }
    }

    public void hay_jaque_con_parametros
      (
      propiedades_pieza pieza_que_da_jaque
      ,
      propiedades_pieza pieza_que_da_jaque_2
      ,
      propiedades_casilla casilla_rey_jaqueado)
    {
        jaque();
        pieza_que_hace_jaque = pieza_que_da_jaque;
        pieza_que_hace_jaque_2 = pieza_que_da_jaque_2;
        casilla_del_rey_en_jaque = casilla_rey_jaqueado;
        if (pieza_que_hace_jaque.es_blanca)
        {
            jaque_a_negras = true;
        }
        else
        {
            jaque_a_blancas = true;
        }
    }

    public void ya_no_hay_jaque()
    {
        pieza_que_hace_jaque = null;
        pieza_que_hace_jaque_2 = null;
        casilla_del_rey_en_jaque = null;
        jaque_a_blancas = false;
        jaque_a_negras = false;
        cantidad_casillas_en_medio_del_jaque_por_ahora = 0;
        vaciar_tabla_casillas_en_medio_del_jaque();
  
    }

    public bool comprobar_si_casilla_neutralizada_evita_el_jaque(propiedades_casilla casilla)
    {
        if (pieza_que_hace_jaque_2)
        {
            return false;
        }
        
        bool resultado = false;
        int contador = 0;

        while(!resultado && contador<=cantidad_casillas_en_medio_del_jaque_por_ahora)
        {
            if (casilla == casillas_en_medio_del_jaque[contador])
            {               
                resultado = true;
            }
            else
            {
                contador++;
            }
        }

        return resultado;

    }


    public void mostrar_caja_corona()
    {
        la_caja_confirmar_corona.ocultar_caja_de_texto_confirmar();
        //la_caja_corona.Show();
    }


    public void mostrar_caja_confirma_corona(int tipo_pieza)
    {
        la_caja_corona.Hide();
        la_caja_confirmar_corona.mostrar_caja_de_texto_confirmar(tipo_pieza);
    }


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        nueva_partida();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
