using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const bool WHITE_TURN = true;
    private const bool BLACK_TURN = false;


    public static GameObject auxiliar { get; set; }
    public APiece last_piece_moved;
    public ASquare last_square_moved;


    public Boxes boxes { get; set; }
    public Board board { get; set; }
    public bool is_white_turn;
    //public bool is_white_turn { get; set; }
    public bool is_finished { get; set; }
    public List<AKing> kings_get_a_check { get; set; }






    public void Default_values()
    {
        is_finished = true;
        this.kings_get_a_check = new List<AKing>();
        board.pieces.Set_default_values_in_game();
        board.squares.Set_default_values_in_game();
        board.Default_pieces_set_when_die();
        board.Default_pieces_to_squares();
        board.pieces.Update_pieces_in_game();
        White_turn();

        is_finished = false;
    }

    public void Next_turn()
    {
        this.is_white_turn = !this.is_white_turn;
        this.board.Update_squares_attacked_in_game();
        this.board.pieces.Set_cache_empty_in_game();

        if (!this.Game_finished())
        {
            this.board.Rotate();
        }
    }

    public void Next_turn_auxiliar()
    {
        this.is_white_turn = !this.is_white_turn;
        this.board.Update_squares_attacked_in_game();
    }

    public void White_turn()
    {
        is_white_turn = true;
        this.board.Rotate_default();
    }

    public bool Game_finished()
    {
        if(this.board.Check_cant_move_in_game())
        {
            if(this.Theres_a_check())
            {
                this.Checkmate();
                return true;
            }
            else
            {
                this.Stalemate();
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public void Check()
    {

    }

    public void Checkmate()
    {
        is_finished = true;
        if(this.board.game.boxes.Get_box_checkmate())
        {
            this.board.game.boxes.Get_box_checkmate().Show();
        }
    }

    public void Stalemate()
    {
        is_finished = true;
        if (this.board.game.boxes.Get_box_stalemate())
        {
            this.board.game.boxes.Get_box_stalemate().Show();
        }
    }

    public void Win_white()
    {
        is_finished = true;
    }

    public void Win_black()
    {
        is_finished = true;
    }

    public void Draw()
    {
        is_finished = true;
    }

    public void New_game()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Close_game()
    {
        Application.Quit();
    }

    public GameObject Clone_game()
    {
        Debug.Log("CREATED");
        if(GameObject.FindObjectsOfType<Game>().Length > 1)
        {
            var result = GameObject.Instantiate(this.gameObject);

            return result;
        }
        else
        {
            var result = GameObject.Instantiate(this.gameObject);
            return result;
        }
    }

    // FIXME: Dont forget the case when you can promote pawns
    public Game Make_a_move_in_a_cloned_game(APiece piece, ASquare square, GameObject clone_gameobject=null)
    {
        Game clone_game;
        this.board.pieces.Update_pieces_in_game();
      
        if(!clone_gameobject)
        {
            clone_game = this.Clone_game().GetComponent<Game>();
        }
        else
        {
            clone_game = clone_gameobject.GetComponent<Game>();
        }

        var last_piece_aux = clone_game.board.pieces.Get_piece_in_game(this.board.pieces.Get_id_in_game(this.last_piece_moved).Value);
        var last_square_aux = clone_game.board.squares.Get_square_in_game(this.last_square_moved);
        if (last_piece_aux && last_square_aux)
        {
            clone_game.board.Piece_to_square(last_piece_aux, last_square_aux);
        }


        var piece_aux = clone_game.board.pieces.Get_piece_in_game(this.board.pieces.Get_id_in_game(piece).Value);
        var square_aux = clone_game.board.squares.Get_square_in_game(square);


        clone_game.board.Piece_to_square(piece_aux, square_aux);

        if (typeof(TMoved).IsAssignableFrom(piece_aux.GetType()))
        {
            piece_aux.GetComponent<TMoved>().moved = true;
        }

        clone_game.is_white_turn = !clone_game.is_white_turn;
        clone_game.board.Update_squares_attacked_in_game();

        return clone_game;
    }

    public bool Theres_no_checks_to_me_after_move(APiece piece, ASquare square, GameObject clone_gameobject = null)
    {
        var clon_game_after_move = this.Make_a_move_in_a_cloned_game(piece, square, clone_gameobject);
        return !clon_game_after_move.Theres_a_check() || (!clon_game_after_move.Theres_a_check_to_color(piece.is_white));
    }

    public APiece Get_in_cloned_game(APiece piece, GameObject clone_gameobject)
    {
        if(!piece || !clone_gameobject || !clone_gameobject.GetComponent<Game>())
        {
            return null;
        }
        else
        {
            return clone_gameobject.GetComponent<Game>().board.pieces.Get_piece_in_game(this.board.pieces.Get_id_in_game(piece).Value);
        }
    }

    public ASquare Get_in_cloned_game(ASquare square, GameObject clone_gameobject)
    {
        if (!square || !clone_gameobject || !clone_gameobject.GetComponent<Game>())
        {
            return null;
        }
        else
        {
            return clone_gameobject.GetComponent<Game>().board.squares.Get_square_in_game(square);
        }
    }


    public bool Theres_a_check()
    {
        return this.kings_get_a_check.Count != 0;
    }

    public bool Theres_a_check_to_color(bool is_white)
    {
        foreach (AKing king in this.kings_get_a_check)
        {
            if(king.is_white == is_white)
            {
                return true;
            }
        }
        return false;
    }

    void Awake()
    {
        board = this.GetComponentInChildren<Board>();
        boxes = this.GetComponentInChildren<Boxes>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindObjectsOfType<Game>().Length == 1)
        {
            this.Default_values();
        }
        else
        {
            //this.Default_values_aux();
        }

        /*
        foreach (ASquare child in transform.GetComponentsInChildren<Square>())
        {
            Debug.Log(child);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
