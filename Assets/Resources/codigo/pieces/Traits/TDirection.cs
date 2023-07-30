public interface TDirection
{
    ADirection direction { get; set; }
}

public static class TDirection_methods
{  
    public static void Get_Up(TDirection t_direction)
    {
        t_direction.direction = Up.Instance;
    }

    public static void Get_Down(TDirection t_direction)
    {
        t_direction.direction = Down.Instance;
    }

    public static void Get_Left(TDirection t_direction)
    {
        t_direction.direction = Left.Instance;
    }

    public static void Get_Right(TDirection t_direction)
    {
        t_direction.direction = Right.Instance;
    }
}