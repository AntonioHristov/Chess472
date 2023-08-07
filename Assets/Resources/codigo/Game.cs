using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const bool WHITE_TURN = true;
    private const bool BLACK_TURN = false;


    public Boxes boxes { get; set; }
    public Board board { get; set; }
    public bool is_white_turn;
    //public bool is_white_turn { get; set; }
    public bool is_finished { get; set; }
    public bool theres_a_check { get; set; }






    public void Default_values()
    {
        is_finished = true;
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
        if (this.board.Check_is_stalemate_in_game())
        {
            this.Stalemate();
            return true;
        }
        else if (this.board.Check_is_checkmate_in_game())
        {
            this.Checkmate();
            return true;
        }
        return false;
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

    void Awake()
    {
        board = this.GetComponentInChildren<Board>();
        boxes = this.GetComponentInChildren<Boxes>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Default_values();

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
