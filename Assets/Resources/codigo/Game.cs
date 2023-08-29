using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    // Choose between try to create Copy_game_values method (send 2 games, no use instance inside)
    // or improve current code with comments, etc. When I write this I recommend this (the second one).
    // Choose one of them to do first and probably the other one should be done next.

    /// <summary>
    /// THE BOARD OF THIS GAME WITH THE SQUARES, PIECES, ETC.
    /// </summary>
    public Board board { get; set; }

    // FIXME: CREATE A METHOD WHICH COPY VALUES TO ANOTHER GAME OBJECT AND USE IT WHEN THERE'S A CHECK IN POSIBLE MOVES.

    /// <summary>
    /// IT'S USELESS NOW BUT IT WILL BE AN AUXILIAR CLON GAME TO CALCULATE POSIBLE MOVES
    /// WHEN THERE'S A CHECK WITHOUT CREATING NEW INSTANCES WHICH ARE TOO SLOW. 
    /// AT LEAST THAT'S MY PLAN
    /// </summary>
    public GameObject auxiliar { get; set; }

    /// <summary>
    /// <para>THERE ARE BOXES TO INTERACT WITH THE PLAYER.</para>
    /// <para>FOR EXAMPLE:</para>
    /// <para>PROMOTING BOX WHEN THE PLAYER WANTS TO PROMOTE A PAWN TO A PIECE.</para>
    /// <para>CONFIRM BOX WITH YES OR NO BUTTONS TO CONFIRM A CHOICE LIKE A PROMOTION.</para>
    /// <para>A TEXT BOX WITH AN OK BUTTON LIKE GAME OVER BY CHECKMATE, STALEMATE, ETC.</para>
    /// </summary>
    public Boxes boxes { get; set; }

    /// <summary>
    /// IS THE DEPTH FROM MOVE CLONES WHEN CALCULATE POSIBLE MOVES WHEN THERE'S A CHECK
    /// </summary>
    public const int DEPTH_CLONE_CHECK = 1;

    /// <summary>
    /// <para>IS THE DEFAULT VALUE FROM DEPTH CLONES TO KNOW THERE'S CHECK DEPTH OR NOT.</para>
    /// <para>PROBABLY ITS USELESS FOR NOW BUT I'LL USE IT IN AN IA (OR SOMETHING LIKE THAT).</para>
    /// <para>I ALSO USED IT TO TEST CLONES.</para>
    /// </summary>
    public const int DEPTH_CLONE_DEFAULT = 1;

    // FIXME: CHANGE IT TO A TURNS OBJECT WITH COLOURS.

    /// <summary>
    /// <para>IS A BOOLEAN WHICH HAS THE PLAYER'S TURN.</para>
    /// <para>TRUE IS WHITE'S TURN</para>
    /// <para>FALSE IS BLACK'S TURN</para>
    /// </summary>
    public bool is_white_turn;
    //public bool is_white_turn { get; set; }

    /// <summary>
    /// <para>TRUE = GAME FINISHED.</para>
    /// <para>FALSE = GAME NOT FINISHED YET.</para>
    /// </summary>
    public bool is_finished { get; set; }

    /// <summary>
    /// <para>IS THE WAY I CAN KNOW THE GAME IS THE MAIN GAME (FALSE VALUE) OR A CLONE GAME (TRUE VALUE).</para>
    /// I HAVE THE MAIN GAME WHICH IS NOT A CLONE (FALSE VALUE)
    /// BUT OFTEN I CREATE CLONE GAME OBJECTS (TRUE VALUE) TO EVALUATE
    /// POSITIONS AND POSIBLE MOVES.
    /// </summary>
    public bool is_clone;

    /// <summary>
    /// <para>IT'S THE NUMBER OF DEPTH MOVE CLONES WHICH THIS GAME CAN CREATE.</para>
    /// <para>PROBABLY ITS USELESS FOR NOW BUT I'LL USE IT IN AN IA (OR SOMETHING LIKE THAT).</para>
    /// <para>I ALSO USED IT TO TEST CLONES.</para>
    /// </summary>
    public int depth_clone;





    /// <summary>
    /// THE DEFAULT VALUES FOR THE MAIN GAME (NOT FOR CLONE GAMES)
    /// </summary>
    public void Default_values()
    {
        is_finished = true;
        this.is_clone = false;
        this.depth_clone = Game.DEPTH_CLONE_DEFAULT;
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

    /// <summary>
    /// CALL THIS WHEN YOU WANT TO END THIS TURN AND GO TO THE NEXT TURN
    /// </summary>
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

    /// <summary>
    /// FIRST TURN OF THE GAME, AT LEAST THAT'S THE IDEA.
    /// </summary>
    public void White_turn()
    {
        is_white_turn = true;
        this.board.Rotate_default();
    }

    /// <summary>
    /// CHECK IF THE GAME IS FINISHED AND WHEN IS THE CASE, OPEN THE BOX WITH END OF THE GAME MESSAGE.
    /// IF THE GAME IS FINISHED RETURN TRUE, IF NOT RETURN FALSE.
    /// </summary>
    /// <returns></returns>
    public bool Game_finished()
    {
        if(this.board.Check_cant_move_in_game())
        {
            this.is_finished = true;
            if (this.Theres_a_check())
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
            if (this.Theres_a_check())
            {
                this.Check();
            }
            return false;
        }
    }

    /// <summary>
    /// OPEN THE BOX WITH CHECK MESSAGE.
    /// </summary>
    public void Check()
    {
        // FIXME: CREATE AND OPEN CHECK BOX MESSAGE, LIKE this.Checkmate(); for example
    }

    /// <summary>
    /// OPEN THE BOX WITH CHECKMATE MESSAGE.
    /// </summary>
    public void Checkmate()
    {
        if(this.board.game.boxes.Get_box_checkmate())
        {
            this.board.game.boxes.Get_box_checkmate().Show();
        }
    }

    /// <summary>
    /// OPEN THE BOX WITH STALEMATE MESSAGE.
    /// </summary>
    public void Stalemate()
    {
        if (this.board.game.boxes.Get_box_stalemate())
        {
            this.board.game.boxes.Get_box_stalemate().Show();
        }
    }

    /// <summary>
    /// OPEN THE BOX WITH DRAW MESSAGE.
    /// </summary>
    public void Draw()
    {
        // FIXME: CREATE A DRAW BOX OR REMPLACE STALEMATE BOX FOR IT, OPEN THE BOX WITH DRAW MESSAGE.
        // CREATE A DRAW COMPROBATIONS (BY MATERIAL, 50 MOVES...) AND ADD THESE COMPROBATIONS TO this.Game_finished METHOD
    }

    /// <summary>
    /// LOAD THE SCENE OF THE GAME, RESTARTING THE GAME VALUES.
    /// <para>IT CALLS WHEN THE PLAYER CLICKS THE RESTART BUTTON.</para>
    /// </summary>
    public void New_game()
    {
        // FIXME: CHANGE THE NAME OF THE SCENE AND TRY TO REMOVE "THE MAGIC STRING"
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// CLOSE THE GAME, THE PROGRAM.
    /// <para>IT CALLS WHEN THE PLAYER CLICKS THE EXIT BUTTON.</para>
    /// </summary>
    public void Close_game()
    {
        Application.Quit();
    }

    // FIXME: THINK ABOUT CREATING AGame (ABSTRACT CLASS), MainGame AND AClone EXTENDS FROM AGame, 
    // CheckChecks AND ClonGameFromIA extends from AClone, or something like that.
    /// <summary>
    /// IF THERE'S A DEPTH, CREATE A CLONE GAME WITH 1 DEPTH LESS 
    /// (BECAUSE A CLON GAME CAN CREATE ANOTHER CLON GAME AND WITHOUT DEPTH COULD BE INFINITE CALLS)
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// CHECK IF THERE'S A CHECK OR NOT.
    /// </summary>
    /// <returns>TRUE IF THERE'S A CHECK, ELSE FALSE</returns>
    public bool Theres_a_check()
    {
        return this.board.kings_get_a_check != null && this.board.kings_get_a_check.Count != 0;
    }

    /// <summary>
    /// CHECK IF THERE'S A DEPTH TO CREATE CLONES OR NOT. THIS WILL BE FOR IA CLONES.
    /// </summary>
    /// <returns>TRUE IF THERE'S A DEPTH, ELSE FALSE</returns>
    public bool Theres_depth()
    {
        return this.depth_clone > 0;
    }

    /// <summary>
    /// CHECK IF THERE'S A DEPTH TO CREATE A CLON GAME TO COMPROBATE CHECKS. THIS WILL BE FOR CHECK CLONES.
    /// </summary>
    /// <returns>TRUE IF THERE'S A DEPTH, ELSE FALSE</returns>
    public bool Theres_depth_check()
    {
        //return Game.DEPTH_CLONE_DEFAULT - Game.DEPTH_CLONE_CHECK == this.depth_clone ;
        return Game.DEPTH_CLONE_DEFAULT - this.depth_clone < Game.DEPTH_CLONE_CHECK;
    }

    /// <summary>
    /// CHECK IF THERES A CHECK TO A COLOUR
    /// </summary>
    /// <param name="is_white"></param>
    /// <returns></returns>
    public bool Theres_a_check_to_color(bool is_white)
    {
        foreach (AKing king in this.board.kings_get_a_check)
        {
            if(king.is_white == is_white)
            {
                return true;
            }
        }
        return false;
    }


    /// <summary>
    /// Awake IS CALLED ONLY ONCE DURING THE LIFETIME OF THE SCRIPT INSTANCE
    /// </summary>
    void Awake()
    {
        board = this.GetComponentInChildren<Board>();
        boxes = this.GetComponentInChildren<Boxes>();
    }


    /// <summary>
    /// Start IS CALLED BEFORE THE FIRST FRAME UPDATE
    /// <para>IF ITS NOT A CLONE GAME, GET DEFAULT VALUES, 
    /// IF ITS A CLONE GAME GET THE VALUES BY GAME CLONED AND this.is_clone = true</para>
    /// </summary>
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
}
