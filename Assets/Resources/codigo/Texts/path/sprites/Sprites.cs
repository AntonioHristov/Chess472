using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sprites
{
    private const string src_white_pawn = "images/pieces/white/white_pawn";
    private const string src_white_knight = "images/pieces/white/white_knight";
    private const string src_white_bishop = "images/pieces/white/white_bishop";
    private const string src_white_king = "images/pieces/white/white_king";
    private const string src_white_rook = "images/pieces/white/white_rook";
    private const string src_white_queen = "images/pieces/white/white_queen";

    private const string src_black_pawn = "images/pieces/black/black_pawn";
    private const string src_black_knight = "images/pieces/black/black_knight";
    private const string src_black_bishop = "images/pieces/black/black_bishop";
    private const string src_black_king = "images/pieces/black/black_king";
    private const string src_black_rook = "images/pieces/black/black_rook";
    private const string src_black_queen = "images/pieces/black/black_queen";

    private const string src_square_1 = "images/squares/square1";
    private const string src_square_2 = "images/squares/square2";
    private const string src_square_3 = "images/squares/square3";
    private const string src_square_4 = "images/squares/square4";
    private const string src_square_5 = "images/squares/square5";



    public static Sprite Get_white_pawn()
    { return Resources.Load<Sprite>(src_white_pawn); }
    public static Sprite Get_white_knight()
    { return Resources.Load<Sprite>(src_white_knight); }
    public static Sprite Get_white_bishop()
    { return Resources.Load<Sprite>(src_white_bishop); }
    public static Sprite Get_white_king()
    { return Resources.Load<Sprite>(src_white_king); }
    public static Sprite Get_white_rook()
    { return Resources.Load<Sprite>(src_white_rook); }
    public static Sprite Get_white_queen()
    { return Resources.Load<Sprite>(src_white_queen); }

    public static Sprite Get_black_pawn()
    { return Resources.Load<Sprite>(src_black_pawn); }
    public static Sprite Get_black_knight()
    { return Resources.Load<Sprite>(src_black_knight); }
    public static Sprite Get_black_bishop()
    { return Resources.Load<Sprite>(src_black_bishop); }
    public static Sprite Get_black_king()
    { return Resources.Load<Sprite>(src_black_king); }
    public static Sprite Get_black_rook()
    { return Resources.Load<Sprite>(src_black_rook); }
    public static Sprite Get_black_queen()
    { return Resources.Load<Sprite>(src_black_queen); }

    public static Sprite Get_square_1()
    { return Resources.Load<Sprite>(src_square_1); }
    public static Sprite Get_square_2()
    { return Resources.Load<Sprite>(src_square_2); }
    public static Sprite Get_square_3()
    { return Resources.Load<Sprite>(src_square_3); }
    public static Sprite Get_square_4()
    { return Resources.Load<Sprite>(src_square_4); }
    public static Sprite Get_square_5()
    { return Resources.Load<Sprite>(src_square_5); }
}
