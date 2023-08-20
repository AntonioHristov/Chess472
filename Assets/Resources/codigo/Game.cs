using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    // Choose between try to create Copy_game_values method (send 2 games, no use instance inside)
    // or improve current code with comments, etc. When I write this I recommend this (the second one).
    // Choose one of them to do first and probably the other one should be done next.
    public const int DEPTH_CLONE_CHECK = 0;
    public const int DEPTH_CLONE_DEFAULT = 2;

    private const bool WHITE_TURN = true;
    private const bool BLACK_TURN = false;



    public static GameObject auxiliar { get; set; }


    public Boxes boxes { get; set; }
    public Board board { get; set; }
    public bool is_white_turn;
    //public bool is_white_turn { get; set; }
    public bool is_finished { get; set; }
    public bool is_clone;
    public int depth_clone;
    public List<AKing> kings_get_a_check { get; set; }






    public void Default_values()
    {
        is_finished = true;
        this.is_clone = false;
        this.depth_clone = Game.DEPTH_CLONE_DEFAULT;
        this.kings_get_a_check = new List<AKing>();
        board.pieces.Set_default_values_in_game();
        board.squares.Set_default_values_in_game();
        board.Default_pieces_set_when_die();
        board.Default_pieces_to_squares();
        board.pieces.Update_pieces_in_game();
        White_turn();
        this.board.Update_squares_attacked_in_game();
        this.board.pieces.Set_cache_empty_in_game();

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
        if(this.Theres_depth())
        {
            var result = GameObject.Instantiate(this.gameObject);
            result.GetComponent<Game>().depth_clone--;
            result.GetComponent<Game>().board.pieces.Update_position_in_game();

            return result;
        }
        else
        {
            return null;
        }
    }

    public bool Theres_a_check()
    {
        return this.kings_get_a_check != null && this.kings_get_a_check.Count != 0;
    }

    public bool Theres_depth()
    {
        return this.depth_clone > 0;
    }

    public bool Theres_depth_check()
    {
        return Game.DEPTH_CLONE_DEFAULT - Game.DEPTH_CLONE_CHECK == this.depth_clone ;
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
            this.is_clone = true;
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
