using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class APiece : MonoBehaviour
{
    #region Fields

    #endregion

    #region Properties
    public ASquare when_die;
    public ASquare square;
    public abstract bool is_white { get; set; }
    public bool is_alive;



    public Pieces pieces { get; set; }





    #endregion

    #region Methods




    public abstract void Default_values();
    /// <summary>
    /// The Squares which the piece can capture an enemy piece if it there's
    /// I mean, the squares which this piece attack.
    /// </summary>
    /// <returns></returns>
    public abstract List<ASquare> Squares_which_this_piece_see();
    public virtual List<ASquare> Posible_moves()
    {
        return this.pieces.board.Add_to_list_if_can_move(new List<ASquare>(), this, this.Squares_which_this_piece_see().ToArray());
    }

public void Die()
    { this.is_alive = false; this.GetComponentInParent<Board>().Piece_to_square(this, when_die); }
    public void Revive(ASquare square)
    { this.is_alive = true; this.GetComponentInParent<Board>().Piece_to_square(this, square); }

    public void Set_sprite(Sprite sprite)
    {
        if (!this.gameObject.GetComponent<Image>())
        {
            Image img = gameObject.AddComponent(typeof(Image)) as Image;
        }
        this.gameObject.GetComponent<Image>().sprite = sprite;
    }
    #endregion

    public void Awake()
    {
        pieces = this.GetComponentInParent<Pieces>();
        this.is_alive = false;


    }
}