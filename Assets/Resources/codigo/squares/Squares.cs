using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squares : MonoBehaviour
{
    /// <summary>
    /// First the letter id, second the number id
    /// </summary>
    public ASquare[,] in_game = new ASquare[0, 0];
    public ASquare clicked;

    public ASquare[] when_die { get; set; }
    public Board board { get; set; }

    public ASquare Get_square_in_game(int letter, int number)
    {
        if ( this.in_game.GetLength(0) > letter && this.in_game.GetLength(1) > number && letter >= 0 && number >= 0 )
        {
            return this.in_game[letter, number];
        }
        else
        {
            return null;
        }
    }

    public void Set_square_in_game(int letter, int number, ASquare square = null)
    {
        Check_and_resize_squares_size(letter, number);
        this.in_game[letter, number] = square;
    }

    public ASquare[,] Get_in_game()
    {
        return this.in_game;
    }

    public ASquare[] Get_unidimensional_in_game()
    {
        var list = new List<ASquare>();
        foreach (ASquare square in this.Get_in_game())
        {
            list.Add(square);
        }
        return list.ToArray();
    }

    public void Set_in_game(ASquare[,] new_squares_in_game = null)
    {
        this.in_game = new_squares_in_game;
    }

    public List<ASquare> Add_to_list_squares(List<ASquare> list, ASquare[] squares)
    {
        if (list != null && squares != null)
        {
            foreach (ASquare square in squares)
            {
                list.Add(square);
            }
        }
        return list;
    }

    public ASquare[] Set_no_attacked(ASquare[] squares)
    {
        var list = new List<ASquare>();
        if (squares != null)
        {
            foreach (ASquare square in squares)
            {
                square.attacked_by = new List<APiece>();
                list.Add(square);
            }
        }
        return list.ToArray();
    }

    public void Set_no_attacked_in_game()
    {
        foreach (ASquare square in this.Get_in_game())
        {
            square.attacked_by = new List<APiece>();
        }
    }

    public ASquare Up(ASquare square, int number)
    {
        return this.Get_square_in_game(square.id_letter, square.id_number + number);
    }

    public ASquare Down(ASquare square, int number)
    {
        return this.Get_square_in_game(square.id_letter, square.id_number - number);
    }

    public ASquare Left(ASquare square, int number)
    {
        return this.Get_square_in_game(square.id_letter - number, square.id_number);
    }

    public ASquare Right(ASquare square, int number)
    {
        return this.Get_square_in_game(square.id_letter + number, square.id_number);
    }

    public ASquare Up_left(ASquare square, int number_up, int number_left)
    {
        return this.Get_square_in_game(square.id_letter - number_left, square.id_number + number_up);
    }

    public ASquare Up_right(ASquare square, int number_up, int number_right)
    {
        return this.Get_square_in_game(square.id_letter + number_right, square.id_number + number_up);
    }

    public ASquare Down_left(ASquare square, int number_down, int number_left)
    {
        return this.Get_square_in_game(square.id_letter - number_left, square.id_number - number_down);
    }

    public ASquare Down_right(ASquare square, int number_down, int number_right)
    {
        return this.Get_square_in_game(square.id_letter + number_right, square.id_number - number_down);
    }




    public void Check_and_resize_squares_size(int new_letter, int new_number)
    {
        if (this.in_game.GetLength(0) <= new_letter || this.in_game.GetLength(1) <= new_number)
        {
            int new_size_letter = 0;
            int new_size_number = 0;

            if (this.in_game.GetLength(0) <= new_letter)
            {
                new_size_letter = new_letter + 1;
            }
            else
            {
                new_size_letter = this.in_game.GetLength(0);
            }

            if (this.in_game.GetLength(1) <= new_number)
            {
                new_size_number = new_number + 1;
            }
            else
            {
                new_size_number = this.in_game.GetLength(1);
            }

            var resize = new ASquare[new_size_letter, new_size_number];
            for (int index_letter = 0; index_letter < this.in_game.GetLength(0); index_letter++)
            {
                for (int index_number = 0; index_number < this.in_game.GetLength(1); index_number++)
                {
                    resize[index_letter, index_number] = this.in_game[index_letter, index_number];
                }
            }
            this.Set_in_game(resize);
        }
    }





    public void Click(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Click();
        }
    }

    public void Click(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Click();
        }
    }

    public void Unclick(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Unclick();
        }
    }

    public void Unclick(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Unclick();
        }
    }

    public void Click_or_unclick(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Click_or_unclick();
        }
    }

    public void Click_or_unclick(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Click_or_unclick();
        }
    }

    public void Enable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Enable();
        }
    }

    public void Enable(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Enable();
        }
    }

    public void Disable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Disable();
        }
    }

    public void Disable(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Disable();
        }
    }

    public void Enable_or_disable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Enable_or_disable();
        }
    }

    public void Enable_or_disable(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Enable_or_disable();
        }
    }

    public void Set_default_values(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Default_values();
        }
    }

    public void Set_default_values(ASquare[,] squares)
    {
        foreach (ASquare square in this.in_game)
        {
            square.Default_values();
        }
    }

    public void Set_default_values_in_game()
    {
        this.Set_default_values(this.in_game);
    }



    void Awake()
    {
        this.board = this.GetComponentInParent<Board>();
        this.when_die = this.GetComponentsInChildren<Square_when_die>();
    }
}