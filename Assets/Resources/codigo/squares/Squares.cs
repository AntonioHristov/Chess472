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

    public ASquare[,] Get_squares_in_game()
    {
        return this.in_game;
    }

    public void Set_squares_in_game(ASquare[,] new_squares_in_game = null)
    {
        this.in_game = new_squares_in_game;
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

    public ASquare Up_left(ASquare square, int up, int left)
    {
        return this.Get_square_in_game(square.id_letter - left, square.id_number + up);
    }

    public ASquare Up_right(ASquare square, int up, int right)
    {
        return this.Get_square_in_game(square.id_letter + right, square.id_number + up);
    }

    public ASquare Down_left(ASquare square, int down, int left)
    {
        return this.Get_square_in_game(square.id_letter - left, square.id_number - down);
    }

    public ASquare Down_right(ASquare square, int down, int right)
    {
        return this.Get_square_in_game(square.id_letter + right, square.id_number - down);
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
            this.Set_squares_in_game(resize);
        }
    }




    public void Click(ASquare square)
    {
        square.GetComponent<Image>().sprite = square.clicked_image;
        square.clicked_by_user = true;
        this.clicked = square;
    }

    public void Click(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            this.Click(square);
        }
    }

    public void Unclick(ASquare square)
    {
        square.GetComponent<Image>().sprite = square.main_image;
        square.clicked_by_user = false;
        square.GetComponentInParent<Squares>().clicked = null;
    }

    public void Unclick(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            this.Unclick(square);
        }
    }

    /// <summary>
    /// Click or unclick by user
    /// </summary>
    public void Click_or_unclick(ASquare square)
    {
        if (this.clicked == null && square.piece != null)
        {
            Click(square);
        }
        else if (this.clicked == square)
        {
            Unclick(square);
        }
    }

    public void Click_or_unclick(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            this.Click_or_unclick(square);
        }
    }

    public void Enable(ASquare square)
    {
        square.GetComponent<Image>().sprite = square.enabled_image;
        square.is_enabled = true;
    }

    public void Enable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            this.Enable(square);
        }
    }

    public void Disable(ASquare square)
    {
        square.GetComponent<Image>().sprite = square.main_image;
        square.is_enabled = false;
    }

    public void Disable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            this.Disable(square);
        }
    }

    public void Enable_or_disable(ASquare square)
    {
        if (square.is_enabled)
        {
            Disable(square);
        }
        else
        {
            Enable(square);
        }
    }

    public void Enable_or_disable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            this.Enable_or_disable(square);
        }
    }



    void Awake()
    {
        this.board = this.GetComponentInParent<Board>();
        this.when_die = this.GetComponentsInChildren<Square_when_die>();
    }
}