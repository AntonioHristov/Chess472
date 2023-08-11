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

    public Game Default_values_aux()
    {
        var main = GameObject.FindObjectsOfType<Game>()[0];
        var aux = GameObject.FindObjectsOfType<Game>()[1];
        aux.is_finished = true;
        aux.is_white_turn = main.is_white_turn;
        aux.board = main.board;
        aux.board.squares = main.board.squares;
        aux.board.squares.Set_in_game(main.board.squares.Get_in_game());
        aux.board.pieces = main.board.pieces;
        aux.board.pieces.Set_All_in_game(main.board.pieces.Get_All_in_game());
        board.pieces.Update_pieces_in_game();
        is_finished = false;

        return aux;
    }

    public void Next_turn()
    {
        this.is_white_turn = !this.is_white_turn;
        this.board.Update_squares_attacked_in_game();

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
            //var result = Default_values_aux();
            //var aux = GameObject.FindObjectsOfType<Game>()[1];
            //Game.auxiliar = GameObject.Instantiate(this.gameObject);
            var result = GameObject.Instantiate(this.GetComponent<Game>().gameObject);
            return result;
        }
        else
        {
            var result = GameObject.Instantiate(this.gameObject);
            Game.auxiliar = result;
            return result;
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
