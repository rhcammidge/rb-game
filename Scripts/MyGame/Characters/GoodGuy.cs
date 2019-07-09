public class GoodGuy : Character
{
    public string type;
    public string name;
    public string moveSpeed;

    public GoodGuy(int x, int y) : base(x, y)
    {
        spriteStartIndex = 2;
        numFrames = 10;
    }
}