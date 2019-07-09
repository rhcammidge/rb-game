
/**
 * Class to store all character data and functions for character manipulation
 */
public class Character
{

    public Vector2i position, size;
    public int spriteStartIndex, numFrames;
    public int hp;

    /**
     * Builds Character with default locations x, y
     */
    public Character(int x, int y)
    {
        position.x = x;
        position.y = y;
        numFrames = 1;
    }

    public void draw()
    {
        int spriteIndex = ((int)RB.Ticks / 20) % numFrames + spriteStartIndex;
        // Draw a sprite just below
        RB.DrawSprite(spriteIndex, position);
    }
}