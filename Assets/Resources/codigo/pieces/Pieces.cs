using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pieces : MonoBehaviour
{
    // FIXME: I DON`T REMEMBER WHY I CREATE THIS, MAYBE REMOVE IT.
    public const int ID_ERROR = -1;
    //

    /// <summary>
    /// IT'S ALL PIECES IN THE GAME
    /// </summary>
    private APiece[] in_game = new APiece[0];

    /// <summary>
    /// THE BOARD WHICH HAS THIS, THE SQUARES, THE GAME, ETC
    /// </summary>
    public Board board { get; set; }



    #region APiece

    #region Rotate

    /// <summary>
    /// ROTATE 180º THE IMAGE OF THE PIECES
    /// </summary>
    /// <param name="pieces_list"></param>
    public void Rotate(APiece[] pieces_list)
    {
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                Common.Rotate_z(piece.gameObject);
            }
        }
    }

    /// <summary>
    /// THIS METHOD ROTATE ALL PIECES (THE IMAGE) IN THE GAME.
    /// <para>ITS USE WHEN THE TURN IN A GAME ENDS AND THERE'S A NEW TURN.</para>
    /// </summary>
    public void Rotate_in_game()
    {
        this.Rotate(this.in_game);
    }

    //FIXME: TRY TO ADD THE ROTATION PARAM (Vector3.zero)
    /// <summary>
    /// THIS METHOD ROTATES THE PIECES GIVEN BY PARAM WITH THE MAIN ROTATION
    /// <para>BY DEFAULT THE MAIN ROTATION IS BY WHITE WHICH IS Vector3.zero</para>
    /// </summary>
    /// <param name="pieces_list"></param>
    public void Rotate_default(APiece[] pieces_list)
    {
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.transform.eulerAngles = Vector3.zero;
            }
        }
    }

    /// <summary>
    /// THIS METHOD ROTATES ALL PIECES IN THE GAME WITH THE FIRST ROTATION BY DEFAULT,
    /// WITH WHITE (FOR NOW, BECAUSE IN THE FUTURE MAYBE THIS CAN BE CUSTOMIZED)
    /// </summary>
    public void Rotate_in_game_default()
    {
        Rotate_default(this.in_game);
    }

    #endregion

    #region Update

    //FIXME: TRY TO IMPROVE THIS IF IT'S POSSIBLE
    /// <summary>
    /// THIS METHOD UPDATES THE LIST WITH ALL PIECES IN THE GAME WITH THE VALUES FROM THE GAMEOBJECTS INSIDE.
    /// THIS IS USED BECAUSE WHEN WE DESTROY A COMPONENT, IS NOT UPDATED IN THE LIST this.in_game PROPERLY BUT
    /// IN THE GAME GAMEOBJECT YES.
    /// </summary>
    public void Update_pieces_in_game()
    {
        this.in_game = this.GetComponentsInChildren<APiece>();
    }

    /// <summary>
    /// THIS METHOD MOVES THE PIECE (THE IMAGE) WITH THE SQUARE'S POSITION (THE IMAGE TOO)
    /// </summary>
    /// <param name="pieces_list"></param>
    /// <returns></returns>
    public APiece[] Update_position(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if(piece.square)
                {
                    piece.transform.position = piece.square.transform.position;
                }

            }
        }
        return result.ToArray();
    }

    /// <summary>
    /// MOVES ALL PIECES'S POSITION IN THE GAME INTO IT'S SQUARES POSITION
    /// </summary>
    /// <returns></returns>
    public APiece[] Update_position_in_game()
    {
        return this.Update_position(this.in_game);
    }
    #endregion

    #region Getters and Setters.
    /// <summary>
    /// GET ALL PIECES IN THE GAME
    /// </summary>
    /// <returns></returns>
    public APiece[] Get_All_in_game()
    {
        return this.in_game;
    }

    /// <summary>
    /// REPLACE THE LIST OF PIECES IN THE GAME BY ANOTHER LIST OF PIECES GIVEN BY PARAMETER.
    /// </summary>
    /// <param name="pieces_list"></param>
    public void Set_All_in_game(APiece[] pieces_list)
    {
        this.in_game = pieces_list;
    }

    //FIXME: TRY TO IMPROVE Set_id, MAYBE SOMETHING LIKE i = LAST ID, AND BY DEFAULT LAST ID IS 0 

    /// <summary>
    /// SET AN ID TO ALL PIECES BY PARAM.
    /// THE FIRST ID IS 0, NEXT 1, ETC. IT'S USED ONLY 1 TIME IN THE BEGINNING
    /// </summary>
    /// <param name="pieces"></param>
    /// <returns></returns>
    public APiece[] Set_id(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].id = i;
            }
        }
        return result.ToArray();
    }

    /// <summary>
    /// SET AN ID TO ALL PIECES IN THE GAME. IT'S USED ONCE IN THE BEGINNING.
    /// </summary>
    /// <returns></returns>
    public APiece[] Set_id_in_game()
    {
        return this.Set_id(this.Get_All_in_game());
    }

    /// <summary>
    /// SET DEFAULT VALUES IN THE PIECES BY PARAMETER.
    /// </summary>
    /// <param name="pieces_list"></param>
    public void Set_default_values(APiece[] pieces_list)
    {
        foreach (APiece piece in pieces_list)
        {
            piece.Default_values();
        }
    }

    /// <summary>
    /// IT'S USED BEFORE A GAME
    /// </summary>
    public void Set_default_values_in_game()
    {
        this.Set_default_values(this.in_game);
    }

    /// <summary>
    /// EVERY PIECE IN THE GAME HAVE AN ID WHICH IS UNIQUE IN THE GAME, BUT IT'S NOT UNIQUE IN A DIFFERENT GAMES
    /// SO IT'S USED WHEN WE WANT TO GET THE SAME PIECE IN ANOTHER GAME (CLONED GAME)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public APiece Get_piece_in_game(int id)
    {
        if (id < 0 || id >= this.Get_All_in_game().Length)
        {
            return null;
        }
        else
        {
            return this.Get_All_in_game()[id];
        }
    }

    //FIXME: THINK ABOUT REMOVING THIS METHOD BECAUSE I THINK IT'S THE SAME LIKE piece.Get_in_cloned_game(clone_gameobject);
    // AND I DON'T KNOW WHY I CREATED THIS METHOD.
    public APiece Get_in_cloned_game(APiece piece, GameObject clone_gameobject)
    {
        if (!piece || !clone_gameobject || !clone_gameobject.GetComponent<Game>())
        {
            return null;
        }
        else
        {
            return clone_gameobject.GetComponent<Game>().board.pieces.Get_piece_in_game(piece.id);
        }
    }

    /// <summary>
    /// GET ALL PIECES ALIVES IN A LIST OF PIECES GIVEN BY PARAMETER. 
    /// </summary>
    /// <param name="pieces_list"></param>
    /// <returns></returns>
    public APiece[] Get_alives(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if( pieces_list != null )
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.is_alive)
                {
                    result.Add(piece);
                }
            }
        }
        return result.ToArray();
    }

    /// <summary>
    /// GET ALL PIECES ALIVES IN THE GAME.
    /// </summary>
    /// <returns></returns>
    public APiece[] Get_alives_in_game()
    {
        return this.Get_alives(this.in_game);
    }

    /// <summary>
    /// SET ALIVE TO ALL PIECES GIVEN BY PARAMETER. 
    /// </summary>
    /// <param name="pieces_list"></param>
    /// <returns></returns>
    public APiece[] Set_alives(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.is_alive = true;
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    /// <summary>
    /// SET ALIVE TO ALL PIECES IN THE GAME.
    /// </summary>
    /// <returns></returns>
    public APiece[] Set_alives_in_game()
    {
        return this.Set_alives(this.in_game);
    }

    //FIXME: THINK ABOUT REMOVE THESE GETTERS AND SETTERS WHICH ARE NOT USED.
    // IF NOT, THEN CREATE IT`S SUMMARIES.

    public APiece[] Get_dies(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (!piece.is_alive)
                {
                    result.Add(piece);
                }
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_dies_in_game()
    {
        return this.Get_dies(this.in_game);
    }

    public APiece[] Set_dies(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.is_alive = false;
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_dies_in_game()
    {
        return this.Set_dies(this.in_game);
    }

    public APiece[] Get_whites(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.is_white)
                {
                    result.Add(piece);
                }
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_whites_in_game()
    {
        return this.Get_whites(this.in_game);
    }

    public APiece[] Set_whites(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.is_white = true;
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_whites_in_game()
    {
        return this.Set_whites(this.in_game);
    }

    public APiece[] Get_blacks(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (!piece.is_white)
                {
                    result.Add(piece);
                }
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_blacks_in_game()
    {
        return this.Get_blacks(this.in_game);
    }

    public APiece[] Set_blacks(APiece[] pieces_list)
    {
        var result = new List<APiece>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                piece.is_white = false;
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_blacks_in_game()
    {
        return this.Set_blacks(this.in_game);
    }

    public APiece[] Get_moved(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                if ( typeof(TMoved).IsAssignableFrom(piece.GetType()) && piece.GetComponent<TMoved>().moved )
                {
                    result.Add(piece);
                }
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_moved_in_game()
    {
        return this.Get_moved(this.Get_All_in_game());
    }

    public APiece[] Get_no_moved(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                if (typeof(TMoved).IsAssignableFrom(piece.GetType()) && !piece.GetComponent<TMoved>().moved)
                {
                    result.Add(piece);
                }
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Get_no_moved_in_game()
    {
        return this.Get_no_moved(this.Get_All_in_game());
    }

    public APiece[] Set_moved(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                if (typeof(TMoved).IsAssignableFrom(piece.GetType()))
                {
                    piece.GetComponent<TMoved>().moved = true;
                }
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_moved_in_game()
    {
        return this.Set_moved(this.Get_All_in_game());
    }

    public APiece[] Set_no_moved(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                if (typeof(TMoved).IsAssignableFrom(piece.GetType()))
                {
                    piece.GetComponent<TMoved>().moved = false;
                }
                result.Add(piece);
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_no_moved_in_game()
    {
        return this.Set_no_moved(this.Get_All_in_game());
    }

    public APiece[] Set_cache_empty(APiece[] pieces)
    {
        var result = new List<APiece>();
        if (pieces != null)
        {
            foreach (APiece piece in pieces)
            {
                piece.Set_cache_empty();
            }
        }
        return result.ToArray();
    }

    public APiece[] Set_cache_empty_in_game()
    {
        return this.Set_cache_empty(this.Get_All_in_game());
    }

    #endregion

    #endregion

    #region APawn

    #region Getters and Setters.
    public APawn[] Get_pawns(APiece[] pieces_list)
    {
        var result = new List<APawn>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<APawn>())
                {
                    result.Add(piece.GetComponent<APawn>());
                }
            }
        }
        return result.ToArray();
    }

    public APawn[] Get_pawns_in_game()
    {   
        return this.Get_pawns(this.in_game);
    }

    public APawn[] Get_targets_en_passant(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                if(pawn.is_en_passant_target )
                {
                    result.Add(pawn);
                }
            }
        }
        return result.ToArray();
    }

    public APawn[] Get_targets_en_passant_in_game()
    {
        return this.Get_targets_en_passant(this.Get_pawns_in_game());
    }

    public APawn[] Get_no_targets_en_passant(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                if (!pawn.is_en_passant_target)
                {
                    result.Add(pawn);
                }
            }
        }
        return result.ToArray();
    }

    public APawn[] Get_no_targets_en_passant_in_game()
    {
        return this.Get_no_targets_en_passant(this.Get_pawns_in_game());
    }

    public APawn[] Set_targets_en_passant(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                pawn.is_en_passant_target = true;
                result.Add(pawn);
            }
        }
        return result.ToArray();
    }

    public APawn[] Set_targets_en_passant_in_game()
    {
        return this.Set_targets_en_passant(this.Get_pawns_in_game());
    }

    public APawn[] Set_no_targets_en_passant(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                pawn.is_en_passant_target = false;
                result.Add(pawn);
            }
        }
        return result.ToArray();
    }

    public APawn[] Set_no_targets_en_passant_in_game()
    {
        return this.Set_no_targets_en_passant(this.Get_pawns_in_game());
    }

    public APawn[] Set_default_values(APawn[] pawns_list)
    {
        var result = new List<APawn>();
        if (pawns_list != null)
        {
            foreach (APawn pawn in pawns_list)
            {
                pawn.Default_values();
                result.Add(pawn);
            }
        }
        return result.ToArray();
    }
    #endregion

    #endregion

    #region AKnight

    #region Getters and Setters.
    public AKnight[] Get_knights(APiece[] pieces_list)
    {
        var result = new List<AKnight>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<AKnight>())
                {
                    result.Add(piece.GetComponent<AKnight>());
                }
            }
        }
        return result.ToArray();
    }

    public AKnight[] Get_Knights_in_game()
    {
        return this.Get_knights(this.in_game);
    }
    #endregion

    #endregion

    #region ABishop

    #region Getters and Setters.
    public ABishop[] Get_bishops(APiece[] pieces_list)
    {
        var result = new List<ABishop>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<ABishop>())
                {
                    result.Add(piece.GetComponent<ABishop>());
                }
            }
        }
        return result.ToArray();
    }

    public ABishop[] Get_bishops_in_game()
    {
        return this.Get_bishops(this.in_game);
    }
    #endregion

    #endregion

    #region AKing

    #region Getters and Setters.
    public AKing[] Get_kings(APiece[] pieces_list)
    {
        var result = new List<AKing>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<AKing>())
                {
                    result.Add(piece.GetComponent<AKing>());
                }
            }
        }
        return result.ToArray();
    }

    public AKing[] Get_Kings_in_game()
    {
        return this.Get_kings(this.in_game);
    }
    #endregion

    #endregion

    #region ARook

    #region Getters and Setters.
    public ARook[] Get_rooks(APiece[] pieces_list)
    {
        var result = new List<ARook>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<ARook>())
                {
                    result.Add(piece.GetComponent<ARook>());
                }
            }
        }
        return result.ToArray();
    }

    public ARook[] Get_rooks_in_game()
    {
        return this.Get_rooks(this.in_game);
    }
    #endregion

    #endregion

    #region AQueen

    #region Getters and Setters.

    public AQueen[] Get_queens(APiece[] pieces_list)
    {
        var result = new List<AQueen>();
        if (pieces_list != null)
        {
            foreach (APiece piece in pieces_list)
            {
                if (piece.GetComponent<AQueen>())
                {
                    result.Add(piece.GetComponent<AQueen>());
                }
            }
        }
        return result.ToArray();
    }

    public AQueen[] Get_queens_in_game()
    {
        return this.Get_queens(this.in_game);
    }
    #endregion

    #endregion


    /// <summary>
    /// Awake IS CALLED ONLY ONCE DURING THE LIFETIME OF THE SCRIPT INSTANCE
    /// </summary>
    public void Awake()
    {
        this.in_game = this.GetComponentsInChildren<APiece>();
        this.board = this.GetComponentInParent<Board>();
        if (GameObject.FindObjectsOfType<Game>().Length == 1)
        {
            this.Set_id_in_game();
        }
        
    }
}
