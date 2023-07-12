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



    #region Direction Change Square

    public ASquare Up(int number)
    {
        return this.squares.Up(this,number);
    }

    public ASquare Down(int number)
    {
        return this.squares.Down(this, number);
    }

    public ASquare Left(int number)
    {
        return this.squares.Left(this, number);
    }

    public ASquare Right(int number)
    {
        return this.squares.Right(this, number);
    }

    public ASquare Up_left(ASquare square, int number_up, int number_left)
    {
        return this.squares.Up_left(this, number_up, number_left);
    }

    public ASquare Up_right(ASquare square, int number_up, int number_right)
    {
        return this.squares.Up_right(this, number_up, number_right);
    }

    public ASquare Down_left(ASquare square, int number_down, int number_left)
    {
        return this.squares.Down_left(this, number_down, number_left);
    }

    public ASquare Down_right(ASquare square, int number_down, int number_right)
    {
        return this.squares.Down_right(this, number_down, number_right);
    }

    #endregion


    public void Click()
    {
        this.GetComponent<Image>().sprite = this.clicked_image;
        this.clicked_by_user = true;
        if (this.squares)
        {
            this.squares.clicked = this;
        }
    }

    public void Unclick()
    {
        this.GetComponent<Image>().sprite = this.main_image;
        this.clicked_by_user = false;
        if(this.squares)
        {
            this.squares.clicked = null;
        }
    }

    /// <summary>
    /// Click or unclick by user
    /// </summary>
    public void Click_or_unclick()
    {
        if (this.squares.clicked == null && this.piece != null)
        {
            this.Click();
        }
        else if (this.squares.clicked == this)
        {
            this.Unclick();
        }
    }

    public void Enable()
    {
        this.GetComponent<Image>().sprite = this.enabled_image;
        this.is_enabled = true;
    }

    public void Disable()
    {
        this.GetComponent<Image>().sprite = this.main_image;
        this.is_enabled = false;
    }

    public void Enable_or_disable()
    {
        if (this.is_enabled)
        {
            this.Disable();
        }
        else
        {
            this.Enable();
        }
    }


    public void Default_values()
    {
        this.Disable();
        this.Unclick();
    }






    public void OnPointerDown(PointerEventData eventData)
    {
        this.Awake();
        

        // if click square in a own piece
        if( this.piece != null && this.piece.is_white == squares.board.game.is_white_turn )
        {
            this.Click_or_unclick();

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
            this.squares.clicked.Unclick();

            if(piece_clicked.GetComponent<APawn>())
            {
                // Trying to capture the target piece en passant , if its not been able to do it, then...
                if (! piece_clicked.GetComponent<APawn>().Try_capture_en_passant(this) )
                {
                    // All pawns in game are not en passant target. This is because we want a pawn which is an en passant target only the first chance and not more
                    this.squares.board.pieces.Set_no_targets_en_passant_in_game();

                    // if pawn's first move and go 2 squares, is a target for en passant, if not not.
                    piece_clicked.GetComponent<APawn>().Is_en_passant_target(this);


                    if ( !piece_clicked.GetComponent<APawn>().direction.Forward(this, 5))
                    {
                        Debug.Log("open promotion box");
                        piece_clicked.GetComponent<APawn>().Open_box_promotion();
                    }
                }

                piece_clicked.GetComponent<APawn>().moved = true;
            }



            squares.board.Piece_to_square(piece_clicked, this);
            this.squares.board.game.Next_turn();
        }


    }
    #endregion

    public void Awake()
    {
        this.squares = this.GetComponentInParent<Squares>();
    }

    public void Start()
    {
        this.Default_values();
    }
}

