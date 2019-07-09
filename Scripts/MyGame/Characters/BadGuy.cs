public class BadGuy : Character
{
    public string type;
    public string movePattern;
    public int moveSpeed;

    public BadGuy(int x, int y) : base(x, y)
    {
        spriteStartIndex = 2;
        numFrames = 10;
    }
}