using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const bool WHITE_TURN = true;
    private const bool BLACK_TURN = false;

    public Board board { get; set; }
    public Pieces pieces { get; set; }
    public Squares squares { get; set; }
    public bool is_white_turn { get; set; }
    public bool is_finished { get; set; }


    public void Default_values()
    {
        is_finished = true;
        Choose_turn(WHITE_TURN);
        board.Default_pieces_to_when_die();
        board.Default_pieces_to_squares();

        is_finished = false;
    }

    public void Next_turn()
    {
        this.is_white_turn = !this.is_white_turn;
        this.GetComponentInChildren<Board>().Rotate(this.is_white_turn);
    }

    public void Choose_turn(bool white_chosen = true)
    {
        is_white_turn = white_chosen;
        this.GetComponentInChildren<Board>().Rotate(white_chosen);
    }

    public void Check()
    {

    }

    public void Checkmate()
    {
        is_finished = true;
    }

    public void Stalemate()
    {
        is_finished = true;
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
        Default_values();
    }

    public void Close_game()
    {
        Application.Quit();
    }

    void Awake()
    {
        board = this.GetComponentInChildren<Board>();
    }

    // Start is called before the first frame update
    void Start()
    {
        New_game();

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
