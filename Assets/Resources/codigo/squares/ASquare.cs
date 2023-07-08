using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class ASquare : MonoBehaviour, IPointerDownHandler
{
    #region Fields
    #region Constants

    public const int ID_A = 0;
    public const int ID_B = 1;
    public const int ID_C = 2;
    public const int ID_D = 3;
    public const int ID_E = 4;
    public const int ID_F = 5;
    public const int ID_G = 6;
    public const int ID_H = 7;

    public const int ID_1 = 0;
    public const int ID_2 = 1;
    public const int ID_3 = 2;
    public const int ID_4 = 3;
    public const int ID_5 = 4;
    public const int ID_6 = 5;
    public const int ID_7 = 6;
    public const int ID_8 = 7;
    #endregion
    #endregion



    #region Properties
    public Sprite main_image { get; set; }
    public Sprite clicked_image { get; set; }
    public Sprite enabled_image { get; set; }
    public APiece piece { get; set; }
    public int id_letter { get; set; }
    public int id_number { get; set; }
    public bool clicked_by_user { get; set; }
    public bool is_enabled { get; set; }
    public int seen_by_white { get; set; }
    public int seen_by_black { get; set; }
    public Squares squares { get; set; }
    #endregion


    #region Methods


    protected void Default_in_game(int letter, int number)
    {
        this.id_letter = letter;
        this.id_number = number;
        this.GetComponentInParent<Squares>().Set_square_in_game(letter, number, this);
        this.clicked_image = Sprites.Get_square_5();
        this.enabled = Sprites.Get_square_4();

        if ((letter + number) % 2 == 0)
        {
            // is dark square
            this.main_image = Sprites.Get_square_1();
            //Image img = gameObject.AddComponent(typeof(Image)) as Image;
            //this.gameObject.GetComponent<Image>().sprite = this.main_image;
        }
        else
        {
            // is light square
            this.main_image = Sprites.Get_square_2();
        }
    }

    protected void Default_when_die()
    {
        this.main_image = Sprites.Get_square_4();
    }

    protected void Default_border()
    {
        this.main_image = Sprites.Get_square_3();
    }





    public void OnPointerDown(PointerEventData eventData)
    {
        this.Awake();

        // if click square in a own piece
        if( this.piece != null && this.piece.is_white == squares.board.game.is_white_turn )
        {
            this.squares.Click_or_unclick(this);

            if (this.squares.clicked == null || this.squares.clicked == this)
            {
                this.squares.Enable_or_disable(this.piece.Posible_moves().ToArray());
            }
        }
        // if click in an enable square to move the piece clicked
        else
        if( this.is_enabled && squares.clicked && squares.clicked.piece)
        {

            
            var piece_clicked = squares.clicked.piece;

            this.squares.Disable(squares.clicked.piece.Posible_moves().ToArray());
            this.squares.Unclick(squares.clicked);

            piece_clicked.moved = true;
            squares.board.Piece_to_square(piece_clicked, this);
        }


    }
    #endregion

    public void Awake()
    {
        this.squares = this.GetComponentInParent<Squares>();
        //this.squares.Disable(this);
    }

    public void Start()
    {
        this.GetComponentInParent<Squares>().Disable(this);
    }
}

