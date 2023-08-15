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
    public int id;
    public List<ASquare> cache_posible_moves { get; set; }


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
        if (!this.is_alive)
        {
            return new List<ASquare>();
        }
        else
        {
            /*
            Debug.Log(this);
            foreach (ASquare square in this.Squares_which_this_piece_see())
            {
                Debug.Log(square);
            }
            */
            if(!this.Is_cache_empty())
            {
                return this.cache_posible_moves;
            }
            else
            {
                return this.pieces.board.Add_to_list_if_can_move(new List<ASquare>(), this, this.Squares_which_this_piece_see().ToArray());
            }
        }
    }

    public void Die()
    { this.is_alive = false; this.pieces.board.Piece_to_square(this, this.when_die); }
    public void Revive(ASquare square)
    { this.is_alive = true; this.pieces.board.Piece_to_square(this, square); }

    public void Set_sprite(Sprite sprite)
    {
        if (!this.gameObject.GetComponent<Image>())
        {
            Image img = gameObject.AddComponent(typeof(Image)) as Image;
        }
        this.gameObject.GetComponent<Image>().sprite = sprite;
    }

    public bool Is_cache_empty()
    { return this.cache_posible_moves == null; }

    public bool Theres_in_cache(ASquare square)
    {
        foreach (ASquare cache_square in this.cache_posible_moves)
        {
            if(square == cache_square)
            {
                return true;
            }
        }
        return false;
    }

    public List<ASquare> Get_cache()
    {
        return this.cache_posible_moves;
    }


    /// <summary>
    /// Because we want 0 squares in cache and empty is not the same
    /// </summary>
    public void Add_cache()
    {
        if (this.cache_posible_moves == null)
        {
            this.cache_posible_moves = new List<ASquare>();
        }
    }

    public void Add_cache(ASquare square)
    {
        this.Add_cache();
        if(!this.Theres_in_cache(square))
        {
            if (square != null)
            {
                this.cache_posible_moves.Add(square);
            }
        }            
    }

    public void Add_cache(List<ASquare> squares)
    {
        if (this.cache_posible_moves == null)
        {
            this.cache_posible_moves = new List<ASquare>();
        }
        foreach (ASquare square in squares)
        {
            this.Add_cache(square);
        }
    }

    public void Set_cache_empty()
    {
        this.cache_posible_moves = null;
    }


    public APiece Get_in_cloned_game(GameObject clone_gameobject)
    {
        if (!clone_gameobject || !clone_gameobject.GetComponent<Game>())
        {
            return null;
        }
        else
        {
            return clone_gameobject.GetComponent<Game>().board.pieces.Get_piece_in_game(this.id);
        }
    }



    #endregion

    public void Awake()
    {
        pieces = this.GetComponentInParent<Pieces>();

    }

    public void Start()
    {
        if (GameObject.FindObjectsOfType<Game>().Length == 1)
        {
            //this.Die();
            this.Set_cache_empty();
        }
    }
}