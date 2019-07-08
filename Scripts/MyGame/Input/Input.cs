using System;
using UnityEngine;

public class Input
{

    public static Character checkCharacterInput(Map curMap, Character c)
    {
        Vector2i newPos = c.position;

        if (RB.KeyDown(KeyCode.W))
        {
            newPos.y -= 10;
        }

        if (RB.KeyDown(KeyCode.A))
        {
            newPos.x -= 10;
        }

        if (RB.KeyDown(KeyCode.S))
        {
            newPos.y += 10;
        }

        if (RB.KeyDown(KeyCode.D))
        {
            newPos.x += 10;
        }

        if (!curMap.isTileBlocked(newPos, c.size))
        {
            c.position = newPos;
        }

        return c;
    }

    /**
     * Checks System Key Press
     */
    internal static void checkSystemInput()
    {
        if (RB.ButtonPressed(RB.BTN_SYSTEM))
        {
            Application.Quit();
        }
    }
}