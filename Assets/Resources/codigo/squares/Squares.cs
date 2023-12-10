using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squares : MonoBehaviour
{
    /// <summary>
    /// IT'S ALL SQUARES IN THE GAME
    /// <para>FIRST THE LETTER ID, SECOND THE NUMBER ID</para>
    /// </summary>
    public ASquare[,] in_game = new ASquare[0, 0];

    /// <summary>
    /// IS THE SQUARE WHICH IS CLICKED BY THE PLAYER IN HIS TURN IN THE GAME, 
    /// ONLY IF THE SQUARE HAS A PIECE WHICH WILL BE MOVE BY THE PLAYER.
    /// </summary>
    public ASquare clicked;

    /// <summary>
    /// EACH PIECE HAS A SQUARE TO GO WHEN THE PIECE DIES, SO THIS GET ALL THESE SQUARES BECAUSE WE
    /// ASSIGN THE VALUES WHEN DIE FOR ALL PIECES IN Default_pieces_set_when_die() METHOD IN Board OBJECT
    /// </summary>
    public ASquare[] when_die { get; set; }

    /// <summary>
    /// THE BOARD WHICH HAS THIS, THE PIECES, THE GAME, ETC
    /// </summary>
    public Board board { get; set; }

    /// <summary>
    /// GIVING THE LETTER AND NUMBER THIS RETURN THE SQUARE IN GAME
    /// </summary>
    /// <param name="letter"></param>
    /// <param name="number"></param>
    /// <returns></returns>
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

    /// <summary>
    /// THIS IS BECAUSE WE WANT TO GET THE SAME SQUARE IN DIFFERENTS GAMES, 
    /// <para>FOR EXAMPLE: GET THE SAME SQUARE FROM A CLONE GAME GIVING THE SQUARE IN THE MAIN GAME</para>
    /// </summary>
    /// <param name="square"></param>
    /// <returns></returns>
    public ASquare Get_square_in_game(ASquare square)
    {
        return this.Get_square_in_game(square.id_letter, square.id_number);
    }

    // FIXME: IN Set_square_in_game PROBABLY WE CAN GIVE ONLY THE SQUARE BECAUSE THE SQUARE HAS THE LETTER AND THE NUMBER

    /// <summary>
    /// EACH SQUARE IN GAME (NOT WHEN DIE SQUARES) HAS A LETTER A NUMBER ID, <para>SO THEY CALLS THIS METHOD WHICH
    /// INNITIALIZE THE LIST OF SQUARES this.in_game AFTER RESIZE HIS SIZE TO NOT GET OUT OF BOUNDS EXCEPTION</para>
    /// </summary>
    /// <param name="letter"></param>
    /// <param name="number"></param>
    /// <param name="square"></param>
    public void Set_square_in_game(int letter, int number, ASquare square = null)
    {
        Check_and_resize_squares_size(letter, number);
        this.in_game[letter, number] = square;
    }

    // FIXME: PROBABLY SET PRIVATE this.in_game, OTHERWISE I THINK THE METHOD Get_in_game HAS NO SENSE

    /// <summary>
    /// GET THE SQUARES IN GAME
    /// </summary>
    /// <returns></returns>
    public ASquare[,] Get_in_game()
    {
        return this.in_game;
    }

    /*
    /// <summary>
    /// THIS CONVERTS AND RETURNS THE BIDIMENSIONAL ARRAY OF SQUARES IN GAME INTO AN UNIDIMENSIONAL ARRAY
    /// </summary>
    /// <returns></returns>
    public ASquare[] Get_unidimensional_in_game()
    {
        var list = new List<ASquare>();
        foreach (ASquare square in this.Get_in_game())
        {
            list.Add(square);
        }
        return list.ToArray();
    }
    */

    /// <summary>
    /// THIS METHOD CHANGES THE LIST OF SQUARES IN GAME TO OTHER ONE.
    /// <para>THIS IS USE AFTER RESIZING THE FIELD this.in_game WHICH IS WHEN WE INITIALIZE this.in_game WITH 
    /// ALL SQUARES IN GAME, ONE BY ONE</para>
    /// </summary>
    /// <param name="new_squares_in_game"></param>
    public void Set_in_game(ASquare[,] new_squares_in_game = null)
    {
        this.in_game = new_squares_in_game;
    }

    /*
    // FIXME: CAN WE DELETE THIS AND RELATIONS? IF NOT, CONTINUE WITH THE SUMMARY
    public ASquare Get_in_cloned_game(ASquare square, GameObject clone_gameobject)
    {
        if (!square || !clone_gameobject || !clone_gameobject.GetComponent<Game>())
        {
            return null;
        }
        else
        {
            return clone_gameobject.GetComponent<Game>().board.squares.Get_square_in_game(square);
        }
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
    */

    // FIXME: TEST THE PREVIOUS COMMENTED METHOD public ASquare[] Set_no_attacked(ASquare[] squares)
    // IN THE METHOD Set_no_attacked_in_game()

    /// <summary>
    /// SET ALL SQUARES IN THE GAME WITH NO ATTACKED BY ANY PIECE.
    /// <para>IT'S USED BEFORE A NEW TURN AND IN THE FIRST TURN IN THE GAME</para>
    /// </summary>
    public void Set_no_attacked_in_game()
    {
        foreach (ASquare square in this.Get_in_game())
        {
            square.attacked_by = new List<APiece>();
        }      
    }


    #region GetRelativeSquare
    /// <summary>
    /// YOU GIVE A SQUARE IN THE GAME AND A NUMBER, SO YOU GET THE SQUARE IN THE GAME WHICH IS UP TO THE SQUARE GIVEN
    /// THE NUMBER GIVEN SQUARES.
    /// <para>IF THE SQUARE GIVEN OR THE SQUARE WHICH YOU GET IS NULL OR NOT EXIST, YOU GET NULL IN THIS METHOD</para>
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    public ASquare Up(ASquare square, int number)
    {
        // FIXME: TEST THIS INSTEAD AND IF IT WORKS CHANGE IT HERE AND IN THE RELATION METHODS (Down, Left, ETC)
        //return square.Up(number);
        return this.Get_square_in_game(square.id_letter, square.id_number + number);
    }

    /// <summary>
    /// YOU GIVE A SQUARE IN THE GAME AND A NUMBER, SO YOU GET THE SQUARE IN THE GAME WHICH IS DOWN TO THE SQUARE GIVEN
    /// THE NUMBER GIVEN SQUARES.
    /// <para>IF THE SQUARE GIVEN OR THE SQUARE WHICH YOU GET IS NULL OR NOT EXIST, YOU GET NULL IN THIS METHOD</para>
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    public ASquare Down(ASquare square, int number)
    {
        return this.Get_square_in_game(square.id_letter, square.id_number - number);
    }

    /// <summary>
    /// YOU GIVE A SQUARE IN THE GAME AND A NUMBER, SO YOU GET THE SQUARE IN THE GAME WHICH IS LEFT TO THE SQUARE GIVEN
    /// THE NUMBER GIVEN SQUARES.
    /// <para>IF THE SQUARE GIVEN OR THE SQUARE WHICH YOU GET IS NULL OR NOT EXIST, YOU GET NULL IN THIS METHOD</para>
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    public ASquare Left(ASquare square, int number)
    {
        return this.Get_square_in_game(square.id_letter - number, square.id_number);
    }

    /// <summary>
    /// YOU GIVE A SQUARE IN THE GAME AND A NUMBER, SO YOU GET THE SQUARE IN THE GAME WHICH IS RIGHT TO THE SQUARE GIVEN
    /// THE NUMBER GIVEN SQUARES.
    /// <para>IF THE SQUARE GIVEN OR THE SQUARE WHICH YOU GET IS NULL OR NOT EXIST, YOU GET NULL IN THIS METHOD</para>
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number"></param>
    /// <returns></returns>
    public ASquare Right(ASquare square, int number)
    {
        return this.Get_square_in_game(square.id_letter + number, square.id_number);
    }

    /// <summary>
    /// YOU GIVE A SQUARE IN THE GAME AND 2 NUMBERS, SO YOU GET THE SQUARE IN THE GAME WHICH IS UP AND LEFT TO THE SQUARE GIVEN
    /// THE NUMBERS GIVEN SQUARES.
    /// <para>IF THE SQUARE GIVEN OR THE SQUARE WHICH YOU GET IS NULL OR NOT EXIST, YOU GET NULL IN THIS METHOD</para>
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number_up"></param>
    /// <param name="number_left"></param>
    /// <returns></returns>
    public ASquare Up_left(ASquare square, int number_up, int number_left)
    {
        return this.Get_square_in_game(square.id_letter - number_left, square.id_number + number_up);
    }

    /// <summary>
    /// YOU GIVE A SQUARE IN THE GAME AND 2 NUMBERS, SO YOU GET THE SQUARE IN THE GAME WHICH IS UP AND RIGHT TO THE SQUARE GIVEN
    /// THE NUMBERS GIVEN SQUARES.
    /// <para>IF THE SQUARE GIVEN OR THE SQUARE WHICH YOU GET IS NULL OR NOT EXIST, YOU GET NULL IN THIS METHOD</para>
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number_up"></param>
    /// <param name="number_right"></param>
    /// <returns></returns>
    public ASquare Up_right(ASquare square, int number_up, int number_right)
    {
        return this.Get_square_in_game(square.id_letter + number_right, square.id_number + number_up);
    }

    /// <summary>
    /// YOU GIVE A SQUARE IN THE GAME AND 2 NUMBERS, SO YOU GET THE SQUARE IN THE GAME WHICH IS DOWN AND LEFT TO THE SQUARE GIVEN
    /// THE NUMBERS GIVEN SQUARES.
    /// <para>IF THE SQUARE GIVEN OR THE SQUARE WHICH YOU GET IS NULL OR NOT EXIST, YOU GET NULL IN THIS METHOD</para>
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number_down"></param>
    /// <param name="number_left"></param>
    /// <returns></returns>
    public ASquare Down_left(ASquare square, int number_down, int number_left)
    {
        return this.Get_square_in_game(square.id_letter - number_left, square.id_number - number_down);
    }

    /// <summary>
    /// YOU GIVE A SQUARE IN THE GAME AND 2 NUMBERS, SO YOU GET THE SQUARE IN THE GAME WHICH IS DOWN AND RIGHT TO THE SQUARE GIVEN
    /// THE NUMBERS GIVEN SQUARES.
    /// <para>IF THE SQUARE GIVEN OR THE SQUARE WHICH YOU GET IS NULL OR NOT EXIST, YOU GET NULL IN THIS METHOD</para>
    /// </summary>
    /// <param name="square"></param>
    /// <param name="number_down"></param>
    /// <param name="number_right"></param>
    /// <returns></returns>
    public ASquare Down_right(ASquare square, int number_down, int number_right)
    {
        return this.Get_square_in_game(square.id_letter + number_right, square.id_number - number_down);
    }
    #endregion


    /// <summary>
    /// THIS METHOD CHANGE THE SIZE OF THE FIELD this.in_game. YOU GIVE THE NEW SIZE.
    /// <para>THIS IS USED ONE TIME WITH ALL SQUARES ONE BY ONE IN THE BEGINNING</para>
    /// </summary>
    /// <param name="new_letter"></param>
    /// <param name="new_number"></param>
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




    /// <summary>
    /// CLICK ALL SQUARES GIVEN.
    /// (THE PLAYER CLICKS A SQUARE WHICH HAS A PIECE)
    /// </summary>
    /// <param name="squares"></param>
    public void Click(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Click();
        }
    }

    /// <summary>
    /// CLICK ALL SQUARES GIVEN.
    /// (THE PLAYER CLICKS A SQUARE WHICH HAS A PIECE)
    /// </summary>
    /// <param name="squares"></param>
    public void Click(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Click();
        }
    }

    /// <summary>
    /// UNCLICK ALL SQUARES GIVEN.
    /// (THE PLAYER CLICKS A SQUARE WHICH IS CLICKED)
    /// </summary>
    /// <param name="squares"></param>
    public void Unclick(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Unclick();
        }
    }

    /// <summary>
    /// UNCLICK ALL SQUARES GIVEN.
    /// (THE PLAYER CLICKS A SQUARE WHICH IS CLICKED)
    /// </summary>
    /// <param name="squares"></param>
    public void Unclick(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Unclick();
        }
    }

    /// <summary>
    /// CLICK OR UNCLICK ALL SQUARES GIVEN.
    /// <para>CLICK IF ITS UNCLICKED, UNCLICK IF ITS CLICKED.</para>
    /// </summary>
    /// <param name="squares"></param>
    public void Click_or_unclick(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Click_or_unclick();
        }
    }

    /// <summary>
    /// CLICK OR UNCLICK ALL SQUARES GIVEN.
    /// <para>CLICK IF ITS UNCLICKED, UNCLICK IF ITS CLICKED.</para>
    /// </summary>
    /// <param name="squares"></param>
    public void Click_or_unclick(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Click_or_unclick();
        }
    }

    /// <summary>
    /// ENABLE ALL SQUARES GIVEN.
    /// (WHEN THE PLAYER CLICKS A SQUARE WHICH HAS A PIECE AND CAN MOVE, THEN WE ENABLE ALL SQUARES IN THE GAME
    /// WHICH THE PIECE CAN MOVE)
    /// </summary>
    /// <param name="squares"></param>
    public void Enable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Enable();
        }
    }

    /// <summary>
    /// ENABLE ALL SQUARES GIVEN.
    /// (WHEN THE PLAYER CLICKS A SQUARE WHICH HAS A PIECE AND CAN MOVE, THEN WE ENABLE ALL SQUARES IN THE GAME
    /// WHICH THE PIECE CAN MOVE)
    /// </summary>
    /// <param name="squares"></param>
    public void Enable(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Enable();
        }
    }

    /// <summary>
    /// DISABLE ALL SQUARES GIVEN.
    /// (WHEN THE PLAYER CLICKS A SQUARE CLICKED, THEN UNCLICK THAT SQUARE AND DISABLE ALL SQUARES WHICH THE
    /// PIECE IN THE SQUARE CLICKED BEFORE CAN MOVE AND WERE ENABLED BEFORE)
    /// </summary>
    /// <param name="squares"></param>
    public void Disable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Disable();
        }
    }

    /// <summary>
    /// DISABLE ALL SQUARES GIVEN.
    /// (WHEN THE PLAYER CLICKS A SQUARE CLICKED, THEN UNCLICK THAT SQUARE AND DISABLE ALL SQUARES WHICH THE
    /// PIECE IN THE SQUARE CLICKED BEFORE CAN MOVE AND WERE ENABLED BEFORE)
    /// </summary>
    /// <param name="squares"></param>
    public void Disable(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Disable();
        }
    }

    /// <summary>
    /// ENABLE OR DISABLE ALL SQUARES GIVEN.
    /// <para>ENABLE IF ITS DISABLED, DISABLE IF ITS ENABLED.</para>
    /// </summary>
    /// <param name="squares"></param>
    public void Enable_or_disable(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Enable_or_disable();
        }
    }

    /// <summary>
    /// ENABLE OR DISABLE ALL SQUARES GIVEN.
    /// <para>ENABLE IF ITS DISABLED, DISABLE IF ITS ENABLED.</para>
    /// </summary>
    /// <param name="squares"></param>
    public void Enable_or_disable(ASquare[,] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Enable_or_disable();
        }
    }

    /// <summary>
    /// INITIALIZE THE SQUARES GIVEN WITH IT'S DEFAULT VALUES.
    /// </summary>
    /// <param name="squares"></param>
    public void Set_default_values(ASquare[] squares)
    {
        foreach (ASquare square in squares)
        {
            square.Default_values();
        }
    }

    /// <summary>
    /// INITIALIZE THE SQUARES GIVEN WITH IT'S DEFAULT VALUES.
    /// </summary>
    /// <param name="squares"></param>
    public void Set_default_values(ASquare[,] squares)
    {
        foreach (ASquare square in this.in_game)
        {
            square.Default_values();
        }
    }

    /// <summary>
    /// INITIALIZE ALL SQUARES IN THE GAME WITH IT'S DEFAULT VALUES.
    /// </summary>
    public void Set_default_values_in_game()
    {
        this.Set_default_values(this.in_game);
    }

    /// <summary>
    /// Awake IS CALLED ONLY ONCE DURING THE LIFETIME OF THE SCRIPT INSTANCE
    /// </summary>
    void Awake()
    {
        this.board = this.GetComponentInParent<Board>();
        this.when_die = this.GetComponentsInChildren<Square_when_die>();
    }
}